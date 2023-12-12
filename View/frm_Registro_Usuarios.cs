using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using hotel_nn.Controller;

namespace hotel_nn
{
    public partial class frm_Registro_Usuarios : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        bool es_Nuevo;
        public frm_Registro_Usuarios()
        {
            
            InitializeComponent();
        }

        private void LoadComboboxes()
        {
            // Se cargan los tipos de rol que va a tener el usuario
            connection.openConnection();

            SqlCommand cmd = new SqlCommand("Select cod_rol, tipo_rol from Roles", conex);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            DataRow itemrow = table.NewRow();
            itemrow[1] = "seleccione rol";
            table.Rows.InsertAt(itemrow, 0);

            cbCargo_Usuarios.DataSource = table;
            cbCargo_Usuarios.DisplayMember = "tipo_rol";
            cbCargo_Usuarios.ValueMember = "cod_rol";

            cmd = new SqlCommand("select nom_ciudad from Ciudad order by nom_ciudad desc", conex);
            table = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(table);

            itemrow = table.NewRow();
            itemrow[0] = "seleccione ciudad";
            table.Rows.InsertAt(itemrow, 0);

            cbLugarNac_Usuarios.DataSource = table;
            cbLugarNac_Usuarios.DisplayMember = "nom_ciudad";
            cbLugarNac_Usuarios.ValueMember = "nom_ciudad";

            connection.closeConnection();
        }

        private void Clear()
        {
            // Se limpian los campos
            txtApellido_Usuarios.Clear();
            txtCorreo_Usuarios.Clear();
            txtDireccion_Usuarios.Clear();
            txtDocumento_Usuarios.Clear();
            txtNombre_Usuarios.Clear();
            txtTelefono_Usuario.Clear();
            txt_Passwd_Usuarios.Clear();
            txt_ConfirmarPasswd_Usuarios.Clear();
            cbCargo_Usuarios.SelectedIndex = 0;
            cbGenero_Usuarios.SelectedIndex = 0;
            cbLugarNac_Usuarios.SelectedIndex = 0;
            cbTipoDoc_Usuarios.SelectedIndex = 0;
        }

        private void CargarDefault()
        {
            // Se carga el estado por defecto del formulario
            ts_Buscar_Pais.Enabled = true;
            ts_Nuevo_Usuarios.Enabled = true;
            ts_Text_Usuarios.Enabled = true;
            ts_Eliminar_Pais.Enabled = false;
            ts_Guardar_Pais.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            cbCargo_Usuarios.Enabled = false;
            cbTipoDoc_Usuarios.Enabled = false;
            cbGenero_Usuarios.Enabled = false;
            cbLugarNac_Usuarios.Enabled = false;
            dtpFechaExp_Usuarios.Enabled = false;
            dtpFechaNac_Usuarios.Enabled = false;
            txtApellido_Usuarios.Enabled = false;
            txtDocumento_Usuarios.Enabled = false;
            txtNombre_Usuarios.Enabled = false;
            txtCorreo_Usuarios.Enabled = false;
            txtDireccion_Usuarios.Enabled = false;
            txtTelefono_Usuario.Enabled = false;
            txt_ConfirmarPasswd_Usuarios.Enabled = false;
            txt_Passwd_Usuarios.Enabled = false;
        }

        private void frm_Registro_Usuarios_Load(object sender, EventArgs e)
        {
            LoadComboboxes();
            CargarDefault();
            Clear();

        }

        private void ts_Nuevo_Usuarios_Click(object sender, EventArgs e)
        {
            // Se habilitan o desabilitan botones cuando se da click a usuario nuevo
            ts_Buscar_Pais.Enabled = false;
            ts_Text_Usuarios.Enabled = false;
            ts_Guardar_Pais.Enabled = true;
            ts_Cancelar_Accion.Enabled = true;
            cbCargo_Usuarios.Enabled = true;
            cbTipoDoc_Usuarios.Enabled = true;
            cbGenero_Usuarios.Enabled = true;
            cbLugarNac_Usuarios.Enabled = true;
            dtpFechaExp_Usuarios.Enabled = true;
            dtpFechaNac_Usuarios.Enabled = true;
            txtApellido_Usuarios.Enabled = true;
            txtNombre_Usuarios.Enabled = true;
            txtCorreo_Usuarios.Enabled = true;
            txtDireccion_Usuarios.Enabled = true;
            txt_Passwd_Usuarios.Enabled = true;
            txt_ConfirmarPasswd_Usuarios.Enabled = true;
            txtTelefono_Usuario.Enabled = true;
            txtDocumento_Usuarios.Enabled = true;
            es_Nuevo = true;
            txtDocumento_Usuarios.Focus();

        }

        private void ts_Guardar_Pais_Click(object sender, EventArgs e)
        {
            // Para guardar el usuario
            connection.openConnection();
            if (string.IsNullOrEmpty(txtApellido_Usuarios.Text) || string.IsNullOrEmpty(txtCorreo_Usuarios.Text) || string.IsNullOrEmpty(txtDireccion_Usuarios.Text) || string.IsNullOrEmpty(txtNombre_Usuarios.Text) || string.IsNullOrEmpty(txtTelefono_Usuario.Text) || string.IsNullOrEmpty(txt_Passwd_Usuarios.Text) || string.IsNullOrEmpty(txt_ConfirmarPasswd_Usuarios.Text) || cbCargo_Usuarios.SelectedIndex == 0 || cbTipoDoc_Usuarios.SelectedIndex == 0 || cbGenero_Usuarios.SelectedIndex == 0 || cbLugarNac_Usuarios.SelectedIndex == 0)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                if (es_Nuevo)
                {
                    // Se verifica que el correo tenga formato de correo
                    if (!validateEmail.validate(txtCorreo_Usuarios.Text))
                        MessageBox.Show("Ingrese un formato de correo electrónico correcto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    else  
                    {
                        // Se verifica antes de guardar que ambas contraseñas coincidan
                        if (txt_Passwd_Usuarios.Text != txt_ConfirmarPasswd_Usuarios.Text)
                        {
                            MessageBox.Show("Las contraseñas no coinciden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            string insertUsuarioQuery = "INSERT INTO Usuarios(tipo_doc, num_doc, apellidos, nombres, fecha_nac, fecha_exp, lug_nacimiento, genero, direccion, correo, telefono, cargo) VALUES (@tipo_doc, @num_doc, @apellidos, @nombres, @fecha_nac, @fecha_exp, @lug_nacimiento, @genero, @direccion, @correo, @telefono, @cargo)";

                            SqlCommand cmd = new SqlCommand(insertUsuarioQuery, conex);
                            cmd.Parameters.AddWithValue("@tipo_doc", cbTipoDoc_Usuarios.Text.ToUpper());
                            cmd.Parameters.AddWithValue("@num_doc", txtDocumento_Usuarios.Text);
                            cmd.Parameters.AddWithValue("@apellidos", txtApellido_Usuarios.Text.ToUpper());
                            cmd.Parameters.AddWithValue("@nombres", txtNombre_Usuarios.Text.ToUpper());
                            cmd.Parameters.AddWithValue("@fecha_nac", dtpFechaNac_Usuarios.Value);
                            cmd.Parameters.AddWithValue("@fecha_exp", dtpFechaExp_Usuarios.Value);
                            cmd.Parameters.AddWithValue("@lug_nacimiento", cbLugarNac_Usuarios.Text.ToUpper());
                            cmd.Parameters.AddWithValue("@genero", cbGenero_Usuarios.Text.ToUpper());
                            cmd.Parameters.AddWithValue("@direccion", txtDireccion_Usuarios.Text.ToUpper());
                            cmd.Parameters.AddWithValue("@correo", txtCorreo_Usuarios.Text.ToUpper());
                            cmd.Parameters.AddWithValue("@telefono", txtTelefono_Usuario.Text);
                            cmd.Parameters.AddWithValue("@cargo", cbCargo_Usuarios.SelectedValue.ToString());

                            try
                            {
                                int i = cmd.ExecuteNonQuery();
                                if (i >= 1)
                                    MessageBox.Show($"Usuario '{txtDocumento_Usuarios.Text}' registrado exitosamente");
                            }
                            catch (SqlException ex)
                            {
                                if (ex.Number == 2627) // Violación de clave primaria
                                    MessageBox.Show("Usuario ya existe");
                            }

                                // Se encripta la contraseña con el modulo Encrypt para agregar el nuevo usuario a la tabla ingreso
                            string insertIngresoQuery = "INSERT INTO Ingreso(num_documento, contrasena) VALUES (@num_documento, @contrasena)";
                            SqlCommand cmd3 = new SqlCommand(insertIngresoQuery, conex);
                            string passwd = passwordEncrypt.GetSHA256(txt_ConfirmarPasswd_Usuarios.Text);
                            cmd3.Parameters.AddWithValue("@num_documento", txtDocumento_Usuarios.Text);
                            cmd3.Parameters.AddWithValue("@contrasena", passwd);

                            try
                            {
                                int i = cmd3.ExecuteNonQuery();
                                if (i < 1)
                                    MessageBox.Show("Hubo un error.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                CargarDefault();
                                Clear();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex);
                            }
                        }
                    }
                }
                else
                {
                    // Si el usuario no es nuevo se hace el mismo proceso pero se actualiza en vez de agregarse.
                    txtDocumento_Usuarios.Enabled = false;
                    cbCargo_Usuarios.Enabled = false;

                    if (!validateEmail.validate(txtCorreo_Usuarios.Text))
                        MessageBox.Show("Ingrese un formato de correo electrónico correcto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    else
                    {
                        string updateUsuarioQuery = "UPDATE Usuarios SET tipo_doc=@tipo_doc, apellidos=@apellidos, nombres=@nombres, fecha_nac=@fecha_nac, fecha_exp=@fecha_exp, lug_nacimiento=@lug_nacimiento, genero=@genero, direccion=@direccion, correo=@correo, telefono=@telefono WHERE num_doc=@num_doc";

                        SqlCommand cmd = new SqlCommand(updateUsuarioQuery, conex);
                        cmd.Parameters.AddWithValue("@tipo_doc", cbTipoDoc_Usuarios.Text);
                        cmd.Parameters.AddWithValue("@apellidos", txtApellido_Usuarios.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@nombres", txtNombre_Usuarios.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@fecha_nac", dtpFechaNac_Usuarios.Value);
                        cmd.Parameters.AddWithValue("@fecha_exp", dtpFechaExp_Usuarios.Value);
                        cmd.Parameters.AddWithValue("@lug_nacimiento", cbLugarNac_Usuarios.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@genero", cbGenero_Usuarios.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion_Usuarios.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@correo", txtCorreo_Usuarios.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono_Usuario.Text);
                        cmd.Parameters.AddWithValue("@num_doc", txtDocumento_Usuarios.Text);

                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i >= 1)
                                MessageBox.Show($"Usuario '{txtDocumento_Usuarios.Text}' actualizado exitosamente");
                        }
                        catch(SqlException ex)
                        {
                            if (ex.Number == 2627) // Violación de clave primaria
                                MessageBox.Show("Usuario ya existe");
                        }

                        // Se encripta la contraseña con el modulo Encrypt para actualizar la contraseña del usuario en la tabla ingreso
                        string updateIngresoQuery = "UPDATE Ingreso set contrasena = @contrasena WHERE num_documento = @num_documento";
                        SqlCommand cmd3 = new SqlCommand(updateIngresoQuery, conex);
                        string passwd = passwordEncrypt.GetSHA256(txt_ConfirmarPasswd_Usuarios.Text);
                        cmd3.Parameters.AddWithValue("@num_documento", txtDocumento_Usuarios.Text);
                        cmd3.Parameters.AddWithValue("@contrasena", passwd);

                        try
                        {
                            int i = cmd3.ExecuteNonQuery();
                            if (i < 1)
                                MessageBox.Show("Hubo un error.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            CargarDefault();
                            Clear();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex);
                        }
                    }
                }
            }

            connection.closeConnection();
        }


        private void ts_Cancelar_Accion_Click(object sender, EventArgs e)
        {
            CargarDefault();
            Clear();
        }

        private void ts_Eliminar_Pais_Click(object sender, EventArgs e)
        {
            // Se elimina el usuario seleccionado.
            connection.openConnection();
            string deleteUsuarioQuery = "DELETE FROM Permisos WHERE num_documento = @num_doc; DELETE FROM Ingreso WHERE num_documento = @num_doc ;DELETE FROM Usuarios WHERE num_doc=@num_doc";
            SqlCommand cmd = new SqlCommand(deleteUsuarioQuery, conex);
            cmd.Parameters.AddWithValue("@num_doc", txtDocumento_Usuarios.Text);

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show($"Usuario '{txtDocumento_Usuarios.Text}' eliminado exitosamente");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Violación de clave foránea (se quiere borrar algo con datos asociados
                    MessageBox.Show("No puede borrar un usuario con datos asociados a este.");
            }

            CargarDefault();
            Clear();
            connection.closeConnection();
        }


        private void ts_Buscar_Pais_Click(object sender, EventArgs e)
        {
            // Se busca el usuario seleccionado  y se cargan los datos
            connection.openConnection();
            try
            {
                string selectUsuarioQuery = "SELECT * FROM Usuarios WHERE num_doc=@num_doc";
                SqlCommand cmd = new SqlCommand(selectUsuarioQuery, conex);
                cmd.Parameters.AddWithValue("@num_doc", ts_Text_Usuarios.Text);

                SqlCommand cmd2 = new SqlCommand("SELECT tipo_rol FROM Roles WHERE cod_rol=(SELECT cargo FROM Usuarios WHERE num_doc=@num_doc);", conex);
                cmd2.Parameters.AddWithValue("@num_doc", ts_Text_Usuarios.Text);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                string cargo_usuario = "";
                if (reader2.Read())
                    cargo_usuario = reader2.GetString(0);

                reader2.Close();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ts_Nuevo_Usuarios.Enabled = false;
                    ts_Guardar_Pais.Enabled = true;
                    ts_Cancelar_Accion.Enabled = true;
                    ts_Eliminar_Pais.Enabled = true;
                    ts_Buscar_Pais.Enabled = false;
                    ts_Text_Usuarios.Enabled = false;
                    txtNombre_Usuarios.Enabled = true;
                    txtApellido_Usuarios.Enabled = true;
                    txtCorreo_Usuarios.Enabled = true;
                    txtDireccion_Usuarios.Enabled = true;
                    txtDocumento_Usuarios.Enabled = false;
                    txtTelefono_Usuario.Enabled = true;
                    cbCargo_Usuarios.Enabled = false;
                    cbGenero_Usuarios.Enabled = true;
                    cbLugarNac_Usuarios.Enabled = true;
                    cbTipoDoc_Usuarios.Enabled = true;
                    txt_ConfirmarPasswd_Usuarios.Enabled = true;
                    txt_Passwd_Usuarios.Enabled = true;
                    dtpFechaExp_Usuarios.Enabled = true;
                    dtpFechaNac_Usuarios.Enabled = true;
                    cbCargo_Usuarios.Text = cargo_usuario;
                    cbGenero_Usuarios.Text = reader[7].ToString();
                    cbLugarNac_Usuarios.Text = reader[6].ToString();
                    cbTipoDoc_Usuarios.Text = reader[0].ToString();
                    txtDocumento_Usuarios.Text = reader[1].ToString();
                    txtApellido_Usuarios.Text = reader[2].ToString();
                    txtCorreo_Usuarios.Text = reader[9].ToString();
                    txtDireccion_Usuarios.Text = reader[8].ToString();
                    txtNombre_Usuarios.Text = reader[3].ToString();
                    txtTelefono_Usuario.Text = reader[10].ToString();
                    dtpFechaExp_Usuarios.Text = reader[5].ToString();
                    dtpFechaNac_Usuarios.Text = reader[4].ToString();
                    es_Nuevo = false;

                    reader.Close();
                }
                else
                    MessageBox.Show($"No se encuentra ningún Usuario con el documento: '{ts_Text_Usuarios.Text}'.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 245) // Error de tipo de dato
                    MessageBox.Show("Error: verifique los tipos de datos");
            }

            ts_Text_Usuarios.Text = "";
            connection.closeConnection();
        }

        private void btnSalir_Pais_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
