using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Sprite
    {
        //buttons
        protected Texture2D texture;
        protected Rectangle destination;

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, destination, Color.White);

        }

        public Sprite(Texture2D texture, Rectangle destination)
        {
            this.texture = texture;
            this.destination = destination;
        }


    }
}
