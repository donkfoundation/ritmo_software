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
    public partial class frm_Reservas : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;

        public frm_Reservas()
        {
             
            InitializeComponent();
        }

        private void LoadReservasLv()
        {
            // Se cargan todas las reservas
            connection.openConnection();
            lv_Preview_Reservas.Items.Clear();
            lv_Preview_Reservas.Columns.Clear();

            lv_Preview_Reservas.Columns.Add("Código de Reserva");
            lv_Preview_Reservas.Columns.Add("Fecha Inicio");
            lv_Preview_Reservas.Columns.Add("Fecha Fin");
            lv_Preview_Reservas.Columns.Add("Número de documento");
            lv_Preview_Reservas.Columns.Add("Tipo de Pago");
            lv_Preview_Reservas.Columns.Add("Pago Anticipado");
            lv_Preview_Reservas.Columns.Add("Cantidad de Huespedes");


            foreach (ColumnHeader column in lv_Preview_Reservas.Columns)
            {
                column.Width = lv_Preview_Reservas.Width / lv_Preview_Reservas.Columns.Count;
            }

            lv_Preview_Reservas.Items.Clear();

            cmd = new SqlCommand("select cod_reserva, fecha_inicio, fecha_fin, num_doc, tipo_pago, pago_anti, cantidad_huespedes from Reservas", conex);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Test Table");
            dt = ds.Tables["Test Table"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lv_Preview_Reservas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
            }
            connection.closeConnection();
        }

        private void frm_Reservas_Load(object sender, EventArgs e)
        {
            LoadReservasLv();
        }

        private void pbBuscar_Reserva_Click(object sender, EventArgs e)
        {
            // Se buscan las reservas según el número de reserva ingresado
            connection.openConnection();

            if (string.IsNullOrEmpty(txtBuscar_Reserva.Text))
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    lv_Preview_Reservas.Items.Clear();

                    string query = "SELECT * FROM Reservas WHERE cod_reserva=@cod_reserva";
                    cmd = new SqlCommand(query, conex);
                    cmd.Parameters.AddWithValue("@cod_reserva", txtBuscar_Reserva.Text);

                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds, "Test Table");
                    dt = ds.Tables["Test Table"];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lv_Preview_Reservas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                        lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                        lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                        lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                        lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                        lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                        lv_Preview_Reservas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
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
        private void btn_Salir_Inventario_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
