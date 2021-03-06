﻿using System;
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
            // Filtro de escala de gfrises pero realza rojo o azul
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c, c2, cf;
            //int main, gray1, gray2;
            bool main, gray1, gray2;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = gs.GetPixel(x, y);

                    int pr = (c.R + c.G + c.B) / 3;
                    c2 = Color.FromArgb(c.A, pr, pr, pr);

                    //main = (si == "r") ? c.R : (si == "g") ? c.G : c.B;
                    //gray1 = (si != "r") ? c.R : (si != "g") ? c.G : c.B;
                    //gray2 = (si != "g") ? c.G : c.B;
                    main = (si == "r") & (c.R > rango) & (c.G <= rango / 2) & (c.B <= c.R);
                    gray1 = (si == "b") & (c.B > rango) & (c.G <= c.B) & (c.R < rango); // listo

                    cf = (gray1) ^ (main) ? c : c2;
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


        public Bitmap colorEnhance(Bitmap ruta, double aug, string color)
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

                    r = (color == "r") ? truncateS(c.R * (1 + aug / 10)) : c.R;
                    g = (color == "g") ? truncateS(c.G * (1 + aug / 10)) : c.G;
                    b = (color == "b") ? truncateS(c.B * (1 + aug / 10)) : c.B;

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

        public Bitmap edgeDetect(Bitmap ruta)
        {
            Bitmap s;
            Bitmap og;
            int chkV1, chkH1, ch, cv, nc, v, l;
            s = new Bitmap(ruta);
            //og = grayscaleShades(ruta, 6);
            og = grayscale(ruta);
            og = blurSize(og, 3);
            List<int> sov = new List<int>();

            //este queda piola
            int[] sovV = new int[] { 0, -1, 0, -1, 4, -1, 0, -1, 0 };
            int[] sovH = new int[] { 0, -1, 0, -1, 4, -1, 0, -1, 0 };

            h = s.Height;
            w = s.Width;
            cv = 0;
            ch = 0;
            v = 0;
            l = 0;
            Color c, c2;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = s.GetPixel(x, y);
                    chkH1 = (x < (w - 3)) ? (x + 3) : w;
                    chkV1 = (y < (h - 3)) ? (y + 3) : h;
                    for (int yy = y; yy < chkV1; yy++)
                    {
                        l = 0;
                        for (int xx = x; xx < chkH1; xx++)
                        {
                            c2 = og.GetPixel(xx, yy);
                            cv += c2.R * sovV[v + l];
                            ch += c2.R * sovH[v + l];
                            l++;
                        }
                        v++;
                    }

                    
                    nc = Convert.ToInt32(Math.Pow(cv, 2) + Math.Pow(ch, 2));
                    nc = Convert.ToInt32(Math.Sqrt(nc));

                    nc = truncate(nc);

                    s.SetPixel(x, y, Color.FromArgb(c.A, nc, nc, nc));

                    sov.Clear();
                    cv = 0;
                    ch = 0;
                    v = 0;
                    l = 0;
                }
            }

            return s;
        }
        public Bitmap bright(Bitmap ruta, double aug)
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

                    r = truncateS(c.R * (aug / 10));
                    g = truncateS(c.G * (aug / 10));
                    b = truncateS(c.B * (aug / 10));

                    s.SetPixel(x, y, Color.FromArgb(c.A, r, g, b));

                }
            }
            return s;
        }


        public Bitmap zoome(Bitmap ruta, int z)
        {
            Bitmap s = new Bitmap(ruta);
            Bitmap sz = new Bitmap(ruta.Width * z, ruta.Height * z);
            h = sz.Height;
            w = sz.Width;
            Color c;
         
            for (int y = 0; y < h; y += z)
            {
                for (int x = 0; x < w; x += z)
                {
                    c = s.GetPixel(x / z, y / z);

                    sz.SetPixel(x, y, c);

                    for (int yy = 0; yy < z; yy++)
                    {
                        for (int xx = 0; xx < z; xx++)
                        {
                            sz.SetPixel(x + xx, y + yy, c);
                        }
                    }
                }
            }

            return sz;
        }
    }

}
