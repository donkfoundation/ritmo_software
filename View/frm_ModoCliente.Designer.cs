namespace hotel_nn
{
    partial class frm_ModoCliente
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
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_NombreCliente = new System.Windows.Forms.Label();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.dtp_FechaCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_CantidadHuespedes = new System.Windows.Forms.ComboBox();
            this.cb_HabitacionesDisp = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_PrecioHabitacion = new System.Windows.Forms.TextBox();
            this.cb_Paquetes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_PrecioPaquetes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_DescripPaquete = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_TipoPago = new System.Windows.Forms.ComboBox();
            this.checkb_PagoAnticipado = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_PagoAnticipado = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.dtp_FechaCheckIn = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservar Habitación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(486, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Registrado como:";
            // 
            // lbl_NombreCliente
            // 
            this.lbl_NombreCliente.AutoSize = true;
            this.lbl_NombreCliente.Location = new System.Drawing.Point(582, 19);
            this.lbl_NombreCliente.Name = "lbl_NombreCliente";
            this.lbl_NombreCliente.Size = new System.Drawing.Size(66, 13);
            this.lbl_NombreCliente.TabIndex = 2;
            this.lbl_NombreCliente.Text = "XXXX XXXX";
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Salir.FlatAppearance.BorderSize = 0;
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir.Location = new System.Drawing.Point(603, 343);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(75, 23);
            this.btn_Salir.TabIndex = 3;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = false;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // dtp_FechaCheckOut
            // 
            this.dtp_FechaCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaCheckOut.Location = new System.Drawing.Point(272, 95);
            this.dtp_FechaCheckOut.Name = "dtp_FechaCheckOut";
            this.dtp_FechaCheckOut.Size = new System.Drawing.Size(200, 20);
            this.dtp_FechaCheckOut.TabIndex = 5;
            this.dtp_FechaCheckOut.ValueChanged += new System.EventHandler(this.dtp_FechaCheckOut_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha de check-in";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de check-out";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(503, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total de Huéspedes";
            // 
            // cb_CantidadHuespedes
            // 
            this.cb_CantidadHuespedes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CantidadHuespedes.FormattingEnabled = true;
            this.cb_CantidadHuespedes.Items.AddRange(new object[] {
            "seleccione cantidad de huespedes",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cb_CantidadHuespedes.Location = new System.Drawing.Point(506, 93);
            this.cb_CantidadHuespedes.Name = "cb_CantidadHuespedes";
            this.cb_CantidadHuespedes.Size = new System.Drawing.Size(121, 21);
            this.cb_CantidadHuespedes.TabIndex = 9;
            this.cb_CantidadHuespedes.SelectedIndexChanged += new System.EventHandler(this.cb_CantidadHuespedes_SelectedIndexChanged);
            // 
            // cb_HabitacionesDisp
            // 
            this.cb_HabitacionesDisp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_HabitacionesDisp.FormattingEnabled = true;
            this.cb_HabitacionesDisp.Location = new System.Drawing.Point(27, 153);
            this.cb_HabitacionesDisp.Name = "cb_HabitacionesDisp";
            this.cb_HabitacionesDisp.Size = new System.Drawing.Size(121, 21);
            this.cb_HabitacionesDisp.TabIndex = 10;
            this.cb_HabitacionesDisp.SelectedIndexChanged += new System.EventHandler(this.cb_HabitacionesDisp_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Habitaciones Disponibles";
            // 
            // txt_PrecioHabitacion
            // 
            this.txt_PrecioHabitacion.Enabled = false;
            this.txt_PrecioHabitacion.Location = new System.Drawing.Point(154, 154);
            this.txt_PrecioHabitacion.Name = "txt_PrecioHabitacion";
            this.txt_PrecioHabitacion.Size = new System.Drawing.Size(87, 20);
            this.txt_PrecioHabitacion.TabIndex = 12;
            this.txt_PrecioHabitacion.TextChanged += new System.EventHandler(this.txt_PrecioHabitacion_TextChanged);
            // 
            // cb_Paquetes
            // 
            this.cb_Paquetes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Paquetes.FormattingEnabled = true;
            this.cb_Paquetes.Location = new System.Drawing.Point(295, 153);
            this.cb_Paquetes.Name = "cb_Paquetes";
            this.cb_Paquetes.Size = new System.Drawing.Size(121, 21);
            this.cb_Paquetes.TabIndex = 13;
            this.cb_Paquetes.SelectedIndexChanged += new System.EventHandler(this.cb_Paquetes_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Paquetes Disponibles";
            // 
            // txt_PrecioPaquetes
            // 
            this.txt_PrecioPaquetes.Enabled = false;
            this.txt_PrecioPaquetes.Location = new System.Drawing.Point(422, 153);
            this.txt_PrecioPaquetes.Name = "txt_PrecioPaquetes";
            this.txt_PrecioPaquetes.Size = new System.Drawing.Size(87, 20);
            this.txt_PrecioPaquetes.TabIndex = 15;
            this.txt_PrecioPaquetes.TextChanged += new System.EventHandler(this.txt_PrecioPaquetes_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(292, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Viene con:";
            // 
            // lbl_DescripPaquete
            // 
            this.lbl_DescripPaquete.Location = new System.Drawing.Point(357, 186);
            this.lbl_DescripPaquete.Name = "lbl_DescripPaquete";
            this.lbl_DescripPaquete.Size = new System.Drawing.Size(250, 40);
            this.lbl_DescripPaquete.TabIndex = 17;
            this.lbl_DescripPaquete.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\r\nXX";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Tipo de Pago";
            // 
            // cb_TipoPago
            // 
            this.cb_TipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TipoPago.FormattingEnabled = true;
            this.cb_TipoPago.Items.AddRange(new object[] {
            "seleccione metodo de pago",
            "EFECTIVO",
            "TARJETA DE CREDITO"});
            this.cb_TipoPago.Location = new System.Drawing.Point(27, 273);
            this.cb_TipoPago.Name = "cb_TipoPago";
            this.cb_TipoPago.Size = new System.Drawing.Size(121, 21);
            this.cb_TipoPago.TabIndex = 18;
            this.cb_TipoPago.SelectedIndexChanged += new System.EventHandler(this.cb_TipoPago_SelectedIndexChanged);
            // 
            // checkb_PagoAnticipado
            // 
            this.checkb_PagoAnticipado.AutoSize = true;
            this.checkb_PagoAnticipado.Location = new System.Drawing.Point(178, 266);
            this.checkb_PagoAnticipado.Name = "checkb_PagoAnticipado";
            this.checkb_PagoAnticipado.Size = new System.Drawing.Size(104, 17);
            this.checkb_PagoAnticipado.TabIndex = 20;
            this.checkb_PagoAnticipado.Text = "Pago Anticipado";
            this.checkb_PagoAnticipado.UseVisualStyleBackColor = true;
            this.checkb_PagoAnticipado.CheckedChanged += new System.EventHandler(this.cb_PagoAnticipado_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(285, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Pago Anticipado";
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Guardar.FlatAppearance.BorderSize = 0;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Location = new System.Drawing.Point(603, 314);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_Guardar.TabIndex = 23;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(27, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Ver Reservas Realizadas";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_PagoAnticipado
            // 
            this.txt_PagoAnticipado.Enabled = false;
            this.txt_PagoAnticipado.Location = new System.Drawing.Point(288, 273);
            this.txt_PagoAnticipado.Name = "txt_PagoAnticipado";
            this.txt_PagoAnticipado.Size = new System.Drawing.Size(87, 20);
            this.txt_PagoAnticipado.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 314);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "TOTAL:";
            // 
            // lbl_Total
            // 
            this.lbl_Total.AutoSize = true;
            this.lbl_Total.Location = new System.Drawing.Point(75, 314);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(43, 13);
            this.lbl_Total.TabIndex = 27;
            this.lbl_Total.Text = "000000";
            // 
            // dtp_FechaCheckIn
            // 
            this.dtp_FechaCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaCheckIn.Location = new System.Drawing.Point(27, 95);
            this.dtp_FechaCheckIn.Name = "dtp_FechaCheckIn";
            this.dtp_FechaCheckIn.Size = new System.Drawing.Size(200, 20);
            this.dtp_FechaCheckIn.TabIndex = 28;
            this.dtp_FechaCheckIn.ValueChanged += new System.EventHandler(this.dtp_FechaCheckIn_ValueChanged_1);
            // 
            // frm_ModoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(699, 378);
            this.Controls.Add(this.dtp_FechaCheckIn);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_PagoAnticipado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkb_PagoAnticipado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cb_TipoPago);
            this.Controls.Add(this.lbl_DescripPaquete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_PrecioPaquetes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_Paquetes);
            this.Controls.Add(this.txt_PrecioHabitacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_HabitacionesDisp);
            this.Controls.Add(this.cb_CantidadHuespedes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp_FechaCheckOut);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.lbl_NombreCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_ModoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_ModoCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_NombreCliente;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.DateTimePicker dtp_FechaCheckOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_CantidadHuespedes;
        private System.Windows.Forms.ComboBox cb_HabitacionesDisp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_PrecioHabitacion;
        private System.Windows.Forms.ComboBox cb_Paquetes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_PrecioPaquetes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_DescripPaquete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_TipoPago;
        private System.Windows.Forms.CheckBox checkb_PagoAnticipado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_PagoAnticipado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.DateTimePicker dtp_FechaCheckIn;
    }
}