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
using System.Data.Common;

namespace hotel_nn
{
    public partial class frm_Inventario : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        SqlDataAdapter da;
        DataSet ds;

        public frm_Inventario()
        {
            InitializeComponent();
             
        }

        private void LoadCombobox()
        {
            // Se cargan los proveedores disponibles
            SqlCommand cmd = new SqlCommand("Select nit_proveedor, razon_social from Proveedores order by razon_social asc", conex);
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            DataRow itemrow = table.NewRow();
            itemrow[1]= "seleccione proveedor";
            table.Rows.InsertAt(itemrow, 0);

            cb_Nit_Inventario.DataSource = table;
            cb_Nit_Inventario.DisplayMember = "razon_social";
            cb_Nit_Inventario.ValueMember = "nit_proveedor";
            cb_Nit_Inventario.SelectedIndex = 0;
            cb_Nit_Inventario.Enabled = true;
        }

        private void ClearItems()
        {
            // Para limpiar los cuadros de texto 
            txt_Cantidad_Inventario.Clear();
            txt_Descripcion_Inventario.Clear();
            cb_Nit_Inventario.SelectedIndex = 0;
        }

        private void LoadItems()
        {
            // Se cargan todos los items de inventario
            lv_Items_Inventario.Columns.Clear();
            lv_Items_Inventario.Items.Clear();

            lv_Items_Inventario.Columns.Add("Código");
            lv_Items_Inventario.Columns.Add("Descripción");
            lv_Items_Inventario.Columns.Add("Cantidad");
            lv_Items_Inventario.Columns.Add("NIT Proveedor");
            lv_Items_Inventario.Columns.Add("Fecha Ingreso");
            lv_Items_Inventario.Columns.Add("Fecha Egreso");

            foreach (ColumnHeader column in lv_Items_Inventario.Columns)
            {
                column.Width = lv_Items_Inventario.Width / lv_Items_Inventario.Columns.Count;
            }

            SqlCommand cmd = new SqlCommand("select * from inventario", conex);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Test Table");

            DataTable dt = ds.Tables["Test Table"];
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lv_Items_Inventario.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                lv_Items_Inventario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                lv_Items_Inventario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                lv_Items_Inventario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                lv_Items_Inventario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                lv_Items_Inventario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
            }

            ClearItems();
        }

        private void frm_Inventario_Load(object sender, EventArgs e)
        {
            connection.openConnection();
            dtp_FechaEgreso_Inventario.Enabled = false;
            LoadCombobox();
            LoadItems();
            connection.closeConnection();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se selecciona un item los datos de este se reemplazan en los textbox y comobobox
            connection.openConnection();
            try
            {
                string cadena = "SELECT razon_social FROM Proveedores WHERE nit_proveedor=@nit_proveedor";

                SqlCommand cmd = new SqlCommand(cadena, conex);
                cmd.Parameters.AddWithValue("@nit_proveedor", lv_Items_Inventario.SelectedItems[0].SubItems[3].Text);

                string nom_proveedor;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    nom_proveedor = reader[0].ToString();
                else
                    nom_proveedor = "";
                reader.Close();

                txt_Descripcion_Inventario.Text = lv_Items_Inventario.SelectedItems[0].SubItems[1].Text;
                txt_Cantidad_Inventario.Text = lv_Items_Inventario.SelectedItems[0].SubItems[2].Text;
                cb_Nit_Inventario.Text = nom_proveedor;
                dtp_FechaIngreso_Inventario.Text = lv_Items_Inventario.SelectedItems[0].SubItems[4].Text;
                dtp_FechaEgreso_Inventario.Text = lv_Items_Inventario.SelectedItems[0].SubItems[5].Text;
            }
            catch (Exception)
            {

            }
            connection.closeConnection();
        }


        private void btn_Agregar_Inventario_Click(object sender, EventArgs e)
        {
            // Se agrega un item a la tabla inventario
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Cantidad_Inventario.Text) || string.IsNullOrEmpty(txt_Descripcion_Inventario.Text) ||  cb_Nit_Inventario.SelectedIndex == 0 || !dtp_FechaIngreso_Inventario.Checked)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                // Se verifica si el item tiene fecha de expiración y se modifica la cadena de consulta
                string cadena;
                if (checkB_FechaVen.Checked)
                    cadena = $"Insert into Inventario(descripcion, cantidad, nit_proveedor, fecha_ingreso, fecha_egreso) values(@descripcion, @cantidad, @nit_proveedor, @fecha_ingreso, @fecha_egreso)";
                else
                    cadena = $"Insert into Inventario(descripcion, cantidad, nit_proveedor, fecha_ingreso) values(@descripcion, @cantidad, @nit_proveedor, @fecha_ingreso)";

                SqlCommand cmd = new SqlCommand(cadena, conex);
                cmd.Parameters.AddWithValue("@descripcion", txt_Descripcion_Inventario.Text.ToUpper());
                cmd.Parameters.AddWithValue("@cantidad", txt_Cantidad_Inventario.Text);
                cmd.Parameters.AddWithValue("@nit_proveedor", cb_Nit_Inventario.SelectedValue);
                cmd.Parameters.AddWithValue("@fecha_ingreso", dtp_FechaIngreso_Inventario.Text);

                if (checkB_FechaVen.Checked)
                    cmd.Parameters.AddWithValue("@fecha_egreso", dtp_FechaEgreso_Inventario.Text);

                try
                {
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                        MessageBox.Show("Item Añadido");
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

        private void btn_Borrar_Inventario_Click(object sender, EventArgs e)
        {
            // Se borra el item seleccionado
            connection.openConnection();
            SqlCommand cmd;
            for (int i = 0; i < lv_Items_Inventario.SelectedItems.Count; i++)
            {
                cmd = new SqlCommand("DELETE FROM Inventario WHERE cod_prod=@cod_prod", conex);
                cmd.Parameters.AddWithValue("@cod_prod", lv_Items_Inventario.SelectedItems[i].Text);
                try
                {
                    int j = cmd.ExecuteNonQuery();
                    if (j > 0)
                        MessageBox.Show(lv_Items_Inventario.SelectedItems[i].SubItems[1].Text + " eliminado");
                    else
                        MessageBox.Show("Error");
                }
                catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un item para borrar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un item para borrar");
                }
                LoadItems();
            }
            connection.closeConnection();
        }

        private void btn_Editar_Inventario_Click(object sender, EventArgs e)
        {
            // Se actualiza el item con los datos nuevos registrados
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Cantidad_Inventario.Text) || string.IsNullOrEmpty(txt_Descripcion_Inventario.Text) || cb_Nit_Inventario.SelectedIndex == 0 || !dtp_FechaIngreso_Inventario.Checked)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string cadena;
                if (checkB_FechaVen.Checked)
                    cadena = "UPDATE Inventario SET descripcion=@descripcion, cantidad=@cantidad, nit_proveedor=@nit_proveedor, fecha_ingreso=@fecha_ingreso, fecha_egreso=@fecha_egreso WHERE cod_prod=@cod_prod";
                else
                    cadena = "UPDATE Inventario SET descripcion=@descripcion, cantidad=@cantidad, nit_proveedor=@nit_proveedor, fecha_ingreso=@fecha_ingreso, fecha_egreso=NULL WHERE cod_prod=@cod_prod";

                SqlCommand cmd = new SqlCommand(cadena, conex);
                cmd.Parameters.AddWithValue("@descripcion", txt_Descripcion_Inventario.Text.ToUpper());
                cmd.Parameters.AddWithValue("@cantidad", txt_Cantidad_Inventario.Text);
                cmd.Parameters.AddWithValue("@nit_proveedor", cb_Nit_Inventario.SelectedValue);
                cmd.Parameters.AddWithValue("@fecha_ingreso", dtp_FechaIngreso_Inventario.Value);
                cmd.Parameters.AddWithValue("@cod_prod", lv_Items_Inventario.SelectedItems[0].Text);

                if (checkB_FechaVen.Checked)
                    cmd.Parameters.AddWithValue("@fecha_egreso", dtp_FechaEgreso_Inventario.Value);

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show($"Producto {txt_Descripcion_Inventario.Text} actualizado exitosamente.");
                    else
                        MessageBox.Show("Error");
                }
                catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un item para editar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un item para editar");
                }
                LoadItems();
            }
            connection.closeConnection();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Cada vez que verifiquemos o desverifiquemos el checkbox de fecha de vencimiento se habilitará
            // o deshabilitará el date time picker
            if (!checkB_FechaVen.Checked)
            {
                dtp_FechaEgreso_Inventario.Enabled = false;
            }
            else
            {
                dtp_FechaEgreso_Inventario.Enabled = true;
            }
        }

        private void btn_Salir_Inventario_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
