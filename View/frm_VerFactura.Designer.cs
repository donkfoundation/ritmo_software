namespace hotel_nn.View
{
    partial class frm_VerFactura
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
            this.ObtenerFacturaClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturaData = new hotel_nn.View.FacturaData();
            this.obtenerFacturaClienteBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerFacturaClienteTableAdapter = new hotel_nn.View.FacturaDataTableAdapters.ObtenerFacturaClienteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ObtenerFacturaClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerFacturaClienteBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "facturas";
            reportDataSource1.Value = this.obtenerFacturaClienteBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "hotel_nn.View.Factura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // ObtenerFacturaClienteBindingSource
            // 
            this.ObtenerFacturaClienteBindingSource.DataMember = "ObtenerFacturaCliente";
            this.ObtenerFacturaClienteBindingSource.DataSource = this.facturaData;
            // 
            // facturaData
            // 
            this.facturaData.DataSetName = "FacturaData";
            this.facturaData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // obtenerFacturaClienteBindingSource1
            // 
            this.obtenerFacturaClienteBindingSource1.DataMember = "ObtenerFacturaCliente";
            this.obtenerFacturaClienteBindingSource1.DataSource = this.facturaData;
            // 
            // obtenerFacturaClienteTableAdapter
            // 
            this.obtenerFacturaClienteTableAdapter.ClearBeforeFill = true;
            // 
            // frm_VerFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_VerFactura";
            this.Text = "frm_VerFactura";
            this.Load += new System.EventHandler(this.frm_VerFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ObtenerFacturaClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerFacturaClienteBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource obtenerFacturaClienteBindingSource1;
        private FacturaData facturaData;
        private FacturaDataTableAdapters.ObtenerFacturaClienteTableAdapter obtenerFacturaClienteTableAdapter;
        private System.Windows.Forms.BindingSource ObtenerFacturaClienteBindingSource;
    }
}