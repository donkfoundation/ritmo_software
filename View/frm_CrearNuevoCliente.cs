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
    public partial class frm_CrearNuevoCliente : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        public frm_CrearNuevoCliente()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            // Se limpian los campos
            txtApellido_Clientes.Clear();
            txtCorreo_Clientes.Clear();
            txtDireccion_Clientes.Clear();
            txtDocumento_Clientes.Clear();
            txtNombre_Clientes.Clear();
            txtTelefono_Clientes.Clear();
            txt_Passwd_Clientes.Clear();
            txt_ConfirmarPasswd_Clientes.Clear();
            cbGenero_Clientes.SelectedIndex = 0;
            cbLugarNac_Clientes.SelectedIndex = 0;
            cbTipoDoc_Clientes.SelectedIndex = 0;
        }

        private void LoadCombobox()
        {
            // Se cargan los tipos de rol que va a tener el usuario
            connection.openConnection();

            SqlCommand cmd = new SqlCommand("Select nom_pais, cod_pais from Pais", conex);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            DataRow itemrow = table.NewRow();
            itemrow[0] = "seleccione país";
            table.Rows.InsertAt(itemrow, 0);

            cbLugarNac_Clientes.DataSource = table;
            cbLugarNac_Clientes.DisplayMember = "nom_pais";
            cbLugarNac_Clientes.ValueMember = "cod_pais";

            connection.closeConnection();
        }

        private void frm_CrearNuevoCliente_Load(object sender, EventArgs e)
        {
            LoadCombobox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            // Para guardar el usuario
            connection.openConnection();
            if (string.IsNullOrEmpty(txtApellido_Clientes.Text) || string.IsNullOrEmpty(txtCorreo_Clientes.Text) || string.IsNullOrEmpty(txtDireccion_Clientes.Text) || string.IsNullOrEmpty(txtNombre_Clientes.Text) || string.IsNullOrEmpty(txtTelefono_Clientes.Text) || string.IsNullOrEmpty(txt_Passwd_Clientes.Text) || string.IsNullOrEmpty(txt_ConfirmarPasswd_Clientes.Text) || cbTipoDoc_Clientes.SelectedIndex == 0 || cbGenero_Clientes.SelectedIndex == 0 || cbLugarNac_Clientes.SelectedIndex == 0)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                // Se verifica que el correo tenga formato de correo
                if (!validateEmail.validate(txtCorreo_Clientes.Text))
                    MessageBox.Show("Ingrese un formato de correo electrónico correcto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else
                {
                    // Se verifica antes de guardar que ambas contraseñas coincidan
                    if (txt_Passwd_Clientes.Text != txt_ConfirmarPasswd_Clientes.Text)
                    {
                        MessageBox.Show("Las contraseñas no coinciden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string insertUsuarioQuery = "INSERT INTO Clientes(tipo_doc, num_doc, apellidos, nombres, genero, pais_residencia, direccion, telefono, correo) VALUES (@tipo_doc, @num_doc, @apellidos, @nombres, @genero, @pais_residencia, @direccion, @telefono, @correo)";

                        SqlCommand cmd = new SqlCommand(insertUsuarioQuery, conex);
                        cmd.Parameters.AddWithValue("@tipo_doc", cbTipoDoc_Clientes.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@num_doc", txtDocumento_Clientes.Text);
                        cmd.Parameters.AddWithValue("@apellidos", txtApellido_Clientes.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@nombres", txtNombre_Clientes.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@pais_residencia", cbLugarNac_Clientes.SelectedValue);
                        cmd.Parameters.AddWithValue("@genero", cbGenero_Clientes.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion_Clientes.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono_Clientes.Text);
                        cmd.Parameters.AddWithValue("@correo", txtCorreo_Clientes.Text.ToUpper());

                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i >= 1)
                                MessageBox.Show($"Cliente '{txtDocumento_Clientes.Text}' registrado exitosamente");
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627) // Violación de clave primaria
                                MessageBox.Show("Cliente ya existe");
                            else
                                MessageBox.Show(ex.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        // Se encripta la contraseña con el modulo Encrypt para agregar el nuevo usuario a la tabla ingreso
                        string insertIngresoQuery = "INSERT INTO IngresoClientes(num_documento, contrasena) VALUES (@num_documento, @contrasena)";
                        SqlCommand cmd3 = new SqlCommand(insertIngresoQuery, conex);
                        string passwd = passwordEncrypt.GetSHA256(txt_ConfirmarPasswd_Clientes.Text);
                        cmd3.Parameters.AddWithValue("@num_documento", txtDocumento_Clientes.Text);
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

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
            new frm_LogInClientes().Show();
        }
    }
}
