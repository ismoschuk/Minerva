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
        Pen lapicito = new Pen(Color.Lavender, 3);
        OpenFileDialog abrir = new OpenFileDialog();
        int posX, posY, anch, larg;

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

        public void AbrirImagen(PictureBox picimg, string ruta2)
        {


            picimg.Image = Bitmap.FromFile(ruta2);
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX, posY, anch = 100, larg = 100);

        }
        public void Arriba(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX, posY -= 5, anch, larg);
        }
        public void Abajo(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX, posY += 5, anch, larg);
        }

        public void ArribaSlide(PictureBox picimg, int np)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX, posY = np, anch, larg);
        }
        public void AbajoSlide(PictureBox picimg, int np)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX, posY = np, anch, larg);
        }

        public void Derecha(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX += 5, posY, anch, larg);
        }
        public void Izquierda(PictureBox picimg)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX -= 5, posY, anch, larg);
        }

        public void DerechaSlide(PictureBox picimg, int np)
        {
            picimg.Refresh();
            g = picimg.CreateGraphics();
            g.DrawRectangle(lapicito, posX = np, posY, anch, larg);
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
            g.DrawRectangle(lapicito, posX, posY, anch -= 5, larg);
        }
        public void Recortes(PictureBox img1, PictureBox img2)
        {
            Rectangle rect = new Rectangle(posX, posY, anch, larg);
            recorteBitm = new Bitmap(img1.Image, img1.Width, img1.Height);
            img2.Image = recorteBitm.Clone(rect, recorteBitm.PixelFormat);
        }
    }
}

