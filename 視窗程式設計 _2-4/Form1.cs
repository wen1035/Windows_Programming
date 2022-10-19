using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1093305_2_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("MouseDown at " + e.Location.X.ToString() + " , " + e.Location.Y.ToString() + "\n");

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("MouseMove at " + e.Location.X.ToString() + " , " + e.Location.Y.ToString() + "\n");

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox1.AppendText("MouseUp at " + e.Location.X.ToString() + " , " + e.Location.Y.ToString() + "\n");
        }
    }
}
