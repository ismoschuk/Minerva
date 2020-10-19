using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        int h;
        int w;
        string ruta;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ABRIR IMÁGEN
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ruta = ofd.FileName;
                pictureBox1.Image = Image.FromFile(ruta);



            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // GRAYSCALE
            label1.Text = "uwu";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // GUARDAR
            if (fb.ShowDialog() == DialogResult.OK)
            {
                string sv = fb.SelectedPath;
                //label1.Text = sv + "/gscale.png";
                bmp.Save(sv + "/smartCrop2.png");
                //bmp.Save(sv + "/sovel.png");
                //bmp.Save(sv + "/shade.png");
                //bmp.Save(sv + "/gscale.png");
            }
        }

    public int truncate(int rgb)
        {
            rgb = (rgb > 255) ? 255 : rgb;
            rgb = (rgb < 0) ? 0 : rgb;
            return rgb;
        }

        public int truncateS(int rgb)
        {
            //rgb = (rgb > 780) ? 0 : rgb;
            rgb = (rgb > 255) ? 255 : rgb;
            rgb = (rgb < 0) ? 0 : rgb;
            return rgb;
        }
        public Bitmap grayscale(string ruta)
        {
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    int pr = ((c.R + c.G + c.B) / 3);

                    gs.SetPixel(x, y, Color.FromArgb(c.A, pr, pr, pr));
                }
            }

            return gs;
        }



        public Bitmap badPrinter(string ruta)
        {
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    int pr = c.R + c.G + c.B;

                    pr = pr < 450 ? 0:255;
                    gs.SetPixel(x, y, Color.FromArgb(c.A, pr, pr, pr));
                }
            }

            return gs;
        }
        public Bitmap grayscaleShades(string ruta)
        {
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            int r = 255 / (8 - 1);
            Color c;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    int pr = ((c.R + c.G + c.B) / 3);

                    pr = (pr / r) * r;
                    gs.SetPixel(x, y, Color.FromArgb(c.A, pr, pr, pr));
                }
            }

            return gs;
        }

        public Bitmap edgeDetect(string ruta)
        {
            Bitmap s;
            Bitmap crop;
            Bitmap og;
            int chkV2, chkV1, chkH2, chkH1, ch, cv, nc;
            s = new Bitmap(ruta);
            crop = new Bitmap(ruta);
            og = grayscale(ruta);
            List<int> sov = new List<int>();

            //int[] sovH = new int[] { 0, 5, -3, -3, 5, -3, -3, 5, -3 };
            //int[] sovV = new int[] { 0, -3, -3, 5, 5, 5, -3, -3, -3 };

            int[] sovV = new int[] { 1, 0, -1, 2, 0, -2, 1, 0, -1 };
            int[] sovH = new int[] { 1, 2, 1, 0, 0, 0, -1, -2, -1 };

            //este queda piola
            //int[] sovV = new int[] { 0, -1, 0, -1, 4, -1, 0,-1 , 0 };
            //int[] sovH = new int[] { 0, -1, 0, -1, 4, -1, 0, -1, 0 };

            //int[] sovV = new int[] { -1, -1, -1, -1, 8, -1, -1, -1, -1 };
            //int[] sovH = new int[] { -1, -1, -1, -1, 8, -1, -1, -1, -1 };


            h = s.Height;
            w = s.Width;
            cv = 0;
            ch = 0;
            Color c;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = s.GetPixel(x, y);

                    chkV2 = (y < (h - 3)) ? 1 : 0;
                    chkV1 = (y < (h - 2)) ? 1 : 0;
                    chkH2 = (x < (w - 3)) ? 1 : 0;
                    chkH1 = (x < (w - 2)) ? 1 : 0;
                    sov.Add((og.GetPixel(x, y + 2 * chkV2)).R);
                    sov.Add((og.GetPixel(x + 1 * chkH1, y + 2 * chkV2)).R);
                    sov.Add((og.GetPixel(x + 2 * chkH2, y + 2 * chkV2)).R);
                    sov.Add((og.GetPixel(x, y + 1 * chkV1)).R);
                    sov.Add((og.GetPixel(x + 1 * chkH1, y + 1 * chkV1)).R);
                    sov.Add((og.GetPixel(x + 2 * chkH2, y + 1 * chkV1)).R);
                    sov.Add((og.GetPixel(x, y)).R);
                    sov.Add((og.GetPixel(x + 1 * chkH1, y)).R);
                    sov.Add((og.GetPixel(x + 2 * chkH2, y)).R);

                    for (int l = 0; l < 9; l++)
                    {
                        cv = cv + sov[l] * sovV[l];
                        ch = ch + sov[l] * sovH[l];
                    }

                    nc = Convert.ToInt32(Math.Pow(cv, 2) + Math.Pow(ch, 2));
                    nc = Convert.ToInt32(Math.Sqrt(nc));

                    //textBox1.Text = textBox1.Text + " - " + nc;
                    nc = truncate(nc);

                    s.SetPixel(x, y, Color.FromArgb(c.A, nc, nc, nc));

                    sov.Clear();
                    cv = 0;
                    ch = 0;
                }
            }

            return s;
        }
        public Bitmap smartCrop(string ruta)
        {
            Bitmap s;
            Bitmap crop;
            crop = new Bitmap(ruta);

            s = areaDetect(ruta);

            int limL, limR;
            Color c, c2;

            limL = w / 2 + w % 2;
            limR = w / 2;
            
            for (int y = 0; y < h; y++)
            {
                
                for (int x = 0; x < limL; x++)
                {
                    c = s.GetPixel(x, y);
                    c2 = crop.GetPixel(x, y);

                    if (c.G != 255)
                    {
                        crop.SetPixel(x, y, Color.FromArgb(0, 255, 255, 255));

                    }
                    else
                    {
                        break;
                    }
                }
                for (int x = w - 1; x > limR; x--)
                {
                    c2 = crop.GetPixel(x, y);
                    c = s.GetPixel(x, y);
                    if (c.G != 255)
                    {
                        crop.SetPixel(x, y, Color.FromArgb(0, 255, 255, 255));

                    }
                    else
                    {
                        break;

                    }
                }
            }
            
            limL = h / 2 + h % 2;
            limR = h / 2;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < limL; y++)
                {
                    c = s.GetPixel(x, y);

                    if (c.G != 255)
                    {
                        crop.SetPixel(x, y, Color.FromArgb(0, 255, 255, 255));

                    }
                    else
                    {
                        break;
                    }
                }
                for (int y = h - 1; y > limR; y--)
                {
                    c = s.GetPixel(x, y);
                    if (c.G != 255)
                    {
                        crop.SetPixel(x, y, Color.FromArgb(0, 255, 255, 255));

                    }
                    else
                    {
                        break;

                    }
                }
            }

            return crop;
            //return s;
        }


        public Bitmap blur(string ruta)
        {
            Bitmap s;
            Bitmap crop;
            Bitmap og;
            int chkV2, chkV1, chkH2, chkH1, ch, cv, nc;
            s = new Bitmap(ruta);
            crop = new Bitmap(ruta);
            og = grayscaleShades(ruta);
            List<int> sov = new List<int>();
            int[] box = new int[] { 1, 2, 1, 2, 4, 2, 1, 2, 1 };

            h = s.Height;
            w = s.Width;
            cv = 0;
            ch = 0;
            Color c;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = s.GetPixel(x, y);

                    chkV2 = (y < (h - 3)) ? 1 : 0;
                    chkV1 = (y < (h - 2)) ? 1 : 0;
                    chkH2 = (x < (w - 3)) ? 1 : 0;
                    chkH1 = (x < (w - 2)) ? 1 : 0;
                    sov.Add((og.GetPixel(x, y + 2 * chkV2)).R);
                    sov.Add((og.GetPixel(x + 1 * chkH1, y + 2 * chkV2)).R);
                    sov.Add((og.GetPixel(x + 2 * chkH2, y + 2 * chkV2)).R);
                    sov.Add((og.GetPixel(x, y + 1 * chkV1)).R);
                    sov.Add((og.GetPixel(x + 1 * chkH1, y + 1 * chkV1)).R);
                    sov.Add((og.GetPixel(x + 2 * chkH2, y + 1 * chkV1)).R);
                    sov.Add((og.GetPixel(x, y)).R);
                    sov.Add((og.GetPixel(x + 1 * chkH1, y)).R);
                    sov.Add((og.GetPixel(x + 2 * chkH2, y)).R);

                    for (int l = 0; l < 9; l++)
                    {
                        cv = cv + sov[l] * box[l];
                    }

                    nc = cv / 9;

                    nc = truncate(nc);

                    s.SetPixel(x, y, Color.FromArgb(c.A, nc, nc, nc));

                    sov.Clear();
                    cv = 0;
                    ch = 0;
                }
            }
            return s;
        }


        public Bitmap areaDetect(string ruta)
        {
            Bitmap s;
            Bitmap og;
            int chkV2, chkV1, chkH2, chkH1, ch, cv, nc;
            s = new Bitmap(ruta);
            og = badPrinter(ruta);
            //og = grayscale(ruta);

            Color c;


            List<int> sov = new List<int>();

            // int[] sovV = new int[] { 1, 0, -1, 1, 0, -1, 1, 0, -1 };
            // int[] sovH = new int[] { 1, 1, 1, 0, 0, 0, -1, -1, -1 };


            //int[] sovH = new int[] { 0, 10, -6, -6, 10, -6, -6, 10, -6 };
            //int[] sovV = new int[] { 0, -6, -6, 10, 10, 10, -6, -6, -6 };


            //int[] sovH = new int[] { 0, 5, -3, -3, 5, -3, -3, 5 , -3 };
            //int[] sovV = new int[] { 0, -3, -3, 5, 5, 5, - 3, -3, -3 };
            //este queda piola
            //int[] sovV = new int[] { 0, -1, 0, -1, 4, -1, 0,-1 , 0 };
            //int[] sovH = new int[] { 0, -1, 0, -1, 4, -1, 0, -1, 0 };

            //int[] sovV = new int[] { -1, -1, -1, -1, 8, -1, -1, -1, -1 };
            //int[] sovH = new int[] { -1, -1, -1, -1, 8, -1, -1, -1, -1 };


            int[] sovV = new int[] { 1, 0, -1, 2, 0, -2, 1, 0, -1 };
            int[] sovH = new int[] { 1, 2, 1, 0, 0, 0, -1, -2, -1 };

            h = s.Height;
            w = s.Width;
            cv = 0;
            ch = 0;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = s.GetPixel(x, y);

                    chkV2 = (y < (h - 3)) ? 1 : 0;
                    chkV1 = (y < (h - 2)) ? 1 : 0;
                    chkH2 = (x < (w - 3)) ? 1 : 0;
                    chkH1 = (x < (w - 2)) ? 1 : 0;
                    sov.Add((og.GetPixel(x, y + 2 * chkV2)).R);
                    sov.Add((og.GetPixel(x + 1 * chkH1, y + 2 * chkV2)).R);
                    sov.Add((og.GetPixel(x + 2 * chkH2, y + 2 * chkV2)).R);
                    sov.Add((og.GetPixel(x, y + 1 * chkV1)).R);
                    sov.Add((og.GetPixel(x + 1 * chkH1, y + 1 * chkV1)).R);
                    sov.Add((og.GetPixel(x + 2 * chkH2, y + 1 * chkV1)).R);
                    sov.Add((og.GetPixel(x, y)).R);
                    sov.Add((og.GetPixel(x + 1 * chkH1, y)).R);
                    sov.Add((og.GetPixel(x + 2 * chkH2, y)).R);

                    for (int l = 0; l < 9; l++)
                    {
                        cv = cv + sov[l] * sovV[l];
                        ch = ch + sov[l] * sovH[l];
                    }

                    nc = Convert.ToInt32(Math.Pow(cv, 2) + Math.Pow(ch, 2));
                    nc = Convert.ToInt32(Math.Sqrt(nc));

                    nc = truncate(nc);

                    s.SetPixel(x, y, Color.FromArgb(c.A, nc, nc, nc));

                    sov.Clear();
                    cv = 0;
                    ch = 0;
                }
            }

            return s;
        }

        public Bitmap testin(string ruta)
        {
            Bitmap s = areaDetect(ruta);
            Bitmap crop = new Bitmap(s);
            int limL, limR, chck;
            limL = h / 8;
            limR = w / 8;
            Color c;
            // List<int> yV = new List<int>();
            //List<int> xV = new List<int>();
            int threshold = 255;

            for (int y = 0; y < h; y++)
            {
                chck = 0;
                for (int x = 0; x < w; x++)
                {
                    c = s.GetPixel(x, y);
                    for (int w = y; w < (y + limL); w++)
                    {
                        for (int z = x; z < (x + limR); z++)
                        {
                            chck = +c.R;
                        }
                    }
                    if (chck >= threshold)
                    {
                        crop.SetPixel(x, y, Color.FromArgb(c.A, 0, 255, 0));
                    }
                    else
                    {
                        crop.SetPixel(x, y, c);
                    }
                }
            }
            return crop;
        }
        public Bitmap grayscaleColor(string ruta)
        {
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c, c2, cf;
            int rango = 75;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    int pr = (c.R + c.G + c.B) / 3;
                    c2 = Color.FromArgb(c.A, pr, pr, pr);

                    cf = (c.R < rango) & (c.G < rango) & (c.B > rango) ? c : c2;
                    gs.SetPixel(x, y, cf);
                }
            }

            return gs;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            bmp = grayscale(ruta);
            //bmp = alpha(ruta);

            pictureBox2.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bmp = grayscaleShades(ruta);
            pictureBox2.Image = bmp;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            bmp = edgeDetect(ruta);
            pictureBox2.Image = bmp;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            bmp = smartCrop(ruta);
            pictureBox2.Image = bmp;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            bmp = badPrinter(ruta);
            pictureBox2.Image = bmp;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            bmp = blur(ruta);
            pictureBox2.Image = bmp;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bmp = areaDetect(ruta);
            pictureBox2.Image = bmp;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            bmp = testin(ruta);
            pictureBox2.Image = bmp;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            bmp = grayscaleColor(ruta);
            pictureBox2.Image = bmp;

        }
    }

}

