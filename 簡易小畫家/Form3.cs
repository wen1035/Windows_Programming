using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1093305_12_1
{
    public partial class Form3 : Form
    {
        private float R = -1, G = -1, B = -1, A = -1;
       
        private void button1_Click(object sender, EventArgs e)
        {
            R = (float)trackBar1.Value / 10;
            G = (float)trackBar2.Value / 10;
            B = (float)trackBar3.Value / 10;
            A = (float)trackBar4.Value / 10;
           
            Close();
        }
        

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            R = (float)trackBar1.Value / 10;
            string s = R.ToString();
            label5.Text=s;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            G = (float)trackBar2.Value / 10;
            string s = G.ToString();
            label6.Text = s;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            B = (float)trackBar3.Value / 10;
            string s = B.ToString();
            label7.Text = s;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            A = (float)trackBar4.Value / 10;
            string s = A.ToString();
            label8.Text = s;
        }
        public float getR()
        {
            return R;
        }
        public float getG()
        {
            return G;
        }

        public float getB()
        { 
            return B;
        }
        public float getA()
        {
            return A;
        }

        public Form3()
        {
            InitializeComponent();
        }
    }
}
