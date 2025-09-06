
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level;
using Solarized.Level.Buttons;
using Solarized.Level.Sound;
using System;
using System.Collections.Generic;

namespace Solarized.Screen
{
    public class MainMenu : AbstractScreen
    {
        public class Cinder
        {
            public int Time;
            public int Lifetime;
            public int IdentityIndex;
            public float Scale;
            public float Depth;
            public Color DrawColor;
            public Vector2 Velocity;
            public Vector2 Center;

            public Cinder(int lifetime, int identity, float depth, Color color, Vector2 startingPosition, Vector2 startingVelocity)
            {
                Lifetime = lifetime;
                IdentityIndex = identity;
                Depth = depth;
                DrawColor = color;
                Center = startingPosition;
                Velocity = startingVelocity;
            }
        }
        public static List<Cinder> Cinders
        {
            get;
            internal set;
        } = new();
        private ResourceLocation<Texture2D> MainMenuScreen = new ResourceLocation<Texture2D>("Content/Textures/MainMenu/MainMenuBackground");
        private ResourceLocation<Texture2D> GameTitle = new ResourceLocation<Texture2D>("Content/Textures/MainMenu/GameTitle");
        public string Title = "Solarized";
        public MainMenu() : base(GamePanel.Instance)
        {
            this.Contents.Add("Play Game");
            this.Contents.Add("Options");
            this.Contents.Add("Exit");
        }

        public override void Init()
        {
            base.Init();
            MusicManager.Play(SoundID.INTRO);
            this.SetupButtons();
        }
        private void SetupButtons()
        {
            int row = 0;
            foreach (string content in this.Contents)
            {
                Vector2 vec = this.GameInstance.Font.MeasureString(content);
                int padding = (int) vec.Y + 20;
                int x = (int) ((this.GameInstance.GetScreenWidth() - vec.X) / 2);
                int y = this.GameInstance.GetMaxTileSize() * 4;
                row += 1;
                if (content.Equals(Contents[0]))
                {
                    this.AddRenderableWidget(new BaseButton(x, y + (padding * row), 250, 20, content, this.GameInstance.Font, () =>
                    {
                        this.GameInstance.Exit();
                    }));
                }
                if (content.Equals(Contents[1]))
                {
                    this.AddRenderableWidget(new BaseButton(x, y + (padding * row), 250, 20, content, this.GameInstance.Font, () =>
                    {
                        this.GameInstance.Exit();
                    }));
                }
                if (content.Equals(Contents[2]))
                {
                    this.AddRenderableWidget(new BaseButton(x, y + (padding * row), 250, 20, content, this.GameInstance.Font, () =>
                    {
                        this.GameInstance.Exit();
                    }));
                }
            }
        }

        public override void Tick(GameTime gameTime)
        {   
            base.Tick(gameTime);
        }

        public override void RenderBackground(GameGraphics gameGraphics)
        {
            GraphicManager.DrawFullScreen(MainMenuScreen);
            GraphicManager.DrawCenteredFit(GameTitle, 0, 20);
        }
        //public void AddCinderEffect(SpriteBatch spriteBatch)
        //{
        //    Color selectCinderColor()
        //    {
        //        if (this.Random.NextBool(3))
        //            return Color.Lerp(Color.DarkGray, Color.LightGray, this.Random.NextFloat());

        //        return Color.Lerp(Color.Red, Color.Yellow, this.Random.NextFloat(0.9f));
        //    }
        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (this.Random.NextBool(4))
        //        {
        //            int lifetime = this.Random.Next(200, 300);
        //            float depth = this.Random.NextFloat(1.8f, 5f);
        //            Vector2 startingPosition = new Vector2(GamePanel.Instance.GetScreenWidth() * this.Random.NextFloat(-0.1f, 1.1f), Main.screenHeight * 1.05f);
        //            Vector2 startingVelocity = -Vector2.UnitY.RotatedBy(this.Random.NextFloat(-0.9f, 0.9f)) * 4f;
        //            Color cinderColor = selectCinderColor();
        //            Cinders.Add(new Cinder(lifetime, Cinders.Count, depth, cinderColor, startingPosition, startingVelocity));
        //        }
        //    }

        //    // Update all cinders.
        //    for (int i = 0; i < Cinders.Count; i++)
        //    {
        //        Cinders[i].Scale = Utils.GetLerpValue(Cinders[i].Lifetime, Cinders[i].Lifetime / 3, Cinders[i].Time, true);
        //        Cinders[i].Scale *= MathHelper.Lerp(0.6f, 0.9f, Cinders[i].IdentityIndex % 6f / 6f);
        //        if (Cinders[i].IdentityIndex % 13 == 12)
        //            Cinders[i].Scale *= 2f;

        //        float flySpeed = MathHelper.Lerp(3.2f, 14f, Cinders[i].IdentityIndex % 21f / 21f);
        //        Vector2 idealVelocity = -Vector2.UnitY.RotatedBy(MathHelper.Lerp(-0.44f, 0.44f, (float)Math.Sin(Cinders[i].Time / 16f + Cinders[i].IdentityIndex) * 0.5f + 0.5f));
        //        idealVelocity = (idealVelocity + Vector2.UnitX).SafeNormalize(Vector2.UnitY) * flySpeed;

        //        float movementInterpolant = MathHelper.Lerp(0.01f, 0.08f, Utils.GetLerpValue(45f, 145f, Cinders[i].Time, true));
        //        Cinders[i].Velocity = Vector2.Lerp(Cinders[i].Velocity, idealVelocity, movementInterpolant);

        //        Cinders[i].Time++;
        //        Cinders[i].Center += Cinders[i].Velocity;
        //    }

        //    // Clear away all dead cinders.
        //    Cinders.RemoveAll(c => c.Time >= c.Lifetime);

        //    // Draw cinders.
        //    Texture2D cinderTexture = new ResourceLocation<Texture2D>("CalamityMod/Skies/CalamitasCinder").Get();
        //    for (int i = 0; i < Cinders.Count; i++)
        //    {
        //        Vector2 drawPosition = Cinders[i].Center;
        //        spriteBatch.Draw(cinderTexture, drawPosition, null, Cinders[i].DrawColor, 0f, new Vector2(), Cinders[i].Scale, 0, 0f);
        //    }

        //}
    }
}
