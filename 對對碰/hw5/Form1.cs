using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1093305_hw5
{
    public partial class Form1 : Form
    {
        int num1=0,num2=0;
        List<Image> imgs = new List<Image>();
        Image img0 = Properties.Resources._8_0;
        Image img1 = Properties.Resources._8_1;
        Image img2 = Properties.Resources._8_2;
        Image img3 = Properties.Resources._8_3;
        Image img4 = Properties.Resources._8_4;
        Image img5 = Properties.Resources._8_5;
        Image img6 = Properties.Resources._8_6;
        Image img7 = Properties.Resources._8_7;
        Image img8 = Properties.Resources._8_8;

        List<Rectangle> rect = new List<Rectangle>();
        Rectangle rect1 = new Rectangle(11, 51, 49, 49);
        Rectangle rect2 = new Rectangle(11, 101, 49, 49);
        Rectangle rect3 = new Rectangle(11, 151, 49, 49);
        Rectangle rect4 = new Rectangle(11, 201, 49, 49);
        Rectangle rect5 = new Rectangle(61, 51, 49, 49);
        Rectangle rect6 = new Rectangle(61, 101, 49, 49);
        Rectangle rect7 = new Rectangle(61, 151, 49, 49);
        Rectangle rect8 = new Rectangle(61, 201, 49, 49);
        Rectangle rect9 = new Rectangle(111, 51, 49, 49);
        Rectangle rect10 = new Rectangle(111, 101, 49, 49);
        Rectangle rect11 = new Rectangle(111, 151, 49, 49);
        Rectangle rect12 = new Rectangle(111, 201, 49, 49);
        Rectangle rect13 = new Rectangle(161, 51, 49, 49);
        Rectangle rect14 = new Rectangle(161, 101, 49, 49);
        Rectangle rect15 = new Rectangle(161, 151, 49, 49);
        Rectangle rect16 = new Rectangle(161, 201, 49, 49);
        private Random rnd = new Random();
        int[,] Draw_img = new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        int[,] Draw_0 = new int[,] { { 1, 5, 9, 13 }, { 2, 6, 10, 14 }, { 3, 7, 11, 15 }, { 4, 8, 12, 16 } };
        int[] number = new int[16];
        int op = 0;
        /* PointF[] ptr1 = new PointF[]
        {
             new PointF(11,51),new PointF(11,101),new PointF(11,151),new PointF(11,201),
             new PointF(61,51),new PointF(61,101),new PointF(61,151),new PointF(61,201),
             new PointF(111,51), new PointF(111,101),new PointF(111,151),new PointF(111,201),
             new PointF(161,51), new PointF(161,101),new PointF(161,151),new PointF(161,201)
        };*/
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 10, 50, 50, 50); // 繪出矩形1,1
            e.Graphics.DrawRectangle(Pens.Black, 10, 100, 50, 50); // 繪出矩形1,2
            e.Graphics.DrawRectangle(Pens.Black, 10, 150, 50, 50); // 繪出矩形1,3
            e.Graphics.DrawRectangle(Pens.Black, 10, 200, 50, 50); // 繪出矩形1,4
            e.Graphics.DrawRectangle(Pens.Black, 60, 50, 50, 50); // 繪出矩形2,1
            e.Graphics.DrawRectangle(Pens.Black, 60, 100, 50, 50); // 繪出矩形2,2
            e.Graphics.DrawRectangle(Pens.Black, 60, 150, 50, 50); // 繪出矩形2,3
            e.Graphics.DrawRectangle(Pens.Black, 60, 200, 50, 50); // 繪出矩形2,4
            e.Graphics.DrawRectangle(Pens.Black, 110, 50, 50, 50); // 繪出矩形3,1
            e.Graphics.DrawRectangle(Pens.Black, 110, 100, 50, 50); // 繪出矩形3,2
            e.Graphics.DrawRectangle(Pens.Black, 110, 150, 50, 50); // 繪出矩形3,3
            e.Graphics.DrawRectangle(Pens.Black, 110, 200, 50, 50); // 繪出矩形3,4
            e.Graphics.DrawRectangle(Pens.Black, 160, 50, 50, 50); // 繪出矩形4,1
            e.Graphics.DrawRectangle(Pens.Black, 160, 100, 50, 50); // 繪出矩形4,2
            e.Graphics.DrawRectangle(Pens.Black, 160, 150, 50, 50); // 繪出矩形4,3
            e.Graphics.DrawRectangle(Pens.Black, 160, 200, 50, 50); // 繪出矩形4,4

            Graphics g1 = CreateGraphics();

            for (int i = 0; i < 16; i++)
            {
                g1.DrawImage(img0, rect[i]);
            }
            int s = 0, a = 0,n=0,no,p=0,sum=0;
            int[] abc = new int[1000];
            while(s < 2)
            {
                int r;
                r = rnd.Next(1, 9);
                s = 0;
                no = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (s == 0)
                    {
                        for (int k = 0, z = 2; k <= 1; k++, z++)
                        {
                            if (Draw_img[k, j] == 0 )
                            {
                                for(int o=0;o<16;o++)
                                {
                                    if(r == abc[o])
                                    {
                                        no = 1;
                                    }

                                }
                                if (no == 0)
                                {
                                    Draw_img[k, j] = r;
                                    Draw_img[z, j] = r;
                                    abc[p] = r;
                                    s = 1;
                                    p++;
                                    break;
                                }
                            }
                        }
                    }
                      
                   
                }
                n = 0;
                for(int i=0;i<4;i++)
                {
                    for(int j=0;j<4;j++)
                    {
                        if(Draw_img[i, j] == 0 )
                        {
                            a = 1;
                            break;
                        }
                        else 
                        {
                            n++;
                            if(i == 3 && j == 3 && n == 16)
                            {
                                s = 2;
                            }
                            
                        }
                    }
                    
                }

            }
            sum = 0;
            for (int i = 0; i < op; i++)
            {
                //Graphics g1 = CreateGraphics();
                for (int o = 0; o < 4; o++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (number[i] == Draw_0[o, k] - 1)
                        {
                            if (i % 2 == 1)
                            {
                                for (int z = 0; z < 4; z++)
                                {
                                    for (int c = 0; c < 4; c++)
                                    {
                                        if (number[i-1] == Draw_0[z, c] - 1)
                                        {
                                            if(imgs[Draw_img[o, k]]== imgs[Draw_img[z, c]])
                                            {
                                                g1.DrawImage(imgs[Draw_img[o, k]], rect[number[i]]);
                                                sum++;
                                            }
                                            else
                                            {
                                                g1.DrawImage(imgs[Draw_img[o, k]], rect[number[i]]);
                                                number[i] = 0;
                                                number[i - 1] = 0;
                                                op -= 2;
                                            }
                                        }
                                    }
                                }
                                
                            }
                            else
                            {
                                g1.DrawImage(imgs[Draw_img[o, k]], rect[number[i]]);
                            }//op++;
                        }
                    }
                }
            }
            if (sum == 8 && op == 16)
                num1 = 0;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
            //判斷按下的右鍵
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //鼠標點下的位置
                Point p = new Point(e.X, e.Y);
                //判斷點下的位置是否包含在矩形里面
                for(int i=0;i<16;i++)
                {
                    if (rect[i].Contains(p))
                    {
                        Graphics g1 = CreateGraphics();
                        for (int o = 0; o < 4; o++)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                if (i == Draw_0[o,k]-1)
                                {
                                    number[op]= i;
                                    g1.DrawImage(imgs[Draw_img[o, k]], rect[i]);
                                    op++;
                                }
                            }
                        }
                            
                      
                    }
                }
                


            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            num1 = 10000;
            num2 = 0;
            timer1.Start();
            rect.Add(rect1);
            rect.Add(rect2);
            rect.Add(rect3);
            rect.Add(rect4);
            rect.Add(rect5);
            rect.Add(rect6);
            rect.Add(rect7);
            rect.Add(rect8);
            rect.Add(rect9);
            rect.Add(rect10);
            rect.Add(rect11);
            rect.Add(rect12);
            rect.Add(rect13);
            rect.Add(rect14);
            rect.Add(rect15);
            rect.Add(rect16);
            imgs.Add(img0);
            imgs.Add(img1);
            imgs.Add(img2);
            imgs.Add(img3);
            imgs.Add(img4);
            imgs.Add(img5);
            imgs.Add(img6);
            imgs.Add(img7);
            imgs.Add(img8);
            

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (num2 < num1)
            {
                num2++;

                label1.Text = num2.ToString();
                
            }
            else
            {
                timer1.Stop();
               
            }

            Invalidate();
           
        }
    }
}
