using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace _1093305_hw6
{
    public partial class Form1 : Form
    {
        Rectangle rect_1 = new Rectangle(0, 0, 500, 400); // 繪出矩形
        Rectangle rect_2 = new Rectangle(0, 399, 500, 50); // 繪出矩形
        int X = 60;
        int Y = 55;

        int num1 = 0, num2 = 0,win=0;
        int myX = 0;
        int myY = 400;
        int stepX = 10; // 開始的角度
        int stepY = 10; // 開始的角度
        //Bitmap img1_1, img1_2, img1_3, img2,img3_1,img3_2,img3_3; //  影像
        List<Bitmap> imgs1 = new List<Bitmap>();
        List<Bitmap> imgs2 = new List<Bitmap>();
        Bitmap img1_1 = Properties.Resources.Tulips;
        Bitmap img1_2 = Properties.Resources.Hydrangeas;
        Bitmap img1_3 = Properties.Resources.Penguins;
        Bitmap img2 = Properties.Resources.Bowl;
        Bitmap img3_1 = Properties.Resources.Banana;
        Bitmap img3_2 = Properties.Resources.StawBerry;
        Bitmap img3_3 = Properties.Resources.Tomato;
        Bitmap  imgClone, img2Clone, img3Clone;   //  影像,// 透明的影像
        Point MousePos;
        Bitmap img,img3, img_all;
        int rand_true = 1, d_size = 0, m_size = 0;
        int[] d = new int[10000000];
        int[] m = new int[10000000];


        private Random rnd = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (num2 > num1)
            {
                num2--;
                if(num2 % 10 == 0)
                {
                    rand_true = 1;
                }
                label2.Text = num2.ToString();

            }
            else
            {
                timer1.Stop();

            }

            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer2.Interval = 100;
            num1 = 0;
            num2 = 120;
            timer1.Start();
            timer2.Start();
            imgs1.Add(img1_1);
            imgs1.Add(img1_2);
            imgs1.Add(img1_3);
            imgs2.Add(img1_1);
            imgs2.Add(img1_2);
            imgs2.Add(img1_3);


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(Pens.Black, rect_1); // 繪出矩形
            
           // Brush b1 = new SolidBrush(c);
            Brush b2 = new SolidBrush(Color.Red);

            //e.Graphics.FillRectangle(b2, myX, myY, 50, 15);
            if ((img2.Width != 50) || (img2.Height != 50))
            {
                img_all = new Bitmap(img2, 50, 50);

                //ClientSize = new Size(500, 500);
            }

            ImageClone_2();
            Invalidate(); // 要求重畫
            DoubleBuffered = true;
            if (img_all != null)
            {
                Rectangle rectDest1 = new Rectangle(myX, myY, img3Clone.Width, img3Clone.Height);
                e.Graphics.DrawImage(img3Clone, rectDest1);
            }
            

            

            int r;
            if (rand_true == 1)
            {
                r = rnd.Next(0, 3);
                d[d_size] = r;
                while (true)
                {
                    if (d_size > 0)
                    {
                        if (d[d_size] == d[d_size - 1])
                        {
                            r = rnd.Next(0, 3);
                            d[d_size] = r;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
                d_size++;
                rand_true = 0;
                if ((imgs1[r].Width != 500) || (imgs1[r].Height != 400))
                {
                    img = new Bitmap(imgs1[r], 500, 400);

                    ClientSize = new Size(500, 500);
                }

                backImageClone();
                Invalidate(); // 要求重畫
               

            }
            DoubleBuffered = true;
            if (img != null)
            {
                Rectangle rectDest1 = new Rectangle(0, 0, imgClone.Width, imgClone.Height);
                e.Graphics.DrawImage(imgClone, rectDest1);
            }

            //e.Graphics.FillEllipse(b1, X, Y, 10, 10);
            int rand;
            if (m_size < 4)
            {
                rand = rnd.Next(0, 3);
                m[m_size] = rand;
                m_size++;
                rand_true = 0;
                if ((imgs2[rand].Width != 50) || (imgs2[rand].Height != 50))
                {
                    img3 = new Bitmap(imgs2[rand], 50, 50);

                    //ClientSize = new Size(500, 500);
                }

                ImageClone();
                Invalidate(); // 要求重畫


            }
            DoubleBuffered = true;
            if (img3 != null)
            {
                Rectangle rectDest2 = new Rectangle(0, Y, img2Clone.Width, img2Clone.Height);
                e.Graphics.DrawImage(img2Clone, rectDest2);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
            if ((Y + 50) > 399 )
            {
                int p = 0;
                p = myX + 50;
                if (myX >= X || p <= X)
                {
                    m_size--;

                }
                else
                {
                    win++;
                    label5.Text = win.ToString();
                }
            }
         
            Y += stepY;
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
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

        public Form1()
        {
            InitializeComponent();
        }
        void backImageClone()
        {
            imgClone = (Bitmap)img.Clone();
            int x, y;
            // 重設 img 的 圖素
            for (x = 0; x < imgClone.Width; x++)
            {
                for (y = 0; y < imgClone.Height; y++)
                {
                    Color pixelColor = imgClone.GetPixel(x, y); // 得到圖素
                    Color newColor = pixelColor;
                    newColor = Color.FromArgb(pixelColor.A * 2 / 10, pixelColor.R, pixelColor.G, pixelColor.B);
                    imgClone.SetPixel(x, y, newColor); // 設定圖素
                }
            }
        }
        void ImageClone()
        {
            img2Clone = (Bitmap)img3.Clone();
            int x, y;
            // 重設 img 的 圖素
            for (x = 0; x < img2Clone.Width; x++)
            {
                for (y = 0; y < img2Clone.Height; y++)
                {
                    Color pixelColor = img2Clone.GetPixel(x, y); // 得到圖素
                    Color newColor = pixelColor;
                    newColor = Color.FromArgb(pixelColor.A  , pixelColor.R, pixelColor.G, pixelColor.B);
                    img2Clone.SetPixel(x, y, newColor); // 設定圖素
                }
            }
        }
        void ImageClone_2()
        {
            img3Clone = (Bitmap)img_all.Clone();
            int x, y;
            // 重設 img 的 圖素
            for (x = 0; x < img3Clone.Width; x++)
            {
                for (y = 0; y < img3Clone.Height; y++)
                {
                    Color pixelColor = img3Clone.GetPixel(x, y); // 得到圖素
                    Color newColor = pixelColor;
                    newColor = Color.FromArgb(pixelColor.A, pixelColor.R, pixelColor.G, pixelColor.B);
                    img3Clone.SetPixel(x, y, newColor); // 設定圖素
                }
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
