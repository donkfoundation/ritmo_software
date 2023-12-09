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
    public partial class Tipo_De_Habitacion : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        SqlDataAdapter da;
        DataSet ds;
        private string idViejo;
        public Tipo_De_Habitacion()
        {
            InitializeComponent();
             
        }

        private void Limpiar()
        {
            txt_DescripHabitacion.Clear();
            txt_TipoHab.Clear();
        }

        private void LoadItems()
        {
            // Se cargan todos los items de la tabla descripcion de habitación
            lv_TipoHabitacion.Columns.Clear();
            lv_TipoHabitacion.Items.Clear();

            lv_TipoHabitacion.Columns.Add("Código");
            lv_TipoHabitacion.Columns.Add("Descripción");

            foreach (ColumnHeader column in lv_TipoHabitacion.Columns)
            {
                column.Width = lv_TipoHabitacion.Width / lv_TipoHabitacion.Columns.Count;
            }

            SqlCommand cmd = new SqlCommand("select * from DescripHabitacion", conex);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Test Table");

            DataTable dt = ds.Tables["Test Table"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lv_TipoHabitacion.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                lv_TipoHabitacion.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
            }
            Limpiar();
        }
        private void Tipo_De_Habitacion_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void lv_TipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se selecciona un tipo de habitacion se completan los campos en los cuadros de texto
            try
            {
                txt_TipoHab.Text = lv_TipoHabitacion.SelectedItems[0].SubItems[0].Text;
                idViejo = txt_TipoHab.Text;
                txt_DescripHabitacion.Text = lv_TipoHabitacion.SelectedItems[0].SubItems[1].Text;
            }
            catch (Exception)
            {

            }
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btn_Borrar_Click(object sender, EventArgs e)
        {
            // Se borra el tipo de habitación
            connection.openConnection();
            SqlCommand cmd;
            for (int i = 0; i < lv_TipoHabitacion.SelectedItems.Count; i++)
            {
                cmd = new SqlCommand("DELETE FROM DescripHabitacion WHERE tipo_hab= @tipo_hab", conex);
                cmd.Parameters.AddWithValue("@tipo_hab", lv_TipoHabitacion.SelectedItems[i].Text);
                try
                {
                    int j = cmd.ExecuteNonQuery();
                    if (j > 0)
                        MessageBox.Show($"Tipo de habitación eliminado");
                    else
                        MessageBox.Show("Error");
                }
                catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un tipo de habitación para borrar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un tipo de habitación para borrar");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Número de error si se quiere borrar un tipo de habitacion con datos asociados a esta
                        MessageBox.Show("No se puede borrar porque hay habitaciones de este tipo");
                }
                LoadItems();
            }
            connection.closeConnection();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            // Se agrega el tipo de habitacion
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_TipoHab.Text) || string.IsNullOrEmpty(txt_DescripHabitacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string cadena = "INSERT INTO DescripHabitacion(tipo_hab, descripcion) VALUES(@tipo_hab, @descripcion)";

                SqlCommand cmd = new SqlCommand(cadena, conex);
                cmd.Parameters.AddWithValue("@tipo_hab", txt_TipoHab.Text);
                cmd.Parameters.AddWithValue("@descripcion", txt_DescripHabitacion.Text);

                try
                {
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                        MessageBox.Show("Tipo de habitación añadido");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Número de error si se quiere agregar un tipo de habitación con llave primaria repetida (tipo_hab)
                        MessageBox.Show("Tipo de habitación ya existe");
                    else
                        MessageBox.Show(ex.ToString());
                }
                LoadItems();
            }
            connection.closeConnection();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            // Se edita la habitación
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_TipoHab.Text) || string.IsNullOrEmpty(txt_DescripHabitacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Aquí si podremos editar el tipo de habitacion (llave primaria), para eso necesitamos saber 
                // cual era la llave primaria previa, que será idViejo, esta variable se actualizará cada vez que cambiemos
                // de seleccion de tipo de habitacion

                // Primero se crea un nuevo tipo de habitación con los datos nuevos, se actualizan las habitaciones
                // que estabam asociadas a este y se borra el viejo tipo
                string cadena = $"INSERT INTO DescripHabitacion(tipo_hab, descripcion) VALUES(@tipo_hab, @descripcion); UPDATE Habitaciones SET tipo_hab = @tipo_hab WHERE tipo_hab = '{idViejo}'; DELETE DescripHabitacion WHERE tipo_hab = '{idViejo}'";

                SqlCommand cmd = new SqlCommand(cadena, conex);
                cmd.Parameters.AddWithValue("@tipo_hab", txt_TipoHab.Text);
                cmd.Parameters.AddWithValue("@descripcion", txt_DescripHabitacion.Text);

                try
                {
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                        MessageBox.Show("Habitacion Actualizada");
                }
                catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un tipo de habitación para editar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un tipo de habitacion para editar");
                }
                catch (SqlException ex)
                {
                    // Si solo queremos actualizar la descripción saldrá un error de llave primaria por que creerá que queremos insertar una habitacion nueva
                    // entonces manejamos esta excepcion.
                    if (ex.Number == 2627)
                    {
                        SqlCommand cmd2 = new SqlCommand("UPDATE DescripHabitacion SET descripcion = @descripcion WHERE tipo_hab = @tipo_hab", conex);
                        cmd2.Parameters.AddWithValue("@descripcion", txt_DescripHabitacion.Text);
                        cmd2.Parameters.AddWithValue("@tipo_hab", txt_TipoHab.Text);

                        try
                        {
                            int j = cmd2.ExecuteNonQuery();

                            if (j > 0)
                                MessageBox.Show("Habitacion Actualizada");
                        }
                        catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                        {
                            MessageBox.Show("Seleccione un tipo de habitación para editar");
                        }
                        catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                        {
                            MessageBox.Show("Seleccione un tipo de habitación para editar");
                        }
                    }
                    else
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                LoadItems();
            }
            connection.closeConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
