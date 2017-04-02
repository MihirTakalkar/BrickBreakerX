using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MihirBrickBreaker
{
    class Rectanglez
    {
        public int x;
        public int y;
        public int height;
        public int width;
        public int speedx;
        Rectangle hitbox;
        public Rectanglez (int x, int y, int height, int width, int speedx)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.speedx = speedx;

            hitbox = new Rectangle(x, y, width, height);
        }

        public void Clear(Graphics gfx,Color backColor)
        {
            gfx.Clear(backColor);
        }
      //function to draw
      public void Draw(Graphics gfx)
        {
            gfx.FillRectangle(Brushes.Green, x, y, width, height);
        }


    }
}
