using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel_nn.View
{
    public partial class frm_VerFactura : Form
    {
        public frm_VerFactura()
        {
            InitializeComponent();
        }

        public int codReserva {  get; set; }

        private void frm_VerFactura_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facturaData.ObtenerFacturaCliente' table. You can move, or remove it, as needed.
            this.obtenerFacturaClienteTableAdapter.Fill(this.facturaData.ObtenerFacturaCliente, codReserva);
            
            this.reportViewer1.RefreshReport();
        }
    }
}
