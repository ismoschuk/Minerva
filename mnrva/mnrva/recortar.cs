using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace mnrva
{
    class recortar
    {
        Bitmap recorteBitm;
        Graphics g;
        filtros filtro = new filtros();
        Pen lapicito = new Pen(Color.Lavender, 3);
        OpenFileDialog abrir = new OpenFileDialog();
        int posX, posY, anch, larg, check;

        public Bitmap ImgBitmap
        {
            get
            {
                return recorteBitm;
            }
            set
            {
                recorteBitm = value;
            }
        }
        public int PosX
        {
            get
            {
                return posX;
            }
            set
            {
                posX = value;
            }
        }
        public int PosY
        {
            get
            {
                return posY;
            }
            set
            {
                posY = value;
            }
        }
        public int Ancho
        {
            get
            {
                return anch;
            }
            set
            {
                anch = value;
            }
        }
        public int Largo
        {
            get
            {
                return larg;
            }
            set
            {
                larg = value;
            }
        }

        public void AbrirImagen(PictureBox picimg, Bitmap ruta2)
        {


            picimg.Image = ruta2;
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX, posY, anch = 100, larg = 100);

        }
        public void Arriba(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            check = ((posY - 5) > 0) ? 5 : 0;
            g.DrawRectangle(lapicito, posX, posY -= check, anch, larg);
        }
        public void Abajo(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            check = ((posY + larg + 5) < picimg.Image.Height) ? 5 : 0;
            g.DrawRectangle(lapicito, posX, posY += check, anch, larg);
        }

        public void ArribaSlide(PictureBox picimg, int np)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            check = (np > 0) ? np : posY;
            g.DrawRectangle(lapicito, posX, posY = np, anch, larg);
        }
        public void AbajoSlide(PictureBox picimg, int np)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            check = ((np + larg) < picimg.Image.Height) ? np : posY;
            g.DrawRectangle(lapicito, posX, posY = check, anch, larg);
        }

        public void Derecha(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            check = ((posX + anch + 5) < picimg.Image.Width) ? 5 : 0;
            g.DrawRectangle(lapicito, posX += check, posY, anch, larg);
        }
        public void Izquierda(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            check = ((posX - 5) > 0) ? 5 : 0;
            g.DrawRectangle(lapicito, posX -= check, posY, anch, larg);
        }

        public void DerechaSlide(PictureBox picimg, int np)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            check = ((np + anch) < picimg.Image.Width) ? np : posX;
            g.DrawRectangle(lapicito, posX = check, posY, anch, larg);
        }
        public void IzquierdaSlide(PictureBox picimg, int np)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX = np, posY, anch, larg);
        }
        public void AnchoMas(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX, posY, anch += 5, larg);
        }
        public void AnchoMenos(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX, posY, anch -= 5, larg);
        }
        public void LargoMas(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX, posY, anch, larg += 5);
        }
        public void LargoMenos(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX, posY, anch, larg -= 5);
        }
        public void Recortes(PictureBox img1, PictureBox img2)
        {
            Rectangle rect = new Rectangle(posX, posY, anch, larg);
            recorteBitm = new Bitmap(img1.Image, img1.Width, img1.Height);
            img2.Image = recorteBitm.Clone(rect, recorteBitm.PixelFormat);
        }

        public Bitmap RecortesAgrandar(PictureBox img1, PictureBox img2)
        {
            Rectangle rect = new Rectangle(posX, posY, anch, larg);
            recorteBitm = new Bitmap(img1.Image, img1.Width, img1.Height);
            Bitmap recorteBitm2 = recorteBitm.Clone(rect, recorteBitm.PixelFormat);

            recorteBitm2 = filtro.zoome(recorteBitm2, 5);

            img2.Image = recorteBitm2;

            return recorteBitm2;
        }
    }
}

