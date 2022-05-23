using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Тема_4
{
    public partial class Form1 : Form
    {
        int x = 0, y = 0, dx = 5;

        public static SolidBrush brush1 = new SolidBrush(Color.Red);
        public static SolidBrush brush2 = new SolidBrush(Color.AliceBlue);
        public static SolidBrush brush = brush1;

        Pen pen = new Pen(Color.Black, 2);
        public enum STATUS {Left, Right, Top, Bottom};
        enum rotation {Up, Down};
        rotation rotflag = rotation.Up;
        public static STATUS flag = STATUS.Right;
        Point p1, p2, p3;

        private void button2_Click(object sender, EventArgs e)
        {
            settings set = new settings(this);
            set.Show();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                Application.Exit();
        }

        private void oncollide()
        {
            rotflag = rotflag == rotation.Up ? rotation.Down : rotation.Up;
            brush = brush == brush1 ? brush2 : brush1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Пуск")
            {
                timer1.Start();
                button1.Text = "Стоп";
                return;
            }
            if (button1.Text == "Стоп")
            {
                timer1.Stop();
                button1.Text = "Пуск";
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag == STATUS.Left)
                x -= dx;
            if (flag == STATUS.Right)
                x += dx;
            if (flag == STATUS.Top)
                y -= dx;
            if (flag == STATUS.Bottom)
                y += dx;

            if (x + 100 >= this.ClientSize.Width)
            {
                flag = STATUS.Left;
                oncollide();
            }

            if (x < 0)
            {
                flag = STATUS.Right;
                oncollide();
            }

            if (y + 100 >= this.ClientSize.Height)
            {
                flag = STATUS.Top;
                oncollide();
            }

            if (y < 0)
            {
                flag = STATUS.Bottom;
                oncollide();
            }



            Invalidate();
            p1 = new Point(100 + x, 100 + y - (int)rotflag * 100);
            p2 = new Point(0 + x, 100 + y - (int)rotflag * 100);
            p3 = new Point(50 + x, 0 + y + (int)rotflag * 100);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
                Point[] pap = new Point[] { p1, p2, p3 };
                e.Graphics.FillPolygon(brush, pap);
                e.Graphics.DrawLine(pen, p2, p3);
                e.Graphics.DrawLine(pen, p3, p1);
                e.Graphics.DrawLine(pen, p1, p2);
            
        }
    }
}
