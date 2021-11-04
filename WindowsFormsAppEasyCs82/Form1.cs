using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs82
{
    public partial class Form1 : Form
    {
        private Bitmap bmp1, bmp2;
        private int i;
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "画像あれこれいじるで！";
            this.Width = 400;
            this.Height = 300;

            bmp1 = new Bitmap("C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs82\\WindowsFormsAppEasyCs82\\img\\sunsymbol3.png");
            bmp2 = new Bitmap("C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs82\\WindowsFormsAppEasyCs82\\img\\sunsymbol3.png");

            i = 0;

            this.Click += new EventHandler(ClickForm);
            this.Paint += new PaintEventHandler(PaintBmp);
        }

        public void ConvertBmp()
        {
            for (int x = 0; x < bmp1.Width; x++)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    Color c = bmp1.GetPixel(x, y);
                    int rgb = c.ToArgb(); // Convert to RGB
                    int a = (rgb >> 24) & 0xFF; // Get RGB
                    int r = (rgb >> 16) & 0xFF;
                    int g = (rgb >> 8) & 0xFF;
                    int b = (rgb >> 0) & 0xFF;
                    switch (i)
                    {
                        case 1: r >>= 2; break; // Remove Red
                        case 2: g >>= 2; break; // Remove Green
                        case 3: b >>= 2; break; // Remove Blue
                    }
                    rgb = (a << 24) | (r << 16) | (g << 8) | (b << 0);
                    c = Color.FromArgb(rgb);
                    bmp2.SetPixel(x, y, c);
                }
            }
        }

        public void ClickForm(Object sender, EventArgs e)
        {
            i++;
            if (i >= 4)
            {
                i = 0;
            }
            ConvertBmp();
            this.Invalidate();
        }

        public void PaintBmp(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bmp2, 0, 0, bmp2.Width, bmp2.Height);
        }
    }
}