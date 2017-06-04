using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MihirBrickBreaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //title page
        //lose life and lose page
        //destory all -> bricks win page

        Graphics gfx;
        Rectanglez paddle;
        Ball jo;

        List<Rectanglez> bricks;

        Bitmap bitmap;
        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            gfx = Graphics.FromImage(bitmap);
            paddle = new Rectanglez(228, ClientSize.Height - 15, 20, 150, 7);
            jo = new Ball(234, 250, 40, 40, 5, 5);

            bricks = new List<Rectanglez>();

            int dy = 100;
            for (int j = 0; j < 6; j++)
            {

                int dx = 0;
                for (int i = 0; i < 11; i++)
                {
                    bricks.Add(new Rectanglez(1 + dx, 1 + dy, 20, 80, 0));
                    dx += 80 + 6;
                }

                dy += 20 + 6;
            }
        }

        //Location
        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = $"Location: X:{e.X} Y:{e.Y}";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //erase
            gfx.DrawImage(BackgroundImage, 0, 0, ClientSize.Width, ClientSize.Height);

            label1.Text = jo.hitground.ToString();
            //Update
            paddle.Update(ClientSize);
            jo.Update(ClientSize);

            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Update(ClientSize);
            }

            //if paddle hitbox intersects ball hitbox
            if (paddle.hitbox.IntersectsWith(jo.hitbox))
            {
                //bounce ball so it goes up
                jo.speedy = -Math.Abs(jo.speedy);

            }

            //for
            for (int x = 0; x < bricks.Count; x++)
            {
                if (bricks[x].hitbox.IntersectsWith(jo.hitbox))
                {
                    bricks.RemoveAt(x);
                    jo.speedy *= -1;
                    break;
                }
            }
            //Drawing
            //for
            for (int f = 0; f < bricks.Count; f++)
            {
                bricks[f].Draw(gfx);
            }
            //Paddle
            paddle.Draw(gfx);
            jo.Draw(gfx);

            //label
            gfx.DrawString(label2.Text, label2.Font, new SolidBrush(label2.ForeColor), label2.Location);
            gfx.DrawString(label3.Text, label3.Font, new SolidBrush(label3.ForeColor), new Point(label3.Location.X, label3.Location.Y - 20));

            canvas.Image = bitmap;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                paddle.Right = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                paddle.Left = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                paddle.Left = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                paddle.Right = false;
            }
            
        }
       
    }
}

// The middle of the paddle will be if (paddle.x + (paddle.Width/2)), set ball.speedx = 0