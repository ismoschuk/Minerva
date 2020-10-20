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



        public int truncate(int rgb)
        {
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


    }
}
