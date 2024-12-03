namespace Pesaje
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_codigoarticulo = new System.Windows.Forms.TextBox();
            this.tb_descArticulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMaquinaria = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bt_anadir = new System.Windows.Forms.Button();
            this.tb_sede = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.tb_area = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_nameOperario = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_codeOperario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_countbul_s = new System.Windows.Forms.Label();
            this.lbl_pesotot_s = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_pesotot = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_countbul = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_item = new System.Windows.Forms.Label();
            this.lbl_idlin = new System.Windows.Forms.Label();
            this.lbl_linS = new System.Windows.Forms.Label();
            this.sppuerto = new System.IO.Ports.SerialPort(this.components);
            this.imprimirticket = new System.Windows.Forms.Button();
            this.tb_pesoobtenido = new System.Windows.Forms.TextBox();
            this.btnBorrarPesos = new System.Windows.Forms.Button();
            this.grp_combos = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grp_combos.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(343, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Iniciar Pesaje";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.iniciar_pesaje_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo articulo :";
            // 
            // tb_codigoarticulo
            // 
            this.tb_codigoarticulo.Location = new System.Drawing.Point(126, 54);
            this.tb_codigoarticulo.Margin = new System.Windows.Forms.Padding(2);
            this.tb_codigoarticulo.Name = "tb_codigoarticulo";
            this.tb_codigoarticulo.Size = new System.Drawing.Size(256, 20);
            this.tb_codigoarticulo.TabIndex = 2;
            // 
            // tb_descArticulo
            // 
            this.tb_descArticulo.Location = new System.Drawing.Point(126, 74);
            this.tb_descArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.tb_descArticulo.Name = "tb_descArticulo";
            this.tb_descArticulo.Size = new System.Drawing.Size(256, 20);
            this.tb_descArticulo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción del Articulo :";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(592, 29);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(127, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Maquinaria";
            // 
            // cbMaquinaria
            // 
            this.cbMaquinaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaquinaria.FormattingEnabled = true;
            this.cbMaquinaria.Location = new System.Drawing.Point(592, 5);
            this.cbMaquinaria.Margin = new System.Windows.Forms.Padding(2);
            this.cbMaquinaria.Name = "cbMaquinaria";
            this.cbMaquinaria.Size = new System.Drawing.Size(164, 21);
            this.cbMaquinaria.TabIndex = 7;
            this.cbMaquinaria.TextChanged += new System.EventHandler(this.cbMaquinaria_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(386, 55);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 19);
            this.button2.TabIndex = 8;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.event_buscarArticulo);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 422);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(227, 36);
            this.button3.TabIndex = 11;
            this.button3.Text = "Procesar producción";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bt_anadir
            // 
            this.bt_anadir.Location = new System.Drawing.Point(8, 108);
            this.bt_anadir.Margin = new System.Windows.Forms.Padding(2);
            this.bt_anadir.Name = "bt_anadir";
            this.bt_anadir.Size = new System.Drawing.Size(81, 19);
            this.bt_anadir.TabIndex = 12;
            this.bt_anadir.Text = "Añadir Item";
            this.bt_anadir.UseVisualStyleBackColor = true;
            this.bt_anadir.Click += new System.EventHandler(this.bt_anadir_Click);
            // 
            // tb_sede
            // 
            this.tb_sede.Location = new System.Drawing.Point(44, 5);
            this.tb_sede.Margin = new System.Windows.Forms.Padding(2);
            this.tb_sede.Name = "tb_sede";
            this.tb_sede.ReadOnly = true;
            this.tb_sede.Size = new System.Drawing.Size(23, 20);
            this.tb_sede.TabIndex = 14;
            this.tb_sede.Text = "03";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Sede";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 130);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(428, 160);
            this.listBox1.TabIndex = 15;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 306);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Articulo Producir :";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(96, 306);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(11, 13);
            this.lbl_count.TabIndex = 17;
            this.lbl_count.Text = "*";
            // 
            // tb_area
            // 
            this.tb_area.Location = new System.Drawing.Point(110, 5);
            this.tb_area.Margin = new System.Windows.Forms.Padding(2);
            this.tb_area.Name = "tb_area";
            this.tb_area.ReadOnly = true;
            this.tb_area.Size = new System.Drawing.Size(23, 20);
            this.tb_area.TabIndex = 19;
            this.tb_area.Text = "A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Area :";
            // 
            // tb_nameOperario
            // 
            this.tb_nameOperario.Location = new System.Drawing.Point(194, 5);
            this.tb_nameOperario.Margin = new System.Windows.Forms.Padding(2);
            this.tb_nameOperario.Name = "tb_nameOperario";
            this.tb_nameOperario.ReadOnly = true;
            this.tb_nameOperario.Size = new System.Drawing.Size(145, 20);
            this.tb_nameOperario.TabIndex = 21;
            this.tb_nameOperario.Text = "HUAYHUAPOMA:LEON";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Operario :";
            // 
            // tb_codeOperario
            // 
            this.tb_codeOperario.Location = new System.Drawing.Point(194, 31);
            this.tb_codeOperario.Margin = new System.Windows.Forms.Padding(2);
            this.tb_codeOperario.Name = "tb_codeOperario";
            this.tb_codeOperario.ReadOnly = true;
            this.tb_codeOperario.Size = new System.Drawing.Size(38, 20);
            this.tb_codeOperario.TabIndex = 23;
            this.tb_codeOperario.Text = "152";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Codigo :";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(509, 130);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(325, 160);
            this.listBox2.TabIndex = 24;
            this.listBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox2_KeyDown);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(509, 330);
            this.listBox3.Margin = new System.Windows.Forms.Padding(2);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(325, 82);
            this.listBox3.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(509, 310);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Cant Bultos :";
            // 
            // lbl_countbul_s
            // 
            this.lbl_countbul_s.AutoSize = true;
            this.lbl_countbul_s.Location = new System.Drawing.Point(574, 310);
            this.lbl_countbul_s.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_countbul_s.Name = "lbl_countbul_s";
            this.lbl_countbul_s.Size = new System.Drawing.Size(11, 13);
            this.lbl_countbul_s.TabIndex = 27;
            this.lbl_countbul_s.Text = "*";
            // 
            // lbl_pesotot_s
            // 
            this.lbl_pesotot_s.AutoSize = true;
            this.lbl_pesotot_s.Location = new System.Drawing.Point(693, 310);
            this.lbl_pesotot_s.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pesotot_s.Name = "lbl_pesotot_s";
            this.lbl_pesotot_s.Size = new System.Drawing.Size(11, 13);
            this.lbl_pesotot_s.TabIndex = 29;
            this.lbl_pesotot_s.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(628, 310);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Peso Total :";
            // 
            // lbl_pesotot
            // 
            this.lbl_pesotot.AutoSize = true;
            this.lbl_pesotot.Location = new System.Drawing.Point(692, 110);
            this.lbl_pesotot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_pesotot.Name = "lbl_pesotot";
            this.lbl_pesotot.Size = new System.Drawing.Size(11, 13);
            this.lbl_pesotot.TabIndex = 33;
            this.lbl_pesotot.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(628, 110);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Peso Total :";
            // 
            // lbl_countbul
            // 
            this.lbl_countbul.AutoSize = true;
            this.lbl_countbul.Location = new System.Drawing.Point(573, 110);
            this.lbl_countbul.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_countbul.Name = "lbl_countbul";
            this.lbl_countbul.Size = new System.Drawing.Size(11, 13);
            this.lbl_countbul.TabIndex = 31;
            this.lbl_countbul.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(508, 110);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Cant Bultos :";
            // 
            // lbl_item
            // 
            this.lbl_item.AutoSize = true;
            this.lbl_item.Location = new System.Drawing.Point(453, 78);
            this.lbl_item.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_item.Name = "lbl_item";
            this.lbl_item.Size = new System.Drawing.Size(19, 13);
            this.lbl_item.TabIndex = 34;
            this.lbl_item.Text = "----";
            // 
            // lbl_idlin
            // 
            this.lbl_idlin.AutoSize = true;
            this.lbl_idlin.Location = new System.Drawing.Point(9, 338);
            this.lbl_idlin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_idlin.Name = "lbl_idlin";
            this.lbl_idlin.Size = new System.Drawing.Size(41, 13);
            this.lbl_idlin.TabIndex = 35;
            this.lbl_idlin.Text = "lbl_idlin";
            // 
            // lbl_linS
            // 
            this.lbl_linS.AutoSize = true;
            this.lbl_linS.Location = new System.Drawing.Point(10, 359);
            this.lbl_linS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_linS.Name = "lbl_linS";
            this.lbl_linS.Size = new System.Drawing.Size(40, 13);
            this.lbl_linS.TabIndex = 36;
            this.lbl_linS.Text = "lbl_linS";
            // 
            // imprimirticket
            // 
            this.imprimirticket.Location = new System.Drawing.Point(364, 422);
            this.imprimirticket.Margin = new System.Windows.Forms.Padding(2);
            this.imprimirticket.Name = "imprimirticket";
            this.imprimirticket.Size = new System.Drawing.Size(70, 36);
            this.imprimirticket.TabIndex = 38;
            this.imprimirticket.Text = "Imprimir";
            this.imprimirticket.UseVisualStyleBackColor = true;
            this.imprimirticket.Visible = false;
            this.imprimirticket.Click += new System.EventHandler(this.imprimirticket_Click);
            // 
            // tb_pesoobtenido
            // 
            this.tb_pesoobtenido.Enabled = false;
            this.tb_pesoobtenido.Location = new System.Drawing.Point(343, 30);
            this.tb_pesoobtenido.Margin = new System.Windows.Forms.Padding(2);
            this.tb_pesoobtenido.Name = "tb_pesoobtenido";
            this.tb_pesoobtenido.ReadOnly = true;
            this.tb_pesoobtenido.Size = new System.Drawing.Size(119, 20);
            this.tb_pesoobtenido.TabIndex = 39;
            this.tb_pesoobtenido.TextChanged += new System.EventHandler(this.tb_pesoobtenido_TextChanged);
            // 
            // btnBorrarPesos
            // 
            this.btnBorrarPesos.Location = new System.Drawing.Point(734, 427);
            this.btnBorrarPesos.Margin = new System.Windows.Forms.Padding(2);
            this.btnBorrarPesos.Name = "btnBorrarPesos";
            this.btnBorrarPesos.Size = new System.Drawing.Size(100, 28);
            this.btnBorrarPesos.TabIndex = 40;
            this.btnBorrarPesos.Text = "Borra pesos";
            this.btnBorrarPesos.UseVisualStyleBackColor = true;
            this.btnBorrarPesos.Click += new System.EventHandler(this.btnBorrarPesos_Click);
            // 
            // grp_combos
            // 
            this.grp_combos.BackColor = System.Drawing.SystemColors.HotTrack;
            this.grp_combos.Controls.Add(this.comboBox2);
            this.grp_combos.Controls.Add(this.comboBox1);
            this.grp_combos.Controls.Add(this.button4);
            this.grp_combos.Controls.Add(this.label13);
            this.grp_combos.Controls.Add(this.label15);
            this.grp_combos.Controls.Add(this.label10);
            this.grp_combos.Location = new System.Drawing.Point(234, 172);
            this.grp_combos.Margin = new System.Windows.Forms.Padding(2);
            this.grp_combos.Name = "grp_combos";
            this.grp_combos.Padding = new System.Windows.Forms.Padding(2);
            this.grp_combos.Size = new System.Drawing.Size(525, 136);
            this.grp_combos.TabIndex = 41;
            this.grp_combos.TabStop = false;
            this.grp_combos.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(341, 50);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(152, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(71, 52);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 95);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 19);
            this.button4.TabIndex = 4;
            this.button4.Text = "Confirmar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.event_confirmar);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Yellow;
            this.label13.Location = new System.Drawing.Point(272, 54);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 3;
            this.label13.Text = "Ayudante";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Yellow;
            this.label15.Location = new System.Drawing.Point(8, 54);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 17);
            this.label15.TabIndex = 2;
            this.label15.Text = "Operario ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(11, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(205, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Confirme los siguientes datos...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 517);
            this.Controls.Add(this.grp_combos);
            this.Controls.Add(this.btnBorrarPesos);
            this.Controls.Add(this.tb_pesoobtenido);
            this.Controls.Add(this.imprimirticket);
            this.Controls.Add(this.lbl_linS);
            this.Controls.Add(this.lbl_idlin);
            this.Controls.Add(this.lbl_item);
            this.Controls.Add(this.lbl_pesotot);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl_countbul);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lbl_pesotot_s);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl_countbul_s);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.tb_codeOperario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_nameOperario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_area);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tb_sede);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bt_anadir);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbMaquinaria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.tb_descArticulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_codigoarticulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Pesaje";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.event_clickAnadirItem);
            this.grp_combos.ResumeLayout(false);
            this.grp_combos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_codigoarticulo;
        private System.Windows.Forms.TextBox tb_descArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMaquinaria;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button bt_anadir;
        private System.Windows.Forms.TextBox tb_sede;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.TextBox tb_area;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_nameOperario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_codeOperario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_countbul_s;
        private System.Windows.Forms.Label lbl_pesotot_s;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_pesotot;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_countbul;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_item;
        private System.Windows.Forms.Label lbl_idlin;
        private System.Windows.Forms.Label lbl_linS;
        private System.IO.Ports.SerialPort sppuerto;
        private System.Windows.Forms.Button imprimirticket;
        private System.Windows.Forms.TextBox tb_pesoobtenido;
        private System.Windows.Forms.Button btnBorrarPesos;
        private System.Windows.Forms.GroupBox grp_combos;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

