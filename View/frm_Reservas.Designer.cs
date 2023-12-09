namespace hotel_nn
{
    partial class frm_Reservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Reservas));
            this.lv_Preview_Reservas = new System.Windows.Forms.ListView();
            this.btn_Salir_Inventario = new System.Windows.Forms.Button();
            this.txtBuscar_Reserva = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbBuscar_Reserva = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar_Reserva)).BeginInit();
            this.SuspendLayout();
            // 
            // lv_Preview_Reservas
            // 
            this.lv_Preview_Reservas.HideSelection = false;
            this.lv_Preview_Reservas.Location = new System.Drawing.Point(12, 42);
            this.lv_Preview_Reservas.Name = "lv_Preview_Reservas";
            this.lv_Preview_Reservas.Size = new System.Drawing.Size(633, 325);
            this.lv_Preview_Reservas.TabIndex = 0;
            this.lv_Preview_Reservas.UseCompatibleStateImageBehavior = false;
            this.lv_Preview_Reservas.View = System.Windows.Forms.View.Details;
            // 
            // btn_Salir_Inventario
            // 
            this.btn_Salir_Inventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Salir_Inventario.FlatAppearance.BorderSize = 0;
            this.btn_Salir_Inventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Salir_Inventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Salir_Inventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir_Inventario.Location = new System.Drawing.Point(570, 393);
            this.btn_Salir_Inventario.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Salir_Inventario.Name = "btn_Salir_Inventario";
            this.btn_Salir_Inventario.Size = new System.Drawing.Size(75, 23);
            this.btn_Salir_Inventario.TabIndex = 2;
            this.btn_Salir_Inventario.Text = "Salir";
            this.btn_Salir_Inventario.UseVisualStyleBackColor = false;
            this.btn_Salir_Inventario.Click += new System.EventHandler(this.btn_Salir_Inventario_Click);
            // 
            // txtBuscar_Reserva
            // 
            this.txtBuscar_Reserva.Location = new System.Drawing.Point(250, 12);
            this.txtBuscar_Reserva.Name = "txtBuscar_Reserva";
            this.txtBuscar_Reserva.Size = new System.Drawing.Size(300, 20);
            this.txtBuscar_Reserva.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Buscar por número de reserva";
            // 
            // pbBuscar_Reserva
            // 
            this.pbBuscar_Reserva.BackColor = System.Drawing.Color.Transparent;
            this.pbBuscar_Reserva.Image = ((System.Drawing.Image)(resources.GetObject("pbBuscar_Reserva.Image")));
            this.pbBuscar_Reserva.Location = new System.Drawing.Point(570, 12);
            this.pbBuscar_Reserva.Name = "pbBuscar_Reserva";
            this.pbBuscar_Reserva.Size = new System.Drawing.Size(45, 21);
            this.pbBuscar_Reserva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBuscar_Reserva.TabIndex = 17;
            this.pbBuscar_Reserva.TabStop = false;
            this.pbBuscar_Reserva.Click += new System.EventHandler(this.pbBuscar_Reserva_Click);
            // 
            // frm_Reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(657, 425);
            this.Controls.Add(this.pbBuscar_Reserva);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar_Reserva);
            this.Controls.Add(this.btn_Salir_Inventario);
            this.Controls.Add(this.lv_Preview_Reservas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Reservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Reservas";
            this.Load += new System.EventHandler(this.frm_Reservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar_Reserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_Preview_Reservas;
        private System.Windows.Forms.Button btn_Salir_Inventario;
        private System.Windows.Forms.TextBox txtBuscar_Reserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbBuscar_Reserva;
    }
}