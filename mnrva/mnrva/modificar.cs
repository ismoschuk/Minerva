using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mnrva
{
    class modificar
    {
        int h, w;
        filtros filtro = new filtros();


        public Bitmap rotate(Bitmap ruta, int dir)
        {
            Bitmap gs;
            gs = new Bitmap(ruta);

            switch(dir)
            {
                case 90:
                    gs.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 270:
                    gs.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case 180:
                    gs.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    break;
                case 360:
                    gs.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    break;
            }


            return gs;
        }

        public Bitmap colorCrop(Bitmap ruta, Color sel)
        {
            // Bitmap s = colorSimple(ruta);
            Bitmap crop = new Bitmap(ruta);
            h = crop.Height;
            w = crop.Width;
            Color c, c2;
            // List<int> yV = new List<int>();
            //List<int> xV = new List<int>();
            int threshold1 = 30;
            int chck1, chck2, chck3;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    c = crop.GetPixel(x, y);
                    chck1 = (sel.R > (filtro.truncate(c.R - threshold1)) && sel.R < filtro.truncate(c.R + threshold1)) ? 1 : 0;
                    chck2 = (sel.G > (filtro.truncate(c.G - threshold1)) && sel.G < filtro.truncate(c.G + threshold1)) ? 1 : 0;
                    chck3 = (sel.B > (filtro.truncate(c.B - threshold1)) && sel.B < filtro.truncate(c.B + threshold1)) ? 1 : 0;

                    if ((chck1 + chck2 + chck3) > 1)
                    {
                        crop.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));

                    }
                }
            }
            return crop;
        }
        public Bitmap colorCropSelect(Bitmap ruta, Color sel)
        {
            // Bitmap s = colorSimple(ruta);
            Bitmap crop = new Bitmap(ruta);
            Bitmap s = filtro.badPrinter(crop, 130);
            h = s.Height;
            w = s.Width;
            Color c, c2;
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
                        //c2 = crop.GetPixel(x, y);
                        //crop.SetPixel(x, y, c2);
                        break;
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

        public Bitmap sticker(Bitmap ruta, int posX, int posY, Bitmap st)
        {
            // Usa solo blanco y negro puro dependiendo de la saturación
            Bitmap gs;
            gs = new Bitmap(ruta);
            h = gs.Height;
            w = gs.Width;
            Color c;
            int fx, fy;

            fx = (posX + st.Width < w) ? posX + st.Width : w;
            fy = (posY + st.Height < h) ? posY + st.Height : h;

            for (int y = posY; y < (fy); y++)
            {
                for (int x = posX; x < (fx); x++)
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
    }
}
