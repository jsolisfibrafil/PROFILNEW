namespace Pesaje
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optPlan = new System.Windows.Forms.RadioButton();
            this.optDespacho = new System.Windows.Forms.RadioButton();
            this.optDiario = new System.Windows.Forms.RadioButton();
            this.optCodebar = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.optProd = new System.Windows.Forms.RadioButton();
            this.optdetprod = new System.Windows.Forms.RadioButton();
            this.optProdMes = new System.Windows.Forms.RadioButton();
            this.Button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnprocess = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.optDiario);
            this.groupBox1.Controls.Add(this.optDespacho);
            this.groupBox1.Controls.Add(this.optPlan);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informes";
            // 
            // optPlan
            // 
            this.optPlan.AutoSize = true;
            this.optPlan.Location = new System.Drawing.Point(41, 36);
            this.optPlan.Name = "optPlan";
            this.optPlan.Size = new System.Drawing.Size(169, 20);
            this.optPlan.TabIndex = 0;
            this.optPlan.TabStop = true;
            this.optPlan.Text = "Informe de planificación";
            this.optPlan.UseVisualStyleBackColor = true;
            // 
            // optDespacho
            // 
            this.optDespacho.AutoSize = true;
            this.optDespacho.Location = new System.Drawing.Point(41, 64);
            this.optDespacho.Name = "optDespacho";
            this.optDespacho.Size = new System.Drawing.Size(162, 20);
            this.optDespacho.TabIndex = 1;
            this.optDespacho.TabStop = true;
            this.optDespacho.Text = "Informe de despachos";
            this.optDespacho.UseVisualStyleBackColor = true;
            // 
            // optDiario
            // 
            this.optDiario.AutoSize = true;
            this.optDiario.Location = new System.Drawing.Point(41, 90);
            this.optDiario.Name = "optDiario";
            this.optDiario.Size = new System.Drawing.Size(133, 20);
            this.optDiario.TabIndex = 2;
            this.optDiario.TabStop = true;
            this.optDiario.Text = "Producción diaria";
            this.optDiario.UseVisualStyleBackColor = true;
            // 
            // optCodebar
            // 
            this.optCodebar.AutoSize = true;
            this.optCodebar.Location = new System.Drawing.Point(250, 90);
            this.optCodebar.Name = "optCodebar";
            this.optCodebar.Size = new System.Drawing.Size(169, 20);
            this.optCodebar.TabIndex = 5;
            this.optCodebar.TabStop = true;
            this.optCodebar.Text = "Búsqueda CODERBAR";
            this.optCodebar.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(250, 64);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(136, 20);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Informe de Kardex";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // optProd
            // 
            this.optProd.AutoSize = true;
            this.optProd.Location = new System.Drawing.Point(250, 36);
            this.optProd.Name = "optProd";
            this.optProd.Size = new System.Drawing.Size(164, 20);
            this.optProd.TabIndex = 3;
            this.optProd.TabStop = true;
            this.optProd.Text = "Informe  de producción";
            this.optProd.UseVisualStyleBackColor = true;
            this.optProd.CheckedChanged += new System.EventHandler(this.btnexport_Click);
            // 
            // optdetprod
            // 
            this.optdetprod.AutoSize = true;
            this.optdetprod.Location = new System.Drawing.Point(450, 64);
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
            this.optProdMes.Location = new System.Drawing.Point(450, 36);
            this.optProdMes.Name = "optProdMes";
            this.optProdMes.Size = new System.Drawing.Size(215, 20);
            this.optProdMes.TabIndex = 6;
            this.optProdMes.TabStop = true;
            this.optProdMes.Text = "Informe de producción mensual";
            this.optProdMes.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(520, 104);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(203, 49);
            this.Button1.TabIndex = 8;
            this.Button1.Text = "Ver Pesos x  dia (Mes actual)";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(830, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 169);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametros desde";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 22);
            this.textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(98, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(201, 22);
            this.textBox2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sede";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Fech Ini";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Fech Fin";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(98, 108);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(149, 22);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(372, 108);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(163, 22);
            this.dateTimePicker2.TabIndex = 17;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnprint);
            this.groupBox3.Controls.Add(this.btnexport);
            this.groupBox3.Controls.Add(this.btnprocess);
            this.groupBox3.Location = new System.Drawing.Point(271, 626);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(742, 91);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // btnprocess
            // 
            this.btnprocess.Location = new System.Drawing.Point(31, 21);
            this.btnprocess.Name = "btnprocess";
            this.btnprocess.Size = new System.Drawing.Size(162, 49);
            this.btnprocess.TabIndex = 0;
            this.btnprocess.Text = "Procesar Informe";
            this.btnprocess.UseVisualStyleBackColor = true;
            this.btnprocess.Click += new System.EventHandler(this.btnprocess_Click);
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(311, 21);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(162, 49);
            this.btnexport.TabIndex = 1;
            this.btnexport.Tag = "";
            this.btnexport.Text = "Exportar Informe";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(559, 21);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(162, 49);
            this.btnprint.TabIndex = 2;
            this.btnprint.Text = "Imprimir Informe";
            this.btnprint.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1440, 401);
            this.dataGridView1.TabIndex = 11;
            // 
            // frmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 743);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmInformes";
            this.Text = "Informes de Sistema";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optDiario;
        private System.Windows.Forms.RadioButton optDespacho;
        private System.Windows.Forms.RadioButton optPlan;
        private System.Windows.Forms.RadioButton optdetprod;
        private System.Windows.Forms.RadioButton optProdMes;
        private System.Windows.Forms.RadioButton optCodebar;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton optProd;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button btnprocess;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}