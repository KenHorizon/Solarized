using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Solarized.Level;
using Solarized.Level.Registry;
using Solarized.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized
{
    public class GamePanel : Game
    {
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
        private GraphicsDeviceManager deviceManager;
        private SpriteBatch spriteBatch;
        protected static ContentManager contentManager;
        protected static AbstractScreen currentScreen;
        private GameGraphics GameGraphics;
        public static ContentManager ContentManager
        {
            get { return contentManager; }
        }
        public static AbstractScreen CurrentScreen
        {
            get { return currentScreen; }
        }
        private static GamePanel _instance;
        public static GamePanel Instance
        {
            get { return _instance; }
        }
        //

        public GamePanel()
        {
            this.random = new Random((int) this.Time.TotalSeconds);
            this.deviceManager = new GraphicsDeviceManager(this);
            this.deviceManager.PreferredBackBufferWidth = ScreenWitdh;
            this.deviceManager.PreferredBackBufferHeight = ScreenHeight;
            this.deviceManager.ApplyChanges();
            this.Window.Title = "Solarized";
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            _instance = this;
        }
        protected override void Initialize()
        {
            base.Initialize();
            RegistryFont.FONTS.Register();
            this.GameGraphics = new GameGraphics(this, this.GraphicsDevice);
            this.SetScreen(new StartupScreen());
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            contentManager = new ContentManager(Services);
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public void SetScreen(AbstractScreen screen)
        {
            currentScreen = screen;
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            CurrentScreen?.Tick(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();
            //
            if (this.GameGraphics != null)
            {
                this.GameGraphics.Render(gameTime.ElapsedGameTime.TotalSeconds);
                CurrentScreen?.Render(this.GameGraphics);
            }
            //
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
        public int GetScreenWidth()
        {
            return ScreenWitdh;
        }
        public int GetScreenHeight()
        {
            return ScreenHeight;
        }
        public int GetMaxTilSize()
        {
            return MaxTileSize;
        }
    }
}
