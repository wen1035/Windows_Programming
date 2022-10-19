using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1093305_2_3
{
    public partial class Form1 : Form
    {
        private bool nonNumberEntered = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
                label2.Text = e.KeyChar + " is not a digit. Please input a digit.";
            }
            else
                label2.Text = e.KeyChar + " is OK.";

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) // 鍵盤上數字
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) //數字盤
                {
                    if (e.KeyCode != Keys.Back)   //Backspace
                        nonNumberEntered = true;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
                label3.Text = "大寫鎖鍵已按下";
            else
                label3.Text = "大寫鎖鍵已取消";
            if (Control.IsKeyLocked(Keys.NumLock))
                label3.Text += "\n數字鎖鍵已按下";
            else
                label3.Text += "\n數字鎖鍵已取消";

        }

    }
}
