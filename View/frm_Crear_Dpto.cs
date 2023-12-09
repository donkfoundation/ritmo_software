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
    public partial class frm_Crear_Dpto : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        bool es_Nuevo;

        public frm_Crear_Dpto()
        {
            
            InitializeComponent();
        }

        private void frm_Crear_Dpto_Load(object sender, EventArgs e)
        {
            // Estado por defecto del formulario
            cb_Dpto_Pais.Enabled = false;
            ts_Buscar_Dpto.Enabled = true;
            ts_Nuevo_Dpto.Enabled = true;
            ts_Eliminar_Dpto.Enabled = false;
            ts_Guardar_Dpto.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            txtId_Dpto.Enabled = false;
            txtNombre_Dpto.Enabled = false;
            txt_Nuevo_IdDpto.Visible = false;
            txt_Nuevo_NombreDpto.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            cb_Nuevo_Dpto_Pais.Visible = false;


            Load_Combobox_Pais();
        }

        private void ts_Nuevo_Dpto_Click(object sender, EventArgs e)
        {
            // Cuando se le da a nuevo departamento se va a cambiar la disponibilidad de ciertos objetos
            cb_Dpto_Pais.Enabled = true;
            txtId_Dpto.Enabled = true;
            txtNombre_Dpto.Enabled = true;
            ts_Cancelar_Accion.Enabled = true;
            ts_Guardar_Dpto.Enabled = true;
            es_Nuevo = true;
            txtNombre_Dpto.Focus();
            ts_Text_Dpto.Enabled = false;
            ts_Buscar_Dpto.Enabled = false;
        }

        private void ts_Guardar_Dpto_Click(object sender, EventArgs e)
        {
            // Cuando se guarda se verifica si el dpto es nuevo o ha sido buscado por el cuadro de texto (para actualizarlo en vez de agregarlo)

            connection.openConnection();
            if (string.IsNullOrEmpty(txtNombre_Dpto.Text) || string.IsNullOrEmpty(txtId_Dpto.Text) || cb_Dpto_Pais.SelectedIndex == 0)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (es_Nuevo)
                {

                    string cadena = $"insert into Dpto(cod_dpto, nom_dpto, cod_pais) values(@cod_dpto, @nom_dpto, @cod_pais)";

                    SqlCommand cmd = new SqlCommand(cadena, conex);
                    cmd.Parameters.AddWithValue("@cod_dpto", txtId_Dpto.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@nom_dpto", txtNombre_Dpto.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@cod_pais", cb_Dpto_Pais.SelectedValue.ToString());

                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i >= 1)
                            MessageBox.Show($"Departamento '{txtNombre_Dpto.Text}' registrado exitosamente");
                        else
                        {
                            MessageBox.Show("error");
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Violación de clave primaria
                            MessageBox.Show("Departamento ya existe");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_Nuevo_IdDpto.Text) || string.IsNullOrEmpty(txt_Nuevo_NombreDpto.Text) || cb_Nuevo_Dpto_Pais.SelectedIndex == 0)
                        MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        string cadena = $"update Dpto set cod_dpto=@nuevo_cod_dpto, nom_dpto=@nuevo_nom_dpto, cod_pais=@nuevo_cod_pais where cod_dpto=@cod_dpto and nom_dpto=@nom_dpto and cod_pais=@cod_pais";

                        SqlCommand cmd = new SqlCommand(cadena, conex);
                        cmd.Parameters.AddWithValue("@nuevo_cod_dpto", txt_Nuevo_IdDpto.Text);
                        cmd.Parameters.AddWithValue("@nuevo_nom_dpto", txt_Nuevo_NombreDpto.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@nuevo_cod_pais", cb_Nuevo_Dpto_Pais.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@cod_dpto", txtNombre_Dpto.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@nom_dpto", txtNombre_Dpto.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@cod_pais", cb_Dpto_Pais.SelectedValue.ToString());

                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i >= 1)
                                MessageBox.Show($"Departamento '{txtNombre_Dpto.Text}' actualizado exitosamente");
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627) // Violación de clave primaria
                                MessageBox.Show("Departamento ya existe");
                            else if (ex.Number == 2601) // Violación de índice único
                                MessageBox.Show("No puede haber un nombre de departamento repetido");
                        }
                    }
                }
            }

            txt_Nuevo_NombreDpto.Visible = false;
            cb_Dpto_Pais.Enabled = false;
            txt_Nuevo_IdDpto.Visible = false;
            txtId_Dpto.Enabled = false;
            txtNombre_Dpto.Enabled = false;
            txtId_Dpto.Text = "";
            txtNombre_Dpto.Text = "";
            txt_Nuevo_IdDpto.Text = "";
            txt_Nuevo_NombreDpto.Text = "";
            cb_Dpto_Pais.SelectedIndex = 0;
            ts_Nuevo_Dpto.Enabled = true;
            ts_Guardar_Dpto.Enabled = false;
            ts_Eliminar_Dpto.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            ts_Buscar_Dpto.Enabled = true;
            ts_Text_Dpto.Enabled = true;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            cb_Nuevo_Dpto_Pais.Visible = false;

            connection.closeConnection();

        }

        private void ts_Cancelar_Accion_Click(object sender, EventArgs e)
        {
            // Se cancela la acción
            txt_Nuevo_NombreDpto.Visible = false;
            cb_Dpto_Pais.Enabled = false;
            txt_Nuevo_IdDpto.Visible = false;
            txtId_Dpto.Enabled = false;
            txtNombre_Dpto.Enabled = false;
            txtId_Dpto.Text = "";
            txtNombre_Dpto.Text = "";
            txt_Nuevo_IdDpto.Text = "";
            txt_Nuevo_NombreDpto.Text = "";
            cb_Dpto_Pais.SelectedIndex = 0;
            ts_Nuevo_Dpto.Enabled = true;
            ts_Guardar_Dpto.Enabled = false;
            ts_Eliminar_Dpto.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            ts_Buscar_Dpto.Enabled = true;
            ts_Text_Dpto.Enabled = true;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            cb_Nuevo_Dpto_Pais.Visible = false;
        }

        private void ts_Eliminar_Dpto_Click(object sender, EventArgs e)
        {
            // Aquí se elimina el departamento siempre y cuando no hayan ciudades asociadas a este.
            connection.openConnection();
            string cadena = "DELETE FROM Dpto WHERE cod_dpto=@cod_dpto";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue("@cod_dpto", txtId_Dpto.Text);

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show($"Departamento '{txtNombre_Dpto.Text}' eliminado exitosamente");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Violación de clave foránea (se quiere borrar algo con datos asociados
                    MessageBox.Show("No puede borrar un departamento con datos asociados a este.");
            }

            txt_Nuevo_NombreDpto.Visible = false;
            cb_Dpto_Pais.Enabled = false;
            txt_Nuevo_IdDpto.Visible = false;
            txtId_Dpto.Enabled = false;
            txtNombre_Dpto.Enabled = false;
            txtId_Dpto.Text = "";
            txtNombre_Dpto.Text = "";
            txt_Nuevo_IdDpto.Text = "";
            txt_Nuevo_NombreDpto.Text = "";
            cb_Dpto_Pais.SelectedIndex = 0;
            ts_Nuevo_Dpto.Enabled = true;
            ts_Guardar_Dpto.Enabled = false;
            ts_Eliminar_Dpto.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            ts_Buscar_Dpto.Enabled = true;
            ts_Text_Dpto.Enabled = true;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            cb_Nuevo_Dpto_Pais.Visible = false;

            connection.closeConnection();
        }


        private void ts_Buscar_Dpto_Click(object sender, EventArgs e)
        {
            // Aquí se busca el depto que se ha copiado en el cuadro de texto
            connection.openConnection();
            string cadena = "SELECT * FROM Dpto WHERE nom_dpto=@nom_dpto";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue("@nom_dpto", ts_Text_Dpto.Text.ToUpper());

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Se deja todo listo para editarla, borrarla o cancelar la acción.
                    ts_Nuevo_Dpto.Enabled = false;
                    ts_Guardar_Dpto.Enabled = true;
                    ts_Cancelar_Accion.Enabled = true;
                    ts_Eliminar_Dpto.Enabled = true;
                    ts_Buscar_Dpto.Enabled = false;
                    ts_Text_Dpto.Enabled = false;
                    txtId_Dpto.Enabled = false;
                    cb_Dpto_Pais.Enabled = false;
                    txtNombre_Dpto.Enabled = false;
                    txt_Nuevo_IdDpto.Visible = true;
                    txt_Nuevo_NombreDpto.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label6.Visible = true;
                    cb_Nuevo_Dpto_Pais.Visible = true;
                    cb_Nuevo_Dpto_Pais.SelectedIndex = 0;
                    txtId_Dpto.Text = reader[0].ToString();
                    txtNombre_Dpto.Text = reader[1].ToString();
                    cb_Dpto_Pais.SelectedValue = reader[2].ToString();
                    es_Nuevo = false;

                    reader.Close();
                }
                else
                    MessageBox.Show($"No se encuentra ningún departamento con el nombre de '{ts_Text_Dpto.Text}'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

            ts_Text_Dpto.Clear();
            connection.closeConnection();
        }


        private void Load_Combobox_Pais()
        {
            // Se cargan los datos del pais que se va a relacionar.
            connection.openConnection();
            SqlCommand cmd = new SqlCommand("Select cod_pais, nom_pais from Pais", conex);
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            da.Fill(table1);

            DataRow itemrow = table.NewRow();
            DataRow second_itemrow = table1.NewRow();
            itemrow[1] = "seleccione país";
            second_itemrow[1] = "seleccione país";
            table.Rows.InsertAt(itemrow, 0);
            table1.Rows.InsertAt(second_itemrow, 0);

            cb_Dpto_Pais.DataSource = table;
            cb_Dpto_Pais.DisplayMember = "nom_pais";
            cb_Dpto_Pais.ValueMember = "cod_pais";

            cb_Nuevo_Dpto_Pais.DataSource = table1;
            cb_Nuevo_Dpto_Pais.DisplayMember = "nom_pais";
            cb_Nuevo_Dpto_Pais.ValueMember = "cod_pais";
            connection.closeConnection();
        }

        private void btnSalir_Dpto_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
