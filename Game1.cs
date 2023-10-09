using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using System.Diagnostics;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Screens;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Content;
using BLOB.Scripts;

namespace BLOB
{
    public class Game1 : Game {
        Texture2D overworldBlueTexture;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ScreenManager _screenManager;
        public static ContentManager contentManager;
        public static GraphicsDeviceManager graphicsDevice;
        public const int SCREEN_WIDTH = 1280;
        public const int SCREEN_HEIGHT = 720;


        //current player controls
        public enum GameControls {
            OVERWORLD,
            MENU,
            COMBAT
        }

        public static readonly Game1 game1 = new Game1();
        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            graphicsDevice = _graphics;
            contentManager = Content;
            Components.Add(_screenManager);
        }

        static Game1(){}

        public static Game1 GAME {
            get { return game1; }
        }

        protected override void Initialize() {
            graphicsDevice.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphicsDevice.PreferredBackBufferHeight = SCREEN_HEIGHT;
            // TODO: Add your initialization logic here
            base.Initialize();
            GameManager.GM.SetState(new OverworldState());
            graphicsDevice.ApplyChanges();
        }

        protected override void LoadContent() {


            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            //overworldBlueTexture = Content.Load<Texture2D>("blueOverworld24-Sheet");
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //iterate through the state's current state method
            GameManager.GM.GetState().currentNumerator().MoveNext();

            // TODO: Add your update logic here
            //should run the update for all the active game objects in the correct state machine state
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
 
            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            // Create a sourceRectangle.
            //Rectangle sourceRectangle = new Rectangle(0, 0, 1080, 720);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void LoadDemoTown() {
            _screenManager.LoadScreen(new DemoTown(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        protected void SetControls() {

        }
    }
}