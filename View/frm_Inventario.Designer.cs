namespace hotel_nn
{
    partial class frm_Inventario
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
            this.txt_Descripcion_Inventario = new System.Windows.Forms.TextBox();
            this.txt_Cantidad_Inventario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lv_Items_Inventario = new System.Windows.Forms.ListView();
            this.dtp_FechaIngreso_Inventario = new System.Windows.Forms.DateTimePicker();
            this.dtp_FechaEgreso_Inventario = new System.Windows.Forms.DateTimePicker();
            this.btn_Agregar_Inventario = new System.Windows.Forms.Button();
            this.btn_Editar_Inventario = new System.Windows.Forms.Button();
            this.btn_Borrar_Inventario = new System.Windows.Forms.Button();
            this.btn_Salir_Inventario = new System.Windows.Forms.Button();
            this.btn_Limpiar_Inventario = new System.Windows.Forms.Button();
            this.cb_Nit_Inventario = new System.Windows.Forms.ComboBox();
            this.checkB_FechaVen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción ";
            // 
            // txt_Descripcion_Inventario
            // 
            this.txt_Descripcion_Inventario.Location = new System.Drawing.Point(93, 27);
            this.txt_Descripcion_Inventario.Name = "txt_Descripcion_Inventario";
            this.txt_Descripcion_Inventario.Size = new System.Drawing.Size(100, 20);
            this.txt_Descripcion_Inventario.TabIndex = 1;
            // 
            // txt_Cantidad_Inventario
            // 
            this.txt_Cantidad_Inventario.Location = new System.Drawing.Point(93, 65);
            this.txt_Cantidad_Inventario.Name = "txt_Cantidad_Inventario";
            this.txt_Cantidad_Inventario.Size = new System.Drawing.Size(100, 20);
            this.txt_Cantidad_Inventario.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha Vencimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha Ingreso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Proveedor";
            // 
            // lv_Items_Inventario
            // 
            this.lv_Items_Inventario.HideSelection = false;
            this.lv_Items_Inventario.Location = new System.Drawing.Point(24, 184);
            this.lv_Items_Inventario.Name = "lv_Items_Inventario";
            this.lv_Items_Inventario.Size = new System.Drawing.Size(521, 176);
            this.lv_Items_Inventario.TabIndex = 11;
            this.lv_Items_Inventario.UseCompatibleStateImageBehavior = false;
            this.lv_Items_Inventario.View = System.Windows.Forms.View.Details;
            this.lv_Items_Inventario.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // dtp_FechaIngreso_Inventario
            // 
            this.dtp_FechaIngreso_Inventario.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaIngreso_Inventario.Location = new System.Drawing.Point(345, 65);
            this.dtp_FechaIngreso_Inventario.Name = "dtp_FechaIngreso_Inventario";
            this.dtp_FechaIngreso_Inventario.Size = new System.Drawing.Size(200, 20);
            this.dtp_FechaIngreso_Inventario.TabIndex = 12;
            // 
            // dtp_FechaEgreso_Inventario
            // 
            this.dtp_FechaEgreso_Inventario.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaEgreso_Inventario.Location = new System.Drawing.Point(345, 106);
            this.dtp_FechaEgreso_Inventario.Name = "dtp_FechaEgreso_Inventario";
            this.dtp_FechaEgreso_Inventario.Size = new System.Drawing.Size(200, 20);
            this.dtp_FechaEgreso_Inventario.TabIndex = 13;
            // 
            // btn_Agregar_Inventario
            // 
            this.btn_Agregar_Inventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Agregar_Inventario.FlatAppearance.BorderSize = 0;
            this.btn_Agregar_Inventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Agregar_Inventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Agregar_Inventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Agregar_Inventario.ForeColor = System.Drawing.Color.Black;
            this.btn_Agregar_Inventario.Location = new System.Drawing.Point(226, 149);
            this.btn_Agregar_Inventario.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Agregar_Inventario.Name = "btn_Agregar_Inventario";
            this.btn_Agregar_Inventario.Size = new System.Drawing.Size(75, 23);
            this.btn_Agregar_Inventario.TabIndex = 14;
            this.btn_Agregar_Inventario.Text = "Añadir";
            this.btn_Agregar_Inventario.UseVisualStyleBackColor = false;
            this.btn_Agregar_Inventario.Click += new System.EventHandler(this.btn_Agregar_Inventario_Click);
            // 
            // btn_Editar_Inventario
            // 
            this.btn_Editar_Inventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Editar_Inventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Editar_Inventario.FlatAppearance.BorderSize = 0;
            this.btn_Editar_Inventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Editar_Inventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Editar_Inventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Editar_Inventario.ForeColor = System.Drawing.Color.Black;
            this.btn_Editar_Inventario.Location = new System.Drawing.Point(305, 149);
            this.btn_Editar_Inventario.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Editar_Inventario.Name = "btn_Editar_Inventario";
            this.btn_Editar_Inventario.Size = new System.Drawing.Size(75, 23);
            this.btn_Editar_Inventario.TabIndex = 15;
            this.btn_Editar_Inventario.Text = "Editar";
            this.btn_Editar_Inventario.UseVisualStyleBackColor = false;
            this.btn_Editar_Inventario.Click += new System.EventHandler(this.btn_Editar_Inventario_Click);
            // 
            // btn_Borrar_Inventario
            // 
            this.btn_Borrar_Inventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Borrar_Inventario.FlatAppearance.BorderSize = 0;
            this.btn_Borrar_Inventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Borrar_Inventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Borrar_Inventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Borrar_Inventario.ForeColor = System.Drawing.Color.Black;
            this.btn_Borrar_Inventario.Location = new System.Drawing.Point(386, 149);
            this.btn_Borrar_Inventario.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Borrar_Inventario.Name = "btn_Borrar_Inventario";
            this.btn_Borrar_Inventario.Size = new System.Drawing.Size(75, 23);
            this.btn_Borrar_Inventario.TabIndex = 16;
            this.btn_Borrar_Inventario.Text = "Borrar";
            this.btn_Borrar_Inventario.UseVisualStyleBackColor = false;
            this.btn_Borrar_Inventario.Click += new System.EventHandler(this.btn_Borrar_Inventario_Click);
            // 
            // btn_Salir_Inventario
            // 
            this.btn_Salir_Inventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Salir_Inventario.FlatAppearance.BorderSize = 0;
            this.btn_Salir_Inventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Salir_Inventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Salir_Inventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir_Inventario.Location = new System.Drawing.Point(470, 370);
            this.btn_Salir_Inventario.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Salir_Inventario.Name = "btn_Salir_Inventario";
            this.btn_Salir_Inventario.Size = new System.Drawing.Size(75, 23);
            this.btn_Salir_Inventario.TabIndex = 13;
            this.btn_Salir_Inventario.Text = "Salir";
            this.btn_Salir_Inventario.UseVisualStyleBackColor = false;
            this.btn_Salir_Inventario.Click += new System.EventHandler(this.btn_Salir_Inventario_Click);
            // 
            // btn_Limpiar_Inventario
            // 
            this.btn_Limpiar_Inventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Limpiar_Inventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Limpiar_Inventario.FlatAppearance.BorderSize = 0;
            this.btn_Limpiar_Inventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Limpiar_Inventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Limpiar_Inventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Limpiar_Inventario.ForeColor = System.Drawing.Color.Black;
            this.btn_Limpiar_Inventario.Location = new System.Drawing.Point(470, 149);
            this.btn_Limpiar_Inventario.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Limpiar_Inventario.Name = "btn_Limpiar_Inventario";
            this.btn_Limpiar_Inventario.Size = new System.Drawing.Size(75, 23);
            this.btn_Limpiar_Inventario.TabIndex = 17;
            this.btn_Limpiar_Inventario.Text = "Limpiar";
            this.btn_Limpiar_Inventario.UseVisualStyleBackColor = false;
            this.btn_Limpiar_Inventario.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_Nit_Inventario
            // 
            this.cb_Nit_Inventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Nit_Inventario.FormattingEnabled = true;
            this.cb_Nit_Inventario.Location = new System.Drawing.Point(345, 26);
            this.cb_Nit_Inventario.Name = "cb_Nit_Inventario";
            this.cb_Nit_Inventario.Size = new System.Drawing.Size(200, 21);
            this.cb_Nit_Inventario.TabIndex = 18;
            // 
            // checkB_FechaVen
            // 
            this.checkB_FechaVen.AutoSize = true;
            this.checkB_FechaVen.Location = new System.Drawing.Point(220, 109);
            this.checkB_FechaVen.Name = "checkB_FechaVen";
            this.checkB_FechaVen.Size = new System.Drawing.Size(15, 14);
            this.checkB_FechaVen.TabIndex = 19;
            this.checkB_FechaVen.UseVisualStyleBackColor = true;
            this.checkB_FechaVen.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frm_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(562, 402);
            this.Controls.Add(this.checkB_FechaVen);
            this.Controls.Add(this.cb_Nit_Inventario);
            this.Controls.Add(this.btn_Limpiar_Inventario);
            this.Controls.Add(this.btn_Salir_Inventario);
            this.Controls.Add(this.btn_Borrar_Inventario);
            this.Controls.Add(this.btn_Editar_Inventario);
            this.Controls.Add(this.btn_Agregar_Inventario);
            this.Controls.Add(this.dtp_FechaEgreso_Inventario);
            this.Controls.Add(this.dtp_FechaIngreso_Inventario);
            this.Controls.Add(this.lv_Items_Inventario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Cantidad_Inventario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Descripcion_Inventario);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Inventario";
            this.Load += new System.EventHandler(this.frm_Inventario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Descripcion_Inventario;
        private System.Windows.Forms.TextBox txt_Cantidad_Inventario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lv_Items_Inventario;
        private System.Windows.Forms.DateTimePicker dtp_FechaIngreso_Inventario;
        private System.Windows.Forms.DateTimePicker dtp_FechaEgreso_Inventario;
        private System.Windows.Forms.Button btn_Agregar_Inventario;
        private System.Windows.Forms.Button btn_Editar_Inventario;
        private System.Windows.Forms.Button btn_Borrar_Inventario;
        private System.Windows.Forms.Button btn_Salir_Inventario;
        private System.Windows.Forms.Button btn_Limpiar_Inventario;
        private System.Windows.Forms.ComboBox cb_Nit_Inventario;
        private System.Windows.Forms.CheckBox checkB_FechaVen;
    }
}