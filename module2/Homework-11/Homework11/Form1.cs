using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework11
{
    public partial class ListBoxForm : Form
    {
        public ListBoxForm()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            listBox.Items.RemoveAt(listBox.SelectedIndex);
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(new object[] { "один", "два", "три", "четыре", "пять", "шесть", "семь" });
            deleteButton.Enabled = false;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = listBox.SelectedIndex != -1;
        }
    }
}
