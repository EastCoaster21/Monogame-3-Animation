using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Monogame_3_Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<Color> colors;

        Random generator;

        Rectangle window;

        SoundEffect tribbleCoo;
        SoundEffect scream;

        Texture2D nebulaTex;
        Rectangle nebula;

        Texture2D tribbleCreamTex;
        Rectangle tribbleCreamRec;
        Vector2 tribbleCreamSpeed;
        Color tribbleCreamColor;

        Texture2D tribbleBrownTex;
        Rectangle tribbleBrownRec;
        Vector2 tribbleBrownSpeed;

        Texture2D tribbleOrangeTex;
        Rectangle tribbleOrangeRec;
        Vector2 tribbleOrangeSpeed;

        Texture2D tribbleGreyTex;
        Rectangle tribbleGreyRec;
        Vector2 tribbleGreySpeed;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public Color RandomColor()
        {
            return new Color(generator.Next(256), generator.Next(256), generator.Next(256));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            generator = new Random();

            colors = new List<Color>() { Color.PaleVioletRed, Color.Aquamarine, Color.YellowGreen, new Color (generator.Next(256), generator.Next(256), generator.Next(256)) };

            nebula = new Rectangle(0, 0, window.Width, window.Height);

            tribbleCreamRec = new Rectangle(300, 10, 100, 100);
            tribbleCreamSpeed = new Vector2(3, 3);
            tribbleCreamColor = Color.White;

            tribbleBrownRec = new Rectangle(200, 10, 100, 100);
            tribbleBrownSpeed = new Vector2(2, 0);

            tribbleGreyRec = new Rectangle(200, 400, 100, 100);
            tribbleGreySpeed = new Vector2(6, 2);

            tribbleOrangeRec = new Rectangle(400, 300, 100, 100);
            tribbleOrangeSpeed = new Vector2(0, 4);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            nebulaTex = Content.Load<Texture2D>("Nebula");
            tribbleCreamTex = Content.Load<Texture2D>("tribbleCream");
            tribbleBrownTex = Content.Load<Texture2D>("tribbleBrown");
            tribbleGreyTex = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTex = Content.Load<Texture2D>("tribbleOrange");
            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
            scream = Content.Load<SoundEffect>("Scream");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            tribbleCreamRec.X += (int)tribbleCreamSpeed.X;
            if (tribbleCreamRec.Right > window.Width || tribbleCreamRec.Left < 0) 
            {
                colors[colors.Count-1] = RandomColor();
                tribbleCreamColor = colors[generator.Next(colors.Count)];
                tribbleCreamSpeed.X *= -1;
                tribbleCoo.Play();
            }
            tribbleCreamRec.Y += (int)tribbleCreamSpeed.Y;
            if (tribbleCreamRec.Bottom > window.Height || tribbleCreamRec.Top < 0)
            {
                colors[colors.Count - 1] = RandomColor();
                tribbleCreamColor = colors[generator.Next(colors.Count)];
                tribbleCreamSpeed.Y *= -1;
                tribbleCoo.Play();
            }

            tribbleBrownRec.X += (int)tribbleBrownSpeed.X;
            if (tribbleBrownRec.Right > window.Width || tribbleBrownRec.Left < 0)
            {
                tribbleBrownSpeed.X *= -1;
                tribbleCoo.Play();
            }
            tribbleBrownRec.Y += (int)tribbleBrownSpeed.Y;

            tribbleOrangeRec.Y += (int)tribbleOrangeSpeed.Y;
            if (tribbleOrangeRec.Bottom > window.Height || tribbleOrangeRec.Top < 0)
            {
                tribbleOrangeSpeed.Y *= -1;
                tribbleCoo.Play();
            }
            tribbleOrangeRec.X += (int)tribbleOrangeSpeed.X;

            tribbleGreyRec.X += (int)tribbleGreySpeed.X;
            if (tribbleGreyRec.Right > window.Width || tribbleGreyRec.Left < 0)
            {
                tribbleGreySpeed.X *= -1;
                scream.Play();
            }
            tribbleGreyRec.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGreyRec.Bottom > window.Height || tribbleGreyRec.Top < 0)
            {
                tribbleGreySpeed.Y *= -1;
                scream.Play();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.HotPink);
            _spriteBatch.Begin();

            _spriteBatch.Draw(nebulaTex, nebula, Color.White);
            _spriteBatch.Draw(tribbleCreamTex, tribbleCreamRec, tribbleCreamColor);
            _spriteBatch.Draw(tribbleBrownTex, tribbleBrownRec, Color.White);
            _spriteBatch.Draw(tribbleGreyTex, tribbleGreyRec, Color.White);
            _spriteBatch.Draw(tribbleOrangeTex, tribbleOrangeRec, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
