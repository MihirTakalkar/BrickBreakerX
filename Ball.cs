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
        public int x;
        public int y;
        public int width;
        public int height;
        public int speedx;
        public int speedy;
        public int originalx;
        public int originaly;
        public int hitground = 0;
        public Rectangle hitbox;

        public Ball(int x, int y, int width, int height, int speedx, int speedy)
        {
            this.x = x;
            this.y = y;
            this.originalx = x;
            this.originaly = y;
            this.width = width;
            this.height = height;
            this.speedx = speedx;
            this.speedy = speedy;

            hitbox = new Rectangle(x,y,width,height);
        }

        public void Update(Size Clientsize)
        {
            
            x += speedx;
            y += speedy;

            hitbox.X = x;
            hitbox.Y = y;

            if (x < 0)
            {
                speedx = Math.Abs(speedx);
            }

            if(x + width > Clientsize.Width)
            {
                speedx = -Math.Abs(speedx);
            }

            if(y < 0)
            {
                speedy = Math.Abs(speedy);
            }
            if(y + height > Clientsize.Height)
            {
                x = originalx;
                y = originaly;
                speedx = Math.Abs(speedx);
                speedy = Math.Abs(speedy);
                hitground++;
            }

        }
        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(Brushes.Orange, x, y, width, height);
            gfx.DrawRectangle(Pens.Red, hitbox);
        }

       
    }
}
