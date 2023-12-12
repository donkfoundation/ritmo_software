using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel_nn
{
    public partial class frm_GenerarReportes : Form
    {
        public frm_GenerarReportes()
        {
            InitializeComponent();
        }

        private void btn_ReportePaquetes_Click(object sender, EventArgs e)
        {
            frm_VerReportesPaquetes paquetes = new frm_VerReportesPaquetes();
            paquetes.ShowDialog();
        }

        private void btn_ReporteGanancias_Click(object sender, EventArgs e)
        {
            frm_VerReportesTotales totales = new frm_VerReportesTotales();
            totales.ShowDialog();
        }

        private void btn_ReporteHabitaciones_Click(object sender, EventArgs e)
        {
            frm_VerReportesHabitaciones habitaciones = new frm_VerReportesHabitaciones();
            habitaciones.ShowDialog();
        }


        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
