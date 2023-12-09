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
using System.Linq.Expressions;

namespace hotel_nn
{
    public partial class frm_Ver_Reservas_Realizadas : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        public string userId;
        public string userName;

        public frm_Ver_Reservas_Realizadas(string userId, string userName)
        {
            InitializeComponent();
              
            this.userId = userId;
            this.userName = userName;
        }

        private void loadListView()
        {
            // Se cargarán los datos de las reservas hechas por el cliente conectado
            connection.openConnection();
            lv_Reservas_Realizadas.Items.Clear();
            lv_Reservas_Realizadas.Columns.Clear();

            lv_Reservas_Realizadas.Columns.Add("# Reserva");
            lv_Reservas_Realizadas.Columns.Add("Habitación");
            lv_Reservas_Realizadas.Columns.Add("Paquete");
            lv_Reservas_Realizadas.Columns.Add("Tipo de Pago");
            lv_Reservas_Realizadas.Columns.Add("Pago Anticipado");
            lv_Reservas_Realizadas.Columns.Add("CheckIn");
            lv_Reservas_Realizadas.Columns.Add("CheckOut");
            lv_Reservas_Realizadas.Columns.Add("Huespedes");

            foreach (ColumnHeader column in lv_Reservas_Realizadas.Columns)
            {
                column.Width = lv_Reservas_Realizadas.Width / lv_Reservas_Realizadas.Columns.Count;
            }

            lv_Reservas_Realizadas.Items.Clear();

            cmd = new SqlCommand("SELECT Factura.cod_reserva, Factura.num_hab, Factura.paquete_seleccionado, Factura.opcion_pago, Reservas.pago_anti, Reservas.fecha_inicio, Reservas.fecha_fin, Reservas.cantidad_huespedes FROM Reservas INNER JOIN Factura ON Reservas.cod_reserva = Factura.cod_reserva WHERE Factura.num_doc_cliente = @num_doc_cliente order by cod_reserva desc", conex);
            cmd.Parameters.AddWithValue("@num_doc_cliente", userId);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Test Table");
            dt = ds.Tables["Test Table"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lv_Reservas_Realizadas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                lv_Reservas_Realizadas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                lv_Reservas_Realizadas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                lv_Reservas_Realizadas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                lv_Reservas_Realizadas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                lv_Reservas_Realizadas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                lv_Reservas_Realizadas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                lv_Reservas_Realizadas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
            }
            connection.closeConnection();
        }

        private void frm_Ver_Reservas_Realizadas_Load(object sender, EventArgs e)
        {
            loadListView();
            lbl_Usuario.Text = userName;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            // Se eliminará la reserva seleccionada
            connection.openConnection();
            SqlCommand cmd;
            for (int i = 0; i < lv_Reservas_Realizadas.SelectedItems.Count; i++)
            {
                cmd = new SqlCommand("DELETE FROM Factura WHERE cod_reserva = @cod_reserva; DELETE FROM Reservas WHERE cod_reserva = @cod_reserva", conex);
                try
                {
                    cmd.Parameters.AddWithValue("@cod_reserva", lv_Reservas_Realizadas.SelectedItems[i].Text);
                    int j = cmd.ExecuteNonQuery();
                    if (j > 0)
                        MessageBox.Show("Reserva eliminada");
                    else
                        MessageBox.Show("Error");
                }
                catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione una reserva para borrar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione una reserva para borrar");
                }
                loadListView();
            }
            connection.closeConnection();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
