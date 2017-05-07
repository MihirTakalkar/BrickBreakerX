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

        Graphics gfx;
        Rectanglez paddle;
        Ball jo;
        Rectanglez random;
        Bitmap bitmap;
        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            gfx = Graphics.FromImage(bitmap);
            paddle = new Rectanglez(228, ClientSize.Height - 15, 20, 150, 5);
            jo = new Ball(234, 150, 40, 40, 5, 5);
            random = new Rectanglez(1,1,20,80, 0);

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

        
            //Update
            paddle.Update(ClientSize);
            jo.Update(ClientSize);
            random.Update(ClientSize);

            //if paddle hitbox intersects ball hitbox
            if (paddle.hitbox.IntersectsWith(jo.hitbox))
            {
                //bounce ball so it goes up
               jo.speedy = -Math.Abs(jo.speedy);
            }
            if (random.hitbox.IntersectsWith(jo.hitbox))
            {
                
            }
            //Drawing
            random.Draw(gfx);
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
