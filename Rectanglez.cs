using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool Left = false;
        public bool Right = false;

        public Rectanglez(int x, int y, int height, int width, int speedx)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.speedx = speedx;

            hitbox = new Rectangle(x, y, width, height);
        }

        public void Update()
        {
            if (Left == true)
            {
                MoveLeft();
            }
        }


        public void MoveLeft()
        {
            if (x > 0)
            {
                x -= speedx;
            }
        }

        public void MoveRight(Size clientSize) //pass in the width of the screen
        {
            if (x > clientSize.Width - width)
            {
                x += speedx;
            }
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillRectangle(Brushes.Green, x, y, width, height);
        }


    }
}
