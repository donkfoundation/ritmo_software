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
    public partial class frm_Paquetes : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        double IVA = 0.20;

        public frm_Paquetes()
        {
            InitializeComponent();
             
        }

        private void clearItems()
        {
            // Para limpiar los cuadros de texto
            txt_Desc_Paquete.Clear();
            txt_IVA_Paquete.Clear();
            txt_Nom_Paquete.Clear();
            txt_Precio_Paquete.Clear();
            txt_Total_Paquete.Clear();
            cb_Estado_Paquetes.SelectedIndex = 0;
        }

        private void loadListView()
        {
            // Se cargan los paquetes 
            lv_Paquetes.Columns.Clear();
            lv_Paquetes.Items.Clear();

            lv_Paquetes.Columns.Add("Código");
            lv_Paquetes.Columns.Add("Nombre");
            lv_Paquetes.Columns.Add("Descripcion");
            lv_Paquetes.Columns.Add("Activo");
            lv_Paquetes.Columns.Add("Precio");
            lv_Paquetes.Columns.Add("Total");

            foreach (ColumnHeader column in lv_Paquetes.Columns)
            {
                column.Width = lv_Paquetes.Width / lv_Paquetes.Columns.Count;
            }

            SqlCommand cmd = new SqlCommand("select cod_paquete, nombre_paquete, descripcion, activo, precio_costo, precio_total from Paquetes", conex);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Test Table");

            dt = ds.Tables["Test Table"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lv_Paquetes.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                lv_Paquetes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                lv_Paquetes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                lv_Paquetes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                lv_Paquetes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                lv_Paquetes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());

            }

            clearItems();
        }

        private void frm_Paquetes_Load(object sender, EventArgs e)
        {
            loadListView();
        }

        private void lv_Paquetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se selecciona un item los datos de este se reemplazan en los textbox y comobobox
            connection.openConnection();

            try
            {
                txt_Nom_Paquete.Text = lv_Paquetes.SelectedItems[0].SubItems[1].Text;
                txt_Desc_Paquete.Text = lv_Paquetes.SelectedItems[0].SubItems[2].Text;
                cb_Estado_Paquetes.Text = lv_Paquetes.SelectedItems[0].SubItems[3].Text;
                txt_Precio_Paquete.Text = lv_Paquetes.SelectedItems[0].SubItems[4].Text;
            }
            catch (Exception)
            {

            }

            connection.closeConnection();
        }

        private void btn_Agregar_Paquete_Click(object sender, EventArgs e)
        {
            // Se agrega un paquete
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Desc_Paquete.Text) || string.IsNullOrEmpty(txt_Nom_Paquete.Text) || string.IsNullOrEmpty(txt_Precio_Paquete.Text) || cb_Estado_Paquetes.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string cadena = "INSERT INTO Paquetes(nombre_paquete, activo, descripcion, precio_costo, iva, precio_total) VALUES(@nombre_paquete, @activo, @descripcion, @precio_costo, @iva, @precio_total)";
                SqlCommand cmd = new SqlCommand(cadena, conex);

                cmd.Parameters.AddWithValue("@nombre_paquete", txt_Nom_Paquete.Text.ToUpper());
                cmd.Parameters.AddWithValue("@activo", cb_Estado_Paquetes.Text.ToUpper());
                cmd.Parameters.AddWithValue("@descripcion", txt_Desc_Paquete.Text.ToUpper());
                cmd.Parameters.AddWithValue("@precio_costo", Convert.ToDecimal(txt_Precio_Paquete.Text));
                cmd.Parameters.AddWithValue("@iva", Convert.ToDecimal(txt_IVA_Paquete.Text));
                cmd.Parameters.AddWithValue("@precio_total", Convert.ToDecimal(txt_Total_Paquete.Text));

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                        MessageBox.Show("Paquete añadido correctamente");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 245) // Error de tipo de dato
                        MessageBox.Show("Error: verifique los tipos de datos");
                }
                loadListView();
            }
            connection.closeConnection();
        }


        private void txt_Precio_Paquete_TextChanged(object sender, EventArgs e)
        {
            // Cada vez que cambie el precio sin iva del paquete se calcula el iva y el precio total de este, mostrandose
            // en los textbox correspondientes.
            try
            {
                txt_IVA_Paquete.Text = (Double.Parse(txt_Precio_Paquete.Text) * IVA).ToString();
                txt_Total_Paquete.Text = (Double.Parse(txt_IVA_Paquete.Text) + Double.Parse(txt_Precio_Paquete.Text)).ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btn_Borrar_Paquete_Click(object sender, EventArgs e)
        {
            // Se borra el paquete seleccionado
            connection.openConnection();
            SqlCommand cmd;

            for (int i = 0; i < lv_Paquetes.SelectedItems.Count; i++)
            {
                cmd = new SqlCommand("DELETE FROM Paquetes WHERE cod_paquete=@cod_paquete", conex);

                try
                {
                    cmd.Parameters.AddWithValue("@cod_paquete", lv_Paquetes.SelectedItems[i].Text);
                    int j = cmd.ExecuteNonQuery();
                    if (j >= 1)
                        MessageBox.Show($"Paquete {lv_Paquetes.SelectedItems[i].SubItems[1].Text} Eliminado");
                    else
                        MessageBox.Show("Error");
                }
                catch (IndexOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un paquete para borrar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un paquete para borrar");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Violación de clave foránea (se quiere borrar algo con datos asociados
                        MessageBox.Show("No puede borrar un país con datos asociados a este.");
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString()); 
                }
                loadListView();
            }

            connection.closeConnection();
        }


        private void btn_Limpiar_Paquete_Click(object sender, EventArgs e)
        {
            clearItems();
        }

        private void btn_Editar_Paquete_Click(object sender, EventArgs e)
        {
            // Se actualiza el paquete con los datos nuevos registrados
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Desc_Paquete.Text) || string.IsNullOrEmpty(txt_Nom_Paquete.Text) || string.IsNullOrEmpty(txt_Precio_Paquete.Text) || cb_Estado_Paquetes.SelectedIndex == 0)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string cadena = "UPDATE Paquetes SET nombre_paquete=@nombre_paquete, activo=@activo, descripcion=@descripcion, precio_costo=@precio_costo, iva=@iva, precio_total=@precio_total WHERE cod_paquete=@cod_paquete";
                SqlCommand cmd = new SqlCommand(cadena, conex);
                cmd.Parameters.AddWithValue("@nombre_paquete", txt_Nom_Paquete.Text.ToUpper());
                cmd.Parameters.AddWithValue("@activo", cb_Estado_Paquetes.Text.ToUpper());
                cmd.Parameters.AddWithValue("@descripcion", txt_Desc_Paquete.Text.ToUpper());
                cmd.Parameters.AddWithValue("@precio_costo", txt_Precio_Paquete.Text);
                cmd.Parameters.AddWithValue("@iva", txt_IVA_Paquete.Text);
                cmd.Parameters.AddWithValue("@precio_total", txt_Total_Paquete.Text);

                try
                {
                    cmd.Parameters.AddWithValue("@cod_paquete", lv_Paquetes.SelectedItems[0].Text);
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                        MessageBox.Show("Paquete actualizado correctamente");
                    else
                        MessageBox.Show("Error");
                }
                catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un paquete para editar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un paquete para editar");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 245) // Error de tipo de dato
                        MessageBox.Show("Error: verifique los tipos de datos");
                }
                loadListView();
            }
            connection.closeConnection();
        }

        private void btn_Salir_Paquetes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
