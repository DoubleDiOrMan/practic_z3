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
    public partial class settings : Form
    {
        Form1 f1;
        public settings(Form1 form1)
        {
            InitializeComponent();
            f1 = form1;
            button1.BackColor = Form1.brush1.Color;
            button2.BackColor = Form1.brush2.Color;
            radioButton2.Checked = Form1.flag == Form1.STATUS.Top || Form1.flag == Form1.STATUS.Bottom;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            trackBar1.Value = 100 - f1.timer1.Interval;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Form1.brush1.Color = colorDialog1.Color;
            button1.BackColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Form1.brush2.Color = colorDialog1.Color;
            button2.BackColor = colorDialog1.Color;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Form1.flag = Form1.flag == Form1.STATUS.Left || Form1.flag == Form1.STATUS.Right ? Form1.STATUS.Bottom : Form1.STATUS.Right;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            f1.timer1.Interval = 100 - trackBar1.Value;
        }
    }
}
