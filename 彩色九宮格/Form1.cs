using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1093305_hw1
{
    public partial class Form1 : Form
    {
        Rectangle rect1= new Rectangle(11, 11, 49, 49);
        Rectangle rect2 = new Rectangle(11, 61, 49, 49);
        Rectangle rect3 = new Rectangle(11, 111, 49, 49);
        Rectangle rect4 = new Rectangle(61, 11, 49, 49);
        Rectangle rect5 = new Rectangle(61, 61, 49, 49);
        Rectangle rect6 = new Rectangle(61, 111, 49, 49);
        Rectangle rect7 = new Rectangle(111, 11, 49, 49);
        Rectangle rect8 = new Rectangle(111, 61, 49, 49);
        Rectangle rect9 = new Rectangle(111, 111, 49, 49);
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 10, 10, 50, 50); // 繪出矩形1,1
            e.Graphics.DrawRectangle(Pens.Black, 10, 60, 50, 50); // 繪出矩形1,2
            e.Graphics.DrawRectangle(Pens.Black, 10, 110, 50, 50); // 繪出矩形1,3
            e.Graphics.DrawRectangle(Pens.Black, 60, 10, 50, 50); // 繪出矩形2,1
            e.Graphics.DrawRectangle(Pens.Black, 60, 60, 50, 50); // 繪出矩形2,2
            e.Graphics.DrawRectangle(Pens.Black, 60, 110, 50, 50); // 繪出矩形2,3
            e.Graphics.DrawRectangle(Pens.Black, 110, 10, 50, 50); // 繪出矩形3,1
            e.Graphics.DrawRectangle(Pens.Black, 110, 60, 50, 50); // 繪出矩形3,2
            e.Graphics.DrawRectangle(Pens.Black, 110, 110, 50, 50); // 繪出矩形3,3

            //填色
            Brush b1 = new SolidBrush(Color.Yellow);
            e.Graphics.FillRectangle(b1,rect1);//1,1
            Brush b2 = new SolidBrush(Color.Red);
            e.Graphics.FillRectangle(b2, rect2);//1,2
            Brush b3 = new SolidBrush(Color.Green);
            e.Graphics.FillRectangle(b3,rect3);//1,3
            Brush b4 = new SolidBrush(Color.Blue);
            e.Graphics.FillRectangle(b4,rect4);//2,1
            Brush b5 = new SolidBrush(Color.Aqua);
            e.Graphics.FillRectangle(b5, rect5);//2,2
            Brush b6 = new SolidBrush(Color.Gray);
            e.Graphics.FillRectangle(b6,rect6);//2,3
            Brush b7 = new SolidBrush(Color.Brown);
            e.Graphics.FillRectangle(b7, rect7);//3,1
            Brush b8 = new SolidBrush(Color.BlueViolet);
            e.Graphics.FillRectangle(b8, rect8);//3,2
            Brush b9 = new SolidBrush(Color.OrangeRed);
            e.Graphics.FillRectangle(b9,rect9);//3,3
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        { 

            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Brush b9 = new SolidBrush(randomColor);

            //判斷按下的右鍵
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //鼠標點下的位置
                Point p = new Point(e.X, e.Y);
                //判斷點下的位置是否包含在矩形里面
                if (rect1.Contains(p))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    g.FillRectangle(b9, rect1);//填充顏色
                   
                    g.Dispose();
                }
                if (rect2.Contains(p))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    g.FillRectangle(b9, rect2);//填充顏色

                    g.Dispose();
                }
                if (rect3.Contains(p))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    g.FillRectangle(b9, rect3);//填充顏色

                    g.Dispose();
                }
                if (rect4.Contains(p))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    g.FillRectangle(b9, rect4);//填充顏色

                    g.Dispose();
                }
                if (rect4.Contains(p))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    g.FillRectangle(b9, rect4);//填充顏色

                    g.Dispose();
                }
                if (rect5.Contains(p))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    g.FillRectangle(b9, rect5);//填充顏色

                    g.Dispose();
                }
                if (rect6.Contains(p))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    g.FillRectangle(b9, rect6);//填充顏色

                    g.Dispose();
                }
                if (rect7.Contains(p))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    g.FillRectangle(b9, rect7);//填充顏色

                    g.Dispose();
                }
                if (rect8.Contains(p))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    g.FillRectangle(b9, rect8);//填充顏色

                    g.Dispose();
                }
                if (rect9.Contains(p))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    g.FillRectangle(b9, rect9);//填充顏色

                    g.Dispose();
                }
            }

        }
    }
}
