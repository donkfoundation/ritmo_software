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
    public partial class frm_VerClientes : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        public frm_VerClientes()
        {
            InitializeComponent();
             
        }

        private void LoadListView()
        {
            // Cargar todos los clientes registrados en la base de datos
            lv_Clientes_Registrados.Items.Clear();
            lv_Clientes_Registrados.Columns.Clear();

            lv_Clientes_Registrados.Columns.Add("Tipo de Doc");
            lv_Clientes_Registrados.Columns.Add("Número de Doc");
            lv_Clientes_Registrados.Columns.Add("Nombres");
            lv_Clientes_Registrados.Columns.Add("Apellidos");
            lv_Clientes_Registrados.Columns.Add("Género");
            lv_Clientes_Registrados.Columns.Add("País");
            lv_Clientes_Registrados.Columns.Add("Dirección");
            lv_Clientes_Registrados.Columns.Add("Teléfono");
            lv_Clientes_Registrados.Columns.Add("Correo");

            foreach (ColumnHeader column in lv_Clientes_Registrados.Columns)
            {
                column.Width = lv_Clientes_Registrados.Width / lv_Clientes_Registrados.Columns.Count;
            }

            SqlCommand cmd = new SqlCommand("select * from Clientes", conex);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Test Table");

            dt = ds.Tables["Test Table"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lv_Clientes_Registrados.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                lv_Clientes_Registrados.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                lv_Clientes_Registrados.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                lv_Clientes_Registrados.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                lv_Clientes_Registrados.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                lv_Clientes_Registrados.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                lv_Clientes_Registrados.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                lv_Clientes_Registrados.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                lv_Clientes_Registrados.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
            }
        }

        private void frm_VerClientes_Load(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
