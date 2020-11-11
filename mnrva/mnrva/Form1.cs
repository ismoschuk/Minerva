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
        modificar mod = new modificar();
        Bitmap ogBmp, zoomed, edit, ogZoomed, firstBmp, impSt; //Bitmap del programa
        string ruta, stickerChoice, stickerImport; // Ruta de la imagen seleccionada
        recortar objRecorte = new recortar();
        Color currentColor; //Color seleccionado en el gotero
        bool stickin, collage;
        Pen blackPen = new Pen(Color.FromArgb(255, 150, 150, 150), 3);
        Graphics graph;

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
            t.Size = new Size(114, 40);
            s.Size = new Size(114, 40);
            br.Size = new Size(114, 40);
            bl.Size = new Size(114, 40);
            ac.Size = new Size(114, 40);
            tool.Dock = DockStyle.Right;
            cropPanel.Enabled = false;
            currentColor = Color.FromArgb(255, 255, 255, 255);
            stickerChoice = "raio";
            impSt = new Bitmap(100, 100);
            //img.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cargando una foto
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ruta = ofd.FileName;
                ogBmp = new Bitmap(ruta);
                pictureBox1.Image = ogBmp;
                label3.Text = pictureBox1.Image.Size.ToString();
                edit = new Bitmap(ogBmp);

                pictureBox3.Image = edit;
                zoomed = new Bitmap(edit);
                firstBmp = new Bitmap(ogBmp);
                ogZoomed = new Bitmap(ogBmp);
                pictureBox4.Image = firstBmp;
                FIlterSelect.Enabled = true;

                trackX.Maximum = firstBmp.Width;
                trackX.Value = firstBmp.Width / 2;
                posX.Text = trackX.Value.ToString();

                trackY.Maximum = firstBmp.Height;
                trackY.Value = firstBmp.Height / 2;
                posY.Text = trackY.Value.ToString();
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gurdado una foto
            sfd.FileName = "out";
            sfd.DefaultExt = "jpg";
            sfd.Filter = "Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|All files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                //var fileName = sfd.FileName;
                //if (!System.IO.Path.HasExtension(fileName) || System.IO.Path.GetExtension(fileName) != "jpg")
                //    fileName = fileName + ".jpg";

                //bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);


                var fileName = sfd.FileName;

                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".bmp")
                        edit.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".jpg")
                        edit.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".gif")
                        edit.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".png")
                    {
                        Bitmap tr = new Bitmap(edit);
                        tr.MakeTransparent();
                        tr.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".tif")
                        edit.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                    else
                        MessageBox.Show("File Save Error.");
                //if (!System.IO.Path.HasExtension(fileName) || System.IO.Path.GetExtension(fileName) != "jpg")
                //{
                //    fileName = fileName + ".jpg";
                //    edit.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                //}

                //if (!System.IO.Path.HasExtension(fileName) || System.IO.Path.GetExtension(fileName) != "png")
                //{
                //    Bitmap tr = new Bitmap(edit);
                //    tr.MakeTransparent();
                //    fileName = fileName + ".png";
                //    tr.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                //}

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

        }

        private void bw_Click_1(object sender, EventArgs e)
        {
            // Filtro de escala de grises
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
            // FIltro puro blanco y negro
            valueRange.Text = fotocopiaRange.Value.ToString();
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.badPrinter(bmpGS, fotocopiaRange.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void shades_Scroll_1(object sender, EventArgs e)
        {
            // FIltro escala de grises limitados
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
        }

        private void red_Click(object sender, EventArgs e)
        {
            // FIltro resaltar Rojo
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleColor(bmpGS, "r", 75);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void blue_Click(object sender, EventArgs e)
        {
            // FIltro resaltar Azul
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.grayscaleColor(bmpGS, "b", 75);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void cr_Click(object sender, EventArgs e)
        {
            c.Height = (c.Height == 235) ? 40 : 235;

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
            if (stickin)
            {
                string getRuta = (collage) ? stickerImport : "stick/" + stickerChoice + ".png";
                Bitmap st = new Bitmap (getRuta);

                int sizeX = (collage) ? (st.Width * stickerSize.Value) / 100 : stickerSize.Value * 10;
                int sizeY = (collage) ? (st.Height * stickerSize.Value) / 100 : stickerSize.Value * 10;

                st = new Bitmap(st, sizeX, sizeY);
                st.MakeTransparent();
                //edit = mod.sticker(edit, 220, 200, st);
                edit = mod.sticker(edit, e.X, e.Y, st);
                pictureBox3.Image = edit;
                pictureBox2.Image = edit;
            }
            else
            {
                currentColor = ogZoomed.GetPixel(e.X, e.Y);
                label2.Text = currentColor.ToString() + " " + e.X.ToString() + " , " + e.Y.ToString() ;
                colorDis.BackColor = currentColor;
            }
        }

        private void tint_Click(object sender, EventArgs e)
        {
            t.Height = (t.Height == 235) ? 40 : 235;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            redRange.Value = currentColor.R;
            greenRange.Value = currentColor.G;
            blueRange.Value = currentColor.B;
            edit = filtro.Tint(bmpGS, redRange2.Value, greenRange2.Value, blueRange2.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(b, pictureBox1.ClientRectangle);
            currentColor = b.GetPixel(e.X, e.Y);
            label2.Text = currentColor.ToString() + " - " + e.Location.ToString();
        }

        private void redRange2_Scroll(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.Tint(bmpGS, redRange2.Value, greenRange2.Value, blueRange2.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void greenRange2_Scroll(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.Tint(bmpGS, redRange2.Value, greenRange2.Value, blueRange2.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void blueRange2_Scroll(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.Tint(bmpGS, redRange2.Value, greenRange2.Value, blueRange2.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void ct_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.invert(bmpGS, 10);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void cst_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.contrast(bmpGS, 99);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void simple_Click(object sender, EventArgs e)
        {
            s.Height = (s.Height == 145) ? 40 : 145;

        }

        private void simpleRange_Scroll(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.onlyRGB(bmpGS, simpleRange.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void cl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clr_Click(object sender, EventArgs e)
        {
            // rojo=1, verde=2, azul=3, magenta=4, cian=5, amarillo=6, naranja=7, violeta=8
            cl.Height = (cl.Height == 145) ? 40 : 145;

        }

        private void lRed_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.oneColor(bmpGS, 1);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void lGreen_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.oneColor(bmpGS, 2);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void lBlue_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.oneColor(bmpGS, 3);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void lMag_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.oneColor(bmpGS, 4);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void lCian_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.oneColor(bmpGS, 5);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void lYell_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.oneColor(bmpGS, 6);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void lOran_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.oneColor(bmpGS, 7);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void lVio_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.oneColor(bmpGS, 8);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void rbw_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.rainbowStripe(bmpGS);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void rbwg_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.rainbow(bmpGS, 2);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void filtrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FIlterSelect.Visible = true;
            tool.Dock = DockStyle.None;
            tool.Visible = false;
            FIlterSelect.Dock = DockStyle.Right;
            EditSelect.Dock = DockStyle.None;
            EditSelect.Visible = false;
            tool.Visible = false;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelect.Visible = true;
            tool.Dock = DockStyle.None;
            tool.Visible = false;
            FIlterSelect.Dock = DockStyle.None;
            FIlterSelect.Visible = false;
            EditSelect.Dock = DockStyle.Right;
        }

        private void escalaDeGrisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FIlterSelect.SelectedTab = gscale;
        }

        private void coloresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FIlterSelect.SelectedTab = colors;

        }

        private void turn90_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(edit);
            edit = mod.rotate(bmpGS, 90);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void turn270_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(edit);
            edit = mod.rotate(bmpGS, 270);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void turnside_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(edit);
            edit = mod.rotate(bmpGS, 360);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void turnup_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(edit);
            edit = mod.rotate(bmpGS, 180);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void blur_Click(object sender, EventArgs e)
        {
            bl.Height = (bl.Height == 99) ? 40 : 99;

        }

        private void blur2_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.blurSize(bmpGS, 6);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void blur1_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.blurSize(bmpGS, 3);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void blur3_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.blurSize(bmpGS, 9);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void edge_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.edgeDetect(bmpGS);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.colorEnhance(bmpGS, redMore.Value, "r");
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void greenMore_Scroll(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.colorEnhance(bmpGS, greenMore.Value, "g");
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void blueMore_Scroll(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.colorEnhance(bmpGS, blueMore.Value, "b");
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void colorcr_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = mod.colorCrop(bmpGS, currentColor);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void cropcol_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = mod.colorCropSelect(bmpGS, currentColor);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void colorcr_Click_1(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = mod.colorCrop(bmpGS, currentColor);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void bright_Scroll(object sender, EventArgs e)
        {

        }

        private void bright_Scroll_1(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(ogBmp);
            edit = filtro.bright(bmpGS, bright.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void btm_Recorte_Manual_Click(object sender, EventArgs e)
        {
            objRecorte.AbrirImagen(pictureBox4, edit);
            txt_Ancho.Text = objRecorte.Ancho.ToString();
            txt_Largo.Text = objRecorte.Largo.ToString();
            trackX.Value = 0;
            trackY.Value = 0;
            cropPanel.Enabled = true;
        }

        private void btm_Mover_Arriba_Click(object sender, EventArgs e)
        {
            objRecorte.Arriba(pictureBox4);
            posY.Text = objRecorte.PosY.ToString();
            objRecorte.Recortes(pictureBox4, pictureBox5);
        }

        private void btm_Mover_Izquierda_Click(object sender, EventArgs e)
        {
            objRecorte.Izquierda(pictureBox4);
            posX.Text = objRecorte.PosX.ToString();
            objRecorte.Recortes(pictureBox4, pictureBox5);
        }

        private void btm_Mover_Abajo_Click(object sender, EventArgs e)
        {
            objRecorte.Abajo(pictureBox4);
            posY.Text = objRecorte.PosY.ToString();
            objRecorte.Recortes(pictureBox4, pictureBox5);
        }

        private void btm_Mover_Derecha_Click(object sender, EventArgs e)
        {
            objRecorte.Derecha(pictureBox4);
            posX.Text = objRecorte.PosX.ToString();
            objRecorte.Recortes(pictureBox4, pictureBox5);
        }

        private void btm_Ancho_Mas_Click(object sender, EventArgs e)
        {
            objRecorte.AnchoMas(pictureBox4);
            txt_Ancho.Text = objRecorte.Ancho.ToString();
            objRecorte.Recortes(pictureBox4, pictureBox5);
        }

        private void btm_Ancho_Menos_Click(object sender, EventArgs e)
        {
            objRecorte.AnchoMenos(pictureBox4);
            txt_Ancho.Text = objRecorte.Ancho.ToString();
            objRecorte.Recortes(pictureBox4, pictureBox5);
        }

        private void btm_Largo_Mas_Click(object sender, EventArgs e)
        {
            objRecorte.LargoMas(pictureBox4);
            txt_Largo.Text = objRecorte.Largo.ToString();
            objRecorte.Recortes(pictureBox4, pictureBox5);
        }

        private void btm_Largo_Menos_Click(object sender, EventArgs e)
        {
            objRecorte.LargoMenos(pictureBox4);
            txt_Largo.Text = objRecorte.Largo.ToString();
            objRecorte.Recortes(pictureBox4, pictureBox5);
        }

        private void btm_Recortar_Click(object sender, EventArgs e)
        {
        }

        private void btm_Recortar_Click_1(object sender, EventArgs e)
        {
            objRecorte.Recortes(pictureBox4, pictureBox3);
            edit = new Bitmap(pictureBox5.Image);
            pictureBox2.Image = edit;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trackX_Scroll(object sender, EventArgs e)
        {
            if (trackX.Value < (ogBmp.Width / 2))
            {
                objRecorte.IzquierdaSlide(pictureBox4, trackX.Value);
                objRecorte.Recortes(pictureBox4, pictureBox5);

            }
            else
            {
                objRecorte.DerechaSlide(pictureBox4, trackX.Value);
                objRecorte.Recortes(pictureBox4, pictureBox5);
            }
            posX.Text = trackX.Value.ToString();
        }

        private void trackY_Scroll(object sender, EventArgs e)
        {
            if (trackY.Value < (ogBmp.Height / 2))
            {
                objRecorte.ArribaSlide(pictureBox4, trackY.Value);
                objRecorte.Recortes(pictureBox4, pictureBox5);
            }
            else
            {
                objRecorte.AbajoSlide(pictureBox4, trackY.Value);
                objRecorte.Recortes(pictureBox4, pictureBox5);
            }
            posY.Text = trackY.Value.ToString();
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void savePic_Click(object sender, EventArgs e)
        {
            ogBmp = edit;
            zoomed = new Bitmap(edit);
            ogZoomed = new Bitmap(ogBmp);
            pictureBox4.Image = ogBmp;
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            ogBmp = firstBmp;
            zoomed = new Bitmap(edit);
            edit = ogBmp;
            ogZoomed = new Bitmap(ogBmp);
            pictureBox2.Image = ogBmp;
            pictureBox3.Image = ogBmp;
            pictureBox4.Image = ogBmp;
        }

        private void brnEnhance_Click(object sender, EventArgs e)
        {
            edit = objRecorte.RecortesAgrandar(pictureBox4, pictureBox3);
            pictureBox2.Image = edit;
        }

        private void stk_Click(object sender, EventArgs e)
        {
            if (!stickin)
            {
                stickin = true;
                zoom.Enabled = false;
                zoomout.Enabled = false;
                zoomed = new Bitmap(edit, edit.Width, edit.Height);
                ogZoomed = new Bitmap(ogBmp, edit.Width, edit.Height);
                imp.Enabled = true;
            }

            else
            {
                stickin = false;
                zoom.Enabled = true;
                zoomout.Enabled = true;
                imp.Enabled = false;
            }

        }



        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (stickin)
            {
                //img.Visible = true;
                //img.Location = new Point(e.X, e.Y);
                int sizeX = (collage) ? (impSt.Width * stickerSize.Value) / 100 : stickerSize.Value * 10;
                int sizeY = (collage) ? (impSt.Height * stickerSize.Value) / 100 : stickerSize.Value * 10;
                pictureBox3.Refresh();
                graph = pictureBox3.CreateGraphics();
                graph.DrawRectangle(blackPen, e.X, e.Y, sizeX, sizeY);


            }
            else
                pictureBox3.Refresh();

        }

        private void stLi_Click(object sender, EventArgs e)
        {
            if (stLi.BackColor == Color.White)
            {
                stLi.BackColor = Color.LightBlue;
                stGo.BackColor = Color.White;
                stHo.BackColor = Color.White;
                stTor.BackColor = Color.White;
                stFla.BackColor = Color.White;
                stFlf.BackColor = Color.White;
                stSp.BackColor = Color.White;
                impS.BackColor = Color.White;
                selSt.Enabled = false;
                collage = false;
                stickerChoice = "raio";
            }
            else
                stLi.BackColor = Color.White;


        }

        private void stGo_Click(object sender, EventArgs e)
        {
            if (stGo.BackColor == Color.White)
            {
                stLi.BackColor = Color.White;
                stGo.BackColor = Color.LightBlue;
                stHo.BackColor = Color.White;
                stTor.BackColor = Color.White;
                stFla.BackColor = Color.White;
                stFlf.BackColor = Color.White;
                stSp.BackColor = Color.White;
                impS.BackColor = Color.White;
                selSt.Enabled = false;
                collage = false;
                stickerChoice = "gota";
            }
            else
                stGo.BackColor = Color.White;
        }

        private void stHo_Click(object sender, EventArgs e)
        {
            if (stHo.BackColor == Color.White)
            {
                stLi.BackColor = Color.White;
                stGo.BackColor = Color.White;
                stHo.BackColor = Color.LightBlue;
                stTor.BackColor = Color.White;
                stFla.BackColor = Color.White;
                stFlf.BackColor = Color.White;
                stSp.BackColor = Color.White;
                impS.BackColor = Color.White;
                selSt.Enabled = false;
                collage = false;
                stickerChoice = "hoja";
            }
            else
                stHo.BackColor = Color.White;
        }

        private void stTor_Click(object sender, EventArgs e)
        {
            if (stTor.BackColor == Color.White)
            {
                stLi.BackColor = Color.White;
                stGo.BackColor = Color.White;
                stHo.BackColor = Color.White;
                stTor.BackColor = Color.LightBlue;
                stFla.BackColor = Color.White;
                stFlf.BackColor = Color.White;
                stSp.BackColor = Color.White;
                impS.BackColor = Color.White;
                selSt.Enabled = false;
                collage = false;
                stickerChoice = "storm";
            }
            else
                stTor.BackColor = Color.White;
        }

        private void stFla_Click(object sender, EventArgs e)
        {
            if (stFla.BackColor == Color.White)
            { 
                stLi.BackColor = Color.White;
                stGo.BackColor = Color.White;
                stHo.BackColor = Color.White;
                stTor.BackColor = Color.White;
                stFla.BackColor = Color.LightBlue;
                stFlf.BackColor = Color.White;
                stSp.BackColor = Color.White;
                impS.BackColor = Color.White;
                selSt.Enabled = false;
                collage = false;
                stickerChoice = "florA";
            }
            else
                stFla.BackColor = Color.White;
        }

        private void stFlf_Click(object sender, EventArgs e)
        {
            if (stFlf.BackColor == Color.White)
            {
                stLi.BackColor = Color.White;
                stGo.BackColor = Color.White;
                stHo.BackColor = Color.White;
                stTor.BackColor = Color.White;
                stFla.BackColor = Color.White;
                stFlf.BackColor = Color.LightBlue;
                stSp.BackColor = Color.White;
                impS.BackColor = Color.White;
                selSt.Enabled = false;
                collage = false;
                stickerChoice = "florF";
            }
            else
                stFlf.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            br.Height = (br.Height == 99) ? 40 : 99;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = (edit == null) ? "No hay ediciones" : edit.Size.ToString();
        }

        private void aug_Click(object sender, EventArgs e)
        {
            ac.Height = (ac.Height == 235) ? 40 : 235;

        }

        private void otrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FIlterSelect.SelectedTab = other;

        }

        private void girarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelect.SelectedTab = spin;

        }

        private void recortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelect.SelectedTab = crop;

        }

        private void stickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelect.SelectedTab = stick;

        }

        private void stSp_Click(object sender, EventArgs e)
        {
            if (stSp.BackColor == Color.White)
            {
                stLi.BackColor = Color.White;
                stGo.BackColor = Color.White;
                stHo.BackColor = Color.White;
                stTor.BackColor = Color.White;
                stFla.BackColor = Color.White;
                stFlf.BackColor = Color.White;
                stSp.BackColor = Color.LightBlue;
                impS.BackColor = Color.White;
                selSt.Enabled = false;
                collage = false;
                stickerChoice = "chispa";
            }
            else
                stSp.BackColor = Color.White;
        }

        private void selSt_Click(object sender, EventArgs e)
        {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string rutaSt = ofd.FileName;
                    impSt = new Bitmap(rutaSt);
                    selSt.BackgroundImage = impSt;
                    collage = true;
                    stickerImport = rutaSt;
                    selSt.Text = "";

                }
            


        }

        private void impS_Click(object sender, EventArgs e)
        {
            collage = collage ? true : false;
            if (!collage)
            {
                selSt.Enabled = true;
                impS.BackColor = Color.LightBlue;
                collage = true;
            }
            else
            {
                selSt.Enabled = false;
                impS.BackColor = Color.White;
                collage = false;
            }
        }

        private void EditSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            stickin = false;
            imp.Enabled = false;

        }

        private void EditSelect_TabIndexChanged(object sender, EventArgs e)
        {
            stickin = false;

        }


        private void crPick_Click(object sender, EventArgs e)
        {
            Bitmap bmpGS = new Bitmap(edit);
            redRange.Value = currentColor.R;
            greenRange.Value = currentColor.G;
            blueRange.Value = currentColor.B;
            edit = filtro.grayscaleColorRange(bmpGS, redRange.Value, greenRange.Value, blueRange.Value);
            pictureBox3.Image = edit;
            pictureBox2.Image = edit;
        }

        private void zoomout_Click(object sender, EventArgs e)
        {
            int aux = (zoomed.Height <= (ogBmp.Height / 6)) & (zoomed.Width <= (ogBmp.Width / 6)) ? 1 : 2;
            zoomed = new Bitmap(edit, zoomed.Width / aux, zoomed.Height / aux);
            ogZoomed = new Bitmap(ogBmp, ogZoomed.Width / aux, ogZoomed.Height / aux);

            pictureBox3.Image = zoomed;
            label1.Text = zoomed.Size.ToString();
        }

        private void zoom_Click(object sender, EventArgs e)
        {
            int aux = (zoomed.Height >= (ogBmp.Height * 6)) & (zoomed.Width >= (ogBmp.Width * 6)) ? 1 : 2;
            zoomed = new Bitmap(edit, zoomed.Width * aux, zoomed.Height * aux);
            ogZoomed = new Bitmap(ogBmp, ogZoomed.Width * aux, ogZoomed.Height * aux);
            pictureBox3.Image = zoomed;
            label1.Text = zoomed.Size.ToString();
        }
    }
}
