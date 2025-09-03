using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private const int MaxTileSize = OriginalTiles * SCALE;
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
        public Random random = new Random();

        private GraphicsDeviceManager deviceManager;
        private SpriteBatch spriteBatch;

        public GamePanel()
        {
            this.deviceManager = new GraphicsDeviceManager(this);
            this.deviceManager.PreferredBackBufferWidth = ScreenWitdh;
            this.deviceManager.PreferredBackBufferHeight = ScreenHeight;
            this.deviceManager.ApplyChanges();
            this.Window.Title = "Solarized";
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }
        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();
            //
            //
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
