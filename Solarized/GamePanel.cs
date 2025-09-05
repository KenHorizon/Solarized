using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Solarized.Effect;
using Solarized.Level;
using Solarized.Level.Registry;
using Solarized.Screen;
using System;

namespace Solarized
{
    public class GamePanel : Game
    {
        private GraphicsDeviceManager deviceManager;
        public SpriteBatch spriteBatch;
        public const string GAME_ID = "Solarized";
        public const int OriginalTiles = 16;
        public const int SCALE = 3;
        public const int MaxScreenCol = 24;
        public const int MaxScreenRow = 14;
        public const int MaxTileSize = OriginalTiles * SCALE;
        public const int ScreenWitdh = MaxTileSize * MaxScreenCol;
        public const int ScreenHeight = MaxTileSize * MaxScreenRow;
        public int WorldX;
        public int WorldY;
        public int MaxWorldCol = 50;
        public int MaxWorldRow = 50;
        public int WorldWidth = MaxTileSize * MaxScreenCol;
        public int WorldHeight = MaxTileSize * MaxScreenRow;
        public int MouseX;
        public int MouseY;
        public int gameTick;
        public TimeSpan Time = new TimeSpan();
        public Random random;
        public SpriteFont Font;
        private GameGraphics GameGraphics;
        MouseState mouse = Mouse.GetState();
        #region Instances

        protected static ContentManager contentManager;
        public static ContentManager ContentManager
        {
            get { return contentManager; }
        }
        protected static AbstractScreen currentScreen;
        public static AbstractScreen CurrentScreen
        {
            get { return currentScreen; }
        }

        private static GamePanel _instance;
        public static GamePanel Instance
        {
            get { return _instance; }
        }
        #endregion
        //
        public GamePanel()
        {
            this.random = new Random((int) this.Time.Milliseconds);
            this.deviceManager = new GraphicsDeviceManager(this);
            this.deviceManager.PreferredBackBufferWidth = ScreenWitdh;
            this.deviceManager.PreferredBackBufferHeight = ScreenHeight;
            this.Content.RootDirectory = "Content";
            this.Window.Title = "Solarized";
            this.IsMouseVisible = true;
            _instance = this;
            contentManager = new ContentManager(Services);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Effects.EFFECTS.Register();
            Attributes.ATTRIBUTES.Register();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.Font = this.Content.Load<SpriteFont>("DefaultFont");
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.GameGraphics = new GameGraphics();
            this.SetScreen(new StartupScreen());

            // TODO: use this.Content to load your game content here
        }
        public void SetScreen(AbstractScreen screen)
        {
            currentScreen = screen;
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            this.MouseX = mouse.X;
            this.MouseY = mouse.Y;
            CurrentScreen?.Tick(gameTime);
            if (this.LeftClicked())
            {
                CurrentScreen?.OnMouseClicked(this.MouseX, this.MouseY);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        public bool LeftClicked()
        {
            return mouse.LeftButton == ButtonState.Pressed;
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.DarkGray);
            this.spriteBatch.Begin();
            //
            if (this.GameGraphics != null)
            {
                this.GameGraphics.Render(gameTime.ElapsedGameTime.TotalSeconds);
                CurrentScreen?.Render(this.GameGraphics);
            }
            //
            this.spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        public int GetScreenWidth()
        {
            return this.GraphicsDevice.Viewport.Width;
        }
        public int GetScreenHeight()
        {
            return this.GraphicsDevice.Viewport.Height;
        }
        public int GetMaxTileSize()
        {
            return MaxTileSize;
        }
    }
}
