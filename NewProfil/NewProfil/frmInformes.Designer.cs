﻿namespace Pesaje
{
    partial class frmInformes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optProd = new System.Windows.Forms.RadioButton();
            this.Button1 = new System.Windows.Forms.Button();
            this.optdetprod = new System.Windows.Forms.RadioButton();
            this.optProdMes = new System.Windows.Forms.RadioButton();
            this.optCodebar = new System.Windows.Forms.RadioButton();
            this.optKardex = new System.Windows.Forms.RadioButton();
            this.optDiario = new System.Windows.Forms.RadioButton();
            this.optDespacho = new System.Windows.Forms.RadioButton();
            this.optPlan = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_sede = new System.Windows.Forms.Label();
            this.dtpFfin = new System.Windows.Forms.DateTimePicker();
            this.dtpFini = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_s_Maq = new System.Windows.Forms.TextBox();
            this.txtItm1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.btnprocess = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.cantFilas = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optProd);
            this.groupBox1.Controls.Add(this.Button1);
            this.groupBox1.Controls.Add(this.optdetprod);
            this.groupBox1.Controls.Add(this.optProdMes);
            this.groupBox1.Controls.Add(this.optCodebar);
            this.groupBox1.Controls.Add(this.optKardex);
            this.groupBox1.Controls.Add(this.optDiario);
            this.groupBox1.Controls.Add(this.optDespacho);
            this.groupBox1.Controls.Add(this.optPlan);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(749, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informes";
            // 
            // optProd
            // 
            this.optProd.AutoSize = true;
            this.optProd.Location = new System.Drawing.Point(251, 36);
            this.optProd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optProd.Name = "optProd";
            this.optProd.Size = new System.Drawing.Size(164, 20);
            this.optProd.TabIndex = 3;
            this.optProd.TabStop = true;
            this.optProd.Text = "Informe  de producción";
            this.optProd.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(520, 103);
            this.Button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(203, 49);
            this.Button1.TabIndex = 8;
            this.Button1.Text = "Ver Pesos x  dia (Mes actual)";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // optdetprod
            // 
            this.optdetprod.AutoSize = true;
            this.optdetprod.Location = new System.Drawing.Point(451, 64);
            this.optdetprod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optdetprod.Name = "optdetprod";
            this.optdetprod.Size = new System.Drawing.Size(141, 20);
            this.optdetprod.TabIndex = 7;
            this.optdetprod.TabStop = true;
            this.optdetprod.Text = "Detalle producción";
            this.optdetprod.UseVisualStyleBackColor = true;
            // 
            // optProdMes
            // 
            this.optProdMes.AutoSize = true;
            this.optProdMes.Location = new System.Drawing.Point(451, 36);
            this.optProdMes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optProdMes.Name = "optProdMes";
            this.optProdMes.Size = new System.Drawing.Size(215, 20);
            this.optProdMes.TabIndex = 6;
            this.optProdMes.TabStop = true;
            this.optProdMes.Text = "Informe de producción mensual";
            this.optProdMes.UseVisualStyleBackColor = true;
            // 
            // optCodebar
            // 
            this.optCodebar.AutoSize = true;
            this.optCodebar.Location = new System.Drawing.Point(251, 90);
            this.optCodebar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optCodebar.Name = "optCodebar";
            this.optCodebar.Size = new System.Drawing.Size(169, 20);
            this.optCodebar.TabIndex = 5;
            this.optCodebar.TabStop = true;
            this.optCodebar.Text = "Búsqueda CODERBAR";
            this.optCodebar.UseVisualStyleBackColor = true;
            // 
            // optKardex
            // 
            this.optKardex.AutoSize = true;
            this.optKardex.Location = new System.Drawing.Point(251, 64);
            this.optKardex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optKardex.Name = "optKardex";
            this.optKardex.Size = new System.Drawing.Size(136, 20);
            this.optKardex.TabIndex = 4;
            this.optKardex.TabStop = true;
            this.optKardex.Text = "Informe de Kardex";
            this.optKardex.UseVisualStyleBackColor = true;
            // 
            // optDiario
            // 
            this.optDiario.AutoSize = true;
            this.optDiario.Location = new System.Drawing.Point(41, 90);
            this.optDiario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optDiario.Name = "optDiario";
            this.optDiario.Size = new System.Drawing.Size(133, 20);
            this.optDiario.TabIndex = 2;
            this.optDiario.TabStop = true;
            this.optDiario.Text = "Producción diaria";
            this.optDiario.UseVisualStyleBackColor = true;
            // 
            // optDespacho
            // 
            this.optDespacho.AutoSize = true;
            this.optDespacho.Location = new System.Drawing.Point(41, 64);
            this.optDespacho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optDespacho.Name = "optDespacho";
            this.optDespacho.Size = new System.Drawing.Size(162, 20);
            this.optDespacho.TabIndex = 1;
            this.optDespacho.TabStop = true;
            this.optDespacho.Text = "Informe de despachos";
            this.optDespacho.UseVisualStyleBackColor = true;
            // 
            // optPlan
            // 
            this.optPlan.AutoSize = true;
            this.optPlan.Location = new System.Drawing.Point(41, 36);
            this.optPlan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optPlan.Name = "optPlan";
            this.optPlan.Size = new System.Drawing.Size(169, 20);
            this.optPlan.TabIndex = 0;
            this.optPlan.TabStop = true;
            this.optPlan.Text = "Informe de planificación";
            this.optPlan.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_sede);
            this.groupBox2.Controls.Add(this.dtpFfin);
            this.groupBox2.Controls.Add(this.dtpFini);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_s_Maq);
            this.groupBox2.Controls.Add(this.txtItm1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(829, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(531, 169);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametros desde";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lb_sede
            // 
            this.lb_sede.AutoSize = true;
            this.lb_sede.Location = new System.Drawing.Point(411, 36);
            this.lb_sede.Name = "lb_sede";
            this.lb_sede.Size = new System.Drawing.Size(19, 20);
            this.lb_sede.TabIndex = 18;
            this.lb_sede.Text = "--";
            // 
            // dtpFfin
            // 
            this.dtpFfin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFfin.Location = new System.Drawing.Point(372, 108);
            this.dtpFfin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFfin.Name = "dtpFfin";
            this.dtpFfin.Size = new System.Drawing.Size(135, 22);
            this.dtpFfin.TabIndex = 17;
            // 
            // dtpFini
            // 
            this.dtpFini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFini.Location = new System.Drawing.Point(99, 108);
            this.dtpFini.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFini.Name = "dtpFini";
            this.dtpFini.Size = new System.Drawing.Size(123, 22);
            this.dtpFini.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Fech Fin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Fech Ini";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sede";
            // 
            // txt_s_Maq
            // 
            this.txt_s_Maq.Location = new System.Drawing.Point(99, 63);
            this.txt_s_Maq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_s_Maq.Name = "txt_s_Maq";
            this.txt_s_Maq.Size = new System.Drawing.Size(201, 22);
            this.txt_s_Maq.TabIndex = 12;
            // 
            // txtItm1
            // 
            this.txtItm1.Location = new System.Drawing.Point(99, 33);
            this.txtItm1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtItm1.Name = "txtItm1";
            this.txtItm1.Size = new System.Drawing.Size(201, 22);
            this.txtItm1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Maquina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Item";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnexport);
            this.groupBox3.Controls.Add(this.btnprint);
            this.groupBox3.Controls.Add(this.btnprocess);
            this.groupBox3.Location = new System.Drawing.Point(271, 626);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(741, 91);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(559, 21);
            this.btnprint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(163, 49);
            this.btnprint.TabIndex = 2;
            this.btnprint.Text = "Imprimir Informe";
            this.btnprint.UseVisualStyleBackColor = true;
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(311, 21);
            this.btnexport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(163, 49);
            this.btnexport.TabIndex = 1;
            this.btnexport.Tag = "";
            this.btnexport.Text = "Exportar Informe";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // btnprocess
            // 
            this.btnprocess.Location = new System.Drawing.Point(31, 21);
            this.btnprocess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnprocess.Name = "btnprocess";
            this.btnprocess.Size = new System.Drawing.Size(163, 49);
            this.btnprocess.TabIndex = 0;
            this.btnprocess.Text = "Procesar Informe";
            this.btnprocess.UseVisualStyleBackColor = true;
            this.btnprocess.Click += new System.EventHandler(this.btnprocess_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(24, 203);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1361, 392);
            this.dataGridView1.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1123, 661);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cantidad de resultados : ";
            // 
            // cantFilas
            // 
            this.cantFilas.AutoSize = true;
            this.cantFilas.Location = new System.Drawing.Point(1304, 661);
            this.cantFilas.Name = "cantFilas";
            this.cantFilas.Size = new System.Drawing.Size(14, 16);
            this.cantFilas.TabIndex = 13;
            this.cantFilas.Text = "0";
            // 
            // frmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 743);
            this.Controls.Add(this.cantFilas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmInformes";
            this.Text = "Informes de Sistema";
            this.Load += new System.EventHandler(this.frmInformes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optDiario;
        private System.Windows.Forms.RadioButton optDespacho;
        private System.Windows.Forms.RadioButton optPlan;
        private System.Windows.Forms.RadioButton optdetprod;
        private System.Windows.Forms.RadioButton optProdMes;
        private System.Windows.Forms.RadioButton optCodebar;
        private System.Windows.Forms.RadioButton optKardex;
        private System.Windows.Forms.RadioButton optProd;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_s_Maq;
        private System.Windows.Forms.TextBox txtItm1;
        private System.Windows.Forms.DateTimePicker dtpFfin;
        private System.Windows.Forms.DateTimePicker dtpFini;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button btnprocess;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lb_sede;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label cantFilas;
    }
}