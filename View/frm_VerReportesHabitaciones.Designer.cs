namespace hotel_nn
{
    partial class frm_VerReportesHabitaciones
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
            this.obtenerHabitacionesPopularesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerHabitacionesPopularesTableAdapter = new hotel_nn.View.ReportDataTableAdapters.ObtenerHabitacionesPopularesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerHabitacionesPopularesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportData
            // 
            this.reportData.DataSetName = "ReportData";
            this.reportData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "habitaciones_populares";
            reportDataSource1.Value = this.obtenerHabitacionesPopularesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "hotel_nn.View.ReporteHabitaciones.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(655, 490);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // obtenerHabitacionesPopularesBindingSource
            // 
            this.obtenerHabitacionesPopularesBindingSource.DataMember = "ObtenerHabitacionesPopulares";
            this.obtenerHabitacionesPopularesBindingSource.DataSource = this.reportData;
            // 
            // obtenerHabitacionesPopularesTableAdapter
            // 
            this.obtenerHabitacionesPopularesTableAdapter.ClearBeforeFill = true;
            // 
            // frm_VerReportesHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 490);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_VerReportesHabitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.frm_Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerHabitacionesPopularesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private View.ReportData reportData;
        private System.Windows.Forms.BindingSource obtenerHabitacionesPopularesBindingSource;
        private View.ReportDataTableAdapters.ObtenerHabitacionesPopularesTableAdapter obtenerHabitacionesPopularesTableAdapter;
    }
}