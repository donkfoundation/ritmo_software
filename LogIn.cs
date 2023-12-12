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
    public partial class LogIn : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;


        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            // se intenta verificar que la conexion funcione
            try
            {
                connection.openConnection();
                connection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    string cadena = "SELECT Usuarios.nombres, Roles.tipo_rol, Ingreso.num_documento FROM Usuarios " +
                                    "INNER JOIN Ingreso ON Usuarios.num_doc = Ingreso.num_documento " +
                                    "INNER JOIN Roles ON Usuarios.cargo = Roles.cod_rol " +
                                    "WHERE Ingreso.num_documento = @documento AND Ingreso.contrasena = @passwd";

                    SqlCommand cmd = new SqlCommand(cadena, conex);
                    // Se compara la contraseña ingresada con la contraseña encriptada en la base de datos
                    string encryptedPasswd = passwordEncrypt.GetSHA256(passwd);
                    cmd.Parameters.AddWithValue("@documento", documento);
                    cmd.Parameters.AddWithValue("@passwd", encryptedPasswd);

                    SqlDataReader dr = cmd.ExecuteReader();

                    // Se inicializan estos datos en el menú principal para tenerlos disponibles en un futuro
                    if (dr.Read())
                    {
                        MessageBox.Show($"Bienvenido {dr.GetValue(0)} {dr.GetValue(1)}: {dr.GetValue(2)}");
                        frm_Menu_Principal menu = new frm_Menu_Principal();
                        menu.UserID = dr.GetValue(0).ToString();
                        menu.UserRol = dr.GetValue(1).ToString();
                        menu.UserDoc = dr.GetValue(2).ToString();
                        this.Hide();
                        menu.Show();
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
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_CrearNuevoUsuario registro = new frm_CrearNuevoUsuario();
            this.Hide();
            registro.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_LogInClientes clientes = new frm_LogInClientes();
            this.Hide();
            clientes.ShowDialog();
        }
    }
}
