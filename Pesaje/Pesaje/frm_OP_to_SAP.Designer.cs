namespace Pesaje
{
    partial class frm_OP_to_SAP
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_sede = new System.Windows.Forms.ComboBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_AddNO = new System.Windows.Forms.RadioButton();
            this.rb_AddSi = new System.Windows.Forms.RadioButton();
            this.rb_kilos = new System.Windows.Forms.RadioButton();
            this.rb_unid = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_SAP = new System.Windows.Forms.Button();
            this.cmb_normr = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_cant = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.lbl_cantdetalle = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_prod = new System.Windows.Forms.Label();
            this.lbl_canti = new System.Windows.Forms.Label();
            this.lbl_peso = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(983, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SEDE : ";
            // 
            // cmb_sede
            // 
            this.cmb_sede.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_sede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_sede.FormattingEnabled = true;
            this.cmb_sede.Location = new System.Drawing.Point(1051, 12);
            this.cmb_sede.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_sede.Name = "cmb_sede";
            this.cmb_sede.Size = new System.Drawing.Size(184, 24);
            this.cmb_sede.TabIndex = 1;
            this.cmb_sede.SelectedIndexChanged += new System.EventHandler(this.cmb_sede_SelectedIndexChanged);
            // 
            // DataGridView1
            // 
            this.DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(16, 46);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersWidth = 51;
            this.DataGridView1.Size = new System.Drawing.Size(1220, 314);
            this.DataGridView1.TabIndex = 2;
            this.DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // DataGridView2
            // 
            this.DataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Location = new System.Drawing.Point(16, 399);
            this.DataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.RowHeadersWidth = 51;
            this.DataGridView2.Size = new System.Drawing.Size(1220, 202);
            this.DataGridView2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 624);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 624);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.lbl_peso);
            this.GroupBox1.Controls.Add(this.lbl_canti);
            this.GroupBox1.Controls.Add(this.lbl_prod);
            this.GroupBox1.Controls.Add(this.groupBox2);
            this.GroupBox1.Controls.Add(this.rb_kilos);
            this.GroupBox1.Controls.Add(this.rb_unid);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.btn_SAP);
            this.GroupBox1.Controls.Add(this.cmb_normr);
            this.GroupBox1.Location = new System.Drawing.Point(33, 412);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Size = new System.Drawing.Size(916, 170);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Visible = false;
            this.GroupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_AddNO);
            this.groupBox2.Controls.Add(this.rb_AddSi);
            this.groupBox2.Location = new System.Drawing.Point(673, 63);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(223, 94);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adicionar Scrap";
            // 
            // rb_AddNO
            // 
            this.rb_AddNO.AutoSize = true;
            this.rb_AddNO.Location = new System.Drawing.Point(128, 52);
            this.rb_AddNO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_AddNO.Name = "rb_AddNO";
            this.rb_AddNO.Size = new System.Drawing.Size(48, 20);
            this.rb_AddNO.TabIndex = 1;
            this.rb_AddNO.TabStop = true;
            this.rb_AddNO.Text = "NO";
            this.rb_AddNO.UseVisualStyleBackColor = true;
            // 
            // rb_AddSi
            // 
            this.rb_AddSi.AutoSize = true;
            this.rb_AddSi.Location = new System.Drawing.Point(39, 52);
            this.rb_AddSi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_AddSi.Name = "rb_AddSi";
            this.rb_AddSi.Size = new System.Drawing.Size(40, 20);
            this.rb_AddSi.TabIndex = 0;
            this.rb_AddSi.TabStop = true;
            this.rb_AddSi.Text = "SI";
            this.rb_AddSi.UseVisualStyleBackColor = true;
            // 
            // rb_kilos
            // 
            this.rb_kilos.AutoSize = true;
            this.rb_kilos.Location = new System.Drawing.Point(344, 118);
            this.rb_kilos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_kilos.Name = "rb_kilos";
            this.rb_kilos.Size = new System.Drawing.Size(57, 20);
            this.rb_kilos.TabIndex = 6;
            this.rb_kilos.TabStop = true;
            this.rb_kilos.Text = "Kilos";
            this.rb_kilos.UseVisualStyleBackColor = true;
            // 
            // rb_unid
            // 
            this.rb_unid.AutoSize = true;
            this.rb_unid.Location = new System.Drawing.Point(195, 118);
            this.rb_unid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb_unid.Name = "rb_unid";
            this.rb_unid.Size = new System.Drawing.Size(87, 20);
            this.rb_unid.TabIndex = 5;
            this.rb_unid.TabStop = true;
            this.rb_unid.Text = "Unidades";
            this.rb_unid.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Peso : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cantidad : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Producto : ";
            // 
            // btn_SAP
            // 
            this.btn_SAP.Location = new System.Drawing.Point(40, 114);
            this.btn_SAP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SAP.Name = "btn_SAP";
            this.btn_SAP.Size = new System.Drawing.Size(100, 28);
            this.btn_SAP.TabIndex = 1;
            this.btn_SAP.Text = "A SAP";
            this.btn_SAP.UseVisualStyleBackColor = true;
            this.btn_SAP.Click += new System.EventHandler(this.Button1_Click);
            // 
            // cmb_normr
            // 
            this.cmb_normr.FormattingEnabled = true;
            this.cmb_normr.Location = new System.Drawing.Point(736, 24);
            this.cmb_normr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_normr.Name = "cmb_normr";
            this.cmb_normr.Size = new System.Drawing.Size(160, 24);
            this.cmb_normr.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(737, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "CANTIDAD : ";
            // 
            // lbl_cant
            // 
            this.lbl_cant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cant.AutoSize = true;
            this.lbl_cant.Location = new System.Drawing.Point(855, 16);
            this.lbl_cant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cant.Name = "lbl_cant";
            this.lbl_cant.Size = new System.Drawing.Size(14, 16);
            this.lbl_cant.TabIndex = 8;
            this.lbl_cant.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1112, 608);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 44);
            this.button4.TabIndex = 9;
            this.button4.Text = "Cancelar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // lbl_cantdetalle
            // 
            this.lbl_cantdetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_cantdetalle.AutoSize = true;
            this.lbl_cantdetalle.Location = new System.Drawing.Point(855, 369);
            this.lbl_cantdetalle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cantdetalle.Name = "lbl_cantdetalle";
            this.lbl_cantdetalle.Size = new System.Drawing.Size(14, 16);
            this.lbl_cantdetalle.TabIndex = 11;
            this.lbl_cantdetalle.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(737, 369);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "CANTIDAD : ";
            // 
            // lbl_prod
            // 
            this.lbl_prod.AutoSize = true;
            this.lbl_prod.Location = new System.Drawing.Point(131, 27);
            this.lbl_prod.Name = "lbl_prod";
            this.lbl_prod.Size = new System.Drawing.Size(28, 20);
            this.lbl_prod.TabIndex = 8;
            this.lbl_prod.Text = "***";
            // 
            // lbl_canti
            // 
            this.lbl_canti.AutoSize = true;
            this.lbl_canti.Location = new System.Drawing.Point(131, 63);
            this.lbl_canti.Name = "lbl_canti";
            this.lbl_canti.Size = new System.Drawing.Size(28, 20);
            this.lbl_canti.TabIndex = 9;
            this.lbl_canti.Text = "***";
            // 
            // lbl_peso
            // 
            this.lbl_peso.AutoSize = true;
            this.lbl_peso.Location = new System.Drawing.Point(303, 63);
            this.lbl_peso.Name = "lbl_peso";
            this.lbl_peso.Size = new System.Drawing.Size(22, 16);
            this.lbl_peso.TabIndex = 10;
            this.lbl_peso.Text = "***";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(603, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Norma Reparto : ";
            // 
            // frm_OP_to_SAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 663);
            this.Controls.Add(this.lbl_cantdetalle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lbl_cant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DataGridView2);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.cmb_sede);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_OP_to_SAP";
            this.Text = "Exportacion de O/P a SAP";
            this.Load += new System.EventHandler(this.frm_OP_to_SAP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_sede;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.DataGridView DataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.ComboBox cmb_normr;
        private System.Windows.Forms.Button btn_SAP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_cant;
        private System.Windows.Forms.RadioButton rb_unid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_AddNO;
        private System.Windows.Forms.RadioButton rb_AddSi;
        private System.Windows.Forms.RadioButton rb_kilos;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbl_cantdetalle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_canti;
        private System.Windows.Forms.Label lbl_prod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_peso;
    }
}