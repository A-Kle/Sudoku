using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public delegate void MyEvent(Button b);
    public class Button : Sprite 
    {
        public MyEvent onClick;   
        public Button(Texture2D texture, Rectangle destination) : base (texture, destination)
        {

        }


        public void CheckClick(int x, int y)
        {
            if(destination.Contains(x, y))
            {
                onClick.Invoke(this); //actions on button click
            }
            
        }

    }
}
