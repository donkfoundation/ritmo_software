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
    public partial class frm_Permisos : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        public frm_Permisos()
        {
            InitializeComponent();
        }

        private void defaultState()
        {
            // Se carga el estado por defecto del formulario
            lbl_Nombre_Usuario.Visible = false;
            lbl_PlaceHolder_Nombre.Visible = false;
            lbl_PlaceHolder_Rol.Visible = false;
            lbl_Rol_Usuario.Visible = false;
            txt_Documento.Enabled = true;
            btn_Buscar.Enabled = true;
            txt_Documento.Clear();
            cb_Pais.Checked = false;
            cb_Dpto.Checked = false;
            cb_Ciudad.Checked = false;
            cb_Roles.Checked = false;
            cb_Habitaciones.Checked = false;
            cb_Inventario.Checked = false;
            cb_Paquetes.Checked = false;
            cb_Proveedores.Checked = false;
            cb_Registro.Checked = false;
            cb_Reservas.Checked = false;
            cb_Clientes.Checked = false;
            cb_Reportes.Checked = false;
            cb_Factura.Checked = false;
            cb_Cuenta.Checked = false;
        }

        private void cargarPermisos(SqlDataReader reader)
        {
            // La funcion encargada de cargar los permisos del usuario seleccionado

            if (Boolean.Parse(reader["pais"].ToString()))
            {
                cb_Pais.Checked = true;
            }

            if (Boolean.Parse(reader["departamento"].ToString()))
            {
                cb_Dpto.Checked = true;
            }

            if (Boolean.Parse(reader["ciudad"].ToString()))
            {
                cb_Ciudad.Checked = true;
            }

            if (Boolean.Parse(reader["roles"].ToString()))
            {
                cb_Roles.Checked = true;
            }

            if (Boolean.Parse(reader["habitaciones"].ToString()))
            {
                cb_Habitaciones.Checked = true;
            }

            if (Boolean.Parse(reader["inventario"].ToString()))
            {
                cb_Inventario.Checked = true;
            }

            if (Boolean.Parse(reader["paquetes"].ToString()))
            {
                cb_Paquetes.Checked = true;
            }

            if (Boolean.Parse(reader["proveedores"].ToString()))
            {
                cb_Proveedores.Checked = true;
            }

            if (Boolean.Parse(reader["registro"].ToString()))
            {
                cb_Registro.Checked = true;
            }

            if (Boolean.Parse(reader["reservas"].ToString()))
            {
                cb_Reservas.Checked = true;
            }

            if (Boolean.Parse(reader["clientes"].ToString()))
            {
                cb_Clientes.Checked = true;
            }

            if (Boolean.Parse(reader["reportes"].ToString()))
            {
                cb_Reportes.Checked = true;
            }

            if (Boolean.Parse(reader["factura"].ToString()))
            {
                cb_Factura.Checked = true;
            }

            if (Boolean.Parse(reader["cuenta"].ToString()))
            {
                cb_Cuenta.Checked = true;
            }

        }

        private void frm_Permisos_Load(object sender, EventArgs e)
        {
            defaultState();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            // Se busca el número de documento en la base de datos
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Documento.Text))
                MessageBox.Show("Por favor digite el número de documento del empleado");
            else
            {
                try
                {
                    // Se selecciona el nombre del tipo de rol que tiene el usuario
                    string cadena3 = "SELECT TIPO_ROL FROM ROLES INNER JOIN USUARIOS ON USUARIOS.CARGO = ROLES.COD_ROL AND USUARIOS.NUM_DOC= @num_doc";
                    SqlCommand cmd3 = new SqlCommand(cadena3, conex);
                    cmd3.Parameters.AddWithValue("@num_doc", txt_Documento.Text);

                    SqlDataReader reader3 = cmd3.ExecuteReader();

                    if (reader3.Read())
                    {
                        lbl_Rol_Usuario.Visible = true;
                        lbl_PlaceHolder_Rol.Visible = true;
                        lbl_PlaceHolder_Rol.Text = (reader3["TIPO_ROL"].ToString());
                    }
                    reader3.Close();

                    // Se seleccionan los datos del empleado seleccionado
                    string cadena2 = "SELECT NOMBRES, APELLIDOS FROM USUARIOS WHERE NUM_DOC = @num_doc";
                    SqlCommand cmd2 = new SqlCommand(cadena2, conex);
                    cmd2.Parameters.AddWithValue("@num_doc", txt_Documento.Text);

                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    if (reader2.Read())
                    {
                        lbl_Nombre_Usuario.Visible = true;
                        lbl_PlaceHolder_Nombre.Visible = true;
                        txt_Documento.Enabled = false;
                        btn_Buscar.Enabled = false;
                        lbl_PlaceHolder_Nombre.Text = (reader2["NOMBRES"].ToString() + " " + reader2["APELLIDOS"].ToString());
                    }
                    else
                        MessageBox.Show("Usuario no encontrado");
                    reader2.Close();

                    // Se cargan los permisos del usuario seleccionado
                    string cadena = "SELECT * FROM PERMISOS WHERE NUM_DOCUMENTO = @num_doc";
                    SqlCommand cmd = new SqlCommand(cadena, conex);
                    cmd.Parameters.AddWithValue("@num_doc", txt_Documento.Text);

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            cargarPermisos(reader);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 245) // Error de tipo de dato
                        MessageBox.Show("Error: verifique los tipos de datos");
                }
            }
            connection.closeConnection();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            // Cada vez que se da guardar se actualizan los permisos con los permisos seleccionados.
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Documento.Text))
                MessageBox.Show("Por favor digite el número de documento del empleado");
            else
            {
                string cadena = @"UPDATE PERMISOS
                      SET
                      pais = @pais,
                      departamento = @departamento,
                      ciudad = @ciudad,
                      roles = @roles,
                      habitaciones = @habitaciones,
                      inventario = @inventario,
                      paquetes = @paquetes,
                      proveedores = @proveedores,
                      registro = @registro,
                      reservas = @reservas,
                      clientes = @clientes,
                      reportes = @reportes,
                      factura = @factura,
                      cuenta = @cuenta  
                      WHERE num_documento = @num_doc";

                SqlCommand cmd = new SqlCommand(cadena, conex);

                cmd.Parameters.AddWithValue("@pais", cb_Pais.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@departamento", cb_Dpto.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@ciudad", cb_Ciudad.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@roles", cb_Roles.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@habitaciones", cb_Habitaciones.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@inventario", cb_Inventario.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@paquetes", cb_Paquetes.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@proveedores", cb_Proveedores.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@registro", cb_Registro.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@reservas", cb_Reservas.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@clientes", cb_Clientes.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@reportes", cb_Reportes.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@factura", cb_Factura.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@cuenta", cb_Cuenta.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@num_doc", txt_Documento.Text);

                try
                {
                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        MessageBox.Show("Permisos actualizados correctamente");
                        defaultState();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            connection.closeConnection();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            defaultState();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
