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
using System.Threading;

namespace hotel_nn
{
    public partial class frm_ModoCliente : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        public string userId;
        public string userName;
        private int diasEstadia;
        private int cod_reserva;
        private frm_Menu_Principal menu;

        public frm_ModoCliente()
        {
            InitializeComponent();
        }

        public void iniciarCliente()
        {
            // Se inicializan los datos del cliente registrado.
            connection.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTES WHERE num_doc = @num_doc", conex);
            cmd.Parameters.AddWithValue("@num_doc", userId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                userId = reader["NUM_DOC"].ToString();
                userName = reader["NOMBRES"].ToString() + " " + reader["APELLIDOS"].ToString();
            }
            connection.closeConnection();
        }

        private void loadDefault()
        {
            // Este será el estado por defecto del formulario
            cb_CantidadHuespedes.SelectedIndex = 0;
            label8.Visible = false;
            lbl_DescripPaquete.Visible = false;
            checkb_PagoAnticipado.Checked = false;
            cb_TipoPago.SelectedIndex = 0;
            lbl_Total.Text = "";
        }

        private void loadTotal()
        {
            // Se intenta cargar el total del paquete y habitación seleccionados.
            try
            {
                lbl_Total.Text = 0.ToString();
                string[] soloPrecioHab = txt_PrecioHabitacion.Text.Split(' ');
                string[] soloPrecioPaq = txt_PrecioPaquetes.Text.Split(' ');
                string subtotal = ((int.Parse(soloPrecioHab[0]) + int.Parse(soloPrecioPaq[0])) * (diasEstadia + 1)).ToString();
                string total = (double.Parse(subtotal) * 1.1).ToString();
                lbl_Total.Text = total;
            }
            catch (Exception ex)
            { }
        }

        private void loadPaquetesCombobox()
        {
            // Se cargan todos los paquetes activos
            connection.openConnection();
            SqlCommand cmd = new SqlCommand("select nombre_paquete, cod_paquete from Paquetes WHERE activo = 'S'", conex);
            DataTable table = new DataTable();
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);

            DataRow itemrow = table.NewRow();
            itemrow[0] = "seleccione paquete";
            table.Rows.InsertAt(itemrow, 0);

            cb_Paquetes.DataSource = table;
            cb_Paquetes.DisplayMember = "nombre_paquete";
            cb_Paquetes.ValueMember = "cod_paquete";
            cb_Paquetes.SelectedIndex = 0;
            cb_Paquetes.Enabled = true;
            connection.closeConnection();
        }

        private void loadHabitacionesCombobox()
        {
            // Se cargan todas las habitaciones (que no estén reservadas en las fechas seleccionadas)
            connection.openConnection();
            string cadena = "SELECT Habitaciones.num_hab, Habitaciones.precio FROM Habitaciones WHERE Habitaciones.capacidad >= @capacidad AND NOT EXISTS (SELECT 1 FROM Reservas JOIN Factura ON Reservas.cod_reserva = Factura.cod_reserva WHERE Factura.num_hab = Habitaciones.num_hab AND ((@fecha_checkin BETWEEN Reservas.fecha_inicio AND Reservas.fecha_fin) OR (@fecha_checkout BETWEEN Reservas.fecha_inicio AND Reservas.fecha_fin) OR (Reservas.fecha_inicio BETWEEN @fecha_checkin AND @fecha_checkout) OR (Reservas.fecha_fin BETWEEN @fecha_checkin AND @fecha_checkout)));";

            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue("@fecha_checkin", dtp_FechaCheckIn.Text);
            cmd.Parameters.AddWithValue("@fecha_checkout", dtp_FechaCheckOut.Text);
            cmd.Parameters.AddWithValue("@capacidad", cb_CantidadHuespedes.Text);

            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);

                cb_HabitacionesDisp.DataSource = table;
                cb_HabitacionesDisp.DisplayMember = "num_hab";
                cb_HabitacionesDisp.ValueMember = "num_hab";
                cb_HabitacionesDisp.SelectedIndex = 0;
                cb_HabitacionesDisp.Enabled = true;
            }
            catch (Exception ex)
            { }

            connection.closeConnection();
        }

        private void frm_ModoCliente_Load(object sender, EventArgs e)
        {
            lbl_NombreCliente.Text = userName;
            loadDefault();
            loadPaquetesCombobox();
        }

        private void cb_PagoAnticipado_CheckedChanged(object sender, EventArgs e)
        {
            // Si el checkbox de pago anticipado está activado se podrá escribir lo que quiero pagar anticipadamente
            if (checkb_PagoAnticipado.Checked)
                txt_PagoAnticipado.Enabled = true;
            else
                txt_PagoAnticipado.Enabled = false;
        }

        // Cuando se cambian las fechas se verifica si hay habitaciones disponibles para las fechas seleccionadas
        private void dtp_FechaCheckIn_ValueChanged_1(object sender, EventArgs e)
        {
            loadHabitacionesCombobox();
        }

        private void dtp_FechaCheckOut_ValueChanged(object sender, EventArgs e)
        { 
            //Aquí se calcula la cantidad de días que durará la estadía
            DateTime check_in = dtp_FechaCheckIn.Value;
            DateTime check_out = dtp_FechaCheckOut.Value;
            TimeSpan timeSpan = check_out - check_in;
            diasEstadia = timeSpan.Days;

            loadHabitacionesCombobox();
        }

        private void cb_CantidadHuespedes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se cambia la cantidad de huespedes tambien se verifica si hay habitaciones disponibles para la cantidad de estos

            if (cb_CantidadHuespedes.SelectedIndex == 0) {}
            else
                loadHabitacionesCombobox();
        }

        private void cb_HabitacionesDisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se cambia la habitación se carga el precio de esta
            try
            {
                connection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT precio FROM Habitaciones where num_hab = @num_hab", conex);
                cmd.Parameters.AddWithValue("@num_hab", cb_HabitacionesDisp.SelectedValue);
                       
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txt_PrecioHabitacion.Text = reader["precio"].ToString() + " COP";
                }
                connection.closeConnection();
            }
            catch (Exception)
            { }
        }

        private void cb_Paquetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando se cambia el paquete se carga el precio de este
            try
            {
                connection.openConnection();
                SqlCommand cmd2 = new SqlCommand("SELECT descripcion, precio_total FROM Paquetes where cod_paquete = @cod_paquete", conex);
                cmd2.Parameters.AddWithValue("@cod_paquete", cb_Paquetes.SelectedValue);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    lbl_DescripPaquete.Visible = true;
                    label8.Visible = true;
                    txt_PrecioPaquetes.Text = reader2["precio_total"].ToString();
                    lbl_DescripPaquete.Text = reader2["descripcion"].ToString();
                }
                reader2.Close();
                connection.closeConnection();
            }
            catch (Exception ex)
            { }
        }

        private void cb_TipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si el tipo de pago es efectivo no habrá pago anticipado
            if (cb_TipoPago.Text == "TARJETA DE CREDITO")
            {
                checkb_PagoAnticipado.Checked = false;
                checkb_PagoAnticipado.Enabled = false;
            }
            else
                checkb_PagoAnticipado.Enabled = true;
        }

        // Se llama a la función para cargar el total
        private void txt_PrecioHabitacion_TextChanged(object sender, EventArgs e)
        {
            loadTotal();
        }

        private void txt_PrecioPaquetes_TextChanged(object sender, EventArgs e)
        {
            loadTotal();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            connection.openConnection();
            if (string.IsNullOrEmpty(dtp_FechaCheckIn.Text) || string.IsNullOrEmpty(dtp_FechaCheckOut.Text) || cb_CantidadHuespedes.SelectedIndex == 0 || cb_Paquetes.SelectedIndex == 0 || cb_TipoPago.SelectedIndex == 0 || cb_HabitacionesDisp.SelectedIndex == -1 )
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                // La reserva va dividida en dos tablas, reservas y factura, cuando se crea una reserva se añanden los datos de esta en las tablas correspondientes
                
                string cadena;
                string cadena2;
                SqlCommand cmd2;
                SqlCommand cmd;
                // Si hay pago anticipado la cadena de la consulta a la base de datos cambia, por eso se verifica el checkbox
                if (checkb_PagoAnticipado.Checked)
                {
                    cadena = "INSERT INTO Reservas(fecha_inicio, fecha_fin, fecha_reserva, num_doc, tipo_pago, pago_anti, cantidad_huespedes) VALUES(@fecha_inicio, @fecha_fin, GETDATE(), @num_doc, @tipo_pago, @pago_anti, @cantidad_huespedes); SELECT SCOPE_IDENTITY()";
                    cmd = new SqlCommand(cadena, conex);
                    cmd.Parameters.AddWithValue("@fecha_inicio", dtp_FechaCheckIn.Text);
                    cmd.Parameters.AddWithValue("@fecha_fin", dtp_FechaCheckOut.Text);
                    cmd.Parameters.AddWithValue("@num_doc", userId);
                    cmd.Parameters.AddWithValue("@tipo_pago", cb_TipoPago.Text);
                    cmd.Parameters.AddWithValue("@pago_anti", txt_PagoAnticipado.Text);
                    cmd.Parameters.AddWithValue("@cantidad_huespedes", cb_CantidadHuespedes.Text);
                    try
                    {
                        cod_reserva = Convert.ToInt32(cmd.ExecuteScalar());

                        cadena2 = $"INSERT INTO Factura (num_doc_cliente, paquete_seleccionado, fecha_compra, cod_reserva, num_hab, opcion_pago, subtotal, iva, total) ";
                        cadena2 += "SELECT @num_doc_cliente, @paquete_seleccionado, (select fecha_reserva from reservas where cod_reserva = @cod_reserva), @cod_reserva, @num_hab, @opcion_pago, (((SELECT precio FROM Habitaciones WHERE num_hab = @num_hab) + (SELECT precio_total FROM Paquetes WHERE cod_paquete = @paquete_seleccionado))  * (select dbo.func_DiasEstadia(@cod_reserva) + 1)) AS subtotal, (0.1 * (((SELECT precio FROM Habitaciones WHERE num_hab = @num_hab) + (SELECT precio_total FROM Paquetes WHERE cod_paquete = @paquete_seleccionado))  * (select dbo.func_DiasEstadia(@cod_reserva) + 1))) AS iva, ((1.1 * (((SELECT precio FROM Habitaciones WHERE num_hab = @num_hab) + (SELECT precio_total FROM Paquetes WHERE cod_paquete = @paquete_seleccionado)) * (select dbo.func_DiasEstadia(@cod_reserva) + 1))) - (SELECT pago_anti FROM Reservas WHERE cod_reserva = @cod_reserva)) AS total";
                        cmd2 = new SqlCommand(cadena2, conex);
                        cmd2.Parameters.AddWithValue("@num_doc_cliente", userId);
                        cmd2.Parameters.AddWithValue("@paquete_seleccionado", cb_Paquetes.SelectedValue);
                        cmd2.Parameters.AddWithValue("@num_hab", cb_HabitacionesDisp.SelectedValue);
                        cmd2.Parameters.AddWithValue("@cod_reserva", cod_reserva);
                        cmd2.Parameters.AddWithValue("@opcion_pago", cb_TipoPago.Text);

                        try
                        {
                            int j = cmd2.ExecuteNonQuery();

                            if (j > 0)
                            {
                                MessageBox.Show("Reserva realizada con éxito");
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Error:" + ex.ToString());
                        }


                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 245) // Error de tipo de dato
                            MessageBox.Show("Error: verifique los tipos de datos");
                    }
                }
                else
                {
                    cadena = "INSERT INTO Reservas(fecha_inicio, fecha_fin, fecha_reserva, num_doc, tipo_pago, cantidad_huespedes) VALUES(@fecha_inicio, @fecha_fin, GETDATE(), @num_doc, @tipo_pago, @cantidad_huespedes); SELECT SCOPE_IDENTITY()";
                    cmd = new SqlCommand(cadena, conex);
                    cmd.Parameters.AddWithValue("@fecha_inicio", dtp_FechaCheckIn.Text);
                    cmd.Parameters.AddWithValue("@fecha_fin", dtp_FechaCheckOut.Text);
                    cmd.Parameters.AddWithValue("@num_doc", userId);
                    cmd.Parameters.AddWithValue("@tipo_pago", cb_TipoPago.Text);
                    cmd.Parameters.AddWithValue("@cantidad_huespedes", cb_CantidadHuespedes.Text);

                    try
                    {
                        cod_reserva = Convert.ToInt32(cmd.ExecuteScalar());

                        cadena2 = $"INSERT INTO Factura (num_doc_cliente, paquete_seleccionado, fecha_compra, cod_reserva, num_hab, opcion_pago, subtotal, iva, total) ";
                        cadena2 += "SELECT @num_doc_cliente, @paquete_seleccionado, (select fecha_reserva from reservas where cod_reserva = @cod_reserva), @cod_reserva, @num_hab, @opcion_pago, (((SELECT precio FROM Habitaciones WHERE num_hab = @num_hab) + (SELECT precio_total FROM Paquetes WHERE cod_paquete = @paquete_seleccionado))  * (select dbo.func_DiasEstadia(@cod_reserva) + 1)) AS subtotal, (0.1 * (((SELECT precio FROM Habitaciones WHERE num_hab = @num_hab) + (SELECT precio_total FROM Paquetes WHERE cod_paquete = @paquete_seleccionado))  * (select dbo.func_DiasEstadia(@cod_reserva) + 1))) AS iva, ((1.1 * (((SELECT precio FROM Habitaciones WHERE num_hab = @num_hab) + (SELECT precio_total FROM Paquetes WHERE cod_paquete = @paquete_seleccionado)) * (select dbo.func_DiasEstadia(@cod_reserva) + 1))) - (SELECT pago_anti FROM Reservas WHERE cod_reserva = @cod_reserva)) AS total";
                        cmd2 = new SqlCommand(cadena2, conex);
                        cmd2.Parameters.AddWithValue("@num_doc_cliente", userId);
                        cmd2.Parameters.AddWithValue("@paquete_seleccionado", cb_Paquetes.SelectedValue);
                        cmd2.Parameters.AddWithValue("@num_hab", cb_HabitacionesDisp.SelectedValue);
                        cmd2.Parameters.AddWithValue("@cod_reserva", cod_reserva);
                        cmd2.Parameters.AddWithValue("@opcion_pago", cb_TipoPago.Text);

                        try
                        {
                            int j = cmd2.ExecuteNonQuery();

                            if (j > 0)
                            {
                                MessageBox.Show("Reserva realizada con éxito");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error:" + ex.ToString());
                        }

                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 245) // Error de tipo de dato
                            MessageBox.Show("Error: verifique los tipos de datos");
                    }
                }
            }
            connection.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Aquí se verán las reservas realizadas por el cliente.
            connection.closeConnection();
            frm_Ver_Reservas_Realizadas reservas = new frm_Ver_Reservas_Realizadas(userId, userName);
            reservas.ShowDialog();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
            new frm_LogInClientes().Show();
        }
    }
}