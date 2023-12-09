using Microsoft.ReportingServices.Diagnostics.Internal;
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

namespace hotel_nn.View
{
    public partial class frm_Facturas : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        DataTable dt;
        SqlDataAdapter da;
        System.Data.DataSet ds;
        public frm_Facturas()
        {
            InitializeComponent();
        }

        private void loadReservas()
        {
            // Se cargan todas las reservas
            connection.openConnection();
            lv_Facturas.Items.Clear();
            lv_Facturas.Columns.Clear();

            lv_Facturas.Columns.Add("Código de Reserva");
            lv_Facturas.Columns.Add("Fecha Inicio");
            lv_Facturas.Columns.Add("Fecha Fin");
            lv_Facturas.Columns.Add("Número de documento");
            lv_Facturas.Columns.Add("Tipo de Pago");
            lv_Facturas.Columns.Add("Pago Anticipado");
            lv_Facturas.Columns.Add("Cantidad de Huespedes");


            foreach (ColumnHeader column in lv_Facturas.Columns)
            {
                column.Width = lv_Facturas.Width / lv_Facturas.Columns.Count;
            }

            lv_Facturas.Items.Clear();

            SqlCommand cmd = new SqlCommand("select cod_reserva, fecha_inicio, fecha_fin, num_doc, tipo_pago, pago_anti, cantidad_huespedes from Reservas", conex);
            da = new SqlDataAdapter(cmd);
            ds = new System.Data.DataSet();
            da.Fill(ds, "Test Table");
            dt = ds.Tables["Test Table"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lv_Facturas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
            }
            connection.closeConnection();
        }

        private void frm_Facturas_Load(object sender, EventArgs e)
        {
            loadReservas();
        }

        private void lv_Facturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_Facturas.SelectedItems.Count > 0)
            {
                btn_Generar_Factura.Enabled = true;
            }
            else
            {
                btn_Generar_Factura.Enabled = false;
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            // Se buscan las reservas según el número de reserva ingresado
            connection.openConnection();

            if (string.IsNullOrEmpty(txtBuscar_Reserva.Text))
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    lv_Facturas.Items.Clear();

                    string query = "SELECT cod_reserva, fecha_inicio, fecha_fin, num_doc, tipo_pago, pago_anti, cantidad_huespedes FROM Reservas WHERE num_doc=@num_doc";
                    SqlCommand cmd = new SqlCommand(query, conex);
                    cmd.Parameters.AddWithValue("@num_doc", txtBuscar_Reserva.Text);

                    da = new SqlDataAdapter(cmd);
                    ds = new System.Data.DataSet();
                    da.Fill(ds, "Test Table");
                    dt = ds.Tables["Test Table"];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lv_Facturas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                        lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                        lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                        lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                        lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                        lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                        lv_Facturas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
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

        private void btn_Generar_Factura_Click(object sender, EventArgs e)
        {
            frm_VerFactura Factura = new frm_VerFactura();
            Factura.codReserva = int.Parse(lv_Facturas.SelectedItems[0].Text);

            Factura.ShowDialog();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
