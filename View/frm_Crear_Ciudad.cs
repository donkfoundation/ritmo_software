using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel_nn
{
    public partial class frm_Crear_Ciudad : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        bool es_Nuevo;

        public frm_Crear_Ciudad()
        {
            
            InitializeComponent();
        }


        private void frm_Crear_Ciudad_Load(object sender, EventArgs e)
        {
            // Estado por defecto del formulario
            cb_Ciudad_Dpto.Enabled = false;
            ts_Buscar_Ciudad.Enabled = true;
            ts_Nueva_Ciudad.Enabled = true;
            ts_Eliminar_Ciudad.Enabled = false;
            ts_Guardar_Ciudad.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            txtId_Ciudad.Enabled = false;
            txtNombre_Ciudad.Enabled = false;
            txt_Nuevo_IdCiudad.Visible = false;
            txt_Nuevo_NombreCiudad.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            cb_Nuevo_Ciudad_Dpto.Visible = false;

            Load_Combobox_Dpto();
        }

        private void ts_Nueva_Ciudad_Click(object sender, EventArgs e)
        {
            // Cuando se le da a nueva ciudad se va a cambiar la disponibilidad de ciertos objetos
            cb_Ciudad_Dpto.Enabled = true;
            txtId_Ciudad.Enabled = true;
            txtNombre_Ciudad.Enabled = true;
            ts_Cancelar_Accion.Enabled = true;
            ts_Guardar_Ciudad.Enabled = true;
            es_Nuevo = true;
            txtNombre_Ciudad.Focus();
            ts_Text_Ciudad.Enabled = false;
            ts_Buscar_Ciudad.Enabled = false;
        }

        private void ts_Guardar_Ciudad_Click(object sender, EventArgs e)
        {
            // Cuando se guarda se verifica si la ciudad es nueva o ha sido buscada por el cuadro de texto (para actualizarla en vez de agregarla)
            connection.openConnection();
            if (string.IsNullOrEmpty(txtNombre_Ciudad.Text) || string.IsNullOrEmpty(txtId_Ciudad.Text) || cb_Ciudad_Dpto.SelectedIndex == 0)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (es_Nuevo)
                {
                    string cadena = "INSERT INTO Ciudad(cod_ciudad, nom_ciudad, cod_dpto) VALUES(@cod_ciudad, @nom_ciudad, @cod_dpto)";

                    SqlCommand cmd = new SqlCommand(cadena, conex);
                    cmd.Parameters.AddWithValue("@cod_ciudad", txtId_Ciudad.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@nom_ciudad", txtNombre_Ciudad.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@cod_dpto", cb_Ciudad_Dpto.SelectedValue.ToString());

                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i >= 1)
                            MessageBox.Show($"Ciudad '{txtNombre_Ciudad.Text}' registrada exitosamente");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Violación de clave primaria
                            MessageBox.Show("Ciudad ya existe");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_Nuevo_IdCiudad.Text) || string.IsNullOrEmpty(txt_Nuevo_NombreCiudad.Text) || cb_Nuevo_Ciudad_Dpto.SelectedIndex == 0)
                        MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        string cadena = "UPDATE Ciudad SET cod_ciudad=@cod_ciudad, nom_ciudad=@nom_ciudad, cod_dpto=@cod_dpto WHERE cod_ciudad=@old_cod_ciudad AND nom_ciudad=@old_nom_ciudad AND cod_dpto=@old_cod_dpto";

                        SqlCommand cmd = new SqlCommand(cadena, conex);
                        cmd.Parameters.AddWithValue("@cod_ciudad", txt_Nuevo_IdCiudad.Text);
                        cmd.Parameters.AddWithValue("@nom_ciudad", txt_Nuevo_NombreCiudad.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@cod_dpto", cb_Nuevo_Ciudad_Dpto.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@old_cod_ciudad", txtId_Ciudad.Text);
                        cmd.Parameters.AddWithValue("@old_nom_ciudad", txtNombre_Ciudad.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@old_cod_dpto", cb_Ciudad_Dpto.SelectedValue.ToString());

                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i >= 1)
                                MessageBox.Show($"Ciudad '{txtNombre_Ciudad.Text}' actualizada exitosamente");
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627) // Violación de clave primaria
                                MessageBox.Show("Departamento ya existe");
                        }
                    }
                }
            }

            txt_Nuevo_NombreCiudad.Visible = false;
            cb_Ciudad_Dpto.Enabled = false;
            txt_Nuevo_IdCiudad.Visible = false;
            txtId_Ciudad.Enabled = false;
            txtNombre_Ciudad.Enabled = false;
            txtId_Ciudad.Text = "";
            txtNombre_Ciudad.Text = "";
            txt_Nuevo_IdCiudad.Text = "";
            txt_Nuevo_NombreCiudad.Text = "";
            cb_Ciudad_Dpto.SelectedIndex = 0;
            ts_Nueva_Ciudad.Enabled = true;
            ts_Guardar_Ciudad.Enabled = false;
            ts_Eliminar_Ciudad.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            ts_Buscar_Ciudad.Enabled = true;
            ts_Text_Ciudad.Enabled = true;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            cb_Nuevo_Ciudad_Dpto.Visible = false;
            connection.closeConnection();
        }


        private void ts_Cancelar_Accion_Click(object sender, EventArgs e)
        {
            // Se cancela la acción
            txt_Nuevo_NombreCiudad.Visible = false;
            cb_Ciudad_Dpto.Enabled = false;
            txt_Nuevo_IdCiudad.Visible = false;
            txtId_Ciudad.Enabled = false;
            txtNombre_Ciudad.Enabled = false;
            txtId_Ciudad.Text = "";
            txtNombre_Ciudad.Text = "";
            txt_Nuevo_IdCiudad.Text = "";
            txt_Nuevo_NombreCiudad.Text = "";
            cb_Ciudad_Dpto.SelectedIndex = 0;
            ts_Nueva_Ciudad.Enabled = true;
            ts_Guardar_Ciudad.Enabled = false;
            ts_Eliminar_Ciudad.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            ts_Buscar_Ciudad.Enabled = true;
            ts_Text_Ciudad.Enabled = true;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            cb_Nuevo_Ciudad_Dpto.Visible = false;
        }

        private void ts_Eliminar_Ciudad_Click(object sender, EventArgs e)
        {
            // Aquì se elimina la ciudad
            connection.openConnection();
            string cadena = "DELETE FROM Ciudad WHERE cod_ciudad=@cod_ciudad";

            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue("@cod_ciudad", txtId_Ciudad.Text);

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show($"Ciudad '{txtNombre_Ciudad.Text}' eliminada exitosamente");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Violación de clave foránea (se quiere borrar algo con datos asociados
                    MessageBox.Show("No puede borrar una ciudad con datos asociados a esta.");
            }

            txt_Nuevo_NombreCiudad.Visible = false;
            cb_Ciudad_Dpto.Enabled = false;
            txt_Nuevo_IdCiudad.Visible = false;
            txtId_Ciudad.Enabled = false;
            txtNombre_Ciudad.Enabled = false;
            txtId_Ciudad.Text = "";
            txtNombre_Ciudad.Text = "";
            txt_Nuevo_IdCiudad.Text = "";
            txt_Nuevo_NombreCiudad.Text = "";
            cb_Ciudad_Dpto.SelectedIndex = 0;
            ts_Nueva_Ciudad.Enabled = true;
            ts_Guardar_Ciudad.Enabled = false;
            ts_Eliminar_Ciudad.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            ts_Buscar_Ciudad.Enabled = true;
            ts_Text_Ciudad.Enabled = true;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            cb_Nuevo_Ciudad_Dpto.Visible = false;

            connection.closeConnection();
        }


        private void ts_Buscar_Ciudad_Click(object sender, EventArgs e)
        {
            // Aquí se busca la ciudad que se ha copiado en el cuadro de texto
            connection.openConnection();
            string cadena = "SELECT * FROM Ciudad WHERE nom_ciudad=@nom_ciudad";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue("@nom_ciudad", ts_Text_Ciudad.Text.ToUpper());

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Se deja todo listo para editarla, borrarla o cancelar la acción.
                    ts_Nueva_Ciudad.Enabled = false;
                    ts_Guardar_Ciudad.Enabled = true;
                    ts_Cancelar_Accion.Enabled = true;
                    ts_Eliminar_Ciudad.Enabled = true;
                    ts_Buscar_Ciudad.Enabled = false;
                    ts_Text_Ciudad.Enabled = false;
                    txtId_Ciudad.Enabled = false;
                    cb_Ciudad_Dpto.Enabled = false;
                    txtNombre_Ciudad.Enabled = false;
                    txt_Nuevo_IdCiudad.Visible = true;
                    txt_Nuevo_NombreCiudad.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label6.Visible = true;
                    cb_Nuevo_Ciudad_Dpto.Visible = true;
                    cb_Nuevo_Ciudad_Dpto.SelectedIndex = 0;
                    txtId_Ciudad.Text = reader[0].ToString();
                    txtNombre_Ciudad.Text = reader[1].ToString();
                    cb_Ciudad_Dpto.SelectedValue = reader[2].ToString();
                    es_Nuevo = false;

                    reader.Close();
                }
                else
                {
                    MessageBox.Show($"No se encuentra ninguna ciudad con el nombre de '{ts_Text_Ciudad.Text}'.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

            ts_Text_Ciudad.Clear();
            connection.closeConnection();
        }


        private void Load_Combobox_Dpto()
        {
            // Se cargan los datos del departamento que se va a relacionar.
            connection.openConnection();
            SqlCommand cmd = new SqlCommand("Select cod_dpto, nom_dpto from Dpto", conex);
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            da.Fill(table1);

            DataRow itemrow = table.NewRow();
            DataRow second_itemrow = table1.NewRow();
            itemrow[1] = "seleccione departamento";
            second_itemrow[1] = "seleccione departamento";
            table.Rows.InsertAt(itemrow, 0);
            table1.Rows.InsertAt(second_itemrow, 0);

            cb_Ciudad_Dpto.DataSource = table;
            cb_Ciudad_Dpto.DisplayMember = "nom_dpto";
            cb_Ciudad_Dpto.ValueMember = "cod_dpto";

            cb_Nuevo_Ciudad_Dpto.DataSource = table1;
            cb_Nuevo_Ciudad_Dpto.DisplayMember = "nom_dpto";
            cb_Nuevo_Ciudad_Dpto.ValueMember = "cod_dpto";
            connection.closeConnection();
        }
        private void btnSalir_Ciudad_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
