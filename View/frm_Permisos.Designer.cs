namespace hotel_nn
{
    partial class frm_Permisos
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
            this.txt_Documento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.lbl_Nombre_Usuario = new System.Windows.Forms.Label();
            this.lbl_PlaceHolder_Nombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Pais = new System.Windows.Forms.CheckBox();
            this.cb_Dpto = new System.Windows.Forms.CheckBox();
            this.cb_Ciudad = new System.Windows.Forms.CheckBox();
            this.cb_Roles = new System.Windows.Forms.CheckBox();
            this.cb_Habitaciones = new System.Windows.Forms.CheckBox();
            this.cb_Inventario = new System.Windows.Forms.CheckBox();
            this.cb_Paquetes = new System.Windows.Forms.CheckBox();
            this.cb_Cuenta = new System.Windows.Forms.CheckBox();
            this.cb_Factura = new System.Windows.Forms.CheckBox();
            this.cb_Reportes = new System.Windows.Forms.CheckBox();
            this.cb_Clientes = new System.Windows.Forms.CheckBox();
            this.cb_Reservas = new System.Windows.Forms.CheckBox();
            this.cb_Registro = new System.Windows.Forms.CheckBox();
            this.cb_Proveedores = new System.Windows.Forms.CheckBox();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.lbl_Rol_Usuario = new System.Windows.Forms.Label();
            this.lbl_PlaceHolder_Rol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Documento
            // 
            this.txt_Documento.Location = new System.Drawing.Point(100, 22);
            this.txt_Documento.Name = "txt_Documento";
            this.txt_Documento.Size = new System.Drawing.Size(292, 20);
            this.txt_Documento.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Documento";
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Buscar.FlatAppearance.BorderSize = 0;
            this.btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Buscar.Location = new System.Drawing.Point(412, 22);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 2;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // lbl_Nombre_Usuario
            // 
            this.lbl_Nombre_Usuario.AutoSize = true;
            this.lbl_Nombre_Usuario.Location = new System.Drawing.Point(32, 71);
            this.lbl_Nombre_Usuario.Name = "lbl_Nombre_Usuario";
            this.lbl_Nombre_Usuario.Size = new System.Drawing.Size(47, 13);
            this.lbl_Nombre_Usuario.TabIndex = 3;
            this.lbl_Nombre_Usuario.Text = "Nombre:";
            // 
            // lbl_PlaceHolder_Nombre
            // 
            this.lbl_PlaceHolder_Nombre.AutoSize = true;
            this.lbl_PlaceHolder_Nombre.Location = new System.Drawing.Point(97, 71);
            this.lbl_PlaceHolder_Nombre.Name = "lbl_PlaceHolder_Nombre";
            this.lbl_PlaceHolder_Nombre.Size = new System.Drawing.Size(35, 13);
            this.lbl_PlaceHolder_Nombre.TabIndex = 4;
            this.lbl_PlaceHolder_Nombre.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Permisos:";
            // 
            // cb_Pais
            // 
            this.cb_Pais.AutoSize = true;
            this.cb_Pais.Location = new System.Drawing.Point(35, 147);
            this.cb_Pais.Name = "cb_Pais";
            this.cb_Pais.Size = new System.Drawing.Size(108, 17);
            this.cb_Pais.TabIndex = 6;
            this.cb_Pais.Text = "Formulario Paises";
            this.cb_Pais.UseVisualStyleBackColor = true;
            // 
            // cb_Dpto
            // 
            this.cb_Dpto.AutoSize = true;
            this.cb_Dpto.Location = new System.Drawing.Point(35, 181);
            this.cb_Dpto.Name = "cb_Dpto";
            this.cb_Dpto.Size = new System.Drawing.Size(149, 17);
            this.cb_Dpto.TabIndex = 7;
            this.cb_Dpto.Text = "Formulario Departamentos";
            this.cb_Dpto.UseVisualStyleBackColor = true;
            // 
            // cb_Ciudad
            // 
            this.cb_Ciudad.AutoSize = true;
            this.cb_Ciudad.Location = new System.Drawing.Point(35, 213);
            this.cb_Ciudad.Name = "cb_Ciudad";
            this.cb_Ciudad.Size = new System.Drawing.Size(121, 17);
            this.cb_Ciudad.TabIndex = 8;
            this.cb_Ciudad.Text = "Formulario Ciudades";
            this.cb_Ciudad.UseVisualStyleBackColor = true;
            // 
            // cb_Roles
            // 
            this.cb_Roles.AutoSize = true;
            this.cb_Roles.Location = new System.Drawing.Point(35, 246);
            this.cb_Roles.Name = "cb_Roles";
            this.cb_Roles.Size = new System.Drawing.Size(104, 17);
            this.cb_Roles.TabIndex = 9;
            this.cb_Roles.Text = "Formulario Roles";
            this.cb_Roles.UseVisualStyleBackColor = true;
            // 
            // cb_Habitaciones
            // 
            this.cb_Habitaciones.AutoSize = true;
            this.cb_Habitaciones.Location = new System.Drawing.Point(35, 280);
            this.cb_Habitaciones.Name = "cb_Habitaciones";
            this.cb_Habitaciones.Size = new System.Drawing.Size(139, 17);
            this.cb_Habitaciones.TabIndex = 10;
            this.cb_Habitaciones.Text = "Formulario Habitaciones";
            this.cb_Habitaciones.UseVisualStyleBackColor = true;
            // 
            // cb_Inventario
            // 
            this.cb_Inventario.AutoSize = true;
            this.cb_Inventario.Location = new System.Drawing.Point(35, 313);
            this.cb_Inventario.Name = "cb_Inventario";
            this.cb_Inventario.Size = new System.Drawing.Size(124, 17);
            this.cb_Inventario.TabIndex = 11;
            this.cb_Inventario.Text = "Formulario Inventario";
            this.cb_Inventario.UseVisualStyleBackColor = true;
            // 
            // cb_Paquetes
            // 
            this.cb_Paquetes.AutoSize = true;
            this.cb_Paquetes.Location = new System.Drawing.Point(35, 346);
            this.cb_Paquetes.Name = "cb_Paquetes";
            this.cb_Paquetes.Size = new System.Drawing.Size(122, 17);
            this.cb_Paquetes.TabIndex = 12;
            this.cb_Paquetes.Text = "Formulario Paquetes";
            this.cb_Paquetes.UseVisualStyleBackColor = true;
            // 
            // cb_Cuenta
            // 
            this.cb_Cuenta.AutoSize = true;
            this.cb_Cuenta.Location = new System.Drawing.Point(306, 346);
            this.cb_Cuenta.Name = "cb_Cuenta";
            this.cb_Cuenta.Size = new System.Drawing.Size(111, 17);
            this.cb_Cuenta.TabIndex = 19;
            this.cb_Cuenta.Text = "Formulario Cuenta";
            this.cb_Cuenta.UseVisualStyleBackColor = true;
            // 
            // cb_Factura
            // 
            this.cb_Factura.AutoSize = true;
            this.cb_Factura.Location = new System.Drawing.Point(306, 313);
            this.cb_Factura.Name = "cb_Factura";
            this.cb_Factura.Size = new System.Drawing.Size(113, 17);
            this.cb_Factura.TabIndex = 18;
            this.cb_Factura.Text = "Formulario Factura";
            this.cb_Factura.UseVisualStyleBackColor = true;
            // 
            // cb_Reportes
            // 
            this.cb_Reportes.AutoSize = true;
            this.cb_Reportes.Location = new System.Drawing.Point(306, 280);
            this.cb_Reportes.Name = "cb_Reportes";
            this.cb_Reportes.Size = new System.Drawing.Size(120, 17);
            this.cb_Reportes.TabIndex = 17;
            this.cb_Reportes.Text = "Formulario Reportes";
            this.cb_Reportes.UseVisualStyleBackColor = true;
            // 
            // cb_Clientes
            // 
            this.cb_Clientes.AutoSize = true;
            this.cb_Clientes.Location = new System.Drawing.Point(306, 246);
            this.cb_Clientes.Name = "cb_Clientes";
            this.cb_Clientes.Size = new System.Drawing.Size(114, 17);
            this.cb_Clientes.TabIndex = 16;
            this.cb_Clientes.Text = "Formulario Clientes";
            this.cb_Clientes.UseVisualStyleBackColor = true;
            // 
            // cb_Reservas
            // 
            this.cb_Reservas.AutoSize = true;
            this.cb_Reservas.Location = new System.Drawing.Point(306, 213);
            this.cb_Reservas.Name = "cb_Reservas";
            this.cb_Reservas.Size = new System.Drawing.Size(122, 17);
            this.cb_Reservas.TabIndex = 15;
            this.cb_Reservas.Text = "Formulario Reservas";
            this.cb_Reservas.UseVisualStyleBackColor = true;
            // 
            // cb_Registro
            // 
            this.cb_Registro.AutoSize = true;
            this.cb_Registro.Location = new System.Drawing.Point(306, 181);
            this.cb_Registro.Name = "cb_Registro";
            this.cb_Registro.Size = new System.Drawing.Size(160, 17);
            this.cb_Registro.TabIndex = 14;
            this.cb_Registro.Text = "Formulario Registro Usuarios";
            this.cb_Registro.UseVisualStyleBackColor = true;
            // 
            // cb_Proveedores
            // 
            this.cb_Proveedores.AutoSize = true;
            this.cb_Proveedores.Location = new System.Drawing.Point(306, 147);
            this.cb_Proveedores.Name = "cb_Proveedores";
            this.cb_Proveedores.Size = new System.Drawing.Size(137, 17);
            this.cb_Proveedores.TabIndex = 13;
            this.cb_Proveedores.Text = "Formulario Proveedores";
            this.cb_Proveedores.UseVisualStyleBackColor = true;
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Salir.FlatAppearance.BorderSize = 0;
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir.Location = new System.Drawing.Point(412, 387);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(75, 23);
            this.btn_Salir.TabIndex = 21;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = false;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Guardar.FlatAppearance.BorderSize = 0;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Location = new System.Drawing.Point(331, 387);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_Guardar.TabIndex = 22;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btn_Limpiar.FlatAppearance.BorderSize = 0;
            this.btn_Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Limpiar.Location = new System.Drawing.Point(250, 387);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_Limpiar.TabIndex = 23;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // lbl_Rol_Usuario
            // 
            this.lbl_Rol_Usuario.AutoSize = true;
            this.lbl_Rol_Usuario.Location = new System.Drawing.Point(250, 71);
            this.lbl_Rol_Usuario.Name = "lbl_Rol_Usuario";
            this.lbl_Rol_Usuario.Size = new System.Drawing.Size(26, 13);
            this.lbl_Rol_Usuario.TabIndex = 24;
            this.lbl_Rol_Usuario.Text = "Rol:";
            // 
            // lbl_PlaceHolder_Rol
            // 
            this.lbl_PlaceHolder_Rol.AutoSize = true;
            this.lbl_PlaceHolder_Rol.Location = new System.Drawing.Point(303, 71);
            this.lbl_PlaceHolder_Rol.Name = "lbl_PlaceHolder_Rol";
            this.lbl_PlaceHolder_Rol.Size = new System.Drawing.Size(35, 13);
            this.lbl_PlaceHolder_Rol.TabIndex = 25;
            this.lbl_PlaceHolder_Rol.Text = "label3";
            // 
            // frm_Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(514, 422);
            this.Controls.Add(this.lbl_PlaceHolder_Rol);
            this.Controls.Add(this.lbl_Rol_Usuario);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.cb_Cuenta);
            this.Controls.Add(this.cb_Factura);
            this.Controls.Add(this.cb_Reportes);
            this.Controls.Add(this.cb_Clientes);
            this.Controls.Add(this.cb_Reservas);
            this.Controls.Add(this.cb_Registro);
            this.Controls.Add(this.cb_Proveedores);
            this.Controls.Add(this.cb_Paquetes);
            this.Controls.Add(this.cb_Inventario);
            this.Controls.Add(this.cb_Habitaciones);
            this.Controls.Add(this.cb_Roles);
            this.Controls.Add(this.cb_Ciudad);
            this.Controls.Add(this.cb_Dpto);
            this.Controls.Add(this.cb_Pais);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_PlaceHolder_Nombre);
            this.Controls.Add(this.lbl_Nombre_Usuario);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Documento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Permisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Permisos";
            this.Load += new System.EventHandler(this.frm_Permisos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Documento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label lbl_Nombre_Usuario;
        private System.Windows.Forms.Label lbl_PlaceHolder_Nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_Pais;
        private System.Windows.Forms.CheckBox cb_Dpto;
        private System.Windows.Forms.CheckBox cb_Ciudad;
        private System.Windows.Forms.CheckBox cb_Roles;
        private System.Windows.Forms.CheckBox cb_Habitaciones;
        private System.Windows.Forms.CheckBox cb_Inventario;
        private System.Windows.Forms.CheckBox cb_Paquetes;
        private System.Windows.Forms.CheckBox cb_Cuenta;
        private System.Windows.Forms.CheckBox cb_Factura;
        private System.Windows.Forms.CheckBox cb_Reportes;
        private System.Windows.Forms.CheckBox cb_Clientes;
        private System.Windows.Forms.CheckBox cb_Reservas;
        private System.Windows.Forms.CheckBox cb_Registro;
        private System.Windows.Forms.CheckBox cb_Proveedores;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Label lbl_Rol_Usuario;
        private System.Windows.Forms.Label lbl_PlaceHolder_Rol;
    }
}