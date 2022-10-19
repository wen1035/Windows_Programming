using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging; // ColorMatrix


namespace _1093305_12_1
{
    public partial class Form1 : Form
    {
        int w, h, x0, y0, pen_width = 1;
        Bitmap img1, img2, BackupImg, BackupImg2;
        Pen p;
        Brush p1;
        int tools = 0, tools_2 = 1,ok=0;
        Color c = Color.Black;
        Color c2 = Color.Black;
        Image img; //  影像
        //Image img2;  // 透明的影像
        Point MousePos;
        float r1, g1, b1, a1;


        public Bitmap ConvertCM(Image image, ColorMatrix cm)
        {
            Bitmap dest = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(dest); // 從點陣圖 建立 新的畫布
            // cm 定義含有 RGBA 空間座標的 5 x 5 矩陣
            // (R, G, B, A, 1) 乘上 此矩陣
            // ImageAttributes 類別的多個方法會使用色彩矩陣來調整影像色彩
            ImageAttributes ia = new ImageAttributes();
            // 設定預設分類的色彩調整矩陣。
            ia.SetColorMatrix(cm);
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);
            g.Dispose(); //清掉畫布與點陣圖變數的連結

            BackupImg = (Bitmap)pictureBox1.Image.Clone();
            toolStripMenuItem26.Enabled = true;

            return dest;
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  // 開啟影像檔
            {
                String input = openFileDialog1.FileName;
                img1 = (Bitmap)Image.FromFile(input); // 產生一個Image物件
                w = img1.Width;
                h = img1.Height;
                if ((ClientSize.Width < w) || (ClientSize.Height < h))
                    ClientSize = new Size(w, h + 56);
                pictureBox1.Image = img1;
                pictureBox1.Refresh(); // 要求重畫
                
                toolStripStatusLabel1.Text = "Width: " + w.ToString() + ", Height: " + h.ToString();
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                {
                    toolStripStatusLabel2.Text = e.Location.ToString();
                }
                else
                {
                    toolStripStatusLabel2.Text = "{,}";
                }
                if (e.Button == MouseButtons.Left)
                {
                    if (tools == 0)
                    {
                        Graphics g = Graphics.FromImage(pictureBox1.Image);
                        //Method 1: 直接改pictureBox1的圖
                        if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                        {
                            g.DrawLine(p, x0, y0, e.X, e.Y);
                            x0 = e.X;
                            y0 = e.Y;
                            pictureBox1.Refresh();
                        }
                    }
                    
                    if (tools == 1)
                    {
                        if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                        {
                            Bitmap tempImg = (Bitmap)img2.Clone();
                            //Method 2: 複製一份點陣圖，最後再放回pictureBox1
                            Graphics gg = Graphics.FromImage(tempImg);
                            gg.DrawLine(p, x0, y0, e.X, e.Y);
                            pictureBox1.Image = tempImg;
                            pictureBox1.Refresh();
                        }
                    }
                    if (tools == 2)
                    {
                        
                        if(tools_2 == 0)
                        {
                           
                            if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                            {
                                Bitmap tempImg = (Bitmap)img2.Clone();
                                //Method 2: 複製一份點陣圖，最後再放回pictureBox1
                                Graphics gg = Graphics.FromImage(tempImg);
                                gg.FillRectangle(p1, x0 , y0 , e.X - x0, e.Y - y0);
                                gg.DrawRectangle(p, x0, y0, e.X - x0, e.Y - y0);
                                Rectangle rect;
                                rect = new Rectangle(x0, y0, e.X - x0, e.Y - y0);
                                


                                /*if (ok == 1)
                                {
                                    gg.FillRectangle(p1, rect);
                                    ok = 0;
                                }*/
                                pictureBox1.Image = tempImg;
                                pictureBox1.Refresh();
                            }
                        }
                        if(tools_2 == 1)
                        {
                            if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                            {
                                Bitmap tempImg = (Bitmap)img2.Clone();
                                //Method 2: 複製一份點陣圖，最後再放回pictureBox1
                                Graphics gg = Graphics.FromImage(tempImg);
                                gg.DrawRectangle(p, x0, y0, e.X - x0, e.Y - y0);
                                pictureBox1.Image = tempImg;
                                pictureBox1.Refresh();
                            }
                        }
                       
                    }
                    if (tools == 3)
                    {

                        if (tools_2 == 0)
                        {

                            if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                            {
                                Bitmap tempImg = (Bitmap)img2.Clone();
                                //Method 2: 複製一份點陣圖，最後再放回pictureBox1
                                Graphics gg = Graphics.FromImage(tempImg);
                                gg.FillEllipse(p1, x0, y0, e.X - x0, e.Y - y0);
                                gg.DrawEllipse(p, x0, y0, e.X - x0, e.Y - y0);
                                Rectangle rect;
                                rect = new Rectangle(x0, y0, e.X - x0, e.Y - y0);



                                /*if (ok == 1)
                                {
                                    gg.FillRectangle(p1, rect);
                                    ok = 0;
                                }*/
                                pictureBox1.Image = tempImg;
                                pictureBox1.Refresh();
                            }
                        }
                        if (tools_2 == 1)
                        {
                            if ((e.X < w) && (e.Y < h) && (e.X > 0) && (e.Y > 0))
                            {
                                Bitmap tempImg = (Bitmap)img2.Clone();
                                //Method 2: 複製一份點陣圖，最後再放回pictureBox1
                                Graphics gg = Graphics.FromImage(tempImg);
                                gg.DrawEllipse(p, x0, y0, e.X - x0, e.Y - y0);
                                pictureBox1.Image = tempImg;
                                pictureBox1.Refresh();
                            }
                        }

                    }
                }
            }


        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                ColorMatrix cm = new ColorMatrix(
                       new float[][]{ new float[]{0.33f, 0.33f, 0.33f, 0, 0},
                                  new float[]{0.33f, 0.33f, 0.33f, 0, 0},
                                  new float[]{0.33f, 0.33f, 0.33f, 0, 0},
                                  new float[]{  0,    0,    0,  1, 0},
                                  new float[]{  0,    0,    0,  0, 1}});
                pictureBox1.Image = ConvertCM(pictureBox1.Image, cm);
            }

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                ColorMatrix cm = new ColorMatrix(
                   new float[][]{ new float[]{ -1f,    0,    0,  0, 0},
                                  new float[]{  0,   -1f,    0,  0, 0},
                                  new float[]{  0,    0,   -1f,  0, 0},
                                  new float[]{  0,    0,    0,  1, 0},
                                  new float[]{  1,    1,    1,  0, 1}});
                pictureBox1.Image = ConvertCM(pictureBox1.Image, cm);
            }

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                ColorMatrix cm = new ColorMatrix(
                   new float[][]{ new float[]{  1.1f,    0,    0,  0, 0},
                                  new float[]{  0,    1.1f,    0,  0, 0},
                                  new float[]{  0,    0,    1.1f,  0, 0},
                                  new float[]{  0,    0,    0,  1, 0},
                                  new float[]{  0,    0,    0,  0, 1}});
                pictureBox1.Image = ConvertCM(pictureBox1.Image, cm);
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                ColorMatrix cm = new ColorMatrix(
                   new float[][]{ new float[]{  0.9f,    0,    0,  0, 0},
                                  new float[]{  0,    0.9f,    0,  0, 0},
                                  new float[]{  0,    0,    0.9f,  0, 0},
                                  new float[]{  0,    0,    0,  1, 0},
                                  new float[]{  0,    0,    0,  0, 1}});
                pictureBox1.Image = ConvertCM(pictureBox1.Image, cm);
            }

        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c = colorDialog1.Color;
                p = new Pen(c, pen_width);
                toolStripStatusLabel3.Text = c.ToString();
            }

        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            toolStripMenuItem15.Checked = true;
            toolStripMenuItem16.Checked = false;
            toolStripMenuItem29.Checked = false;
            toolStripMenuItem30.Checked = false;
            tools = 0;

        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            toolStripMenuItem15.Checked = false;
            toolStripMenuItem16.Checked = true;
            toolStripMenuItem29.Checked = false;
            toolStripMenuItem30.Checked = false;
            tools = 1;

        }
        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            toolStripMenuItem15.Checked = false;
            toolStripMenuItem16.Checked = false;
            toolStripMenuItem29.Checked = true;
            toolStripMenuItem30.Checked = false;
            tools = 2;
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            toolStripMenuItem15.Checked = false;
            toolStripMenuItem16.Checked = false;
            toolStripMenuItem29.Checked = false;
            toolStripMenuItem30.Checked = true;
            tools = 3;
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            pen_width = 1;
            toolStripMenuItem20.Checked = true;
            toolStripMenuItem22.Checked = false;
            toolStripMenuItem23.Checked = false;
            toolStripMenuItem24.Checked = false;
            toolStripMenuItem25.Checked = false;
            p = new Pen(c, pen_width);

        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            pen_width = 2;
            toolStripMenuItem20.Checked = false;
            toolStripMenuItem22.Checked = true;
            toolStripMenuItem23.Checked = false;
            toolStripMenuItem24.Checked = false;
            toolStripMenuItem25.Checked = false;
            p = new Pen(c, pen_width);
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            pen_width = 3;
            toolStripMenuItem20.Checked = false;
            toolStripMenuItem22.Checked = false;
            toolStripMenuItem23.Checked = true;
            toolStripMenuItem24.Checked = false;
            toolStripMenuItem25.Checked = false;
            p = new Pen(c, pen_width);
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            pen_width = 4;
            toolStripMenuItem20.Checked = false;
            toolStripMenuItem22.Checked = false;
            toolStripMenuItem23.Checked = false;
            toolStripMenuItem24.Checked = true;
            toolStripMenuItem25.Checked = false;
            p = new Pen(c, pen_width);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            toolStripMenuItem26.Enabled = true;
            ok = 1;
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c2 = colorDialog1.Color;
                 p1 = new SolidBrush(c2);
                //p1 = new Pen(c, pen_width);
                
                toolStripStatusLabel5.Text = "Brush:";
                toolStripStatusLabel6.Text = c2.ToString();
            }
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            toolStripMenuItem33.Checked = true;
            toolStripMenuItem34.Checked = false;
            tools_2 = 0;
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            toolStripMenuItem33.Checked = false;
            toolStripMenuItem34.Checked = true;
            tools_2 = 1;
        }

       


        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            toolStripMenuItem26.Enabled = false;
            toolStripMenuItem27.Enabled = true;
            BackupImg2 = (Bitmap)pictureBox1.Image;
            pictureBox1.Image = BackupImg;
            pictureBox1.Refresh();

        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            toolStripMenuItem26.Enabled = true;
            toolStripMenuItem27.Enabled = false;
            pictureBox1.Image = BackupImg2;
            pictureBox1.Refresh();

        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            Form3 x = new Form3();
            x.TopMost = true;  //移到最上層
            x.Text = "調整畫布的顏色"; //Form3 的標題
            x.ShowDialog();    // Show Form3

            if (pictureBox1.Image != null)
            {
                //Graphics g = Graphics.FromImage(pictureBox1.Image);
                //Graphics g = Graphics.FromImage(pictureBox1.Image);
                //Graphics g = pictureBox1.CreateGraphics();
                r1 = x.getR();
                g1 = x.getG();
                b1 = x.getB();
                a1 = x.getA();
                // 色彩調整矩陣
                float[][] cmArray1 =
               {
                  new float[] {r1, 0, 0, 0,    0},
                  new float[] {0, g1, 0, 0,    0},
                  new float[] {0, 0, b1, 0,    0},
                  new float[] {0, 0, 0, a1,    0},
                  new float[] {0, 0, 0, 0,     1}
               };
                ColorMatrix cm1 = new ColorMatrix(cmArray1);
                ImageAttributes ia1 = new ImageAttributes();
                ia1.SetColorMatrix(cm1, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                // 繪出透明的背景影像
                Rectangle rectDest = new Rectangle(0, 0, img1.Width, img1.Height);
                Bitmap img = new Bitmap(img1.Width, img1.Height);
                Graphics flagGraphics = Graphics.FromImage(img);
                flagGraphics.DrawImage(img1,rectDest,0, 0, img1.Width, img1.Height,GraphicsUnit.Pixel, ia1);
                pictureBox1.Image = img;
                pictureBox1.Refresh(); // 要求重畫
            }
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            pen_width = 5;
            toolStripMenuItem20.Checked = false;
            toolStripMenuItem22.Checked = false;
            toolStripMenuItem23.Checked = false;
            toolStripMenuItem24.Checked = false;
            toolStripMenuItem25.Checked = true;
            p = new Pen(c, pen_width);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                x0 = e.X;
                y0 = e.Y;
                img2 = (Bitmap)pictureBox1.Image.Clone();
                BackupImg = (Bitmap)pictureBox1.Image.Clone();
               
            }
           

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            BackupImg = (Bitmap)pictureBox1.Image.Clone();
            toolStripMenuItem26.Enabled = true;

            w = pictureBox1.Image.Width;
            h = pictureBox1.Image.Height;
            img1 = (Bitmap)pictureBox1.Image;
            Bitmap p = new Bitmap(w / 2, h / 2);
            for (int i = 0; i < w && (i + 2 < w); i += 2)
            {
                for (int j = 0; j < h && (j + 2 < h); j += 2)
                {
                    Color c = img1.GetPixel(i, j);
                    int i2 = i / 2;
                    int j2 = j / 2;
                    p.SetPixel(i2, j2, c);
                }
            }
            pictureBox1.Image = p;
            img1 = p;
            w = p.Width;
            h = p.Height;
            pictureBox1.Refresh();
            toolStripStatusLabel1.Text = "Width: " + w.ToString() + ", Height: " + h.ToString();

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            BackupImg = (Bitmap)pictureBox1.Image.Clone();
            toolStripMenuItem26.Enabled = true;
            w = pictureBox1.Image.Width;
            h = pictureBox1.Image.Height;
            Bitmap p = new Bitmap(w * 2, h * 2);
            img1 = (Bitmap)pictureBox1.Image;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color c = img1.GetPixel(i, j);
                    for (int ii = 0; ii < 2; ii++)
                        for (int jj = 0; jj < 2; jj++)
                            p.SetPixel(i * 2 + ii, j * 2 + jj, c); //垂直與水平方向都重複畫兩遍
                }
            }
            pictureBox1.Image = p;
            img1 = p;
            w = p.Width;
            h = p.Height;
            pictureBox1.Refresh();
            toolStripStatusLabel1.Text = "Width: " + w.ToString() + ", Height: " + h.ToString();
            if ((ClientSize.Width < w) || (ClientSize.Height < (h + 56)))
                ClientSize = new Size(w, h + 56);

        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Form2 x = new Form2();
            x.TopMost = true;  //移到最上層
            x.Text = "設定畫布的寬與高"; //Form2 的標題
            x.ShowDialog();    // Show Form2
            w = x.getWidth();
            h = x.getHeight();
            if (w != -1)
            {
                img1 = new Bitmap(w, h);
                pictureBox1.Image = img1;
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                g.Clear(Color.White);
                pictureBox1.Refresh(); // 要求重畫
                if ((ClientSize.Width < w) || (ClientSize.Height < (h + 56)))
                    ClientSize = new Size(w, h + 56);
                toolStripStatusLabel1.Text = "Width: " + w.ToString() + ", Height: " + h.ToString();
            }

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String output = saveFileDialog1.FileName;
                    pictureBox1.Image.Save(output);
                    img1 = (Bitmap)pictureBox1.Image;
                }

        }


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            p = new Pen(c, pen_width);
            toolStripStatusLabel1.Text = "Width: " + w.ToString() + ", Height: " + h.ToString();
            toolStripStatusLabel3.Text = c.ToString();
            toolStripMenuItem26.Enabled = false;
            toolStripMenuItem27.Enabled = false;


        }
    }
}
