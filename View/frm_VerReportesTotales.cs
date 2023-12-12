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
    public partial class frm_VerReportesTotales : Form
    {
        public frm_VerReportesTotales()
        {
            InitializeComponent();
        }

        private void frm_VerReportesTotales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reportData.ObtenerTotalCuentasUltimoMes' table. You can move, or remove it, as needed.
            this.obtenerTotalCuentasUltimoMesTableAdapter.Fill(this.reportData.ObtenerTotalCuentasUltimoMes);
            // TODO: This line of code loads data into the 'reportData.ObtenerTotalUltimoMes' table. You can move, or remove it, as needed.
            this.obtenerTotalUltimoMesTableAdapter.Fill(this.reportData.ObtenerTotalUltimoMes);
            // TODO: This line of code loads data into the 'reportData.ObtenerTotalCuentasUltimoMes' table. You can move, or remove it, as needed.
            this.obtenerTotalCuentasUltimoMesTableAdapter.Fill(this.reportData.ObtenerTotalCuentasUltimoMes);
            // TODO: This line of code loads data into the 'reportData.ObtenerTotalUltimoMes' table. You can move, or remove it, as needed.
            this.obtenerTotalUltimoMesTableAdapter.Fill(this.reportData.ObtenerTotalUltimoMes);

            this.reportViewer1.RefreshReport();
        }
    }
}
