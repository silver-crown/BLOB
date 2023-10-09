using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Content;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System.Xml.Linq;
using MonoGame.Extended.Tiled.Serialization;

namespace BLOB.Scripts
{
    public class DemoTown : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;
        private OrthographicCamera _camera;


        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;
        private SpriteBatch _spriteBatch;
        TiledMapObject _tileMapPlayer;

        private Vector2 _position = new Vector2(50, 50);
        public DemoTown(Game1 game) : base(game) { }

        public override void Initialize() {
            base.Initialize();
       
            var viewportAdapter = new BoxingViewportAdapter(Game1.GAME.Window, Game1.graphicsDevice.GraphicsDevice, 800, 480);
            _camera = new OrthographicCamera(viewportAdapter);
            Game1.graphicsDevice.ApplyChanges();
        }

        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Game1.graphicsDevice.GraphicsDevice);
            var spriteSheet = Game1.contentManager.Load<SpriteSheet>("blueOverworld24-Sheet.sf", new JsonContentLoader());
            OverworldPlayer.PLAYER.SetSprite(spriteSheet);

            _tiledMap = Game1.contentManager.Load<TiledMap>("BLOB testMap");
            _tiledMapRenderer = new TiledMapRenderer(Game1.graphicsDevice.GraphicsDevice, _tiledMap);

            //set start position for player
            if (!OverworldPlayer.PLAYER.HasPlayerSpawned()) {
                foreach (var obj in _tiledMap.ObjectLayers[0].Objects) {
                    if (obj.Name.Equals("Player")) {
                        OverworldPlayer.PLAYER.SetPosition(new System.Numerics.Vector2(obj.Position.X, obj.Position.Y));
                        OverworldPlayer.PLAYER.PlayerHasSpawned();
                        break;
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            var deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var walkSpeed = deltaSeconds * 128;

            OverworldPlayer.PLAYER.GetSprite().Update(deltaSeconds);

            _tiledMapRenderer.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.R))
                _camera.ZoomIn(deltaSeconds);

            if (Keyboard.GetState().IsKeyDown(Keys.F))
                _camera.ZoomOut(deltaSeconds);

            var offset = new Vector2 (Game1.SCREEN_WIDTH / 2, Game1.SCREEN_HEIGHT / 2);
            _camera.Position = new Vector2(OverworldPlayer.PLAYER.GetPosition().X - (Game1.SCREEN_WIDTH/3), OverworldPlayer.PLAYER.GetPosition().Y - (Game1.SCREEN_HEIGHT/3));
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.graphicsDevice.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            var transformMatrix = _camera.GetViewMatrix();
            _tiledMapRenderer.Draw(transformMatrix); _spriteBatch.Begin(transformMatrix: transformMatrix,samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(OverworldPlayer.PLAYER.GetSprite(), OverworldPlayer.PLAYER.GetPosition());
            _spriteBatch.End();
        }
    }
}
