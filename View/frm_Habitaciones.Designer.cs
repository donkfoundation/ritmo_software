namespace hotel_nn
{
    partial class frm_Habitaciones
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
            this.lv_Habitaciones = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Salir_Habitaciones = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_TipoHabitaciones = new System.Windows.Forms.Button();
            this.btn_AdminHabitaciones = new System.Windows.Forms.Button();
            this.btn_RefrescarHab = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lv_Habitaciones
            // 
            this.lv_Habitaciones.HideSelection = false;
            this.lv_Habitaciones.Location = new System.Drawing.Point(12, 12);
            this.lv_Habitaciones.Name = "lv_Habitaciones";
            this.lv_Habitaciones.Size = new System.Drawing.Size(405, 356);
            this.lv_Habitaciones.TabIndex = 0;
            this.lv_Habitaciones.UseCompatibleStateImageBehavior = false;
            this.lv_Habitaciones.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Administrar tipos de \r\nhabitaciones";
            // 
            // btn_Salir_Habitaciones
            // 
            this.btn_Salir_Habitaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Salir_Habitaciones.FlatAppearance.BorderSize = 0;
            this.btn_Salir_Habitaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir_Habitaciones.Location = new System.Drawing.Point(519, 345);
            this.btn_Salir_Habitaciones.Name = "btn_Salir_Habitaciones";
            this.btn_Salir_Habitaciones.Size = new System.Drawing.Size(75, 23);
            this.btn_Salir_Habitaciones.TabIndex = 2;
            this.btn_Salir_Habitaciones.Text = "Salir";
            this.btn_Salir_Habitaciones.UseVisualStyleBackColor = false;
            this.btn_Salir_Habitaciones.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Administrar\r\nhabitaciones";
            // 
            // btn_TipoHabitaciones
            // 
            this.btn_TipoHabitaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_TipoHabitaciones.FlatAppearance.BorderSize = 0;
            this.btn_TipoHabitaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TipoHabitaciones.Location = new System.Drawing.Point(426, 276);
            this.btn_TipoHabitaciones.Name = "btn_TipoHabitaciones";
            this.btn_TipoHabitaciones.Size = new System.Drawing.Size(75, 23);
            this.btn_TipoHabitaciones.TabIndex = 4;
            this.btn_TipoHabitaciones.Text = "Seleccionar";
            this.btn_TipoHabitaciones.UseVisualStyleBackColor = false;
            this.btn_TipoHabitaciones.Click += new System.EventHandler(this.btn_TipoHabitaciones_Click);
            // 
            // btn_AdminHabitaciones
            // 
            this.btn_AdminHabitaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_AdminHabitaciones.FlatAppearance.BorderSize = 0;
            this.btn_AdminHabitaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AdminHabitaciones.Location = new System.Drawing.Point(426, 212);
            this.btn_AdminHabitaciones.Name = "btn_AdminHabitaciones";
            this.btn_AdminHabitaciones.Size = new System.Drawing.Size(75, 23);
            this.btn_AdminHabitaciones.TabIndex = 5;
            this.btn_AdminHabitaciones.Text = "Seleccionar";
            this.btn_AdminHabitaciones.UseVisualStyleBackColor = false;
            this.btn_AdminHabitaciones.Click += new System.EventHandler(this.btn_AdminHabitaciones_Click);
            // 
            // btn_RefrescarHab
            // 
            this.btn_RefrescarHab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_RefrescarHab.FlatAppearance.BorderSize = 0;
            this.btn_RefrescarHab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RefrescarHab.Location = new System.Drawing.Point(438, 345);
            this.btn_RefrescarHab.Name = "btn_RefrescarHab";
            this.btn_RefrescarHab.Size = new System.Drawing.Size(75, 23);
            this.btn_RefrescarHab.TabIndex = 6;
            this.btn_RefrescarHab.Text = "Refrescar";
            this.btn_RefrescarHab.UseVisualStyleBackColor = false;
            this.btn_RefrescarHab.Click += new System.EventHandler(this.btn_RefrescarHab_Click);
            // 
            // frm_Habitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(606, 380);
            this.Controls.Add(this.btn_RefrescarHab);
            this.Controls.Add(this.btn_AdminHabitaciones);
            this.Controls.Add(this.btn_TipoHabitaciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Salir_Habitaciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_Habitaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Habitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Habitaciones";
            this.Load += new System.EventHandler(this.frm_Habitaciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_Habitaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Salir_Habitaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_TipoHabitaciones;
        private System.Windows.Forms.Button btn_AdminHabitaciones;
        private System.Windows.Forms.Button btn_RefrescarHab;
    }
}