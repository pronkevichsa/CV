namespace viewer2
{
    partial class SchetchikReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SchetchikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbaseDataSet = new viewer2.dbaseDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SchetchikTableAdapter = new viewer2.dbaseDataSetTableAdapters.SchetchikTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SchetchikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // SchetchikBindingSource
            // 
            this.SchetchikBindingSource.DataMember = "Schetchik";
            this.SchetchikBindingSource.DataSource = this.dbaseDataSet;
            // 
            // dbaseDataSet
            // 
            this.dbaseDataSet.DataSetName = "dbaseDataSet";
            this.dbaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "dbaseDataSet_Schetchik";
            reportDataSource2.Value = this.SchetchikBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "viewer2.SchetchikReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(832, 506);
            this.reportViewer1.TabIndex = 0;
            // 
            // SchetchikTableAdapter
            // 
            this.SchetchikTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(663, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SchetchikReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SchetchikReport";
            this.Text = "SchetchikReport";
            this.Load += new System.EventHandler(this.SchetchikReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SchetchikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SchetchikBindingSource;
        private dbaseDataSet dbaseDataSet;
        private viewer2.dbaseDataSetTableAdapters.SchetchikTableAdapter SchetchikTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}