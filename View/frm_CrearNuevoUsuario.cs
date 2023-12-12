using Microsoft.ReportingServices.Diagnostics.Internal;
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
    public partial class frm_CrearNuevoUsuario : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        public frm_CrearNuevoUsuario()
        {
            InitializeComponent();
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

        private void frm_CrearNuevoUsuario_Load(object sender, EventArgs e)
        {
            LoadComboboxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Para guardar el usuario
            connection.openConnection();
            if (string.IsNullOrEmpty(txtApellido_Usuarios.Text) || string.IsNullOrEmpty(txtCorreo_Usuarios.Text) || string.IsNullOrEmpty(txtDireccion_Usuarios.Text) || string.IsNullOrEmpty(txtNombre_Usuarios.Text) || string.IsNullOrEmpty(txtTelefono_Usuario.Text) || string.IsNullOrEmpty(txt_Passwd_Usuarios.Text) || string.IsNullOrEmpty(txt_ConfirmarPasswd_Usuarios.Text) || cbCargo_Usuarios.SelectedIndex == 0 || cbTipoDoc_Usuarios.SelectedIndex == 0 || cbGenero_Usuarios.SelectedIndex == 0 || cbLugarNac_Usuarios.SelectedIndex == 0)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
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
                            else
                                MessageBox.Show(ex.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
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
                            
                            Clear();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex);
                        }
                    }
                }
            connection.closeConnection();
            }
        }

        private void btnSalir_Pais_Click(object sender, EventArgs e)
        {
            this.Close();
            new LogIn().Show();
        }
    }
}
