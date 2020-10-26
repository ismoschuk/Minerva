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
    }
}
