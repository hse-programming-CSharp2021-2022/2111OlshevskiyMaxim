using System;
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
    public partial class Form1 : Form
    {
        private int X, Y;   // Координаты форточки
        private int W, H;   // Размеры форточки

        public Form1()
        {
            InitializeComponent();
            W = H = 100;
            trackBar2.Maximum = Height - H - 60;
            trackBar2.Value = Height - H - 90;
            X = Y = 0;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Y = trackBar2.Maximum - trackBar2.Value;
            Invalidate();
        }

        // Метод для перерисовки формы:
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            trackBar1.Maximum = Width - W - 60;
            trackBar2.Maximum = Height - H - 90;
            e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlDark), X, Y, W, H);
            // Устанавливаем цвет ControlDark "прозрачным":
            TransparencyKey = SystemColors.ControlDark;
        }

        // Метод реагирует на каждое перемещение
        // пользователем ползунка на элементе trackBar1:
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            X = trackBar1.Value;
            // после изменения пользователем ползунка
            // элемента trackBar1 необходимо
            // переместить форточку, для чего перерисуем всю форму:
            Invalidate();
        }
    }
}
