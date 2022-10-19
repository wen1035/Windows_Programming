using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1093305_hw4
{
    public partial class Form1 : Form
    {
        Rectangle rect_1 = new Rectangle(0, 50, 225, 225); // 繪出矩形
        Rectangle rect_2 = new Rectangle( 0, 274,225,15); // 繪出矩形

        int X = 60;
        int Y = 55;
        Color c = Color.Red;
       
        int num1 = 0;
        int num2 = 0;

        int stepX = 1; // 開始的角度
        int stepY = 1; // 開始的角度

        int s = 100;
        int myX = 0;
        int myY = 275;
        int abc = 1;
        Point pos = new Point();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, rect_1); // 繪出矩形
            
            Brush b1 = new SolidBrush(c);
            Brush b2 = new SolidBrush(Color.Red);

            e.Graphics.FillEllipse(b1, X,Y, 10, 10);
            e.Graphics.FillRectangle(b2,myX,myY,50,15);
           

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(num2 %5 == 0 && num2 != 0 && num2 != 1)
            {
                if(abc==1)
                {
                    abc++;
                    timer1.Interval = 900;
                }
                if (abc == 2)
                {
                    abc++;
                    timer1.Interval = 800;
                }
                if (abc == 3)
                {
                    abc++;
                    timer1.Interval = 700;
                }
                if (abc == 4)
                {
                    abc++;
                    timer1.Interval = 600;
                }
                if (abc == 5)
                {
                    abc++;
                    timer1.Interval = 500;

                }   
                if (abc == 6)
                {
                    abc++;
                    timer1.Interval = 400;
                }
                if (abc == 7)
                {
                    abc++;
                    timer1.Interval = 300;
                }
                if (abc == 8)
                {
                    abc++;
                    timer1.Interval = 200;
                }
                if (abc == 9)
                {
                    abc++;
                    timer1.Interval = 100;
                }
                if (abc == 10)
                {
                    abc++;
                    timer1.Interval = 50;
                }
                if (abc == 11)
                {
                    abc++;
                    timer1.Interval = 25;
                }
                if (abc == 12)
                {
                    abc++;
                    timer1.Interval = 1;
                }

            }
            if ((X+10)>225 || X<0)
            {
                stepX = 0 - stepX;
            }
            if( Y < 50)
            {
                stepY = 0 - stepY;

            }
            if ((Y + 10) > 275 ) 
            {
                int p = 0;
                p = myX + 50;
                if (myX >=X ||p<=X )
                {

                    num1 = 0;
                    stepX = 0;
                    stepY = 0;
                }
                else
                {
                    stepY = 0 - stepY;
                }
            }
            X += stepX;
            Y += stepY;
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            timer1.Interval = 1000;
            timer2.Interval = 1000;
            num1 = 1000;
            toolStripStatusLabel1.Text = "0";
            num2 = 0;
            timer1.Start();
            timer2.Start();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            c = Color.Red;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            c = Color.Green;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            c = Color.Blue;
        }

       
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (num2 < num1)
            {
                num2++;

                toolStripStatusLabel1.Text = num2.ToString();
                toolStripStatusLabel2.Text = "Playing!";
            }
            else
            {
                timer1.Stop();
                toolStripStatusLabel2.Text = "Game Over!";
            }

            Invalidate();
        }

      
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
       
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //鼠標點下的位置
                Point p = new Point(e.X, e.Y);
                int pX = p.X;
                int pY = p.Y;
                //判斷點下的位置是否包含在矩形里面
                if (rect_2.Contains(p))
                {
                    //rect_2 = (e.X,e.Y,50,15);
                    Graphics g = this.CreateGraphics();
                    //g.FillRectangle(b9, rect1);//填充顏色
                    //ellipse.Width = pX;
                    //ellipse.Height = pY;
                    myX = pX;
                    //myY = pY;
                    Invalidate();
                    g.Dispose();
                }
            }
        }
    }
}
