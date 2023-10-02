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

namespace BLOB.Scripts
{
    public class DemoTown : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;
        private OverworldPlayer _player;
        private OrthographicCamera _camera;


        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;
        private SpriteBatch _spriteBatch;


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
            _player = new OverworldPlayer(spriteSheet, new System.Numerics.Vector2(300, 300));


            _tiledMap = Game1.contentManager.Load<TiledMap>("BLOB testMap");
            _tiledMapRenderer = new TiledMapRenderer(Game1.graphicsDevice.GraphicsDevice, _tiledMap);
        }

        public override void Update(GameTime gameTime)
        {
            var deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var walkSpeed = deltaSeconds * 128;

            _player.GetSprite().Update(deltaSeconds);

            _tiledMapRenderer.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(GameManager.GM.keyboardUP)) _player.Walk(OverworldPlayer.Direction.UP);
            else if (Keyboard.GetState().IsKeyDown(GameManager.GM.keyboardDOWN)) _player.Walk(OverworldPlayer.Direction.DOWN);
            else if (Keyboard.GetState().IsKeyDown(GameManager.GM.keyboardLEFT)) _player.Walk(OverworldPlayer.Direction.LEFT);
            else if (Keyboard.GetState().IsKeyDown(GameManager.GM.keyboardRIGHT)) _player.Walk(OverworldPlayer.Direction.RIGHT);

            if (Keyboard.GetState().IsKeyDown(Keys.R))
                _camera.ZoomIn(deltaSeconds);

            if (Keyboard.GetState().IsKeyDown(Keys.F))
                _camera.ZoomOut(deltaSeconds);

            var offset = new Vector2 (Game1.SCREEN_WIDTH / 2, Game1.SCREEN_HEIGHT / 2);
            _camera.Position = new Vector2(_player.GetPosition().X - (Game1.SCREEN_WIDTH/3), _player.GetPosition().Y - (Game1.SCREEN_HEIGHT/3));
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.graphicsDevice.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            var transformMatrix = _camera.GetViewMatrix();
            _tiledMapRenderer.Draw(transformMatrix); _spriteBatch.Begin(transformMatrix: transformMatrix,samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_player.GetSprite(), _player.GetPosition());
            _spriteBatch.End();
        }
    }
}
