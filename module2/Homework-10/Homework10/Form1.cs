using System;
using static System.Math;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework10
{
    public partial class MyForm : Form
    {
        private int flag = 0;

        public MyForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                if (label1.Text.Length != 0)
                {
                    if (label1.Text[label1.Text.Length - 1] == ' ')
                        label1.Text = label1.Text[..^2];
                    else
                        label1.Text = label1.Text[..^1];
                }
                else
                {
                    Opacity = Round(Opacity - 0.1, 2);
                    if (Opacity == 0)
                        flag = 1;
                }
            }
            else if (flag == 1)
            {
                label1.Text = "Кот уже ушёл!";
                Opacity = Round(Opacity + 0.1, 2);
                flag = 2;
            }
            else
            {
                if (Opacity != 1)
                    Opacity = Round(Opacity + 0.1, 2);
                else
                    timer1.Enabled = false;
            }
        }
    }
}
