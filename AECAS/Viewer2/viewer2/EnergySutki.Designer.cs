namespace viewer2
{
    partial class EnergySutki
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
            this.Energy30BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbaseDataSet = new viewer2.dbaseDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Energy30TableAdapter = new viewer2.dbaseDataSetTableAdapters.Energy30TableAdapter();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button2 = new System.Windows.Forms.Button();
            this.dateDay = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Energy30BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Energy30BindingSource
            // 
            this.Energy30BindingSource.DataMember = "Energy30";
            this.Energy30BindingSource.DataSource = this.dbaseDataSet;
            // 
            // dbaseDataSet
            // 
            this.dbaseDataSet.DataSetName = "dbaseDataSet";
            this.dbaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dbaseDataSet_Energy30";
            reportDataSource1.Value = this.Energy30BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "viewer2.SutEnergy.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(339, 694);
            this.reportViewer1.TabIndex = 0;
            // 
            // Energy30TableAdapter
            // 
            this.Energy30TableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer2
            // 
            reportDataSource2.Name = "dbaseDataSet_Energy30";
            reportDataSource2.Value = this.Energy30BindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "viewer2.SutEnergygraph.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(351, 2);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(636, 593);
            this.reportViewer2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(610, 639);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Обновить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateDay
            // 
            this.dateDay.Location = new System.Drawing.Point(610, 613);
            this.dateDay.Name = "dateDay";
            this.dateDay.Size = new System.Drawing.Size(161, 20);
            this.dateDay.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 668);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EnergySutki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 708);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateDay);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "EnergySutki";
            this.Text = "EnergySutki";
            this.Load += new System.EventHandler(this.EnergySutki_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Energy30BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Energy30BindingSource;
        private dbaseDataSet dbaseDataSet;
        private viewer2.dbaseDataSetTableAdapters.Energy30TableAdapter Energy30TableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateDay;
        private System.Windows.Forms.Button button1;

    }
}