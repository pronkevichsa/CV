namespace viewer2
{
    partial class EnergyReport
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
            this.EnergyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbaseDataSet = new viewer2.dbaseDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.EnergyTableAdapter = new viewer2.dbaseDataSetTableAdapters.EnergyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // EnergyBindingSource
            // 
            this.EnergyBindingSource.DataMember = "Energy";
            this.EnergyBindingSource.DataSource = this.dbaseDataSet;
            // 
            // dbaseDataSet
            // 
            this.dbaseDataSet.DataSetName = "dbaseDataSet";
            this.dbaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dbaseDataSet_Energy";
            reportDataSource1.Value = this.EnergyBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "viewer2.Energy.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(759, 567);
            this.reportViewer1.TabIndex = 0;
            // 
            // EnergyTableAdapter
            // 
            this.EnergyTableAdapter.ClearBeforeFill = true;
            // 
            // EnergyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 568);
            this.Controls.Add(this.reportViewer1);
            this.Name = "EnergyReport";
            this.Text = "EnergyReport";
            this.Load += new System.EventHandler(this.EnergyReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EnergyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EnergyBindingSource;
        private dbaseDataSet dbaseDataSet;
        private viewer2.dbaseDataSetTableAdapters.EnergyTableAdapter EnergyTableAdapter;
    }
}