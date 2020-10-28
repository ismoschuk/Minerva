using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mnrva
{
    class filtros
    {
        int h, w;


        //TRUNCATES
        public int truncate(int rgb)
        {
            rgb = (rgb > 255) ? 255 : rgb;
            rgb = (rgb < 0) ? 0 : rgb;
            return rgb;
        }

        public int truncateS(double pix)
        {
            int rgb = Convert.ToInt32(Math.Floor(pix));
            rgb = (rgb > 255) ? 255 : rgb;
            rgb = (rgb < 0) ? 0 : rgb;
            return rgb;
        }

        //GRAYSCALE FILTERS
        public Bitmap grayscale(Bitmap ruta)
        {
            // Filtro blanco y negro normal (escala de calores de grises)

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

        public Bitmap grayscaleShades(Bitmap ruta, int s)
        {
            // Filtro blanco y negro pero solo utiliza un número determinado de grises
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            int r = 255 / (s - 1);
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

        public Bitmap badPrinter(Bitmap ruta, int rango)
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

                    pr = (c.R < rango) ^ (c.G < rango) ^ (c.B < rango)  ? 0 : 255;
                    gs.SetPixel(x, y, Color.FromArgb(c.A, pr, pr, pr));
                }
            }

            return gs;
        }

        public Bitmap grayscaleColor(Bitmap ruta, string si, int rango)
        {
            // Filtro de escala de gfrises pero realta rojo o azul
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c, c2, cf;
            int main, gray1, gray2;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    int pr = (c.R + c.G + c.B) / 3;
                    c2 = Color.FromArgb(c.A, pr, pr, pr);

                    main = (si == "r") ? c.R : (si == "g") ? c.G : c.B;
                    gray1 = (si != "r") ? c.R : (si != "g") ? c.G : c.B;
                    gray2 = (si != "g") ? c.G : c.B;

                    cf = (gray1 < rango) & (gray2 < rango) & (main > rango) ? c : c2;
                    gs.SetPixel(x, y, cf);
                }
            }

            return gs;
        }

        public Bitmap grayscaleColorRange(Bitmap ruta, int rangoR, int rangoG, int rangoB)
        {
            // Filtro de escala de gfrises pero realta el color dado
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c, c2, cf;
            bool r, g, b;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    int pr = (c.R + c.G + c.B) / 3;
                    c2 = Color.FromArgb(c.A, pr, pr, pr);

                    r = (rangoR - 60) <= c.R & c.R < (rangoR + 60);
                    g = (rangoG - 60) <= c.G & c.G < (rangoG + 60);
                    b = (rangoB - 60) <= c.B & c.B < (rangoB + 60);

                    cf = r & g & b ? c : c2;
                    gs.SetPixel(x, y, cf);
                }
            }

            return gs;
        }


        //END GRAYSCALE FILTERS
        //*//
        //COLOR FILTERS
        public Bitmap Tint(Bitmap ruta, int rangoR, int rangoG, int rangoB)
        {
            // Filtro que aplica colores alternativos
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c, c2, cf;
            int r, g, b;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    int pr = (c.R + c.G + c.B) / 3;
                    c2 = Color.FromArgb(c.A, pr, pr, pr);

                    r = (rangoR < c.R) ? c.R : pr;
                    g = (rangoG < c.G) ? c.R : pr;
                    b = (rangoB < c.B) ? c.G : pr;

                    cf = Color.FromArgb(c.A, r, g, b);
                    gs.SetPixel(x, y, cf);
                }
            }

            return gs;
        }
        public Bitmap invert(Bitmap ruta, int con)
        {
            // Filtro de contraste

            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c;
            int r, g, b;
            int f = (259 * (con + 255)) / (255 * (con - 259));

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);


                    r = truncate((f * (c.R - 128) + 128));
                    g = truncate((f * (c.G - 128) + 128));
                    b = truncate((f * (c.B - 128) + 128));

                    gs.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));
                }
            }

            return gs;
        }

        public Bitmap contrast(Bitmap ruta, int con)
        {
            // Filtro de contraste

            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c;
            int r, g, b;
            int f = (259 * (255 + con)) / (255 * (259 - con));

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);


                    r = (f * (c.R - 128) + 128);
                    g = (f * (c.G - 128) + 128);
                    b = (f * (c.B - 128) + 128);

                    r = truncate(r);
                    g = truncate(g);
                    b = truncate(b);

                    gs.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));
                }
            }

            return gs;
        }
        public Bitmap onlyRGB(Bitmap ruta, int colors)
        {
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c;
            int r, g, b;
            int rango = colors * 10;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    r = (c.R > rango) ? 250 : 0;
                    g = (c.G > rango) ? 250 : 0;
                    b = (c.B > rango) ? 250 : 0;

                    gs.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));
                }
            }

            return gs;
        }
        public Bitmap oneColor(Bitmap ruta, int colors)
        {
            // rojo=1, verde=2, azul=3, magenta=4, cian=5, amarillo=6, naranja=7, violeta=8
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            int rango = w / 8;
            Color c;
            int r, g, b;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    r = (colors == 1) ^ (colors == 4) ^ (colors == 6) ^ (colors == 7) ? c.R : (colors == 8) ? c.R / 2 : 0;
                    g = (colors == 2) ^ (colors == 5) ^ (colors == 6) ? c.G : (colors == 7) ? c.G / 2 : 0;
                    b = (colors == 3) ^ (colors == 4) ^ (colors == 5) ^ (colors == 8) ? c.B : 0;

                    gs.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));
                }
            }

            return gs;
        }

        public Bitmap rainbowStripe(Bitmap ruta)
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


        public Bitmap rainbow(Bitmap ruta, int colors)
        {
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c;
            float rango = (w / 9);
            double r, g, b, aux1, aux2, aux3, aux;
            aux = 1 / (rango);

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

                    gs.SetPixel(x, y, Color.FromArgb(c.A, truncateS(r), truncateS(g), truncateS(b)));
                }
            }

            return gs;
        }


        public Bitmap colorSimple(string ruta)
        {
            Bitmap s = new Bitmap(ruta);
            int r, g, b;
            h = s.Height;
            w = s.Width;
            Color c;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = s.GetPixel(x, y);

                    r = (c.R > c.B) & (c.R > c.G) ? 255 : 0;
                    g = (c.G > c.B) & (c.G > c.R) ? 255 : 0;
                    b = (c.B > c.R) & (c.R > c.G) ? 255 : 0;

                    s.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));

                }
            }
            return s;
        }

        //OTROS

        public Bitmap blurSize(Bitmap ruta, int sz)
        {
            Bitmap s;
            Bitmap og;
            int nc, ch, cv, r, g, b;
            s = new Bitmap(ruta);
            og = new Bitmap(ruta);
            List<int> sov = new List<int>();

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
    }
}
