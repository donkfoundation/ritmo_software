namespace hotel_nn
{
    partial class frm_Crear_Paises
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Crear_Paises));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ts_Nuevo_Pais = new System.Windows.Forms.ToolStripButton();
            this.ts_Guardar_Pais = new System.Windows.Forms.ToolStripButton();
            this.ts_Eliminar_Pais = new System.Windows.Forms.ToolStripButton();
            this.ts_Cancelar_Accion = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ts_Text_Pais = new System.Windows.Forms.ToolStripTextBox();
            this.ts_Buscar_Pais = new System.Windows.Forms.ToolStripButton();
            this.txtId_Pais = new System.Windows.Forms.TextBox();
            this.txtNombre_Pais = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalir_Pais = new System.Windows.Forms.Button();
            this.txt_Nuevo_NombrePais = new System.Windows.Forms.TextBox();
            this.txt_Nuevo_IdPais = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_Nuevo_Pais,
            this.ts_Guardar_Pais,
            this.ts_Eliminar_Pais,
            this.ts_Cancelar_Accion,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.ts_Text_Pais,
            this.ts_Buscar_Pais});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(520, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ts_Nuevo_Pais
            // 
            this.ts_Nuevo_Pais.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_Nuevo_Pais.Image = ((System.Drawing.Image)(resources.GetObject("ts_Nuevo_Pais.Image")));
            this.ts_Nuevo_Pais.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Nuevo_Pais.Name = "ts_Nuevo_Pais";
            this.ts_Nuevo_Pais.Size = new System.Drawing.Size(23, 22);
            this.ts_Nuevo_Pais.Text = "Nuevo País";
            this.ts_Nuevo_Pais.Click += new System.EventHandler(this.ts_Nuevo_Pais_Click);
            // 
            // ts_Guardar_Pais
            // 
            this.ts_Guardar_Pais.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_Guardar_Pais.Image = ((System.Drawing.Image)(resources.GetObject("ts_Guardar_Pais.Image")));
            this.ts_Guardar_Pais.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Guardar_Pais.Name = "ts_Guardar_Pais";
            this.ts_Guardar_Pais.Size = new System.Drawing.Size(23, 22);
            this.ts_Guardar_Pais.Text = "Guardar País";
            this.ts_Guardar_Pais.Click += new System.EventHandler(this.ts_Guardar_Pais_Click);
            // 
            // ts_Eliminar_Pais
            // 
            this.ts_Eliminar_Pais.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_Eliminar_Pais.Image = ((System.Drawing.Image)(resources.GetObject("ts_Eliminar_Pais.Image")));
            this.ts_Eliminar_Pais.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Eliminar_Pais.Name = "ts_Eliminar_Pais";
            this.ts_Eliminar_Pais.Size = new System.Drawing.Size(23, 22);
            this.ts_Eliminar_Pais.Text = "Eliminar País";
            this.ts_Eliminar_Pais.Click += new System.EventHandler(this.ts_Eliminar_Pais_Click);
            // 
            // ts_Cancelar_Accion
            // 
            this.ts_Cancelar_Accion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_Cancelar_Accion.Image = ((System.Drawing.Image)(resources.GetObject("ts_Cancelar_Accion.Image")));
            this.ts_Cancelar_Accion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Cancelar_Accion.Name = "ts_Cancelar_Accion";
            this.ts_Cancelar_Accion.Size = new System.Drawing.Size(23, 22);
            this.ts_Cancelar_Accion.Text = "Cancelar Acción";
            this.ts_Cancelar_Accion.Click += new System.EventHandler(this.ts_Cancelar_Accion_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(132, 22);
            this.toolStripLabel1.Text = "Buscar pais por nombre";
            // 
            // ts_Text_Pais
            // 
            this.ts_Text_Pais.BackColor = System.Drawing.Color.White;
            this.ts_Text_Pais.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ts_Text_Pais.Name = "ts_Text_Pais";
            this.ts_Text_Pais.Size = new System.Drawing.Size(200, 25);
            // 
            // ts_Buscar_Pais
            // 
            this.ts_Buscar_Pais.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_Buscar_Pais.Image = ((System.Drawing.Image)(resources.GetObject("ts_Buscar_Pais.Image")));
            this.ts_Buscar_Pais.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Buscar_Pais.Name = "ts_Buscar_Pais";
            this.ts_Buscar_Pais.Size = new System.Drawing.Size(23, 22);
            this.ts_Buscar_Pais.Text = "Buscar País";
            this.ts_Buscar_Pais.Click += new System.EventHandler(this.ts_Buscar_Pais_Click);
            // 
            // txtId_Pais
            // 
            this.txtId_Pais.Location = new System.Drawing.Point(68, 85);
            this.txtId_Pais.Name = "txtId_Pais";
            this.txtId_Pais.Size = new System.Drawing.Size(151, 20);
            this.txtId_Pais.TabIndex = 1;
            // 
            // txtNombre_Pais
            // 
            this.txtNombre_Pais.Location = new System.Drawing.Point(68, 131);
            this.txtNombre_Pais.Name = "txtNombre_Pais";
            this.txtNombre_Pais.Size = new System.Drawing.Size(151, 20);
            this.txtNombre_Pais.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre";
            // 
            // btnSalir_Pais
            // 
            this.btnSalir_Pais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnSalir_Pais.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir_Pais.FlatAppearance.BorderSize = 0;
            this.btnSalir_Pais.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSalir_Pais.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSalir_Pais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir_Pais.Location = new System.Drawing.Point(419, 207);
            this.btnSalir_Pais.Name = "btnSalir_Pais";
            this.btnSalir_Pais.Size = new System.Drawing.Size(75, 23);
            this.btnSalir_Pais.TabIndex = 5;
            this.btnSalir_Pais.Text = "Salir";
            this.btnSalir_Pais.UseVisualStyleBackColor = false;
            this.btnSalir_Pais.Click += new System.EventHandler(this.btnSalir_Pais_Click);
            // 
            // txt_Nuevo_NombrePais
            // 
            this.txt_Nuevo_NombrePais.Location = new System.Drawing.Point(343, 131);
            this.txt_Nuevo_NombrePais.Name = "txt_Nuevo_NombrePais";
            this.txt_Nuevo_NombrePais.Size = new System.Drawing.Size(151, 20);
            this.txt_Nuevo_NombrePais.TabIndex = 4;
            // 
            // txt_Nuevo_IdPais
            // 
            this.txt_Nuevo_IdPais.Location = new System.Drawing.Point(343, 85);
            this.txt_Nuevo_IdPais.Name = "txt_Nuevo_IdPais";
            this.txt_Nuevo_IdPais.Size = new System.Drawing.Size(151, 20);
            this.txt_Nuevo_IdPais.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre Nuevo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Id Nuevo";
            // 
            // frm_Crear_Paises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(520, 254);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Nuevo_NombrePais);
            this.Controls.Add(this.txt_Nuevo_IdPais);
            this.Controls.Add(this.btnSalir_Pais);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre_Pais);
            this.Controls.Add(this.txtId_Pais);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Crear_Paises";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Crear_Paises";
            this.Load += new System.EventHandler(this.frm_Crear_Paises_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ts_Nuevo_Pais;
        private System.Windows.Forms.ToolStripButton ts_Guardar_Pais;
        private System.Windows.Forms.ToolStripButton ts_Eliminar_Pais;
        private System.Windows.Forms.ToolStripButton ts_Cancelar_Accion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox ts_Text_Pais;
        private System.Windows.Forms.ToolStripButton ts_Buscar_Pais;
        private System.Windows.Forms.TextBox txtId_Pais;
        private System.Windows.Forms.TextBox txtNombre_Pais;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir_Pais;
        private System.Windows.Forms.TextBox txt_Nuevo_NombrePais;
        private System.Windows.Forms.TextBox txt_Nuevo_IdPais;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}