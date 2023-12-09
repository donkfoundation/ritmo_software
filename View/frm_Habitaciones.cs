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
    public partial class frm_Habitaciones : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        public frm_Habitaciones()
        {
            InitializeComponent();
             
        }

        private void LoadItems()
        {
            // Se carga un preview de las habitaciones
            lv_Habitaciones.Items.Clear();
            lv_Habitaciones.Columns.Clear();

            lv_Habitaciones.Columns.Add("Número de Habitación");
            lv_Habitaciones.Columns.Add("Tipo de Habitación");
            lv_Habitaciones.Columns.Add("Estado");
            lv_Habitaciones.Columns.Add("Capacidad");
            lv_Habitaciones.Columns.Add("Precio");

            foreach (ColumnHeader column in lv_Habitaciones.Columns)
            {
                column.Width = lv_Habitaciones.Width / lv_Habitaciones.Columns.Count;
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
                    lv_Habitaciones.Items.Add(listViewItem);

                }
            }
        }

        private void frm_Habitaciones_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void btn_TipoHabitaciones_Click(object sender, EventArgs e)
        {
            // Abrir formulario de tipo de habitaciones
            connection.closeConnection();
            Form Tipo_De_Habitacion = new Tipo_De_Habitacion();
            Tipo_De_Habitacion.ShowDialog();
        }

        private void btn_AdminHabitaciones_Click(object sender, EventArgs e)
        {
            // Abrir formulario para administrar habitaciones
            Form habitaciones = new frm_AdministrarHabitaciones();
            habitaciones.Show();
        }

        // Se vuelven a cargar los datos cuando se le da click al botón
        private void btn_RefrescarHab_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
