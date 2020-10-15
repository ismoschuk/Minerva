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
        Bitmap ogBmp;
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
                pictureBox3.Image = ogBmp;


            }
        }


        private void shades_Scroll(object sender, EventArgs e)
        {
            valuedis.Text = shades.Value.ToString();

        }

        private void bw_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            Bitmap gs = filtro.grayscale(bmpGS);
            pictureBox3.Image = gs;
            pictureBox2.Image = gs;
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


    }
}
