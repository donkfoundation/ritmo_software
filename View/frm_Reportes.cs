using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace hotel_nn
{
    public partial class frm_Reportes : Form
    {
        public frm_Reportes()
        {
            InitializeComponent();
        }

        private void frm_Reportes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reportData.ObtenerTotalUltimoMes' table. You can move, or remove it, as needed.
            this.obtenerTotalUltimoMesTableAdapter.Fill(this.reportData.ObtenerTotalUltimoMes);
            // TODO: This line of code loads data into the 'reportData.ObtenerReservasUltimoMes' table. You can move, or remove it, as needed.
            this.obtenerReservasUltimoMesTableAdapter.Fill(this.reportData.ObtenerReservasUltimoMes);
            // TODO: This line of code loads data into the 'reportData.ObtenerPaquetesPopulares' table. You can move, or remove it, as needed.
            this.obtenerPaquetesPopularesTableAdapter.Fill(this.reportData.ObtenerPaquetesPopulares);
            // TODO: This line of code loads data into the 'reportData.ObtenerHabitacionesPopulares' table. You can move, or remove it, as needed.
            this.obtenerHabitacionesPopularesTableAdapter.Fill(this.reportData.ObtenerHabitacionesPopulares);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
