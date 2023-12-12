using hotel_nn.View;

namespace hotel_nn
{
    partial class frm_VerReportesPaquetes
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
            this.reportData = new hotel_nn.View.ReportData();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.obtenerPaquetesPopularesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerPaquetesPopularesTableAdapter = new hotel_nn.View.ReportDataTableAdapters.ObtenerPaquetesPopularesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerPaquetesPopularesBindingSource)).BeginInit();
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
            reportDataSource1.Name = "reporte_paquetes";
            reportDataSource1.Value = this.obtenerPaquetesPopularesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "hotel_nn.View.ReportePaquetes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(728, 471);
            this.reportViewer1.TabIndex = 0;
            // 
            // obtenerPaquetesPopularesBindingSource
            // 
            this.obtenerPaquetesPopularesBindingSource.DataMember = "ObtenerPaquetesPopulares";
            this.obtenerPaquetesPopularesBindingSource.DataSource = this.reportData;
            // 
            // obtenerPaquetesPopularesTableAdapter
            // 
            this.obtenerPaquetesPopularesTableAdapter.ClearBeforeFill = true;
            // 
            // frm_VerReportesPaquetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 471);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_VerReportesPaquetes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.frm_VerReportesPaquetes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerPaquetesPopularesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ReportData reportData;
        private System.Windows.Forms.BindingSource obtenerPaquetesPopularesBindingSource;
        private View.ReportDataTableAdapters.ObtenerPaquetesPopularesTableAdapter obtenerPaquetesPopularesTableAdapter;
    }
}