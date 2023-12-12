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

namespace hotel_nn
{
    public partial class frm_LogInClientes : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        public frm_LogInClientes()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_CrearNuevoCliente nuevo_cliente = new frm_CrearNuevoCliente();
            this.Hide();
            nuevo_cliente.ShowDialog();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Se da click al boton de ingresar
            connection.openConnection();
            // Se recuperan los datos en los textbox;
            string passwd = txtPassword.Text;
            string documento = txtDocumento.Text;

            if (string.IsNullOrEmpty(passwd) || string.IsNullOrEmpty(documento))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    // Se hace la cadena que va a devolver el nombre, rol y documento del usuario ingresado
                    string cadena = "SELECT Clientes.num_doc, Clientes.nombres, Clientes.apellidos FROM Clientes INNER JOIN IngresoClientes ON Clientes.num_doc = IngresoClientes.num_documento WHERE Clientes.num_doc = @documento AND IngresoClientes.contrasena = @passwd";

                    SqlCommand cmd = new SqlCommand(cadena, conex);
                    // Se compara la contraseña ingresada con la contraseña encriptada en la base de datos
                    string encryptedPasswd = passwordEncrypt.GetSHA256(passwd);
                    cmd.Parameters.AddWithValue("@documento", documento);
                    cmd.Parameters.AddWithValue("@passwd", encryptedPasswd);

                    SqlDataReader dr = cmd.ExecuteReader();

                    // Se inicializan estos datos en el menú principal para tenerlos disponibles en un futuro
                    if (dr.Read())
                    {
                        frm_ModoCliente modo_cliente = new frm_ModoCliente();
                        modo_cliente.userId = dr.GetValue(0).ToString();
                        modo_cliente.userName = dr.GetValue(1).ToString() + " " + dr.GetValue(2).ToString();
                        this.Hide();
                        modo_cliente.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecto.");
                    }

                    dr.Close();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 245) //Error de tipo de dato
                    {
                        MessageBox.Show("Usuario o contraseña incorrecto.");
                    }
                }
            }

            connection.closeConnection();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            new LogIn().Show();
        }
    }
}
