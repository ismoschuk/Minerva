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
        Bitmap ogBmp, zoomed, edit;
        string ruta;
        Color currentColor;
       // Size coso = new Size(155, 114);
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
            g.Size = new Size(114, 40);
            p.Size = new Size(114, 40);
            uc.Size = new Size(114, 40);
            c.Size = new Size(114, 40);
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

                edit.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }


        private void zoomInOg_Click(object sender, EventArgs e)
        {
            Bitmap zoomed = new Bitmap(ogBmp, 400, 400);
            //pictureBox4.Image = zoomed;
            //label1.Text = pictureBox4.Size.ToString();
        }

        private void ss_Click_1(object sender, EventArgs e)
        {
            g.Height = (g.Height == 114) ? 40 : 114;
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleShades(bmpGS, shades.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void bw_Click_1(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscale(bmpGS);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void print_Click(object sender, EventArgs e)
        {

            p.Height = (p.Height == 114) ? 40 : 114;


        }

        private void fotocopiaRange_Scroll_1(object sender, EventArgs e)
        {
            valueRange.Text = fotocopiaRange.Value.ToString();
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.badPrinter(bmpGS, fotocopiaRange.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void shades_Scroll_1(object sender, EventArgs e)
        {
            valuedis.Text = shades.Value.ToString();
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleShades(bmpGS, shades.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void gscale_Click(object sender, EventArgs e)
        {

        }

        private void gc_Click(object sender, EventArgs e)
        {
            uc.Height = (uc.Height == 114) ? 40 : 114;
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleColor(bmpGS, "r", 75);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void red_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleColor(bmpGS, "r", 75);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void blue_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleColor(bmpGS, "b", 75);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void cr_Click(object sender, EventArgs e)
        {
            c.Height = (c.Height == 200) ? 40 : 200;

        }

        private void redRange_Scroll(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleColorRange(bmpGS, redRange.Value, greenRange.Value, blueRange.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void greenRange_Scroll(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleColorRange(bmpGS, redRange.Value, greenRange.Value, blueRange.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void blueRange_Scroll(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleColorRange(bmpGS, redRange.Value, greenRange.Value, blueRange.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Cursor.Position.X, Cursor.Position.Y

        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            currentColor = edit.GetPixel(e.X, e.Y);
            label2.Text = currentColor.ToString();
        }

        private void zoomout_Click(object sender, EventArgs e)
        {
            int aux = (zoomed.Height <= (ogBmp.Height / 6)) & (zoomed.Width <= (ogBmp.Width / 6)) ? 1 : 2;
            zoomed = new Bitmap(edit, zoomed.Width / aux, zoomed.Height / aux);
            pictureBox3.Image = zoomed;
            label1.Text = zoomed.Size.ToString();
        }

        private void zoom_Click(object sender, EventArgs e)
        {
            int aux = (zoomed.Height >= (ogBmp.Height * 6)) & (zoomed.Width >= (ogBmp.Width * 6)) ? 1 : 2;
            zoomed = new Bitmap(edit, zoomed.Width * aux, zoomed.Height * aux);
            pictureBox3.Image = zoomed;
            label1.Text = zoomed.Size.ToString();
        }
    }
}
