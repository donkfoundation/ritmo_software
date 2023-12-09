namespace hotel_nn.View
{
    partial class frm_VerCuentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cuentaData = new hotel_nn.View.CuentaData();
            this.obtenerCuentaClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerCuentaClienteTableAdapter = new hotel_nn.View.CuentaDataTableAdapters.ObtenerCuentaClienteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerCuentaClienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "cuentas";
            reportDataSource1.Value = this.obtenerCuentaClienteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "hotel_nn.View.Cuenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // cuentaData
            // 
            this.cuentaData.DataSetName = "CuentaData";
            this.cuentaData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // obtenerCuentaClienteBindingSource
            // 
            this.obtenerCuentaClienteBindingSource.DataMember = "ObtenerCuentaCliente";
            this.obtenerCuentaClienteBindingSource.DataSource = this.cuentaData;
            // 
            // obtenerCuentaClienteTableAdapter
            // 
            this.obtenerCuentaClienteTableAdapter.ClearBeforeFill = true;
            // 
            // frm_VerCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_VerCuentas";
            this.Text = "frm_VerCuentas";
            this.Load += new System.EventHandler(this.frm_VerCuentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cuentaData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerCuentaClienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource obtenerCuentaClienteBindingSource;
        private CuentaData cuentaData;
        private CuentaDataTableAdapters.ObtenerCuentaClienteTableAdapter obtenerCuentaClienteTableAdapter;
    }
}