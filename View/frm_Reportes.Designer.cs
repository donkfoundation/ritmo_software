namespace hotel_nn
{
    partial class frm_Reportes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource10 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource11 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource12 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.obtenerHabitacionesPopularesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportData = new hotel_nn.View.ReportData();
            this.obtenerPaquetesPopularesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerReservasUltimoMesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obtenerTotalUltimoMesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.obtenerHabitacionesPopularesTableAdapter = new hotel_nn.View.ReportDataTableAdapters.ObtenerHabitacionesPopularesTableAdapter();
            this.obtenerPaquetesPopularesTableAdapter = new hotel_nn.View.ReportDataTableAdapters.ObtenerPaquetesPopularesTableAdapter();
            this.obtenerReservasUltimoMesTableAdapter = new hotel_nn.View.ReportDataTableAdapters.ObtenerReservasUltimoMesTableAdapter();
            this.obtenerTotalUltimoMesTableAdapter = new hotel_nn.View.ReportDataTableAdapters.ObtenerTotalUltimoMesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerHabitacionesPopularesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerPaquetesPopularesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerReservasUltimoMesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerTotalUltimoMesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // obtenerHabitacionesPopularesBindingSource
            // 
            this.obtenerHabitacionesPopularesBindingSource.DataMember = "ObtenerHabitacionesPopulares";
            this.obtenerHabitacionesPopularesBindingSource.DataSource = this.reportData;
            // 
            // reportData
            // 
            this.reportData.DataSetName = "ReportData";
            this.reportData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // obtenerPaquetesPopularesBindingSource
            // 
            this.obtenerPaquetesPopularesBindingSource.DataMember = "ObtenerPaquetesPopulares";
            this.obtenerPaquetesPopularesBindingSource.DataSource = this.reportData;
            // 
            // obtenerReservasUltimoMesBindingSource
            // 
            this.obtenerReservasUltimoMesBindingSource.DataMember = "ObtenerReservasUltimoMes";
            this.obtenerReservasUltimoMesBindingSource.DataSource = this.reportData;
            // 
            // obtenerTotalUltimoMesBindingSource
            // 
            this.obtenerTotalUltimoMesBindingSource.DataMember = "ObtenerTotalUltimoMes";
            this.obtenerTotalUltimoMesBindingSource.DataSource = this.reportData;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource9.Name = "habitaciones_populares";
            reportDataSource9.Value = this.obtenerHabitacionesPopularesBindingSource;
            reportDataSource10.Name = "paquetes_populares";
            reportDataSource10.Value = this.obtenerPaquetesPopularesBindingSource;
            reportDataSource11.Name = "reservas_mes";
            reportDataSource11.Value = this.obtenerReservasUltimoMesBindingSource;
            reportDataSource12.Name = "totales";
            reportDataSource12.Value = this.obtenerTotalUltimoMesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource9);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource10);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource11);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource12);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "hotel_nn.View.Reporte.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(655, 490);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // obtenerHabitacionesPopularesTableAdapter
            // 
            this.obtenerHabitacionesPopularesTableAdapter.ClearBeforeFill = true;
            // 
            // obtenerPaquetesPopularesTableAdapter
            // 
            this.obtenerPaquetesPopularesTableAdapter.ClearBeforeFill = true;
            // 
            // obtenerReservasUltimoMesTableAdapter
            // 
            this.obtenerReservasUltimoMesTableAdapter.ClearBeforeFill = true;
            // 
            // obtenerTotalUltimoMesTableAdapter
            // 
            this.obtenerTotalUltimoMesTableAdapter.ClearBeforeFill = true;
            // 
            // frm_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 490);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_Reportes";
            this.Load += new System.EventHandler(this.frm_Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.obtenerHabitacionesPopularesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerPaquetesPopularesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerReservasUltimoMesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerTotalUltimoMesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private View.ReportData reportData;
        private System.Windows.Forms.BindingSource obtenerHabitacionesPopularesBindingSource;
        private View.ReportDataTableAdapters.ObtenerHabitacionesPopularesTableAdapter obtenerHabitacionesPopularesTableAdapter;
        private System.Windows.Forms.BindingSource obtenerPaquetesPopularesBindingSource;
        private View.ReportDataTableAdapters.ObtenerPaquetesPopularesTableAdapter obtenerPaquetesPopularesTableAdapter;
        private System.Windows.Forms.BindingSource obtenerReservasUltimoMesBindingSource;
        private View.ReportDataTableAdapters.ObtenerReservasUltimoMesTableAdapter obtenerReservasUltimoMesTableAdapter;
        private System.Windows.Forms.BindingSource obtenerTotalUltimoMesBindingSource;
        private View.ReportDataTableAdapters.ObtenerTotalUltimoMesTableAdapter obtenerTotalUltimoMesTableAdapter;
    }
}