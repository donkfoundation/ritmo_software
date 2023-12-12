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

namespace hotel_nn.View
{
    public partial class frm_CuentasPorCobrar : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        SqlDataAdapter da;
        DataSet ds;
        frm_Menu_Principal menu;
        public frm_CuentasPorCobrar(frm_Menu_Principal menu)
        {
            InitializeComponent();
            this.menu = menu;
        }

        private void clearItems()
        {
            // Para limpiar los cuadros de texto 
            txt_Detalle.Clear();
            txt_Doc.Clear();
            txt_Total.Clear();
        }

        private void loadItems()
        {
            // Se cargan todos los items de inventario
            lv_Cuentas.Columns.Clear();
            lv_Cuentas.Items.Clear();

            lv_Cuentas.Columns.Add("Número de cuenta");
            lv_Cuentas.Columns.Add("Documento");
            lv_Cuentas.Columns.Add("Descripcion");
            lv_Cuentas.Columns.Add("Costo");

            foreach (ColumnHeader column in lv_Cuentas.Columns)
            {
                column.Width = lv_Cuentas.Width / lv_Cuentas.Columns.Count;
            }

            SqlCommand cmd = new SqlCommand("select * from Cuenta", conex);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Test Table");

            DataTable dt = ds.Tables["Test Table"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lv_Cuentas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                lv_Cuentas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                lv_Cuentas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                lv_Cuentas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
            }

            clearItems();
        }

        private void frm_CuentasPorCobrar_Load(object sender, EventArgs e)
        {
            loadItems();
        }

        private void lv_Cuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se selecciona un item de la tabla cuentas se llenan los cuadros de texto con la información de este
            try
            {
                txt_Doc.Text = lv_Cuentas.SelectedItems[0].SubItems[1].Text;
                txt_Detalle.Text = lv_Cuentas.SelectedItems[0].SubItems[2].Text;
                txt_Total.Text = lv_Cuentas.SelectedItems[0].SubItems[3].Text;

                if (lv_Cuentas.SelectedItems.Count > 0)
                    btn_Generar.Enabled = true;
                else 
                    btn_Generar.Enabled = false;
            }
            catch (Exception)
            { }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Doc.Text) || string.IsNullOrEmpty(txt_Detalle.Text) || string.IsNullOrEmpty(txt_Total.Text))
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Cuenta(num_doc, descripcion, costo, fecha_compra) VALUES(@num_doc, @descripcion, @costo, GETDATE())",conex);
                cmd.Parameters.AddWithValue("@num_doc", txt_Doc.Text);
                cmd.Parameters.AddWithValue("@descripcion", txt_Detalle.Text.ToUpper());
                cmd.Parameters.AddWithValue("@costo", txt_Total.Text);

                try
                {
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                        MessageBox.Show("Cuenta añadida");
                    menu.LoadData();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 245) // Error de tipo de dato
                        MessageBox.Show("Error: verifique los tipos de datos");
                    else if (ex.Number == 547) // Error si copia un número de documento de cliente que no existe 
                        MessageBox.Show("Error: verifique el número de documento del cliente");
                } 
                loadItems();
            }
            connection.closeConnection();
        }
        private void btn_Borrar_Click(object sender, EventArgs e)
        {
            // Se borra la cuenta seleccionada
            connection.openConnection();
            SqlCommand cmd;
            for (int i = 0; i < lv_Cuentas.SelectedItems.Count; i++)
            {
                cmd = new SqlCommand("DELETE FROM Cuenta WHERE num_cuenta = @num_cuenta", conex);
                try
                {
                    cmd.Parameters.AddWithValue("@num_cuenta", lv_Cuentas.SelectedItems[i].Text);
                    int j = cmd.ExecuteNonQuery();
                    if (j > 0)
                        MessageBox.Show("Cuenta eliminada");
                    else
                        MessageBox.Show("Error");
                    menu.LoadData();
                }
                catch(IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione una cuenta para borrar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione una cuenta para borrar");
                }
                loadItems();
            }
            connection.closeConnection();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            // Para editar la cuenta
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Doc.Text) || string.IsNullOrEmpty(txt_Detalle.Text) || string.IsNullOrEmpty(txt_Total.Text))
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE Cuenta set num_doc = @num_doc, descripcion = @descripcion, costo = @costo WHERE num_cuenta = @num_cuenta", conex);
                cmd.Parameters.AddWithValue("@num_doc", txt_Doc.Text);
                cmd.Parameters.AddWithValue("@descripcion", txt_Detalle.Text);
                cmd.Parameters.AddWithValue("@costo", txt_Total.Text);

                try
                {
                    cmd.Parameters.AddWithValue("@num_cuenta", lv_Cuentas.SelectedItems[0].Text);
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                        MessageBox.Show("Cuenta editada");
                    menu.LoadData();
                }
                catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione una cuenta para editar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione una cuenta para editar");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 245) // Error de tipo de dato
                        MessageBox.Show("Error: verifique los tipos de datos");
                }
                loadItems();
            }
            connection.closeConnection();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            clearItems();
        }

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            frm_VerCuentas cuentas = new frm_VerCuentas();
            cuentas.codCuenta = int.Parse(lv_Cuentas.SelectedItems[0].Text);
            cuentas.ShowDialog();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
