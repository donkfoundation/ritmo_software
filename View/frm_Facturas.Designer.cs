namespace hotel_nn.View
{
    partial class frm_Facturas
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
            this.txtBuscar_Reserva = new System.Windows.Forms.TextBox();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.lv_Facturas = new System.Windows.Forms.ListView();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Generar_Factura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Buscar por documento de cliente";
            // 
            // txtBuscar_Reserva
            // 
            this.txtBuscar_Reserva.Location = new System.Drawing.Point(209, 22);
            this.txtBuscar_Reserva.Name = "txtBuscar_Reserva";
            this.txtBuscar_Reserva.Size = new System.Drawing.Size(283, 20);
            this.txtBuscar_Reserva.TabIndex = 20;
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Salir.FlatAppearance.BorderSize = 0;
            this.btn_Salir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Salir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir.Location = new System.Drawing.Point(588, 414);
            this.btn_Salir.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(75, 23);
            this.btn_Salir.TabIndex = 19;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = false;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // lv_Facturas
            // 
            this.lv_Facturas.HideSelection = false;
            this.lv_Facturas.Location = new System.Drawing.Point(30, 51);
            this.lv_Facturas.Name = "lv_Facturas";
            this.lv_Facturas.Size = new System.Drawing.Size(633, 348);
            this.lv_Facturas.TabIndex = 18;
            this.lv_Facturas.UseCompatibleStateImageBehavior = false;
            this.lv_Facturas.View = System.Windows.Forms.View.Details;
            this.lv_Facturas.SelectedIndexChanged += new System.EventHandler(this.lv_Facturas_SelectedIndexChanged);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Buscar.FlatAppearance.BorderSize = 0;
            this.btn_Buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Buscar.Location = new System.Drawing.Point(504, 20);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 22;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Generar_Factura
            // 
            this.btn_Generar_Factura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Generar_Factura.Enabled = false;
            this.btn_Generar_Factura.FlatAppearance.BorderSize = 0;
            this.btn_Generar_Factura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Generar_Factura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Generar_Factura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Generar_Factura.Location = new System.Drawing.Point(588, 20);
            this.btn_Generar_Factura.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Generar_Factura.Name = "btn_Generar_Factura";
            this.btn_Generar_Factura.Size = new System.Drawing.Size(75, 23);
            this.btn_Generar_Factura.TabIndex = 23;
            this.btn_Generar_Factura.Text = "Generar";
            this.btn_Generar_Factura.UseVisualStyleBackColor = false;
            this.btn_Generar_Factura.Click += new System.EventHandler(this.btn_Generar_Factura_Click);
            // 
            // frm_Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(693, 446);
            this.Controls.Add(this.btn_Generar_Factura);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar_Reserva);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.lv_Facturas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Facturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Facturas";
            this.Load += new System.EventHandler(this.frm_Facturas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar_Reserva;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.ListView lv_Facturas;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Generar_Factura;
    }
}