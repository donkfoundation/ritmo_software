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
    public partial class frm_VerReportesPaquetes : Form
    {
        public frm_VerReportesPaquetes()
        {
            InitializeComponent();
        }

        private void frm_VerReportesPaquetes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reportData.ObtenerPaquetesPopulares' table. You can move, or remove it, as needed.
            this.obtenerPaquetesPopularesTableAdapter.Fill(this.reportData.ObtenerPaquetesPopulares);
            // TODO: This line of code loads data into the 'reportData.ObtenerPaquetesPopulares' table. You can move, or remove it, as needed.
            this.obtenerPaquetesPopularesTableAdapter.Fill(this.reportData.ObtenerPaquetesPopulares);

            this.reportViewer1.RefreshReport();
        }
    }
}
