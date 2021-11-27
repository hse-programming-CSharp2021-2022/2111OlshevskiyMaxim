using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar4
{
    public partial class Form1 : Form
    {
        private static int p1 = 1, p2 = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Text == "0")
                checkBox1.Text = "1";
            else
                checkBox1.Text = "0";
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                int p3 = checked(p1 + 2 * p2);
                labelNext.Text = p3.ToString();
                p1 = p2;
                p2 = p3;
            }
            catch
            {
                MessageBox.Show("Переполнение!");
                p1 = 1;
                p2 = 2;
            }
        }
    }
}
