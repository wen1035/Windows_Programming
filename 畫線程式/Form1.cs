using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;    //DashStyle



namespace _1093305_5_6
{
    public partial class Form1 : Form
    {
        //File
        List<Point> startPt = new List<Point>();
        List<Point> endPt = new List<Point>();
       
        Point p1;

        //Color
        Color c = Color.Red;
        List<Color> colorlist = new List<Color>();

        //Style
        List<int> W_list = new List<int>();
        List<bool> S_list = new List<bool>();
        int lineWidth = 1;
        bool lineSolid = true;
       

        public Form1()
        {
            InitializeComponent();
        }

        //File----------------------------------------------------------------------------------------
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            startPt.Add(p1);
            endPt.Add(e.Location);
            colorlist.Add(c);
            W_list.Add(lineWidth);
            S_list.Add(lineSolid);
            Invalidate();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           // Brush b1 = new SolidBrush(c);
            

            for (int i = 0; i < endPt.Count(); i++)
            {
                Pen pen1 = new Pen(colorlist[i], W_list[i]);
                if (S_list[i])
                    pen1.DashStyle = DashStyle.Solid;
                else
                    pen1.DashStyle = DashStyle.Dash;
                e.Graphics.DrawLine(pen1, startPt[i].X, startPt[i].Y, endPt[i].X, endPt[i].Y);
                
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "線段檔(*.pnt)|*.pnt";
            saveFileDialog1.Filter = "線段檔(*.pnt)|*.pnt";
            c = Color.Red;
            toolStripMenuItem6.Checked = true;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String s = saveFileDialog1.FileName;
                BinaryWriter outFile = new BinaryWriter(File.Open(s, FileMode.Create));
                outFile.Write(endPt.Count());
                for (int i = 0; i < endPt.Count(); i++)
                {
                    outFile.Write(startPt[i].X);
                    outFile.Write(startPt[i].Y);
                    outFile.Write(endPt[i].X);
                    outFile.Write(endPt[i].Y);
                }
                outFile.Close();
            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String s = openFileDialog1.FileName;
                if (!File.Exists(s)) return;
                BinaryReader inFile = new BinaryReader(File.Open(s, FileMode.Open));
                startPt.Clear();
                endPt.Clear();
                int n = inFile.ReadInt32();
                for (int i = 0; i < n; i++)
                {
                    startPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                    endPt.Add(new Point(inFile.ReadInt32(), inFile.ReadInt32()));
                }
                Invalidate();
                inFile.Close();
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            startPt.Clear();
            endPt.Clear();
            Invalidate();

        }

        //Color---------------------------------------------------------------------------------------
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            c = Color.Red;
            toolStripMenuItem6.Checked = true;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            c = Color.Green;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = true;
            toolStripMenuItem8.Checked = false;

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            c = Color.Blue;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = true;

        }

        //Style---------------------------------------------------------------------------------------
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            lineSolid = true;
            toolStripMenuItem10.Checked = true;
            toolStripMenuItem11.Checked = false;

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            lineSolid = false;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem11.Checked = true;
        }
        //Width---------------------------------------------------------------------------------------
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            lineWidth = 1;
            toolStripMenuItem13.Checked = true;
            toolStripMenuItem14.Checked = false;
            toolStripMenuItem15.Checked = false;
            toolStripMenuItem16.Checked = false;
            toolStripMenuItem17.Checked = false;
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            lineWidth = 2;
            toolStripMenuItem13.Checked = false;
            toolStripMenuItem14.Checked = true;
            toolStripMenuItem15.Checked = false;
            toolStripMenuItem16.Checked = false;
            toolStripMenuItem17.Checked = false;
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            lineWidth = 3;
            toolStripMenuItem13.Checked = false;
            toolStripMenuItem14.Checked = false;
            toolStripMenuItem15.Checked = true;
            toolStripMenuItem16.Checked = false;
            toolStripMenuItem17.Checked = false;
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            lineWidth = 4;
            toolStripMenuItem13.Checked = false;
            toolStripMenuItem14.Checked = false;
            toolStripMenuItem15.Checked = false;
            toolStripMenuItem16.Checked = true;
            toolStripMenuItem17.Checked = false;
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            lineWidth = 5;
            toolStripMenuItem13.Checked = false;
            toolStripMenuItem14.Checked = false;
            toolStripMenuItem15.Checked = false;
            toolStripMenuItem16.Checked = false;
            toolStripMenuItem17.Checked = true;
        }
    }
}
