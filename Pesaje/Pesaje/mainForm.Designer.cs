namespace Pesaje
{
    partial class mainForm
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
            this.mAESTROSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPERACIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enProducciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enAlmacenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enGestiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeIntegradoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dATOSPRODUCCIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.producciónMasivaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recepcionDeProducciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAESTROSToolStripMenuItem,
            this.oPERACIONESToolStripMenuItem,
            this.dATOSPRODUCCIONToolStripMenuItem,
            this.vERToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1632, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mAESTROSToolStripMenuItem
            // 
            this.mAESTROSToolStripMenuItem.Name = "mAESTROSToolStripMenuItem";
            this.mAESTROSToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.mAESTROSToolStripMenuItem.Text = "MAESTROS";
            // 
            // oPERACIONESToolStripMenuItem
            // 
            this.oPERACIONESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enProducciónToolStripMenuItem,
            this.enAlmacenToolStripMenuItem,
            this.enGestiónToolStripMenuItem,
            this.informeIntegradoToolStripMenuItem});
            this.oPERACIONESToolStripMenuItem.Name = "oPERACIONESToolStripMenuItem";
            this.oPERACIONESToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.oPERACIONESToolStripMenuItem.Text = "OPERACIONES";
            // 
            // enProducciónToolStripMenuItem
            // 
            this.enProducciónToolStripMenuItem.Name = "enProducciónToolStripMenuItem";
            this.enProducciónToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.enProducciónToolStripMenuItem.Text = "En Producción";
            // 
            // enAlmacenToolStripMenuItem
            // 
            this.enAlmacenToolStripMenuItem.Name = "enAlmacenToolStripMenuItem";
            this.enAlmacenToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.enAlmacenToolStripMenuItem.Text = "En Almacen";
            // 
            // enGestiónToolStripMenuItem
            // 
            this.enGestiónToolStripMenuItem.Name = "enGestiónToolStripMenuItem";
            this.enGestiónToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.enGestiónToolStripMenuItem.Text = "En Gestión";
            // 
            // informeIntegradoToolStripMenuItem
            // 
            this.informeIntegradoToolStripMenuItem.Name = "informeIntegradoToolStripMenuItem";
            this.informeIntegradoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.informeIntegradoToolStripMenuItem.Text = "Informe Integrado";
            this.informeIntegradoToolStripMenuItem.Click += new System.EventHandler(this.InformeIntegradoToolStripMenuItem_Click);
            // 
            // vERToolStripMenuItem
            // 
            this.vERToolStripMenuItem.Name = "vERToolStripMenuItem";
            this.vERToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.vERToolStripMenuItem.Text = "VER";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // dATOSPRODUCCIONToolStripMenuItem
            // 
            this.dATOSPRODUCCIONToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.producciónMasivaToolStripMenuItem,
            this.recepcionDeProducciónToolStripMenuItem});
            this.dATOSPRODUCCIONToolStripMenuItem.Name = "dATOSPRODUCCIONToolStripMenuItem";
            this.dATOSPRODUCCIONToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.dATOSPRODUCCIONToolStripMenuItem.Text = "DATOS PRODUCCION";
            this.dATOSPRODUCCIONToolStripMenuItem.Click += new System.EventHandler(this.dATOSPRODUCCIONToolStripMenuItem_Click);
            // 
            // producciónMasivaToolStripMenuItem
            // 
            this.producciónMasivaToolStripMenuItem.Name = "producciónMasivaToolStripMenuItem";
            this.producciónMasivaToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.producciónMasivaToolStripMenuItem.Text = "Producción Masiva";
            this.producciónMasivaToolStripMenuItem.Click += new System.EventHandler(this.producciónMasivaToolStripMenuItem_Click);
            // 
            // recepcionDeProducciónToolStripMenuItem
            // 
            this.recepcionDeProducciónToolStripMenuItem.Name = "recepcionDeProducciónToolStripMenuItem";
            this.recepcionDeProducciónToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.recepcionDeProducciónToolStripMenuItem.Text = "Recepcion de Producción";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 890);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "ProfilNew";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mAESTROSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPERACIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enProducciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enAlmacenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enGestiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeIntegradoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dATOSPRODUCCIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem producciónMasivaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recepcionDeProducciónToolStripMenuItem;
    }
}