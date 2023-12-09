namespace hotel_nn
{
    partial class frm_Asignacion_Roles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Asignacion_Roles));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre_Roles = new System.Windows.Forms.TextBox();
            this.cbRol_Roles = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCedula_Roles = new System.Windows.Forms.TextBox();
            this.pbBuscar_Roles = new System.Windows.Forms.PictureBox();
            this.btnSalir_Roles = new System.Windows.Forms.Button();
            this.btnGuardar_Roles = new System.Windows.Forms.Button();
            this.btnLimpiar_Roles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar_Roles)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cédula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 252);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rol";
            // 
            // txtNombre_Roles
            // 
            this.txtNombre_Roles.Enabled = false;
            this.txtNombre_Roles.Location = new System.Drawing.Point(157, 180);
            this.txtNombre_Roles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNombre_Roles.Name = "txtNombre_Roles";
            this.txtNombre_Roles.Size = new System.Drawing.Size(337, 20);
            this.txtNombre_Roles.TabIndex = 2;
            // 
            // cbRol_Roles
            // 
            this.cbRol_Roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol_Roles.FormattingEnabled = true;
            this.cbRol_Roles.Location = new System.Drawing.Point(157, 249);
            this.cbRol_Roles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbRol_Roles.Name = "cbRol_Roles";
            this.cbRol_Roles.Size = new System.Drawing.Size(337, 21);
            this.cbRol_Roles.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(217, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Asignacion de roles";
            // 
            // txtCedula_Roles
            // 
            this.txtCedula_Roles.Location = new System.Drawing.Point(157, 113);
            this.txtCedula_Roles.Name = "txtCedula_Roles";
            this.txtCedula_Roles.Size = new System.Drawing.Size(277, 20);
            this.txtCedula_Roles.TabIndex = 1;
            // 
            // pbBuscar_Roles
            // 
            this.pbBuscar_Roles.BackColor = System.Drawing.Color.Transparent;
            this.pbBuscar_Roles.Image = ((System.Drawing.Image)(resources.GetObject("pbBuscar_Roles.Image")));
            this.pbBuscar_Roles.Location = new System.Drawing.Point(449, 112);
            this.pbBuscar_Roles.Name = "pbBuscar_Roles";
            this.pbBuscar_Roles.Size = new System.Drawing.Size(45, 21);
            this.pbBuscar_Roles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBuscar_Roles.TabIndex = 12;
            this.pbBuscar_Roles.TabStop = false;
            this.pbBuscar_Roles.Click += new System.EventHandler(this.pbBuscar_Roles_Click);
            // 
            // btnSalir_Roles
            // 
            this.btnSalir_Roles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir_Roles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir_Roles.FlatAppearance.BorderSize = 0;
            this.btnSalir_Roles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir_Roles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir_Roles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir_Roles.ForeColor = System.Drawing.Color.Black;
            this.btnSalir_Roles.Location = new System.Drawing.Point(571, 349);
            this.btnSalir_Roles.Name = "btnSalir_Roles";
            this.btnSalir_Roles.Size = new System.Drawing.Size(112, 30);
            this.btnSalir_Roles.TabIndex = 5;
            this.btnSalir_Roles.Text = "Salir";
            this.btnSalir_Roles.UseVisualStyleBackColor = false;
            this.btnSalir_Roles.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar_Roles
            // 
            this.btnGuardar_Roles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGuardar_Roles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar_Roles.FlatAppearance.BorderSize = 0;
            this.btnGuardar_Roles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGuardar_Roles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGuardar_Roles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar_Roles.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar_Roles.Location = new System.Drawing.Point(34, 349);
            this.btnGuardar_Roles.Name = "btnGuardar_Roles";
            this.btnGuardar_Roles.Size = new System.Drawing.Size(99, 30);
            this.btnGuardar_Roles.TabIndex = 4;
            this.btnGuardar_Roles.Text = "Guardar";
            this.btnGuardar_Roles.UseVisualStyleBackColor = false;
            this.btnGuardar_Roles.Click += new System.EventHandler(this.btnGuardar_Roles_Click);
            // 
            // btnLimpiar_Roles
            // 
            this.btnLimpiar_Roles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLimpiar_Roles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar_Roles.FlatAppearance.BorderSize = 0;
            this.btnLimpiar_Roles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLimpiar_Roles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLimpiar_Roles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar_Roles.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar_Roles.Location = new System.Drawing.Point(401, 139);
            this.btnLimpiar_Roles.Name = "btnLimpiar_Roles";
            this.btnLimpiar_Roles.Size = new System.Drawing.Size(93, 24);
            this.btnLimpiar_Roles.TabIndex = 16;
            this.btnLimpiar_Roles.Text = "Limpiar";
            this.btnLimpiar_Roles.UseVisualStyleBackColor = false;
            this.btnLimpiar_Roles.Click += new System.EventHandler(this.btnLimpiar_Roles_Click);
            // 
            // frm_Asignacion_Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(724, 405);
            this.Controls.Add(this.btnLimpiar_Roles);
            this.Controls.Add(this.btnGuardar_Roles);
            this.Controls.Add(this.btnSalir_Roles);
            this.Controls.Add(this.pbBuscar_Roles);
            this.Controls.Add(this.txtCedula_Roles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbRol_Roles);
            this.Controls.Add(this.txtNombre_Roles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frm_Asignacion_Roles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignacion de roles";
            this.Load += new System.EventHandler(this.frm_Asignacion_Roles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar_Roles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre_Roles;
        private System.Windows.Forms.ComboBox cbRol_Roles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCedula_Roles;
        private System.Windows.Forms.PictureBox pbBuscar_Roles;
        private System.Windows.Forms.Button btnSalir_Roles;
        private System.Windows.Forms.Button btnGuardar_Roles;
        private System.Windows.Forms.Button btnLimpiar_Roles;
    }
}