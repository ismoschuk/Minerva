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
                pictureBox1.Image = Image.FromFile(ruta);
                ogBmp = new Bitmap(ruta);


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
    }
}
