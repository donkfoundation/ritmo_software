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
    public partial class frm_Crear_Paises : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        bool es_Nuevo;

        public frm_Crear_Paises()
        {
            
            InitializeComponent();
        }

        private void frm_Crear_Paises_Load(object sender, EventArgs e)
        {
            // Estado por defecto del formulario
            ts_Buscar_Pais.Enabled = true;
            ts_Nuevo_Pais.Enabled = true;
            ts_Eliminar_Pais.Enabled = false;
            ts_Guardar_Pais.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            txtId_Pais.Enabled = false;
            txtNombre_Pais.Enabled = false;
            txt_Nuevo_IdPais.Visible = false;
            txt_Nuevo_NombrePais.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }


        private void ts_Nuevo_Pais_Click(object sender, EventArgs e)
        {
            // Cuando se le da a nuevo pais se va a cambiar la disponibilidad de ciertos objetos
            txtId_Pais.Enabled = true;
            txtNombre_Pais.Enabled = true;
            ts_Cancelar_Accion.Enabled = true;
            ts_Guardar_Pais.Enabled = true;
            es_Nuevo = true;
            txtNombre_Pais.Focus();
            ts_Text_Pais.Enabled = false;
            ts_Buscar_Pais.Enabled = false;
        }

        private void ts_Guardar_Pais_Click(object sender, EventArgs e)
        {
            // Cuando se guarda se verifica si el pais es nuevo o ha sido buscado por el cuadro de texto (para actualizarlo en vez de agregarlo)
            connection.openConnection();
            if (string.IsNullOrEmpty(txtNombre_Pais.Text) || string.IsNullOrEmpty(txtId_Pais.Text))
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (es_Nuevo)
                {
                    string cadena = "INSERT INTO Pais(cod_pais, nom_pais) VALUES (@cod_pais, @nom_pais)";
                    SqlCommand cmd = new SqlCommand(cadena, conex);
                    cmd.Parameters.AddWithValue("@cod_pais", txtId_Pais.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@nom_pais", txtNombre_Pais.Text.ToUpper());

                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i >= 1)
                            MessageBox.Show($"País '{txtNombre_Pais.Text}' registrado exitosamente");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Violación de clave primaria o nombre repetido
                            MessageBox.Show("País ya existe");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_Nuevo_IdPais.Text) || string.IsNullOrEmpty(txt_Nuevo_NombrePais.Text))
                        MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        string cadena = "UPDATE Pais SET cod_pais=@nuevo_cod_pais, nom_pais=@nuevo_nom_pais WHERE cod_pais=@cod_pais";
                        SqlCommand cmd = new SqlCommand(cadena, conex);
                        cmd.Parameters.AddWithValue("@nuevo_cod_pais", txt_Nuevo_IdPais.Text);
                        cmd.Parameters.AddWithValue("@nuevo_nom_pais", txt_Nuevo_NombrePais.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@cod_pais", txtId_Pais.Text);

                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i >= 1)
                                MessageBox.Show($"País '{txtNombre_Pais.Text}' actualizado exitosamente");
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627) // Violación de clave primaria
                                MessageBox.Show("País ya existe");
                        }
                    }
                }
            }

            label3.Visible = false;
            label4.Visible = false;
            txt_Nuevo_IdPais.Visible = false;
            txt_Nuevo_NombrePais.Visible = false;
            txtId_Pais.Text = "";
            txtNombre_Pais.Text = "";
            txt_Nuevo_IdPais.Text = "";
            txt_Nuevo_NombrePais.Text = "";
            ts_Buscar_Pais.Enabled = true;
            ts_Nuevo_Pais.Enabled = true;
            ts_Eliminar_Pais.Enabled = false;
            ts_Guardar_Pais.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            txtId_Pais.Enabled = false;
            txtNombre_Pais.Enabled = false;
            ts_Text_Pais.Enabled = true;

            connection.closeConnection();
        }


        private void ts_Cancelar_Accion_Click(object sender, EventArgs e)
        {
            // Se cancela la acción
            txt_Nuevo_NombrePais.Visible = false;
            txt_Nuevo_IdPais.Visible = false;
            txtId_Pais.Enabled = false;
            txtNombre_Pais.Enabled = false;
            txtId_Pais.Text = "";
            txtNombre_Pais.Text = "";
            txt_Nuevo_IdPais.Text = "";
            txt_Nuevo_NombrePais.Text = "";
            ts_Nuevo_Pais.Enabled = true;
            ts_Guardar_Pais.Enabled = false;
            ts_Eliminar_Pais.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            ts_Buscar_Pais.Enabled = true;
            ts_Text_Pais.Enabled = true;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void ts_Eliminar_Pais_Click(object sender, EventArgs e)
        {
            // Aquí se elimina el pais siempre y cuando no hayan departamentos asociados a este.
            connection.openConnection();
            string cadena = "DELETE FROM Pais WHERE cod_pais=@cod_pais";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue("@cod_pais", txtId_Pais.Text);

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show($"País '{txtNombre_Pais.Text}' eliminado exitosamente");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Violación de clave foránea (se quiere borrar algo con datos asociados
                    MessageBox.Show("No puede borrar un país con datos asociados a este.");
            }

            txt_Nuevo_NombrePais.Visible = false;
            txt_Nuevo_IdPais.Visible = false;
            txtId_Pais.Enabled = false;
            txtNombre_Pais.Enabled = false;
            txtId_Pais.Text = "";
            txtNombre_Pais.Text = "";
            txt_Nuevo_IdPais.Text = "";
            txt_Nuevo_NombrePais.Text = "";
            ts_Nuevo_Pais.Enabled = true;
            ts_Guardar_Pais.Enabled = false;
            ts_Eliminar_Pais.Enabled = false;
            ts_Cancelar_Accion.Enabled = false;
            ts_Buscar_Pais.Enabled = true;
            ts_Text_Pais.Enabled = true;
            label3.Visible = false;
            label4.Visible = false;

            connection.closeConnection();
        }


        private void ts_Buscar_Pais_Click(object sender, EventArgs e)
        {
            // Aquí se busca el pais que se ha copiado en el cuadro de texto
            connection.openConnection();
            string cadena = "SELECT * FROM Pais WHERE nom_pais = @nom_pais";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue("@nom_pais", ts_Text_Pais.Text.ToUpper());

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ts_Nuevo_Pais.Enabled = false;
                    ts_Guardar_Pais.Enabled = true;
                    ts_Cancelar_Accion.Enabled = true;
                    ts_Eliminar_Pais.Enabled = true;
                    ts_Buscar_Pais.Enabled = false;
                    ts_Text_Pais.Enabled = false;
                    txtId_Pais.Enabled = false;
                    txtNombre_Pais.Enabled = false;
                    txt_Nuevo_IdPais.Visible = true;
                    txt_Nuevo_NombrePais.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    txtId_Pais.Text = reader[0].ToString();
                    txtNombre_Pais.Text = reader[1].ToString();
                    es_Nuevo = false;

                    reader.Close();
                }
                else
                    MessageBox.Show($"No se encuentra ningún país con el nombre de '{ts_Text_Pais.Text}'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

            ts_Text_Pais.Text = "";
            connection.closeConnection();
        }

        private void btnSalir_Pais_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
