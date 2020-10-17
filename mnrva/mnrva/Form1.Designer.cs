namespace mnrva
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zoomOutOg = new System.Windows.Forms.Button();
            this.zoomInOg = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.zoomOutNew = new System.Windows.Forms.Button();
            this.zoomInNew = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.valuedis = new System.Windows.Forms.Label();
            this.shades = new System.Windows.Forms.TrackBar();
            this.print = new System.Windows.Forms.Button();
            this.ss = new System.Windows.Forms.Button();
            this.bw = new System.Windows.Forms.Button();
            this.gscale = new System.Windows.Forms.GroupBox();
            this.valueRange = new System.Windows.Forms.Label();
            this.fotocopiaRange = new System.Windows.Forms.TrackBar();
            this.otrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bordesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalaDeGrisesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.zoomout = new System.Windows.Forms.Button();
            this.zoom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shades)).BeginInit();
            this.gscale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotocopiaRange)).BeginInit();
            this.menu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1059, 482);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Comparar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.zoomOutOg);
            this.panel1.Controls.Add(this.zoomInOg);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 470);
            this.panel1.TabIndex = 1;
            // 
            // zoomOutOg
            // 
            this.zoomOutOg.Location = new System.Drawing.Point(62, 332);
            this.zoomOutOg.Name = "zoomOutOg";
            this.zoomOutOg.Size = new System.Drawing.Size(39, 40);
            this.zoomOutOg.TabIndex = 2;
            this.zoomOutOg.Text = "button1";
            this.zoomOutOg.UseVisualStyleBackColor = true;
            // 
            // zoomInOg
            // 
            this.zoomInOg.Location = new System.Drawing.Point(17, 332);
            this.zoomInOg.Name = "zoomInOg";
            this.zoomInOg.Size = new System.Drawing.Size(39, 39);
            this.zoomInOg.TabIndex = 1;
            this.zoomInOg.Text = "button1";
            this.zoomInOg.UseVisualStyleBackColor = true;
            this.zoomInOg.Click += new System.EventHandler(this.zoomInOg_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(521, 316);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.zoomOutNew);
            this.panel2.Controls.Add(this.zoomInNew);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(539, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(527, 470);
            this.panel2.TabIndex = 2;
            // 
            // zoomOutNew
            // 
            this.zoomOutNew.Location = new System.Drawing.Point(15, 331);
            this.zoomOutNew.Name = "zoomOutNew";
            this.zoomOutNew.Size = new System.Drawing.Size(39, 40);
            this.zoomOutNew.TabIndex = 4;
            this.zoomOutNew.Text = "button1";
            this.zoomOutNew.UseVisualStyleBackColor = true;
            // 
            // zoomInNew
            // 
            this.zoomInNew.Location = new System.Drawing.Point(60, 331);
            this.zoomInNew.Name = "zoomInNew";
            this.zoomInNew.Size = new System.Drawing.Size(39, 40);
            this.zoomInNew.TabIndex = 3;
            this.zoomInNew.Text = "button1";
            this.zoomInNew.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(3, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(511, 316);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Location = new System.Drawing.Point(3, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1047, 480);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(13, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1059, 482);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Editar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // valuedis
            // 
            this.valuedis.AutoSize = true;
            this.valuedis.Location = new System.Drawing.Point(8, 171);
            this.valuedis.Name = "valuedis";
            this.valuedis.Size = new System.Drawing.Size(51, 20);
            this.valuedis.TabIndex = 4;
            this.valuedis.Text = "label1";
            // 
            // shades
            // 
            this.shades.Location = new System.Drawing.Point(8, 119);
            this.shades.Minimum = 2;
            this.shades.Name = "shades";
            this.shades.Size = new System.Drawing.Size(138, 45);
            this.shades.TabIndex = 3;
            this.shades.Tag = "shades";
            this.shades.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.shades.Value = 2;
            this.shades.Scroll += new System.EventHandler(this.shades_Scroll);
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(7, 218);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(140, 34);
            this.print.TabIndex = 2;
            this.print.Text = "Fotocopia";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // ss
            // 
            this.ss.Location = new System.Drawing.Point(6, 78);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(140, 34);
            this.ss.TabIndex = 1;
            this.ss.Text = "Grises";
            this.ss.UseVisualStyleBackColor = true;
            this.ss.Click += new System.EventHandler(this.ss_Click);
            // 
            // bw
            // 
            this.bw.Location = new System.Drawing.Point(6, 38);
            this.bw.Name = "bw";
            this.bw.Size = new System.Drawing.Size(140, 34);
            this.bw.TabIndex = 0;
            this.bw.Text = "Blanco y Negro";
            this.bw.UseVisualStyleBackColor = true;
            this.bw.Click += new System.EventHandler(this.bw_Click);
            // 
            // gscale
            // 
            this.gscale.Controls.Add(this.valueRange);
            this.gscale.Controls.Add(this.fotocopiaRange);
            this.gscale.Controls.Add(this.valuedis);
            this.gscale.Controls.Add(this.shades);
            this.gscale.Controls.Add(this.print);
            this.gscale.Controls.Add(this.ss);
            this.gscale.Controls.Add(this.bw);
            this.gscale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gscale.Location = new System.Drawing.Point(1078, 58);
            this.gscale.Name = "gscale";
            this.gscale.Size = new System.Drawing.Size(153, 482);
            this.gscale.TabIndex = 6;
            this.gscale.TabStop = false;
            this.gscale.Text = "Grayscale";
            // 
            // valueRange
            // 
            this.valueRange.AutoSize = true;
            this.valueRange.Location = new System.Drawing.Point(8, 306);
            this.valueRange.Name = "valueRange";
            this.valueRange.Size = new System.Drawing.Size(51, 20);
            this.valueRange.TabIndex = 6;
            this.valueRange.Text = "label1";
            // 
            // fotocopiaRange
            // 
            this.fotocopiaRange.Location = new System.Drawing.Point(9, 258);
            this.fotocopiaRange.Maximum = 255;
            this.fotocopiaRange.Minimum = 10;
            this.fotocopiaRange.Name = "fotocopiaRange";
            this.fotocopiaRange.Size = new System.Drawing.Size(138, 45);
            this.fotocopiaRange.SmallChange = 5;
            this.fotocopiaRange.TabIndex = 5;
            this.fotocopiaRange.Tag = "shades";
            this.fotocopiaRange.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.fotocopiaRange.Value = 10;
            this.fotocopiaRange.Scroll += new System.EventHandler(this.fotocopiaRange_Scroll);
            // 
            // otrosToolStripMenuItem
            // 
            this.otrosToolStripMenuItem.Name = "otrosToolStripMenuItem";
            this.otrosToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.otrosToolStripMenuItem.Text = "Otros";
            // 
            // bordesToolStripMenuItem
            // 
            this.bordesToolStripMenuItem.Name = "bordesToolStripMenuItem";
            this.bordesToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.bordesToolStripMenuItem.Text = "Bordes";
            // 
            // coloresToolStripMenuItem
            // 
            this.coloresToolStripMenuItem.Name = "coloresToolStripMenuItem";
            this.coloresToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.coloresToolStripMenuItem.Text = "Colores";
            // 
            // escalaDeGrisesToolStripMenuItem
            // 
            this.escalaDeGrisesToolStripMenuItem.Name = "escalaDeGrisesToolStripMenuItem";
            this.escalaDeGrisesToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.escalaDeGrisesToolStripMenuItem.Text = "Escala de Grises";
            // 
            // filtrosToolStripMenuItem
            // 
            this.filtrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escalaDeGrisesToolStripMenuItem,
            this.coloresToolStripMenuItem,
            this.bordesToolStripMenuItem,
            this.otrosToolStripMenuItem});
            this.filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            this.filtrosToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.filtrosToolStripMenuItem.Text = "Filtros";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(153, 30);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(153, 30);
            this.cargarToolStripMenuItem.Text = "Cargar";
            this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.filtrosToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1234, 33);
            this.menu.TabIndex = 5;
            this.menu.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1067, 508);
            this.tabControl1.TabIndex = 7;
            // 
            // zoomout
            // 
            this.zoomout.Location = new System.Drawing.Point(1090, 36);
            this.zoomout.Name = "zoomout";
            this.zoomout.Size = new System.Drawing.Size(38, 23);
            this.zoomout.TabIndex = 7;
            this.zoomout.Text = "out";
            this.zoomout.UseVisualStyleBackColor = true;
            this.zoomout.Click += new System.EventHandler(this.zoomout_Click);
            // 
            // zoom
            // 
            this.zoom.Location = new System.Drawing.Point(1134, 36);
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(38, 23);
            this.zoom.TabIndex = 8;
            this.zoom.Text = "zoom";
            this.zoom.UseVisualStyleBackColor = true;
            this.zoom.Click += new System.EventHandler(this.zoom_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 547);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoom);
            this.Controls.Add(this.zoomout);
            this.Controls.Add(this.gscale);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shades)).EndInit();
            this.gscale.ResumeLayout(false);
            this.gscale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fotocopiaRange)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button zoomOutOg;
        private System.Windows.Forms.Button zoomInOg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button zoomOutNew;
        private System.Windows.Forms.Button zoomInNew;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label valuedis;
        private System.Windows.Forms.TrackBar shades;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button ss;
        private System.Windows.Forms.Button bw;
        private System.Windows.Forms.GroupBox gscale;
        private System.Windows.Forms.ToolStripMenuItem otrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bordesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalaDeGrisesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Label valueRange;
        internal System.Windows.Forms.TrackBar fotocopiaRange;
        private System.Windows.Forms.Button zoomout;
        private System.Windows.Forms.Button zoom;
        private System.Windows.Forms.Label label1;
    }
}

