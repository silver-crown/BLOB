using BLOB.Content.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using System.Diagnostics;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Screens;

namespace BLOB
{
    public class Game1 : Game
    {
        Texture2D overworldBlueTexture;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private OverworldPlayer _player;
        private ScreenManager _screenManager;
        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            GameManager.GM.SetState(new OverworldState());
            LoadDemoTown();
            base.Initialize();
        }

        protected override void LoadContent() {

    

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //overworldBlueTexture = Content.Load<Texture2D>("blueOverworld24-Sheet");
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            //should run the update for all the active game objects in the correct state machine state
            //LoadDemoTown();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            // Create a sourceRectangle.
            Rectangle sourceRectangle = new Rectangle(0, 0, 24, 24);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void LoadDemoTown() {
            _screenManager.LoadScreen(new DemoTown(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
    }
}