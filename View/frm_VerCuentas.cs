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
    public partial class frm_VerCuentas : Form
    {
        public frm_VerCuentas()
        {
            InitializeComponent();
        }

        public int codCuenta {  get; set; }

        private void frm_VerCuentas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cuentaData.ObtenerCuentaCliente' table. You can move, or remove it, as needed.
            this.obtenerCuentaClienteTableAdapter.Fill(this.cuentaData.ObtenerCuentaCliente, codCuenta);

            this.reportViewer1.RefreshReport();
        }
    }
}
