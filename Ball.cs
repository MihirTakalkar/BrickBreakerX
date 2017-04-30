using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MihirBrickBreaker
{
    class Ball
    {
        int x;
        int y;
        int width;
        int height;
        int speedx;
        int speedy;

        public Ball(int x, int y, int width, int height, int speedx, int speedy)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.speedx = speedx;
            this.speedy = speedy;
        }

        public void Update(Size Clientsize)
        {
            
            x += speedx;
            y += speedy;

            if(x < 0)
            {
                speedx *= -1;
            }

            if(x + width > Clientsize.Width)
            {
                speedx *= -1; 
            }

            if(y < 0)
            {
                speedy *= -1;
            }
            if(y + height > Clientsize.Height)
            {
                speedy *= -1;
            }

        }
        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(Brushes.Orange, x, y, width, height);
        }


    }
}
