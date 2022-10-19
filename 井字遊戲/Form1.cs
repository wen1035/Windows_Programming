using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;    //DashStyle


namespace _1093305_hw2
{
    public partial class Form1 : Form
    {
        Pen p1 = new Pen(Color.Blue, 5);
        Pen MyPen = new Pen(Color.Blue, 5);
        Pen MyPen_2 = new Pen(Color.Red, 5);
        int[,] Draw_X = new int[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } };
        int[,] Draw_0 = new int[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } };

        int sum = 0;
        int Draw_true = 0;
        Rectangle rect_1 = new Rectangle(10, 10, 60, 60); // 繪出矩形1,1
        Rectangle rect_2 = new Rectangle(10, 70, 60, 60); // 繪出矩形1,2
        Rectangle rect_3 = new Rectangle(10, 130, 60, 60); // 繪出矩形1,3
        Rectangle rect_4 = new Rectangle( 70, 10, 60, 60); // 繪出矩形2,1
        Rectangle rect_5 = new Rectangle(70, 70, 60, 60); // 繪出矩形2,2
        Rectangle rect_6 = new Rectangle( 70, 130, 60, 60); // 繪出矩形2,3
        Rectangle rect_7 = new Rectangle( 130, 10, 60, 60); // 繪出矩形3,1
        Rectangle rect_8 = new Rectangle( 130, 70, 60, 60); // 繪出矩形3,2
        Rectangle rect_9 = new Rectangle(130, 130, 60, 60); // 繪出矩形3,3
       
        Rectangle rect1 = new Rectangle(17, 17, 45, 45);
        Rectangle rect2 = new Rectangle(17, 77, 45, 45);
        Rectangle rect3 = new Rectangle(17, 137, 45, 45);
        Rectangle rect4 = new Rectangle(77, 17, 45, 45);
        Rectangle rect5 = new Rectangle(77, 77, 45, 45);
        Rectangle rect6 = new Rectangle(77, 137, 45, 45);
        Rectangle rect7 = new Rectangle(137, 17, 45, 45);
        Rectangle rect8 = new Rectangle(137, 77, 45, 45);
        Rectangle rect9 = new Rectangle(137, 137, 45, 45);
        PointF[] ptr1 = new PointF[]
        {
            new PointF(17,17),new PointF(62,62)
        };
        PointF[] ptr1_2 = new PointF[]
        {
            new PointF(62,17),new PointF(17,62)
        };
        PointF[] ptr2 = new PointF[]
        {
            new PointF(17,77),new PointF(62,122)
        };
        PointF[] ptr2_2 = new PointF[]
        {
            new PointF(62,77),new PointF(17,122)
        };
        PointF[] ptr3 = new PointF[]
       {
            new PointF(17,137),new PointF(62,182)
       };
        PointF[] ptr3_2 = new PointF[]
        {
            new PointF(62,137),new PointF(17,182)
        };


        PointF[] ptr4 = new PointF[]
        {
            new PointF(77,17),new PointF(122,62)
        };
        PointF[] ptr4_2 = new PointF[]
        {
            new PointF(122,17),new PointF(77,62)
        };
        PointF[] ptr5 = new PointF[]
        {
            new PointF(77,77),new PointF(122,122)
        };
        PointF[] ptr5_2 = new PointF[]
        {
            new PointF(122,77),new PointF(77,122)
        };
        PointF[] ptr6 = new PointF[]
       {
            new PointF(77,137),new PointF(122,182)
       };
        PointF[] ptr6_2 = new PointF[]
        {
            new PointF(122,137),new PointF(77,182)
        };

        PointF[] ptr7 = new PointF[]
        {
            new PointF(137,17),new PointF(182,62)
        };
        PointF[] ptr7_2 = new PointF[]
        {
            new PointF(182,17),new PointF(137,62)
        };
        PointF[] ptr8 = new PointF[]
        {
            new PointF(137,77),new PointF(182,122)
        };
        PointF[] ptr8_2 = new PointF[]
        {
            new PointF(182,77),new PointF(137,122)
        };
        PointF[] ptr9 = new PointF[]
       {
            new PointF(137,137),new PointF(182,182)
       };
        PointF[] ptr9_2 = new PointF[]
        {
            new PointF(182,137),new PointF(137,182)
        };



        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 10, 10, 60, 60); // 繪出矩形1,1
            e.Graphics.DrawRectangle(Pens.Black, 10, 70, 60, 60); // 繪出矩形1,2
            e.Graphics.DrawRectangle(Pens.Black, 10, 130, 60, 60); // 繪出矩形1,3
            e.Graphics.DrawRectangle(Pens.Black, 70, 10, 60, 60); // 繪出矩形2,1
            e.Graphics.DrawRectangle(Pens.Black, 70, 70, 60, 60); // 繪出矩形2,2
            e.Graphics.DrawRectangle(Pens.Black, 70, 130, 60, 60); // 繪出矩形2,3
            e.Graphics.DrawRectangle(Pens.Black, 130, 10, 60, 60); // 繪出矩形3,1
            e.Graphics.DrawRectangle(Pens.Black, 130, 70, 60, 60); // 繪出矩形3,2
            e.Graphics.DrawRectangle(Pens.Black, 130, 130, 60, 60); // 繪出矩形3,3
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           
            Graphics g1 = pictureBox1.CreateGraphics();
            Graphics g2 = pictureBox1.CreateGraphics();
            int no = 0;

            while (true)
            {
                
                //判斷按下的右鍵
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //鼠標點下的位置
                    Point p = new Point(e.X, e.Y);
                   
                    //判斷點下的位置是否包含在矩形里面
                    if (rect_1.Contains(p))
                    {
                        Graphics g = pictureBox1.CreateGraphics();
                        if (Draw_0[0, 0] == 1)
                        {
                            if (Draw_X[0, 0] == 1)
                            {
                                g.DrawEllipse(p1, rect1);//填充顏色
                                Draw_0[0, 0] = 0;
                                sum += 1;
                                break;
                            }

                        }
                        else
                        {
                            no++;
                            break;
                        }
                        g.Dispose();
                    }
                    if (rect_2.Contains(p))
                    {
                        Graphics g = pictureBox1.CreateGraphics();
                        if (Draw_0[1, 0] == 2)
                        {
                            if (Draw_X[1, 0] == 2)
                            {
                                g.DrawEllipse(p1, rect2);//填充顏色
                                Draw_0[1, 0] = 0;
                                sum += 1;
                                break;
                            }


                        }
                        else
                        {
                            no++;
                            break;
                        }
                        g.Dispose();
                    }
                    if (rect_3.Contains(p))
                    {

                        Graphics g = pictureBox1.CreateGraphics();
                        if (Draw_0[2, 0] == 3)
                        {
                            if (Draw_X[2, 0] == 3)
                            {
                                g.DrawEllipse(p1, rect3);//填充顏色
                                Draw_0[2, 0] = 0;
                                sum += 1;
                                break;
                            }

                        }
                        else
                        {
                            no++;
                            break;
                        }
                        g.Dispose();
                    }
                    if (rect_4.Contains(p))
                    {

                        Graphics g = pictureBox1.CreateGraphics();
                        if (Draw_0[0, 1] == 4)
                        {
                            if (Draw_X[0, 1] == 4)
                            {
                                g.DrawEllipse(p1, rect4);//填充顏色
                                Draw_0[0, 1] = 0;
                                sum += 1;
                                break;
                            }

                        }
                        else
                        {
                            no++;
                            break;
                        }
                        g.Dispose();
                    }

                    if (rect_5.Contains(p))
                    {

                        Graphics g = pictureBox1.CreateGraphics();
                        if (Draw_0[1, 1] == 5)
                        {
                            if (Draw_X[1, 1] == 5)
                            {
                                g.DrawEllipse(p1, rect5);//填充顏色
                                Draw_0[1, 1] = 0;
                                sum += 1;
                                break;
                            }

                        }
                        else
                        {
                            no++;
                            break;
                        }
                        g.Dispose();
                    }
                    if (rect_6.Contains(p))
                    {

                        Graphics g = pictureBox1.CreateGraphics();
                        if (Draw_0[2, 1] == 6)
                        {
                            if (Draw_X[2, 1] == 6)
                            {
                                g.DrawEllipse(p1, rect6);//填充顏色
                                Draw_0[2, 1] = 0;
                                sum += 1;
                                break;
                            }

                        }
                        else
                        {
                            no++;
                            break;
                        }
                        g.Dispose();
                    }
                    if (rect_7.Contains(p))
                    {

                        Graphics g = pictureBox1.CreateGraphics();
                        if (Draw_0[0, 2] == 7)
                        {
                            if (Draw_X[0, 2] == 7)
                            {
                                g.DrawEllipse(p1, rect7);//填充顏色
                                Draw_0[0, 2] = 0;
                                sum += 1;
                                break;
                            }

                        }
                        else
                        {
                            no++;
                            break;
                        }
                        g.Dispose();
                    }
                    if (rect_8.Contains(p))
                    {

                        Graphics g = pictureBox1.CreateGraphics();
                        if (Draw_0[1, 2] == 8)
                        {
                            if (Draw_X[1, 2] == 8)
                            {
                                g.DrawEllipse(p1, rect8);//填充顏色
                                Draw_0[1, 2] = 0;
                                sum += 1;
                                break;
                            }

                        }
                        else
                        {
                            no++;
                            break;
                        }
                        g.Dispose();
                    }
                    if (rect_9.Contains(p))
                    {

                        Graphics g = pictureBox1.CreateGraphics();
                        if (Draw_0[2, 2] == 9)
                        {
                            if (Draw_X[2, 2] == 9)
                            {
                                g.DrawEllipse(p1, rect9);//填充顏色
                                Draw_0[2, 2] = 0;
                                sum += 1;
                                break;
                            }

                        }
                        else
                        {
                            no++;
                            break;
                        }
                        g.Dispose();
                    }
                }
                
            }
            Point t = new Point(30, 40);
            Point t1 = new Point(160, 40);
            
            Point t2 = new Point(24, 24);
            Point t3 = new Point(170, 170);
            
            Point t4 = new Point(40, 30);
            Point t5 = new Point(40, 160);
            
            Point t6 = new Point(30, 100);
            Point t7 = new Point(160, 100);
            
            Point t8 = new Point(24, 170);
            Point t9 = new Point(170, 24);
            
            Point t10 = new Point(30, 160);
            Point t11 = new Point(160, 160);
            
            Point t12 = new Point(100, 30);
            Point t13 = new Point(100, 160);
            
            Point t14 = new Point(160, 30);
            Point t15 = new Point(160, 160);

            Point x = new Point(30, 250);
            
            int q = 0;
            String FontName = "You win!\n";
            String FontName2 = "You lose!\n";
            String FontName3 = "Draw!\n";
            float text_x = 30;
            float text_y = 200;
            Font font = new Font(FontName, 20);
            //me win 8種
            if (Draw_0[0,0]==0 && Draw_0[0, 1] == 0 && Draw_0[0, 2] == 0)
            {
                q++;
                g1.DrawLine(MyPen_2, t,t1);
                g1.DrawString(FontName, font, Brushes.Black, text_x, text_y);
               
                g1.Dispose();
            }
            if (Draw_0[0, 0] == 0 && Draw_0[1, 1] == 0 && Draw_0[2, 2] == 0)
            {
                q++;
                g1.DrawLine(MyPen_2, t2, t3);
                g1.DrawString(FontName, font, Brushes.Black, text_x, text_y);

                g1.Dispose();
            }
            if (Draw_0[0, 0] == 0 && Draw_0[1, 0] == 0 && Draw_0[2, 0] == 0)
            {
                q++;
                g1.DrawLine(MyPen_2, t4, t5);
                g1.DrawString(FontName, font, Brushes.Black, text_x, text_y);

                g1.Dispose();
            }
            if (Draw_0[1, 0] == 0 && Draw_0[1, 1] == 0 && Draw_0[1, 2] == 0)
            {
                q++;
                g1.DrawLine(MyPen_2, t6, t7);
                g1.DrawString(FontName, font, Brushes.Black, text_x, text_y);

                g1.Dispose();
            }
            if (Draw_0[2, 0] == 0 && Draw_0[1, 1] == 0 && Draw_0[0, 2] == 0)
            {
                q++;
                g1.DrawLine(MyPen_2, t8, t9);
                g1.DrawString(FontName, font, Brushes.Black, text_x, text_y);

                g1.Dispose();
            }
            if (Draw_0[2, 0] == 0 && Draw_0[2, 1] == 0 && Draw_0[2, 2] == 0)
            {
                q++;
                g1.DrawLine(MyPen_2, t10, t11);
                g1.DrawString(FontName, font, Brushes.Black, text_x, text_y);

                g1.Dispose();
            }
            if (Draw_0[0, 1] == 0 && Draw_0[1, 1] == 0 && Draw_0[2, 1] == 0)
            {
                q++;
                g1.DrawLine(MyPen_2, t12, t13);
                g1.DrawString(FontName, font, Brushes.Black, text_x, text_y);

                g1.Dispose();
            }
            if (Draw_0[0, 2] == 0 && Draw_0[1, 2] == 0 && Draw_0[2, 2] == 0)
            {
                q++;
                g1.DrawLine(MyPen_2, t14, t15);
                g1.DrawString(FontName, font, Brushes.Black, text_x, text_y);

                g1.Dispose();
            }

  
         
            if (no == 0 &&q==0)
            {
                while (true)
                {
                    Random rnd = new Random();
                    int ranX = rnd.Next(0, 3);
                    int ranY = rnd.Next(0, 3);

                    if (Draw_0[ranX, ranY] != 0)
                    {
                        if (Draw_X[ranX, ranY] != 0)
                        {

                            if (Draw_X[ranX, ranY] == 1)
                            {
                                g1.DrawLines(MyPen, ptr1);
                                g1.DrawLines(MyPen, ptr1_2);
                                sum += 1;
                                Draw_X[ranX, ranY] = 0;
                                g1.Dispose();
                                break;
                            }
                            if (Draw_X[ranX, ranY] == 2)
                            {
                                g1.DrawLines(MyPen, ptr2);
                                g1.DrawLines(MyPen, ptr2_2);
                                sum+=1;
                                Draw_X[ranX, ranY] = 0;
                                g1.Dispose();
                                break;
                            }
                            if (Draw_X[ranX, ranY] == 3)
                            {
                                g1.DrawLines(MyPen, ptr3);
                                g1.DrawLines(MyPen, ptr3_2);
                                sum+=1;
                                Draw_X[ranX, ranY] = 0;
                                g1.Dispose();
                                break;
                            }
                            if (Draw_X[ranX, ranY] == 4)
                            {
                                g1.DrawLines(MyPen, ptr4);
                                g1.DrawLines(MyPen, ptr4_2);
                                sum+=1;
                                Draw_X[ranX, ranY] = 0;
                                g1.Dispose();
                                break;
                            }
                            if (Draw_X[ranX, ranY] == 5)
                            {
                                g1.DrawLines(MyPen, ptr5);
                                g1.DrawLines(MyPen, ptr5_2);
                                sum+=1;
                                Draw_X[ranX, ranY] = 0;
                                g1.Dispose();
                                break;
                            }
                            if (Draw_X[ranX, ranY] == 6)
                            {
                                g1.DrawLines(MyPen, ptr6);
                                g1.DrawLines(MyPen, ptr6_2);
                                sum+=1;
                                Draw_X[ranX, ranY] = 0;
                                g1.Dispose();
                                break;
                            }
                            if (Draw_X[ranX, ranY] == 7)
                            {
                                g1.DrawLines(MyPen, ptr7);
                                g1.DrawLines(MyPen, ptr7_2);
                                sum+=1;
                                Draw_X[ranX, ranY] = 0;
                                g1.Dispose();
                                break;
                            }
                            if (Draw_X[ranX, ranY] == 8)
                            {
                                g1.DrawLines(MyPen, ptr8);
                                g1.DrawLines(MyPen, ptr8_2);
                                sum += 1;
                                Draw_X[ranX, ranY] = 0;
                                g1.Dispose();
                                break;
                            }
                            if (Draw_X[ranX, ranY] == 9)
                            {
                                g1.DrawLines(MyPen, ptr9);
                                g1.DrawLines(MyPen, ptr9_2);
                                sum += 1;
                                Draw_X[ranX, ranY] = 0;
                                g1.Dispose();
                                break;
                            }


                        }

                    }
                    if (sum == 9)
                        break;

                   
                    
                }
                //lose 8種
                if (Draw_X[0, 0] == 0 && Draw_X[0, 1] == 0 && Draw_X[0, 2] == 0)
                {
                    q++;
                    g2.DrawLine(MyPen_2, t, t1);
                    g2.DrawString(FontName2, font, Brushes.Black, text_x, text_y);

                    g2.Dispose();
                }
                if (Draw_X[0, 0] == 0 && Draw_X[1, 1] == 0 && Draw_X[2, 2] == 0)
                {
                    q++;
                    g2.DrawLine(MyPen_2, t2, t3);
                    g2.DrawString(FontName2, font, Brushes.Black, text_x, text_y);

                    g2.Dispose();
                }
                if (Draw_X[0, 0] == 0 && Draw_X[1, 0] == 0 && Draw_X[2, 0] == 0)
                {
                    q++;
                    g2.DrawLine(MyPen_2, t4, t5);
                    g2.DrawString(FontName2, font, Brushes.Black, text_x, text_y);

                    g2.Dispose();
                }
                if (Draw_X[1, 0] == 0 && Draw_X[1, 1] == 0 && Draw_X[1, 2] == 0)
                {
                    q++;
                    g2.DrawLine(MyPen_2, t6, t7);
                    g2.DrawString(FontName2, font, Brushes.Black, text_x, text_y);

                    g2.Dispose();
                }
                if (Draw_X[2, 0] == 0 && Draw_X[1, 1] == 0 && Draw_X[0, 2] == 0)
                {
                    q++;
                    g2.DrawLine(MyPen_2, t8, t9);
                    g2.DrawString(FontName2, font, Brushes.Black, text_x, text_y);

                    g2.Dispose();
                }
                if (Draw_X[2, 0] == 0 && Draw_X[2, 1] == 0 && Draw_X[2, 2] == 0)
                {
                    q++;
                    g2.DrawLine(MyPen_2, t10, t11);
                    g2.DrawString(FontName2, font, Brushes.Black, text_x, text_y);

                    g2.Dispose();
                }
                if (Draw_X[0, 1] == 0 && Draw_X[1, 1] == 0 && Draw_X[2, 1] == 0)
                {
                    q++;
                    g2.DrawLine(MyPen_2, t12, t13);
                    g2.DrawString(FontName2, font, Brushes.Black, text_x, text_y);

                    g2.Dispose();
                }
                if (Draw_X[0, 2] == 0 && Draw_X[1, 2] == 0 && Draw_X[2, 2] == 0)
                {
                    q++;
                    g2.DrawLine(MyPen_2, t14, t15);
                    g2.DrawString(FontName2, font, Brushes.Black, text_x, text_y);

                    g2.Dispose();
                }
            }
           
            if (sum == 9 &&q==0)
            {
                g1.DrawString(FontName3, font, Brushes.Black, text_x,text_y);           
            }

          
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
