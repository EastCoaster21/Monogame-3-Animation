using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_3_Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        SoundEffect tribbleCoo;

        Texture2D tribbleCreamTex;
        Rectangle tribbleCreamRec;
        Vector2 tribbleCreamSpeed;

        Texture2D tribbleBrownTex;
        Texture2D tribbleBrownRec;
        Vector2 tribbleBrownSpeed;

        Texture2D tribbleOrangeTex;
        Texture2D tribbleOrangeRec;
        Vector2 tribbleOrangeSpeed;

        Texture2D tribbleGreyTex;
        Texture2D tribbleGreyRec;
        Vector2 tribbleGreySpeed;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            tribbleCreamRec = new Rectangle(300, 10, 100, 100);
            tribbleCreamSpeed = new Vector2(2, 2);

            //tribbleBrownRec = new Rectangle(300, 10, 100, 100);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            tribbleCreamTex = Content.Load<Texture2D>("tribbleCream");
            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            tribbleCreamRec.X += (int)tribbleCreamSpeed.X;
            if (tribbleCreamRec.Right > window.Width || tribbleCreamRec.Left < 0) 
            {
                tribbleCreamSpeed.X *= -1;
                tribbleCoo.Play();
            }

            tribbleCreamRec.Y += (int)tribbleCreamSpeed.Y;
            if (tribbleCreamRec.Bottom > window.Height || tribbleCreamRec.Top < 0)
            {
                tribbleCreamSpeed.Y *= -1;
                tribbleCoo.Play();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);
            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleCreamTex, tribbleCreamRec, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
