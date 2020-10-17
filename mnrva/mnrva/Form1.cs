using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mnrva
{
    public partial class Form1 : Form
    {
        filtros filtro = new filtros();
        //int zoom_auxH, zoom_auxW, zoom_aux;
        Bitmap ogBmp, zoomed, edit;
        string ruta;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ruta = ofd.FileName;
                ogBmp = new Bitmap(ruta);
                pictureBox1.Image = ogBmp;
                edit = new Bitmap(ogBmp);

                pictureBox3.Image = edit;
                zoomed = new Bitmap(edit);
            }
        }

        private void shades_Scroll(object sender, EventArgs e)
        {
            valuedis.Text = shades.Value.ToString();
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleShades(bmpGS, shades.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void bw_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscale(bmpGS);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd.FileName = "out";
            sfd.DefaultExt = "jpg";
            sfd.Filter = "JPG images (*.jpg)|*.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                var fileName = sfd.FileName;
                if (!System.IO.Path.HasExtension(fileName) || System.IO.Path.GetExtension(fileName) != "jpg")
                    fileName = fileName + ".jpg";

                ogBmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void ss_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleShades(bmpGS, shades.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void print_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.badPrinter(bmpGS, fotocopiaRange.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void fotocopiaRange_Scroll(object sender, EventArgs e)
        {
            valueRange.Text = fotocopiaRange.Value.ToString();
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.badPrinter(bmpGS, fotocopiaRange.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void zoomInOg_Click(object sender, EventArgs e)
        {
            Bitmap zoomed = new Bitmap(ogBmp, 400, 400);
            //pictureBox4.Image = zoomed;
            //label1.Text = pictureBox4.Size.ToString();
        }

        private void zoomout_Click(object sender, EventArgs e)
        {
            int aux = (zoomed.Height <= (ogBmp.Height / 2)) & (zoomed.Width <= (ogBmp.Width / 2)) ? 1 : 2;
            zoomed = new Bitmap(edit, zoomed.Width / aux, zoomed.Height / aux);
            pictureBox3.Image = zoomed;
            label1.Text = zoomed.Size.ToString();
        }

        private void zoom_Click(object sender, EventArgs e)
        {
            int aux = (zoomed.Height >= (ogBmp.Height * 2)) & (zoomed.Width >= (ogBmp.Width * 2)) ? 1 : 2;
            zoomed = new Bitmap(edit, zoomed.Width * aux, zoomed.Height * aux);
            pictureBox3.Image = zoomed;
            label1.Text = zoomed.Size.ToString();
        }
    }
}
