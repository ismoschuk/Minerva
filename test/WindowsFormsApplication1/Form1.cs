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
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Boolean a = false;
        int h;
        int w;
        string ruta;
        ColorPalette main;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<System.Windows.Media.Color> myPalettecolor = new List<System.Windows.Media.Color>();
            // ABRIR IMÁGEN
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ruta = ofd.FileName;
                pictureBox1.Image = Image.FromFile(ruta);

                //label2.Text = myPalette.Entries[0].ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "uwu";
            Bitmap first = new Bitmap(ruta);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Gurdadno una foto
            sfd.FileName = "out";
            sfd.DefaultExt = "jpg";
            sfd.Filter = "JPG images (*.jpg)|*.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                var fileName = sfd.FileName;
                if (!System.IO.Path.HasExtension(fileName) || System.IO.Path.GetExtension(fileName) != "jpg")
                    fileName = fileName + ".jpg";

                bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

    public int truncate(int rgb)
        {
            rgb = (rgb > 255) ? 255 : rgb;
            rgb = (rgb < 0) ? 0 : rgb;
            return rgb;
        }

        public int truncateS(double pix)
        {
            //rgb = (rgb > 780) ? 0 : rgb;
            int rgb = Convert.ToInt32(Math.Floor(pix));
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
            Bitmap og;
            int chkV2, chkV1, chkH2, chkH1, ch, cv, nc, r, g, b;
            s = new Bitmap(ruta);
            og = new Bitmap(ruta);
            List<int> sov = new List<int>();
            int[] box = new int[] { 4, 2, 2, 2, 1, 1, 2, 1, 1 };
            //int[] box = new int[] { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
            //int[] box = new int[] { 21, 31, 21, 31, 48, 31, 21, 31, 21 };

            h = s.Height;
            w = s.Width;
            cv = 0;
            ch = 0;
            r = 0;
            g = 0;
            b = 0;
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
                    
                    r = r + ((og.GetPixel(x, y)).R) * box[0];
                    g = g + ((og.GetPixel(x, y)).G) * box[0];
                    b = b + ((og.GetPixel(x, y)).B) * box[0];
                    r = r + ((og.GetPixel(x + 1 * chkH1, y)).R) * box[1];
                    g = g + ((og.GetPixel(x + 1 * chkH1, y)).G) * box[1];
                    b = b + ((og.GetPixel(x + 1 * chkH1, y)).B) * box[1];
                    r = r + ((og.GetPixel(x + 2 * chkH2, y)).R) * box[2];
                    g = g + ((og.GetPixel(x + 2 * chkH2, y)).G) * box[2];
                    b = b + ((og.GetPixel(x + 2 * chkH2, y)).B) * box[2];
                    r = r + ((og.GetPixel(x, y + 1 * chkV1)).R) * box[3];
                    g = g + ((og.GetPixel(x, y + 1 * chkV1)).G) * box[3];
                    b = b + ((og.GetPixel(x, y + 1 * chkV1)).B) * box[3];
                    r = r + ((og.GetPixel(x + 1 * chkH1, y + 1 * chkV1)).R) * box[4];
                    g = g + ((og.GetPixel(x + 1 * chkH1, y + 1 * chkV1)).G) * box[4];
                    b = b + ((og.GetPixel(x + 1 * chkH1, y + 1 * chkV1)).B) * box[4];
                    r = r + ((og.GetPixel(x + 2 * chkH2, y + 1 * chkV1)).R) * box[5];
                    g = g + ((og.GetPixel(x + 2 * chkH2, y + 1 * chkV1)).G) * box[5];
                    b = b + ((og.GetPixel(x + 2 * chkH2, y + 1 * chkV1)).B) * box[5];
                    r = r + ((og.GetPixel(x, y + 2 * chkV2)).R) * box[6];
                    g = g + ((og.GetPixel(x, y + 2 * chkV2)).G) * box[6];
                    b = b + ((og.GetPixel(x, y + 2 * chkV2)).B) * box[6];
                    r = r + ((og.GetPixel(x + 1 * chkH1, y + 2 * chkV2)).R) * box[7];
                    g = g + ((og.GetPixel(x + 1 * chkH1, y + 2 * chkV2)).G) * box[7];
                    b = b + ((og.GetPixel(x + 1 * chkH1, y + 2 * chkV2)).B) * box[7];
                    r = r + ((og.GetPixel(x + 2 * chkH2, y + 2 * chkV2)).R) * box[8];
                    g = g + ((og.GetPixel(x + 2 * chkH2, y + 2 * chkV2)).G) * box[8];
                    b = b + ((og.GetPixel(x + 2 * chkH2, y + 2 * chkV2)).B) * box[8];


                    r = truncate(r / 16);
                    g = truncate(g / 16);
                    b = truncate(b / 16);


                    s.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));

                    cv = 0;
                    ch = 0;
                    r = 0;
                    g = 0;
                    b = 0;
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

        public Bitmap onlyRGB(string ruta)
        {
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c, c2, cf;
            int rango = 150;
            int r, g, b;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    r = (c.R > rango) ? 250 : 0;
                    g = (c.G > rango) ? 250 : 0;
                    b = (c.B > rango) ? 250 : 0;

                    //cf = (c.R < rango) & (c.G < rango) & (c.B > rango) ? c : c2;
                    gs.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));
                }
            }

            return gs;
        }


        public Bitmap rainbowStripe(string ruta, int colors)
        {
            // rojo=1, verde=2, azul=3, magenta=4, cian=5, amarillo=6, naranja=7, violeta=8
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c;
            int rango = w / 7;
            int r, g, b;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    r = (x < rango * 3) ^ (x > rango * 6) ? c.R : 0;
                    g = (x > rango * 2) & (x < rango * 5) ? c.G : 0;
                    b = (x < rango) ^ (x > rango * 4) ? c.B : 0;

                    gs.SetPixel(x, y, Color.FromArgb(c.A, truncate(r), truncate(g), truncate(b)));
                }
            }

            return gs;
        }


        public Bitmap rainbow(string ruta, int colors)
        {
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c;
            float rango = (w / 9);
            double r, g, b, aux1, aux2,aux3, aux;
            aux = 1 / (rango );
            //float rango = (w / 12);
            //aux = 1 / (rango * 5);

            aux1 = 0;
            aux2 = 0;
            aux3 = 0;
            for (int y = 0; y < h; y++)
            {
                aux1 = 0;
                aux2 = 0;
                aux3 = 0;
                for (int x = 1; x < w; x++)
                {
                    c = gs.GetPixel(x, y);
                    // uso diferencia co punto máximo para determinar descenso y ascenso de los valores

                    aux1 = (x > 0) & (x <= rango * 2) ? aux1 + aux : (x >= rango * 2) & (x < rango * 6) ? aux1 - aux : 0;
                    r = (x > 0) & (x < rango * 6) ? c.R * (aux1) : 0;

                    aux2 = (x > rango * 2) & (x < rango * 5) ? aux2 + aux : (x >= rango * 5) & (x < rango * 8) ? aux2 - aux : 0;
                    g = (x > rango * 2) & (x < rango * 8) ? c.G * (aux2) : 0;

                    aux3 = (x > rango * 4) & (x < rango * 7) ? aux3 + aux : (x >= rango * 7) & (x < rango * 9) ? aux3 - aux : 0;
                    b = (x > rango * 4) & (x < rango * 9) ? c.B * (aux3) : 0;

                    gs.SetPixel(x, y, Color.FromArgb(c.A, truncateS(r) , truncateS(g), truncateS(b)));
                }
            }

            return gs;
        }


        


        public Bitmap colorCrop(string ruta, Color sel)
        {
            // Bitmap s = colorSimple(ruta);
            Bitmap crop = new Bitmap(ruta);
            Bitmap s = badPrinterBump(crop, 130);
            h = s.Height;
            w = s.Width;
            Color c,c2;
            // List<int> yV = new List<int>();
            //List<int> xV = new List<int>();
            int threshold = 25;
            int threshold1 = 60;
            int ch, chck;
            chck = 0;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    ch = (x < (w - threshold1)) ? (x + threshold1) : w;
                    for (int xx = x; xx < ch; xx++)
                    {
                        c = s.GetPixel(xx, y);
                        chck = (sel == c) ? chck + 1 : chck;
                    }

                    c2 = s.GetPixel(x, y);
                    if ((chck > 45) & (c2 == sel))
                    {
                        c2 = crop.GetPixel(x, y);
                        crop.SetPixel(x, y, c2);
                    }
                    else
                    {
                        crop.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));
                    }
                    chck = 0;
                }
            }
            return crop;
        }


        public Bitmap colorSimple(string ruta)
        {
            Bitmap s = new Bitmap(ruta);
            int r, g, b;
            h = s.Height;
            w = s.Width;
            Color c;
            // List<int> yV = new List<int>();
            //List<int> xV = new List<int>();
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = s.GetPixel(x, y);

                    r = (c.R > (c.B)) & (c.R > (c.G)) ? 255 : 0;
                    g = (c.G > (c.B)) & (c.G > (c.R)) ? 255 : 0;
                    b = (c.B > (c.R)) & (c.R > (c.G)) ? 255 : 0;

                    s.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));

                }
            }
            return s;
        }

        public Bitmap blurSize(string ruta, int sz)
        {
            Bitmap s;
            Bitmap og;
            int chkV2, chkV1, chkH2, nc, ch, cv, r, g, b;
            s = new Bitmap(ruta);
            og = new Bitmap(ruta);
            List<int> sov = new List<int>();
            int[] box = new int[] { 4, 2, 2, 2, 1, 1, 2, 1, 1 };
            //int[] box = new int[] { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
            //int[] box = new int[] { 21, 31, 21, 31, 48, 31, 21, 31, 21 };

            h = s.Height;
            w = s.Width;
            cv = 0;
            ch = 0;
            nc = 0;
            r = 0;
            g = 0;
            b = 0;
            Color c, c2;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = s.GetPixel(x, y);
                    ch = (x < (w - sz)) ? (x + sz) : w;
                    cv = (y < (h - sz)) ? (y + sz) : h; 
                    for (int yy = y; yy < cv; yy++)
                    {
                        for (int xx = x; xx < ch; xx++)
                        {
                            c2 = s.GetPixel(xx, yy);
                            r += c2.R;
                            g += c2.G;
                            b += c2.B;
                            nc++;
                        }
                    }

                    r = truncate(r / nc);
                    g = truncate(g / nc);
                    b = truncate(b / nc);


                    s.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));

                    nc = 0;
                    cv = 0;
                    ch = 0;
                    r = 0;
                    g = 0;
                    b = 0;
                }
            }
            return s;
        }

        public Bitmap badPrinterBump(Bitmap ruta, int rango)
        {
            // Usa solo blanco y negro puro dependiendo de la saturación
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

                    pr = (c.R < rango) ^ (c.G < rango) ^ (c.B < rango) ? 0 : 255;
                    gs.SetPixel(x, y, Color.FromArgb(c.A, pr, pr, pr));
                }
            }

            return gs;
        }

        public Bitmap colorEnhance(string ruta)
        {
            Bitmap s = new Bitmap(ruta);
            int r, g, b;
            h = s.Height;
            w = s.Width;
            Color c;
            // List<int> yV = new List<int>();
            //List<int> xV = new List<int>();
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = s.GetPixel(x, y);

                    //r = (c.R > (c.B)) & (c.R > (c.G)) ? 255 : c.R;
                    //g = (c.G > (c.B)) & (c.G > (c.R)) ? 255 : c.G;
                    //b = (c.B > (c.R)) & (c.R > (c.G)) ? 255 : c.B;

                    r = truncateS(c.R * 1.4);
                    g = /*/ (c.G > (c.B)) & (c.G > (c.R)) ? 255 :/*/  c.G;
                    b = /*/ (c.B > (c.R)) & (c.R > (c.G)) ? 255 :/*/ c.B;

                    s.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));

                }
            }
            return s;
        }

        public Bitmap sticker(string ruta, int posX, int posY, Bitmap st)
        {
            // Usa solo blanco y negro puro dependiendo de la saturación
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c;
            int alpha;

            for (int y = posY; y < (posX + 300); y++)
            {
                for (int x = posX; x < (posX + 300) ; x++)
                {
                    c = st.GetPixel(x - posX, y - posY);

                    // gs.SetPixel(x, y, Color.FromArgb(c.A, 0, 255, 0));
                    if (c.A > 0)
                    {
                        gs.SetPixel(x, y, Color.FromArgb(c.A, c.R, c.G, c.B));
                    }

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
            bmp = blurSize(ruta, 6);
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

        private void button13_Click(object sender, EventArgs e)
        {
            bmp = onlyRGB(ruta);
            pictureBox2.Image = bmp;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bmp = rainbowStripe(ruta, 10);
            pictureBox2.Image = bmp;
            label1.Text = ((222 * 20) / 100).ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bmp = rainbow(ruta, 10);
            pictureBox2.Image = bmp;
        }

        private void fb_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
                     
            if (a == false)
            {
                bmp = new Bitmap(ruta);
                a = true;
            }
            //espejar
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = bmp;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                bmp = new Bitmap(ruta);
                a = true;

            }
            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = bmp;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                bmp = new Bitmap(ruta);
                a = true;

            }
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = bmp;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                bmp = new Bitmap(ruta);
                a = true;
            }
            //espejar
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = bmp;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(255, 255, 255, 255);
            bmp = colorCrop(ruta, c);
            pictureBox2.Image = bmp;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            bmp = colorSimple(ruta);
            pictureBox2.Image = bmp;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            bmp = colorEnhance(ruta);
            pictureBox2.Image = bmp;
        }

        private void button23_Click(object sender, EventArgs e)
        {
             //Bitmap st = new Bitmap(WindowsFormsApplication1.Properties.Resources.eye);
            Bitmap st = new Bitmap(button23.BackgroundImage);
            st.MakeTransparent();
            bmp = sticker(ruta, 200, 200, st);
            pictureBox2.Image = bmp;
        }
    }

}

