using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WindowsGame1;

namespace SudokuGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Sudoku1 : Microsoft.Xna.Framework.Game
    {
        public static Field []sudokuTable = new Field[81];
        public static SpriteBatch Image;
        public static Texture2D blackPixel;
        public static List<Sprite> activeSprite = new List<Sprite>();
        public static List<Button> activeButtons = new List<Button>();
        public static int screenSize;
        public static Vector2 offset = new Vector2();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Sudoku1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            Image = new SpriteBatch(graphics.GraphicsDevice);
            screenSize = Math.Min(graphics.GraphicsDevice.Viewport.Height, graphics.GraphicsDevice.Viewport.Width);
            offset.X = graphics.GraphicsDevice.Viewport.Height < graphics.GraphicsDevice.Viewport.Width ? (graphics.GraphicsDevice.Viewport.Width - graphics.GraphicsDevice.Viewport.Height) / 2 : 0;
            offset.Y = graphics.GraphicsDevice.Viewport.Height < graphics.GraphicsDevice.Viewport.Width ? 0 : (graphics.GraphicsDevice.Viewport.Height - graphics.GraphicsDevice.Viewport.Width) / 2;
            // TODO: Add your initialization logic here

            Texture2D square = new Texture2D(GraphicsDevice, 1, 1);
            UInt32[] squareFill = new UInt32[1];
            squareFill[0] = 0x00000000;
            square.SetData<UInt32>(squareFill);

            Texture2D square2 = new Texture2D(GraphicsDevice, 1, 1);
            UInt32[] squareFill2 = new UInt32[1];
            squareFill2[0] = 0x66ff0000;
            square2.SetData<UInt32>(squareFill2);
            Field.activeTexture = square2;

            for (int i = 0; i <=80; i++)
            {
                sudokuTable[i] = new Field(square, new Rectangle((screenSize * (i%9*10+5) / 100) + (int)offset.X, ((i/9 * 10+5) * screenSize / 100) + (int)offset.Y, (10 * screenSize / 100), (10 * screenSize / 100)) );
                sudokuTable[i].onClick += Action;


            }
            base.Initialize();
        }

        public void Action(Button b)
        {
            ((Field)b).ActivateButton();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            blackPixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
            byte[] Pixel = new byte[4]; //dla kazdego pixela na ekranie przeznaczone sa 4 bajty = rgb + kanal alfa
            Pixel[0] = 255;
            Pixel[1] = 255;
            Pixel[2] = 255;
            Pixel[3] = 255;   //
            blackPixel.SetData<byte>(Pixel);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            MouseState ms = Mouse.GetState();

            if (ms.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i <= 80; i++)
                {
                    sudokuTable[i].CheckClick(ms.X, ms.Y);
                } 
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            Image.Begin();
            
           
            //horisontal

            for (int i = 5; i <= 95; i = i + 30)
            {
                Image.Draw(blackPixel, new Rectangle((screenSize * 5 / 100) + (int)offset.X, (i * screenSize / 100) + (int)offset.Y, screenSize * 90 / 100, 2), Color.Black);

            }

            for (int i = 5; i <= 95; i = i + 10)
            {
                Image.Draw(blackPixel, new Rectangle((screenSize * 5 / 100) + (int)offset.X, (i * screenSize / 100) + (int)offset.Y, screenSize * 90 / 100, 1), Color.Black);

            }
            //vertical

            for (int i = 5; i <= 95; i = i + 30)
            {
                Image.Draw(blackPixel, new Rectangle((screenSize * i / 100) + (int)offset.X, (5 * screenSize / 100) + (int)offset.Y, 2, screenSize * 90 / 100), Color.Black);

            }

            for (int i = 5; i <= 95; i = i + 10)
            {
                Image.Draw(blackPixel, new Rectangle((screenSize * i / 100) + (int)offset.X, (5 * screenSize / 100) + (int)offset.Y, 1, screenSize * 90 / 100), Color.Black);

            }


            for(int i = 0; i <= 80; i++)
            {
                sudokuTable[i].Draw(Image);
            }

            Image.End();
            // TODO: Add your drawing code here



            base.Draw(gameTime);
        }
    }
}
