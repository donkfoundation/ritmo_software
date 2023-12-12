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
using hotel_nn;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using hotel_nn.View;

namespace hotel_nn
{
    public partial class frm_Menu_Principal : Form
    {
        static dbConnection connection = new dbConnection();
        SqlConnection conex = connection.conexString;
        public string UserID;
        public string UserDoc;
        private Timer timer;
        public string UserRol;
        public frm_Menu_Principal()
        {
            InitializeComponent();
            
        }

        private void adminHabitacionesReservadas()
        {
            // Se ejecutan estos procedimientos almacenados para cambiar el estado de habitaciones que ya 
            // habían sido reservadas para fechas posteriores a la de la reserva, si yo hice una reserva hoy
            // para mañana, este código cambiará el estado de la habitación cuando la fecha llegue, además
            // volverá a poner disponibles las habitaciones cuyas fechas de checkout ya pasaron
            connection.openConnection();
            SqlCommand cmd = new SqlCommand("EXEC DesocuparHabitacionesAutomaticamente; exec OcuparHabitacionesAutomaticamente;", conex);
            int i = cmd.ExecuteNonQuery();
            connection.closeConnection();
        }

        private void loadPaquetesPopulares()
        {
            // Aquí se cargarán los paquetes más populares
            connection.openConnection();
            string cadena = "SELECT Paquetes.nombre_paquete, Paquetes.cod_paquete, COUNT(Factura.paquete_seleccionado) AS CantidadSeleccionada FROM Paquetes " +
                "LEFT JOIN Factura ON Paquetes.cod_paquete = Factura.paquete_seleccionado GROUP BY Paquetes.cod_paquete, Paquetes.nombre_paquete " +
                "ORDER BY CantidadSeleccionada DESC;";
            SqlCommand cmd = new SqlCommand(cadena, conex);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lbl_PaqueteUno.Text = reader["nombre_paquete"].ToString();
                    lbl_EleccionesUno.Text = reader["CantidadSeleccionada"].ToString();

                    if (reader.Read())
                    {
                        lbl_PaqueteDos.Text = reader["nombre_paquete"].ToString();
                        lbl_EleccionesDos.Text = reader["CantidadSeleccionada"].ToString();

                        if (reader.Read())
                        {
                            lbl_PaqueteTres.Text = reader["nombre_paquete"].ToString();
                            lbl_EleccionesTres.Text = reader["CantidadSeleccionada"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.closeConnection();
        }

        private void loadDineroSemanal()
        {
            // Aquí se cargará el dinero que se ha hecho cada semana.
            connection.openConnection();

            string cadenacuenta = "DECLARE @FechaCorte DATETIME = GETDATE(); DECLARE @DiaSemanaCorte INT = DATEPART(WEEKDAY, @FechaCorte); DECLARE @ProximoDomingo DATETIME = DATEADD(DAY, 1 + (7 - @DiaSemanaCorte), @FechaCorte); DECLARE @DomingoAnterior DATETIME = DATEADD(DAY, -@DiaSemanaCorte, @FechaCorte); SELECT SUM(costo)  AS 'Ventas' FROM Cuenta Where Cuenta.fecha_compra <= @ProximoDomingo AND Cuenta.fecha_compra > @DomingoAnterior;";
            SqlCommand cmd2 = new SqlCommand(cadenacuenta, conex);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            int cuentas;
            if (reader2.Read())
            {
                try
                {
                    cuentas = int.Parse(reader2["ventas"].ToString());
                }
                catch (FormatException)
                {
                    cuentas = 0;
                }
            }
            else
                cuentas = 0;
            reader2.Close();

            string cadena = "DECLARE @FechaCorte DATETIME = GETDATE(); DECLARE @DiaSemanaCorte INT = DATEPART(WEEKDAY, @FechaCorte); DECLARE @ProximoDomingo DATETIME = DATEADD(DAY, 1 + (7 - @DiaSemanaCorte), @FechaCorte); DECLARE @DomingoAnterior DATETIME = DATEADD(DAY, -@DiaSemanaCorte, @FechaCorte); SELECT SUM(total) + sum(pago_anti) AS 'Ventas' FROM Factura inner join Reservas on Factura.cod_reserva = Reservas.cod_reserva WHERE Factura.fecha_compra <= @ProximoDomingo AND Factura.fecha_compra > @DomingoAnterior;";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataReader reader = cmd.ExecuteReader();
            int total_ventas;
            if (reader.Read())
            {
                try
                {
                    total_ventas = int.Parse(reader["ventas"].ToString());
                }
                catch (FormatException)
                {
                    total_ventas = 0;
                }
            }
            else
                total_ventas = 0;
            reader.Close();

            lbl_Dinero_Semanal.Text = $"{cuentas + total_ventas} $";
            connection.closeConnection();
        }

        private void LoadHabitacionesLv()
        {
            // Este será un preview de las habitaciones disponibles actualmente
            connection.openConnection();
            lv_Disponibilidad_Menu.Columns.Clear();
            lv_Disponibilidad_Menu.Items.Clear();

            lv_Disponibilidad_Menu.Columns.Add("Número de habitación");
            lv_Disponibilidad_Menu.Columns.Add("Tipo de Habitación");
            lv_Disponibilidad_Menu.Columns.Add("Precio");

            // Ajusta el tamaño de las columnas para que quede repartido proporcionalmente
            foreach (ColumnHeader column in lv_Disponibilidad_Menu.Columns)
            {
                column.Width = lv_Disponibilidad_Menu.Width / lv_Disponibilidad_Menu.Columns.Count;
            }

            SqlCommand cmd = new SqlCommand("select num_hab, tipo_hab, precio from Habitaciones where estado='D'", conex);
            DataTable dt;
            SqlDataAdapter da;
            DataSet ds;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "Test Table");
            dt = ds.Tables["Test Table"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem(dt.Rows[i]["num_hab"].ToString());
                listViewItem.SubItems.Add(dt.Rows[i]["tipo_hab"].ToString());
                listViewItem.SubItems.Add(dt.Rows[i]["precio"].ToString());

                lv_Disponibilidad_Menu.Items.Add(listViewItem);
            }
            connection.closeConnection();
        }

        private void loadHabitacionPopular()
        {
            //Aquí se cargará la habitación más elegida
            connection.openConnection();
            string cadena = "SELECT Habitaciones.num_hab, COUNT(Factura.num_hab) " +
                "AS CantidadSeleccionada FROM Habitaciones LEFT JOIN Factura ON " +
                "Habitaciones.num_hab = Factura.num_hab GROUP BY " +
                "Habitaciones.num_hab ORDER BY CantidadSeleccionada DESC;";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    lbl_HabitacionPopular.Text = reader["num_hab"].ToString();
            }
            catch (Exception)
            {

            }
            connection.closeConnection();
        }

        // Cada vez que pasa un segundo se actualizará la fecha

        private void Timer_Tick(object sender, EventArgs e)
        {
            tss_Fecha_Cargada.Text = DateTime.Now.ToLongDateString();
            tss_Hora_Cargada.Text = DateTime.Now.ToLongTimeString();
        }

        public void LoadData()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            timer.Start();

            tss_Usuario_Actual.Text = this.UserID;

            loadPaquetesPopulares();
            loadDineroSemanal();
            LoadHabitacionesLv();
            loadHabitacionPopular();
        }

        private void frm_Menu_Principal_Load_1(object sender, EventArgs e)
        {
            adminHabitacionesReservadas();
            LoadData();
        }

        private bool validarPermiso(string placeholder)
        {
            // Esta función nos ayudará a verificar que el usuario conectado tiene los permisos necesarios para visitar
            // el formulario seleccionado
            connection.openConnection();
            string cadena = $"SELECT {placeholder} FROM Permisos where num_documento = @num_doc";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue("@num_doc", this.UserDoc);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Boolean.Parse(reader[0].ToString());
            } 
            else
            {
                return false;
            }

        }

        // Estos eventos llamarán la función con su cadena correspondiente para verificar el permiso
        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "pais";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                Form crear_paises = new frm_Crear_Paises();
                crear_paises.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "departamento";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                Form crear_deptos = new frm_Crear_Dpto();
                crear_deptos.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "ciudad";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                Form crear_ciudades = new frm_Crear_Ciudad();
                crear_ciudades.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "registro";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                Form registro_usuario = new frm_Registro_Usuarios();
                registro_usuario.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void iNVENTARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "inventario";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                Form inventario = new frm_Inventario();
                inventario.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void asignaciónDeRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "roles";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                Form asignar_roles = new frm_Asignacion_Roles();
                asignar_roles.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void lv_Preview_Reservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Funciona el click");
        }

        private void rESERVASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "reservas";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                Form reservas = new frm_Reservas();
                reservas.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void pROVEEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "proveedores";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                Form proveedores = new frm_Proveedores();
                proveedores.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void hABITACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "habitaciones";
            if (validarPermiso(cadena))
            {
                try
                {
                    connection.closeConnection();
                    Form habitaciones = new frm_Habitaciones();
                    habitaciones.ShowDialog();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void verClientesRegistradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "clientes"; 
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                Form clientes = new frm_VerClientes();
                clientes.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void paquetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "paquetes";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                Form paquetes = new frm_Paquetes();
                paquetes.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void rEPORTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "reportes";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                frm_GenerarReportes reportes = new frm_GenerarReportes();
                reportes.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }

        }

        private void facturaDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "factura";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                frm_Facturas facturas = new frm_Facturas();
                facturas.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }

        }
        private void cobrarServicioAdicionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "cuenta";
            if (validarPermiso(cadena))
            {
                connection.closeConnection();
                frm_CuentasPorCobrar cuentas = new frm_CuentasPorCobrar(this);
                cuentas.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // El formulario de permisos solo podrá ser visitado por un usuario con rol admin o manager.
            if (string.Equals(UserRol, "admin", StringComparison.OrdinalIgnoreCase) || string.Equals(UserRol, "manager", StringComparison.OrdinalIgnoreCase))
            {
                connection.closeConnection();
                Form permisos = new frm_Permisos();
                permisos.ShowDialog();
            }
            else
            {
                connection.closeConnection();
                MessageBox.Show("No tienes los permisos para visitar este recurso");
            }
        }

        private void btn_Salir_Menu_Click(object sender, EventArgs e)
        {
            this.Close();
            new LogIn().Show();
        }

        private void tss_Usuario_Actual_Click(object sender, EventArgs e)
        {

        }
    }
}
