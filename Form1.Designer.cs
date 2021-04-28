
namespace videoclub
{
    partial class FormVideoClub
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.catálogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPelicula = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVideoJuego = new System.Windows.Forms.ToolStripMenuItem();
            this.alquilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAltaAlquiler = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBajaAlquiler = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuListaAlquiler = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catálogosToolStripMenuItem,
            this.alquilerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // catálogosToolStripMenuItem
            // 
            this.catálogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCliente,
            this.mnuPelicula,
            this.mnuVideoJuego});
            this.catálogosToolStripMenuItem.Name = "catálogosToolStripMenuItem";
            this.catálogosToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.catálogosToolStripMenuItem.Text = "Catálogos";
            // 
            // mnuCliente
            // 
            this.mnuCliente.Name = "mnuCliente";
            this.mnuCliente.Size = new System.Drawing.Size(139, 22);
            this.mnuCliente.Text = "Clientes";
            this.mnuCliente.Click += new System.EventHandler(this.mnuCliente_Click);
            // 
            // mnuPelicula
            // 
            this.mnuPelicula.Name = "mnuPelicula";
            this.mnuPelicula.Size = new System.Drawing.Size(139, 22);
            this.mnuPelicula.Text = "Peliculas";
            this.mnuPelicula.Click += new System.EventHandler(this.mnuPelicula_Click);
            // 
            // mnuVideoJuego
            // 
            this.mnuVideoJuego.Name = "mnuVideoJuego";
            this.mnuVideoJuego.Size = new System.Drawing.Size(139, 22);
            this.mnuVideoJuego.Text = "Videojuegos";
            this.mnuVideoJuego.Click += new System.EventHandler(this.mnuVideoJuego_Click);
            // 
            // alquilerToolStripMenuItem
            // 
            this.alquilerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAltaAlquiler,
            this.mnuBajaAlquiler,
            this.mnuListaAlquiler});
            this.alquilerToolStripMenuItem.Name = "alquilerToolStripMenuItem";
            this.alquilerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.alquilerToolStripMenuItem.Text = "Alquiler";
            // 
            // mnuAltaAlquiler
            // 
            this.mnuAltaAlquiler.Name = "mnuAltaAlquiler";
            this.mnuAltaAlquiler.Size = new System.Drawing.Size(162, 22);
            this.mnuAltaAlquiler.Text = "Realizar alquiler";
            this.mnuAltaAlquiler.Click += new System.EventHandler(this.mnuAltaAlquiler_Click);
            // 
            // mnuBajaAlquiler
            // 
            this.mnuBajaAlquiler.Name = "mnuBajaAlquiler";
            this.mnuBajaAlquiler.Size = new System.Drawing.Size(162, 22);
            this.mnuBajaAlquiler.Text = "Devolver alquiler";
            this.mnuBajaAlquiler.Click += new System.EventHandler(this.mnuBajaAlquiler_Click);
            // 
            // mnuListaAlquiler
            // 
            this.mnuListaAlquiler.Name = "mnuListaAlquiler";
            this.mnuListaAlquiler.Size = new System.Drawing.Size(162, 22);
            this.mnuListaAlquiler.Text = "Listar alquiler";
            this.mnuListaAlquiler.Click += new System.EventHandler(this.mnuListaAlquiler_Click);
            // 
            // FormVideoClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormVideoClub";
            this.Text = "Videoclub";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormVideoClub_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem catálogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCliente;
        private System.Windows.Forms.ToolStripMenuItem mnuPelicula;
        private System.Windows.Forms.ToolStripMenuItem mnuVideoJuego;
        private System.Windows.Forms.ToolStripMenuItem alquilerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAltaAlquiler;
        private System.Windows.Forms.ToolStripMenuItem mnuBajaAlquiler;
        private System.Windows.Forms.ToolStripMenuItem mnuListaAlquiler;
    }
}

