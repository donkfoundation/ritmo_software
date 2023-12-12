using hotel_nn.View;

namespace hotel_nn
{
    partial class frm_VerReportesTotales
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportData = new hotel_nn.View.ReportData();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.obtenerTotalUltimoMesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerTotalUltimoMesTableAdapter = new hotel_nn.View.ReportDataTableAdapters.ObtenerTotalUltimoMesTableAdapter();
            this.obtenerTotalCuentasUltimoMesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerTotalCuentasUltimoMesTableAdapter = new hotel_nn.View.ReportDataTableAdapters.ObtenerTotalCuentasUltimoMesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerTotalUltimoMesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerTotalCuentasUltimoMesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportData
            // 
            this.reportData.DataSetName = "ReportData";
            this.reportData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "total_mes";
            reportDataSource1.Value = this.obtenerTotalUltimoMesBindingSource;
            reportDataSource2.Name = "total_cuentas_mes";
            reportDataSource2.Value = this.obtenerTotalCuentasUltimoMesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "hotel_nn.View.ReporteTotales.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(525, 400);
            this.reportViewer1.TabIndex = 0;
            // 
            // obtenerTotalUltimoMesBindingSource
            // 
            this.obtenerTotalUltimoMesBindingSource.DataMember = "ObtenerTotalUltimoMes";
            this.obtenerTotalUltimoMesBindingSource.DataSource = this.reportData;
            // 
            // obtenerTotalUltimoMesTableAdapter
            // 
            this.obtenerTotalUltimoMesTableAdapter.ClearBeforeFill = true;
            // 
            // obtenerTotalCuentasUltimoMesBindingSource
            // 
            this.obtenerTotalCuentasUltimoMesBindingSource.DataMember = "ObtenerTotalCuentasUltimoMes";
            this.obtenerTotalCuentasUltimoMesBindingSource.DataSource = this.reportData;
            // 
            // obtenerTotalCuentasUltimoMesTableAdapter
            // 
            this.obtenerTotalCuentasUltimoMesTableAdapter.ClearBeforeFill = true;
            // 
            // frm_VerReportesTotales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 400);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_VerReportesTotales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.frm_VerReportesTotales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerTotalUltimoMesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerTotalCuentasUltimoMesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ReportData reportData;
        private System.Windows.Forms.BindingSource obtenerTotalUltimoMesBindingSource;
        private View.ReportDataTableAdapters.ObtenerTotalUltimoMesTableAdapter obtenerTotalUltimoMesTableAdapter;
        private System.Windows.Forms.BindingSource obtenerTotalCuentasUltimoMesBindingSource;
        private View.ReportDataTableAdapters.ObtenerTotalCuentasUltimoMesTableAdapter obtenerTotalCuentasUltimoMesTableAdapter;
    }
}