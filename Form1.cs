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

        private void Form1_Load(object sender, EventArgs e)
        {
            gfx = CreateGraphics();
            paddle = new Rectanglez(228, ClientSize.Height - 20, 40, 100, 5);
        }

        //Location
        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = string.Format(" Location: X:{0} Y:{1}", e.X, e.Y);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Paddle
            paddle.Draw(gfx);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                
            }
       
        }
    }
}
