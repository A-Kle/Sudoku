using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Field : Button
    {
        public byte value;
        public static Texture2D activeTexture;
        public Field(Texture2D texture, Rectangle destination) : base(texture, destination)
        {
            value = 0;
        }

        public void ActivateButton()
        {
            texture = activeTexture;
        }

    }
}
