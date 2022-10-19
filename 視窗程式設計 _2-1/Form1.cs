using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1093305_2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Form1 Load事件\r\n";

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            textBox1.AppendText("Form1 Activated事件\r\n");

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Form1 Click事件\r\n");

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("textBox1 Click事件\r\n");

        }
    }
}
