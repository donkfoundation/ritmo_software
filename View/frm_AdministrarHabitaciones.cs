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
    public partial class frm_AdministrarHabitaciones : Form
    {

        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;

        public frm_AdministrarHabitaciones()
        {
            InitializeComponent();
            
        }

        private void LoadItems()
        {
            // Se cargan las habitaciones
            lv_AdminHabitaciones.Items.Clear();
            lv_AdminHabitaciones.Columns.Clear();
            lv_AdminHabitaciones.Columns.Add("Número de Habitación");
            lv_AdminHabitaciones.Columns.Add("Tipo de Habitación");
            lv_AdminHabitaciones.Columns.Add("Estado");
            lv_AdminHabitaciones.Columns.Add("Capacidad");
            lv_AdminHabitaciones.Columns.Add("Precio");

            foreach (ColumnHeader column in lv_AdminHabitaciones.Columns)
            {
                column.Width = lv_AdminHabitaciones.Width / lv_AdminHabitaciones.Columns.Count;
            }

            SqlCommand cmd = new SqlCommand("select * from Habitaciones", conex);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Test Table");

            dt = ds.Tables["Test Table"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                {
                    // Aquí se cambia el color según el contenido de la columna estado
                    ListViewItem listViewItem = new ListViewItem(dt.Rows[i]["num_hab"].ToString());
                    listViewItem.UseItemStyleForSubItems = false;
                    listViewItem.SubItems.Add(dt.Rows[i]["tipo_hab"].ToString());
                    ListViewItem.ListViewSubItem estadoSubItem = new ListViewItem.ListViewSubItem(listViewItem, dt.Rows[i]["estado"].ToString());
                    string estado = estadoSubItem.Text;

                    if (estado == "D")
                        estadoSubItem.ForeColor = Color.Green;
                    else if (estado == "O")
                        estadoSubItem.ForeColor = Color.Red;
                    else if (estado == "M")
                        estadoSubItem.ForeColor = Color.Yellow;

                    listViewItem.SubItems.Add(estadoSubItem);
                    listViewItem.SubItems.Add(dt.Rows[i]["capacidad"].ToString());
                    listViewItem.SubItems.Add(dt.Rows[i]["precio"].ToString());
                    lv_AdminHabitaciones.Items.Add(listViewItem);
                }
            }
        }

        private void frm_AdministrarHabitaciones_Load(object sender, EventArgs e)
        {
            LoadItems();
            Load_Cb();
            cb_Estado_Habitacion.SelectedIndex = 0;
        }

        private void Load_Cb()
        {
            // Se cargan los tipos de habitaciones disponibles
            connection.openConnection();
            SqlCommand cmd = new SqlCommand("Select tipo_hab from DescripHabitacion", conex);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            DataRow itemrow = table.NewRow();
            itemrow[0] = "seleccione descricion";
            table.Rows.InsertAt(itemrow, 0);

            cb_Tipo_de_Habitacion.DataSource = table;
            cb_Tipo_de_Habitacion.DisplayMember = "tipo_hab";
            cb_Tipo_de_Habitacion.ValueMember = "tipo_hab";
            connection.closeConnection();
        }

        private void Limpiar()
        {
            // Se limpian los campos
            txt_Numero_de_habitacion.Clear();
            cb_Estado_Habitacion.SelectedIndex = 0;
            cb_Tipo_de_Habitacion.SelectedIndex = 0;
            txt_Capacidad_Habitacion.Clear();
            txt_Precio_Habitacion.Clear();
        }

        private void btn_Limpiar_habitaciones_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btn_Agregar_Habitaciones_Click(object sender, EventArgs e)
        {
            // Se agrega la habitación
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Capacidad_Habitacion.Text) || string.IsNullOrEmpty(txt_Numero_de_habitacion.Text) || string.IsNullOrEmpty(txt_Precio_Habitacion.Text) || cb_Estado_Habitacion.SelectedIndex == 0 || cb_Tipo_de_Habitacion.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string cadena = "INSERT INTO Habitaciones(num_hab, tipo_hab, estado, capacidad, precio) VALUES(@num_hab, @tipo_hab, @estado, @capacidad, @precio)";

                SqlCommand cmd = new SqlCommand(cadena, conex);
                cmd.Parameters.AddWithValue("@num_hab", txt_Numero_de_habitacion.Text);
                cmd.Parameters.AddWithValue("@tipo_hab", cb_Tipo_de_Habitacion.Text);
                cmd.Parameters.AddWithValue("@estado", cb_Estado_Habitacion.Text);
                cmd.Parameters.AddWithValue("@capacidad", txt_Capacidad_Habitacion.Text);
                cmd.Parameters.AddWithValue("@precio", txt_Precio_Habitacion.Text);

                try
                {
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                        MessageBox.Show("Habitacion Añadida");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 245) // Error de tipo de dato
                        MessageBox.Show("Error: verifique los tipos de datos");
                    else if (ex.Number == 2627) // Violación de índice único
                        MessageBox.Show("Habitación ya existe");
                }
                LoadItems();
            }
            connection.closeConnection();
        }


        private void btn_Borrar_Habitacion_Click(object sender, EventArgs e)
        { 
            // Se borra la habitación
            connection.openConnection();
            SqlCommand cmd;
            for (int i = 0; i < lv_AdminHabitaciones.SelectedItems.Count; i++)
            {
                cmd = new SqlCommand("DELETE FROM Habitaciones WHERE num_hab=@num_hab", conex);
                try
                {
                    cmd.Parameters.AddWithValue("@num_hab", lv_AdminHabitaciones.SelectedItems[i].Text);
                    int j = cmd.ExecuteNonQuery();
                    if (j > 0)
                        MessageBox.Show($"Habitación {lv_AdminHabitaciones.SelectedItems[i].Text} eliminada");
                    else
                        MessageBox.Show("Error");
                }
                catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione una habitación para borrar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione una habitación para borrar");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Violación de clave foránea (se quiere borrar algo con datos asociados
                        MessageBox.Show("No puede borrar una habitación con datos asociados a este.");
                }
                LoadItems();
            }
            connection.closeConnection();
        }


        private void lv_AdminHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se selecciona una habitación diferente se seleccionan los datos de esta en los cuadraos de texto
            try
            {
                txt_Numero_de_habitacion.Text = lv_AdminHabitaciones.SelectedItems[0].SubItems[0].Text;
                cb_Tipo_de_Habitacion.Text = lv_AdminHabitaciones.SelectedItems[0].SubItems[1].Text;
                cb_Estado_Habitacion.Text = lv_AdminHabitaciones.SelectedItems[0].SubItems[2].Text;
                txt_Capacidad_Habitacion.Text = lv_AdminHabitaciones.SelectedItems[0].SubItems[3].Text;
                txt_Precio_Habitacion.Text = lv_AdminHabitaciones.SelectedItems[0].SubItems[4].Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Editar_Habitacion_Click(object sender, EventArgs e)
        {
            // Se edita la habitación
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Capacidad_Habitacion.Text) || string.IsNullOrEmpty(txt_Numero_de_habitacion.Text) || string.IsNullOrEmpty(txt_Precio_Habitacion.Text) || cb_Estado_Habitacion.SelectedIndex == 0 || cb_Tipo_de_Habitacion.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string cadena = "UPDATE habitaciones SET tipo_hab=@tipo_hab, estado=@estado, capacidad=@capacidad, precio=@precio WHERE num_hab=@num_hab";

                SqlCommand cmd = new SqlCommand(cadena, conex);
                cmd.Parameters.AddWithValue("@tipo_hab", cb_Tipo_de_Habitacion.Text);
                cmd.Parameters.AddWithValue("@estado", cb_Estado_Habitacion.Text);
                cmd.Parameters.AddWithValue("@capacidad", txt_Capacidad_Habitacion.Text);
                cmd.Parameters.AddWithValue("@precio", txt_Precio_Habitacion.Text);
                cmd.Parameters.AddWithValue("@num_hab", txt_Numero_de_habitacion.Text);

                try
                {
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                        MessageBox.Show("Habitacion Actualizada");
                }
                catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione una habitación para editar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione una habitación para editar");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 245) // Error de tipo de dato
                        MessageBox.Show("Error: verifique los tipos de datos");
                }
                LoadItems();
            }
            connection.closeConnection();
        }

        private void btn_Salir_Inventario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}