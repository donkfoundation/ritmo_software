namespace hotel_nn
{
    partial class frm_Paquetes
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lv_Paquetes = new System.Windows.Forms.ListView();
            this.btn_Salir_Paquetes = new System.Windows.Forms.Button();
            this.txt_Nom_Paquete = new System.Windows.Forms.TextBox();
            this.txt_Desc_Paquete = new System.Windows.Forms.TextBox();
            this.txt_Precio_Paquete = new System.Windows.Forms.TextBox();
            this.txt_IVA_Paquete = new System.Windows.Forms.TextBox();
            this.txt_Total_Paquete = new System.Windows.Forms.TextBox();
            this.btn_Limpiar_Paquete = new System.Windows.Forms.Button();
            this.btn_Borrar_Paquete = new System.Windows.Forms.Button();
            this.btn_Editar_Paquete = new System.Windows.Forms.Button();
            this.btn_Agregar_Paquete = new System.Windows.Forms.Button();
            this.cb_Estado_Paquetes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Paquete";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "IVA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "TOTAL";
            // 
            // lv_Paquetes
            // 
            this.lv_Paquetes.HideSelection = false;
            this.lv_Paquetes.Location = new System.Drawing.Point(22, 155);
            this.lv_Paquetes.Name = "lv_Paquetes";
            this.lv_Paquetes.Size = new System.Drawing.Size(619, 216);
            this.lv_Paquetes.TabIndex = 6;
            this.lv_Paquetes.UseCompatibleStateImageBehavior = false;
            this.lv_Paquetes.View = System.Windows.Forms.View.Details;
            this.lv_Paquetes.SelectedIndexChanged += new System.EventHandler(this.lv_Paquetes_SelectedIndexChanged);
            // 
            // btn_Salir_Paquetes
            // 
            this.btn_Salir_Paquetes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Salir_Paquetes.FlatAppearance.BorderSize = 0;
            this.btn_Salir_Paquetes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Salir_Paquetes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Salir_Paquetes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir_Paquetes.Location = new System.Drawing.Point(566, 380);
            this.btn_Salir_Paquetes.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Salir_Paquetes.Name = "btn_Salir_Paquetes";
            this.btn_Salir_Paquetes.Size = new System.Drawing.Size(75, 23);
            this.btn_Salir_Paquetes.TabIndex = 11;
            this.btn_Salir_Paquetes.Text = "Salir";
            this.btn_Salir_Paquetes.UseVisualStyleBackColor = false;
            this.btn_Salir_Paquetes.Click += new System.EventHandler(this.btn_Salir_Paquetes_Click);
            // 
            // txt_Nom_Paquete
            // 
            this.txt_Nom_Paquete.Location = new System.Drawing.Point(162, 19);
            this.txt_Nom_Paquete.Name = "txt_Nom_Paquete";
            this.txt_Nom_Paquete.Size = new System.Drawing.Size(100, 20);
            this.txt_Nom_Paquete.TabIndex = 1;
            // 
            // txt_Desc_Paquete
            // 
            this.txt_Desc_Paquete.Location = new System.Drawing.Point(162, 50);
            this.txt_Desc_Paquete.Name = "txt_Desc_Paquete";
            this.txt_Desc_Paquete.Size = new System.Drawing.Size(100, 20);
            this.txt_Desc_Paquete.TabIndex = 2;
            // 
            // txt_Precio_Paquete
            // 
            this.txt_Precio_Paquete.Location = new System.Drawing.Point(469, 50);
            this.txt_Precio_Paquete.Name = "txt_Precio_Paquete";
            this.txt_Precio_Paquete.Size = new System.Drawing.Size(100, 20);
            this.txt_Precio_Paquete.TabIndex = 5;
            this.txt_Precio_Paquete.TextChanged += new System.EventHandler(this.txt_Precio_Paquete_TextChanged);
            // 
            // txt_IVA_Paquete
            // 
            this.txt_IVA_Paquete.Enabled = false;
            this.txt_IVA_Paquete.Location = new System.Drawing.Point(162, 85);
            this.txt_IVA_Paquete.Name = "txt_IVA_Paquete";
            this.txt_IVA_Paquete.Size = new System.Drawing.Size(100, 20);
            this.txt_IVA_Paquete.TabIndex = 3;
            // 
            // txt_Total_Paquete
            // 
            this.txt_Total_Paquete.Enabled = false;
            this.txt_Total_Paquete.Location = new System.Drawing.Point(469, 85);
            this.txt_Total_Paquete.Name = "txt_Total_Paquete";
            this.txt_Total_Paquete.Size = new System.Drawing.Size(100, 20);
            this.txt_Total_Paquete.TabIndex = 6;
            // 
            // btn_Limpiar_Paquete
            // 
            this.btn_Limpiar_Paquete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Limpiar_Paquete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Limpiar_Paquete.FlatAppearance.BorderSize = 0;
            this.btn_Limpiar_Paquete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Limpiar_Paquete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Limpiar_Paquete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Limpiar_Paquete.ForeColor = System.Drawing.Color.Black;
            this.btn_Limpiar_Paquete.Location = new System.Drawing.Point(566, 120);
            this.btn_Limpiar_Paquete.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Limpiar_Paquete.Name = "btn_Limpiar_Paquete";
            this.btn_Limpiar_Paquete.Size = new System.Drawing.Size(75, 23);
            this.btn_Limpiar_Paquete.TabIndex = 10;
            this.btn_Limpiar_Paquete.Text = "Limpiar";
            this.btn_Limpiar_Paquete.UseVisualStyleBackColor = false;
            this.btn_Limpiar_Paquete.Click += new System.EventHandler(this.btn_Limpiar_Paquete_Click);
            // 
            // btn_Borrar_Paquete
            // 
            this.btn_Borrar_Paquete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Borrar_Paquete.FlatAppearance.BorderSize = 0;
            this.btn_Borrar_Paquete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Borrar_Paquete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Borrar_Paquete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Borrar_Paquete.ForeColor = System.Drawing.Color.Black;
            this.btn_Borrar_Paquete.Location = new System.Drawing.Point(482, 120);
            this.btn_Borrar_Paquete.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Borrar_Paquete.Name = "btn_Borrar_Paquete";
            this.btn_Borrar_Paquete.Size = new System.Drawing.Size(75, 23);
            this.btn_Borrar_Paquete.TabIndex = 9;
            this.btn_Borrar_Paquete.Text = "Borrar";
            this.btn_Borrar_Paquete.UseVisualStyleBackColor = false;
            this.btn_Borrar_Paquete.Click += new System.EventHandler(this.btn_Borrar_Paquete_Click);
            // 
            // btn_Editar_Paquete
            // 
            this.btn_Editar_Paquete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Editar_Paquete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Editar_Paquete.FlatAppearance.BorderSize = 0;
            this.btn_Editar_Paquete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Editar_Paquete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Editar_Paquete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Editar_Paquete.ForeColor = System.Drawing.Color.Black;
            this.btn_Editar_Paquete.Location = new System.Drawing.Point(401, 120);
            this.btn_Editar_Paquete.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Editar_Paquete.Name = "btn_Editar_Paquete";
            this.btn_Editar_Paquete.Size = new System.Drawing.Size(75, 23);
            this.btn_Editar_Paquete.TabIndex = 8;
            this.btn_Editar_Paquete.Text = "Editar";
            this.btn_Editar_Paquete.UseVisualStyleBackColor = false;
            this.btn_Editar_Paquete.Click += new System.EventHandler(this.btn_Editar_Paquete_Click);
            // 
            // btn_Agregar_Paquete
            // 
            this.btn_Agregar_Paquete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Agregar_Paquete.FlatAppearance.BorderSize = 0;
            this.btn_Agregar_Paquete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Agregar_Paquete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Agregar_Paquete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Agregar_Paquete.ForeColor = System.Drawing.Color.Black;
            this.btn_Agregar_Paquete.Location = new System.Drawing.Point(322, 120);
            this.btn_Agregar_Paquete.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Agregar_Paquete.Name = "btn_Agregar_Paquete";
            this.btn_Agregar_Paquete.Size = new System.Drawing.Size(75, 23);
            this.btn_Agregar_Paquete.TabIndex = 7;
            this.btn_Agregar_Paquete.Text = "Añadir";
            this.btn_Agregar_Paquete.UseVisualStyleBackColor = false;
            this.btn_Agregar_Paquete.Click += new System.EventHandler(this.btn_Agregar_Paquete_Click);
            // 
            // cb_Estado_Paquetes
            // 
            this.cb_Estado_Paquetes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Estado_Paquetes.FormattingEnabled = true;
            this.cb_Estado_Paquetes.Items.AddRange(new object[] {
            "seleccione estado",
            "S",
            "N"});
            this.cb_Estado_Paquetes.Location = new System.Drawing.Point(469, 19);
            this.cb_Estado_Paquetes.Name = "cb_Estado_Paquetes";
            this.cb_Estado_Paquetes.Size = new System.Drawing.Size(100, 21);
            this.cb_Estado_Paquetes.TabIndex = 4;
            // 
            // frm_Paquetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(663, 412);
            this.Controls.Add(this.cb_Estado_Paquetes);
            this.Controls.Add(this.btn_Limpiar_Paquete);
            this.Controls.Add(this.btn_Borrar_Paquete);
            this.Controls.Add(this.btn_Editar_Paquete);
            this.Controls.Add(this.btn_Agregar_Paquete);
            this.Controls.Add(this.txt_Total_Paquete);
            this.Controls.Add(this.txt_IVA_Paquete);
            this.Controls.Add(this.txt_Precio_Paquete);
            this.Controls.Add(this.txt_Desc_Paquete);
            this.Controls.Add(this.txt_Nom_Paquete);
            this.Controls.Add(this.btn_Salir_Paquetes);
            this.Controls.Add(this.lv_Paquetes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Paquetes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Paquetes";
            this.Load += new System.EventHandler(this.frm_Paquetes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lv_Paquetes;
        private System.Windows.Forms.Button btn_Salir_Paquetes;
        private System.Windows.Forms.TextBox txt_Nom_Paquete;
        private System.Windows.Forms.TextBox txt_Desc_Paquete;
        private System.Windows.Forms.TextBox txt_Precio_Paquete;
        private System.Windows.Forms.TextBox txt_IVA_Paquete;
        private System.Windows.Forms.TextBox txt_Total_Paquete;
        private System.Windows.Forms.Button btn_Limpiar_Paquete;
        private System.Windows.Forms.Button btn_Borrar_Paquete;
        private System.Windows.Forms.Button btn_Editar_Paquete;
        private System.Windows.Forms.Button btn_Agregar_Paquete;
        private System.Windows.Forms.ComboBox cb_Estado_Paquetes;
    }
}