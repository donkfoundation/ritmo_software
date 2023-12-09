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
    public partial class frm_Asignacion_Roles : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        public frm_Asignacion_Roles()
        {
            InitializeComponent();
            
        }

        private void loadCombobox()
        {
            // Se cargan los tipos de roles disponibles
            SqlCommand cmd2 = new SqlCommand("select tipo_rol, cod_rol from Roles;", conex);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            da.Fill(table);

            DataRow itemrow = table.NewRow();
            itemrow[0] = "seleccione rol";
            table.Rows.InsertAt(itemrow, 0);

            cbRol_Roles.DataSource = table;
            cbRol_Roles.DisplayMember = "tipo_rol";
            cbRol_Roles.ValueMember = "cod_rol";

        }

        private void LoadForm()
        {
            // Estado por defecto del formulario
            txtCedula_Roles.Enabled = true;
            txtNombre_Roles.Enabled = false;
            cbRol_Roles.Enabled = false;
            btnLimpiar_Roles.Enabled = false;
            btnGuardar_Roles.Enabled = false;

            txtCedula_Roles.Clear();
            txtNombre_Roles.Clear();
            cbRol_Roles.SelectedIndex = 0;
        }

        private void frm_Asignacion_Roles_Load(object sender, EventArgs e)
        {
            loadCombobox();
            LoadForm();
        }


        private void pbBuscar_Roles_Click(object sender, EventArgs e)
        { 
            // Se busca el usuario al cual le queremos asignar un rol diferente
            connection.openConnection();
            btnLimpiar_Roles.Enabled = true;
            SqlCommand cmd = new SqlCommand("SELECT num_doc, nombres, apellidos FROM Usuarios WHERE num_doc=@num_doc", conex);
            cmd.Parameters.AddWithValue("@num_doc", txtCedula_Roles.Text);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Cargamos los datos del usuario
                    txtCedula_Roles.Enabled = false;
                    txtNombre_Roles.Enabled = false;
                    txtNombre_Roles.Text = reader[1].ToString() + " " + reader[2].ToString();
                    cbRol_Roles.Enabled = true;
                    btnGuardar_Roles.Enabled = true;
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("No se encuentra ningún usuario con ese número de documento");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 245) // Error de tipo de dato
                    MessageBox.Show("Error: verifique los tipos de datos");
            }
            connection.closeConnection();
        }


        private void btnGuardar_Roles_Click(object sender, EventArgs e)
        {
            // Se actualiza el cargo o rol del usuario seleccionado
            connection.openConnection();
            if (string.IsNullOrEmpty(txtCedula_Roles.Text) || string.IsNullOrEmpty(txtNombre_Roles.Text) || cbRol_Roles.SelectedIndex == 0)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string cadena = "UPDATE Usuarios SET cargo=@cargo WHERE num_doc=@num_doc";
                try
                {
                    SqlCommand cmd = new SqlCommand(cadena, conex);
                    cmd.Parameters.AddWithValue("@cargo", cbRol_Roles.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@num_doc", txtCedula_Roles.Text);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show($"Rol del usuario {txtNombre_Roles.Text} actualizado exitosamente");
                    else
                        MessageBox.Show("Hubo un error, intente nuevamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            LoadForm();
            connection.closeConnection();
        }

        private void btnLimpiar_Roles_Click(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
