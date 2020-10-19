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
        

    }
}
