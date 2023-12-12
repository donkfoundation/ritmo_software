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
using hotel_nn.Controller;

namespace hotel_nn
{
    public partial class frm_Proveedores : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        public frm_Proveedores()
        {
             
            InitializeComponent();
        }

        private void ClearItems()
        {
            // Se limpian los cuadros de texto
            txt_Actividad_Proveedores.Clear();
            txt_Correo_Proveedores.Clear();
            txt_Direccion_Proveedores.Clear();
            txt_Nit_Proveedor.Clear();
            txt_Dv_Proveedores.Clear();
            txt_Razon_Social.Clear();
            txt_Telefono_Proveedores.Clear();
            txt_Representante_Proveedores.Clear();
            txt_CCRepr_Proveedores.Clear();
            txt_Dv_Proveedores.Enabled = true;
            txt_Nit_Proveedor.Enabled = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void LoadItems()
        {
            // Se cargan los proveedores ya agregados
            lv_Proveedores.Columns.Clear();
            lv_Proveedores.Items.Clear();

            lv_Proveedores.Columns.Add("NIT");
            lv_Proveedores.Columns.Add("Razón Social");
            lv_Proveedores.Columns.Add("Actividad");
            lv_Proveedores.Columns.Add("Dirección");
            lv_Proveedores.Columns.Add("País");
            lv_Proveedores.Columns.Add("Teléfono");
            lv_Proveedores.Columns.Add("Correo");
            lv_Proveedores.Columns.Add("Representante Legal");
            lv_Proveedores.Columns.Add("Cédula Representante legal");
            lv_Proveedores.Columns.Add("Tipo Persona");

            foreach (ColumnHeader column in lv_Proveedores.Columns)
            {
                column.Width = lv_Proveedores.Width / lv_Proveedores.Columns.Count;
            }

            lv_Proveedores.Items.Clear();
            SqlCommand cmd = new SqlCommand("select * from Proveedores", conex);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Test Table");

            dt = ds.Tables["Test Table"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lv_Proveedores.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                lv_Proveedores.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                lv_Proveedores.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                lv_Proveedores.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                lv_Proveedores.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                lv_Proveedores.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                lv_Proveedores.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                lv_Proveedores.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                lv_Proveedores.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                lv_Proveedores.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());

            }
            
            ClearItems();
        }

        private void LoadCombobox()
        {
            // Se carga solamente el pais Colombia, pues va a ser el único país al cual van a estar asociados los proveedores
            SqlCommand cmd = new SqlCommand("Select cod_pais, nom_pais from Pais where cod_pais = 57", conex);
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            da.Fill(table1);

            DataRow itemrow = table.NewRow();
            itemrow[1] = "seleccione país";
            table.Rows.InsertAt(itemrow, 0);

            cb_Pais_Proveedores.DataSource = table;
            cb_Pais_Proveedores.DisplayMember = "nom_pais";
            cb_Pais_Proveedores.ValueMember = "cod_pais";
            cb_Pais_Proveedores.SelectedIndex = 1;
            cb_Pais_Proveedores.Enabled = false;
        }

        private void frm_Proveedores_Load(object sender, EventArgs e)
        {
            connection.openConnection();
            LoadCombobox();
            LoadItems();
            connection.closeConnection();
        }

        private void lv_Proveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se selecciona un proveedor los datos de este se reemplazan en los textbox y comobobox
            connection.openConnection();
            try
            {
                txt_Nit_Proveedor.Enabled = false;
                txt_Dv_Proveedores.Enabled = false;

                SqlCommand cmd = new SqlCommand($"SELECT nom_pais FROM Pais WHERE cod_pais=@cod_pais", conex);
                cmd.Parameters.AddWithValue("@cod_pais", lv_Proveedores.SelectedItems[0].SubItems[4].Text);

                string nom_pais = string.Empty;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    nom_pais = reader[0].ToString();

                string[] nitDv = lv_Proveedores.SelectedItems[0].Text.Split('-');
                txt_Nit_Proveedor.Text = nitDv[0];
                txt_Dv_Proveedores.Text = nitDv[1];
                txt_Razon_Social.Text = lv_Proveedores.SelectedItems[0].SubItems[1].Text;
                txt_Actividad_Proveedores.Text = lv_Proveedores.SelectedItems[0].SubItems[2].Text;
                txt_Direccion_Proveedores.Text = lv_Proveedores.SelectedItems[0].SubItems[3].Text;
                cb_Pais_Proveedores.Text = nom_pais;
                txt_Telefono_Proveedores.Text = lv_Proveedores.SelectedItems[0].SubItems[5].Text;
                txt_Correo_Proveedores.Text = lv_Proveedores.SelectedItems[0].SubItems[6].Text;
                txt_Representante_Proveedores.Text = lv_Proveedores.SelectedItems[0].SubItems[7].Text;
                txt_CCRepr_Proveedores.Text = lv_Proveedores.SelectedItems[0].SubItems[8].Text;
                if (lv_Proveedores.SelectedItems[0].SubItems[9].Text == "NATURAL")
                    radioButton2.Checked = true;
                else
                    radioButton1.Checked = true;
            }
            catch (Exception ex)
            { }
            connection.closeConnection();
        }


        private void btn_Agregar_Proveedor_Click(object sender, EventArgs e)
        {
            // Se agrega el proveedor
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Actividad_Proveedores.Text) || string.IsNullOrEmpty(txt_CCRepr_Proveedores.Text) || string.IsNullOrEmpty(txt_Correo_Proveedores.Text) || string.IsNullOrEmpty(txt_Direccion_Proveedores.Text) || string.IsNullOrEmpty(txt_Dv_Proveedores.Text)  || string.IsNullOrEmpty(txt_Nit_Proveedor.Text) || string.IsNullOrEmpty(txt_Razon_Social.Text) || string.IsNullOrEmpty(txt_Representante_Proveedores.Text) || string.IsNullOrEmpty(txt_Telefono_Proveedores.Text) || (!radioButton1.Checked && !radioButton2.Checked) || cb_Pais_Proveedores.SelectedIndex == 0)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                // Se verifica si es un correo electronico
                if (!validateEmail.validate(txt_Correo_Proveedores.Text))
                {
                    MessageBox.Show("Ingrese un formato de correo electrónico correcto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Se selecciona el tipo de persona según el radio button seleccionado
                    string tp = radioButton1.Checked ? radioButton1.Text.ToUpper() : radioButton2.Text.ToUpper();

                    string cadena = $"INSERT INTO Proveedores(nit_proveedor, razon_social, actividad, direccion, pais, telefono, correo, representante_legal, cedula_representante_legal, tipo_persona) VALUES(@nit_proveedor, @razon_social, @actividad, @direccion, @pais, @telefono, @correo, @representante_legal, @cedula_representante_legal, @tipo_persona)";

                    SqlCommand cmd = new SqlCommand(cadena, conex);

                    cmd.Parameters.AddWithValue("@nit_proveedor", $"{txt_Nit_Proveedor.Text}-{txt_Dv_Proveedores.Text}");
                    cmd.Parameters.AddWithValue("@razon_social", txt_Razon_Social.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@actividad", txt_Actividad_Proveedores.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@direccion", txt_Direccion_Proveedores.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@pais", cb_Pais_Proveedores.SelectedValue);
                    cmd.Parameters.AddWithValue("@telefono", txt_Telefono_Proveedores.Text);
                    cmd.Parameters.AddWithValue("@correo", txt_Correo_Proveedores.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@representante_legal", txt_Representante_Proveedores.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@cedula_representante_legal", txt_CCRepr_Proveedores.Text);
                    cmd.Parameters.AddWithValue("@tipo_persona", tp);

                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            MessageBox.Show("Proveedor añadido exitosamente");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Si sale un error de clave primaria (se intenta añadir un objeto con clave primaria existente)
                            MessageBox.Show("Proveedor ya existe");
                        if (ex.Number == 207) // Si hay algún tipo de dato incorrecto
                            MessageBox.Show("Tipo de dato incorrecto");
                    }
                    LoadItems();
                }
            }
            connection.closeConnection();
        }


        private void btn_Borrar_Inventario_Click(object sender, EventArgs e)
        {
            // Se borra el proveedor seleccionado.
            connection.openConnection();
            SqlCommand cmd;
            for (int i = 0; i < lv_Proveedores.SelectedItems.Count; i++)
            {
                cmd = new SqlCommand($"DELETE FROM Proveedores WHERE nit_proveedor=@nit_proveedor", conex);
                try
                {
                    cmd.Parameters.AddWithValue("@nit_proveedor", lv_Proveedores.SelectedItems[i].Text);
                    int j = cmd.ExecuteNonQuery();
                    if (j > 0)
                        MessageBox.Show($"{lv_Proveedores.SelectedItems[i].SubItems[1].Text} eliminado");
                    else
                        MessageBox.Show("Error");
                }
                catch (IndexOutOfRangeException) // Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un proveedor para borrar");
                }
                catch (ArgumentOutOfRangeException)// Por si no hay nada seleccionado
                {
                    MessageBox.Show("Seleccione un proveedor para borrar");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Violación de clave foránea (se quiere borrar algo con datos asociados
                        MessageBox.Show("No puede borrar un proveedor con datos asociados a este.");
                }
                LoadItems();
            }
            connection.closeConnection();
        }

        private void btn_Editar_Proveedor_Click(object sender, EventArgs e)
        {
            // Se actualiza el proveedor con los datos nuevos registrados
            connection.openConnection();
            if (string.IsNullOrEmpty(txt_Actividad_Proveedores.Text) || string.IsNullOrEmpty(txt_CCRepr_Proveedores.Text) || string.IsNullOrEmpty(txt_Correo_Proveedores.Text) || string.IsNullOrEmpty(txt_Direccion_Proveedores.Text) || string.IsNullOrEmpty(txt_Dv_Proveedores.Text) || string.IsNullOrEmpty(txt_Nit_Proveedor.Text) || string.IsNullOrEmpty(txt_Razon_Social.Text) || string.IsNullOrEmpty(txt_Representante_Proveedores.Text) || string.IsNullOrEmpty(txt_Telefono_Proveedores.Text) || (!radioButton1.Checked && !radioButton2.Checked) || cb_Pais_Proveedores.SelectedIndex == 0)
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (!validateEmail.validate(txt_Correo_Proveedores.Text))
                {
                    MessageBox.Show("Ingrese un formato de correo electrónico correcto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Se selecciona el tipo de persona según el radio button seleccionado
                    string tp = radioButton1.Checked ? radioButton1.Text.ToUpper() : radioButton2.Text.ToUpper();

                    string cadena = $"UPDATE Proveedores SET razon_social=@razon_social, actividad=@actividad, direccion=@direccion, pais=@pais, telefono=@tlefono, correo=@correo, representante_legal=@representante_legal, cedula_representante_legal=cedula_representante_legal, tipo_persona=@tipo_persona WHERE nit_proveedor=@nit_proveedor";

                    SqlCommand cmd = new SqlCommand(cadena, conex);
                    cmd.Parameters.AddWithValue("@nit_proveedor", $"{txt_Nit_Proveedor.Text}-{txt_Dv_Proveedores.Text}");
                    cmd.Parameters.AddWithValue("@razon_social", txt_Razon_Social.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@actividad", txt_Actividad_Proveedores.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@direccion", txt_Direccion_Proveedores.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@pais", cb_Pais_Proveedores.SelectedValue);
                    cmd.Parameters.AddWithValue("@telefono", txt_Telefono_Proveedores.Text);
                    cmd.Parameters.AddWithValue("@correo", txt_Correo_Proveedores.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@representante_legal", txt_Representante_Proveedores.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@cedula_representante_legal", txt_CCRepr_Proveedores.Text);
                    cmd.Parameters.AddWithValue("@tipo_persona", tp);

                    try
                    {
                        int i = cmd.ExecuteNonQuery();

                        if (i > 0)
                            MessageBox.Show($"Proveedor {txt_Nit_Proveedor.Text}-{txt_Dv_Proveedores.Text} actualizado exitosamente.");
                        else
                            MessageBox.Show("Error");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Si sale un error de clave primaria (se intenta añadir un objeto con clave primaria existente)
                            MessageBox.Show("Proveedor ya existe");
                        if (ex.Number == 207) // Si hay algún tipo de dato incorrecto
                            MessageBox.Show("Tipo de dato incorrecto");
                    }

                    LoadItems();
                }
            }
            connection.closeConnection();
        }


        private void btn_Limpiar_Proveedor_Click(object sender, EventArgs e)
        {
            ClearItems();
        }

        private void btn_Salir_Proveedor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
