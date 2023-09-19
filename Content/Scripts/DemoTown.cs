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
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace BLOB.Content.Scripts
{
    public class DemoTown : GameScreen
    {
        private new Game1 Game => (Game1) base.Game;

        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;
        private SpriteBatch _spriteBatch;
        
        private Vector2 _position = new Vector2 (50,50);
        public DemoTown(Game1 game) : base(game) { }

        public override void LoadContent() {
            _tiledMap = Game1.contentManager.Load<TiledMap>("BLOB testMap");
            _tiledMapRenderer = new TiledMapRenderer(Game1.graphicsDevice.GraphicsDevice, _tiledMap);
        }

        public override void Update(GameTime gameTime) {
            _tiledMapRenderer.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            _tiledMapRenderer.Draw();
        }
    }
}
