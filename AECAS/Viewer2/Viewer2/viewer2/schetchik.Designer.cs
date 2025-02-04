namespace viewer2
{
    partial class schetchik
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SchetchikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbaseDataSet = new viewer2.dbaseDataSet();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.end = new System.Windows.Forms.DateTimePicker();
            this.begin = new System.Windows.Forms.DateTimePicker();
            this.schetchikTableAdapter = new viewer2.dbaseDataSetTableAdapters.SchetchikTableAdapter();
            this.dataInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s8DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s9DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s10DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s11DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s12DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s13DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s14DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s15DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s16DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchetchikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseDataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataInDataGridViewTextBoxColumn,
            this.s1DataGridViewTextBoxColumn,
            this.s2DataGridViewTextBoxColumn,
            this.s3DataGridViewTextBoxColumn,
            this.s4DataGridViewTextBoxColumn,
            this.s5DataGridViewTextBoxColumn,
            this.s6DataGridViewTextBoxColumn,
            this.s7DataGridViewTextBoxColumn,
            this.s8DataGridViewTextBoxColumn,
            this.s9DataGridViewTextBoxColumn,
            this.s10DataGridViewTextBoxColumn,
            this.s11DataGridViewTextBoxColumn,
            this.s12DataGridViewTextBoxColumn,
            this.s13DataGridViewTextBoxColumn,
            this.s14DataGridViewTextBoxColumn,
            this.s15DataGridViewTextBoxColumn,
            this.s16DataGridViewTextBoxColumn,
            this.s17,
            this.s18});
            this.dataGridView1.DataSource = this.SchetchikBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(594, 349);
            this.dataGridView1.TabIndex = 0;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(619, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Отчет";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.end);
            this.groupBox2.Controls.Add(this.begin);
            this.groupBox2.Location = new System.Drawing.Point(606, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 159);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 118);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(161, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Отобразить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Конец пероида:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Начало периода:";
            // 
            // end
            // 
            this.end.Location = new System.Drawing.Point(6, 87);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(161, 20);
            this.end.TabIndex = 14;
            // 
            // begin
            // 
            this.begin.Location = new System.Drawing.Point(6, 31);
            this.begin.Name = "begin";
            this.begin.Size = new System.Drawing.Size(161, 20);
            this.begin.TabIndex = 13;
            // 
            // schetchikTableAdapter
            // 
            this.schetchikTableAdapter.ClearBeforeFill = true;
            // 
            // dataInDataGridViewTextBoxColumn
            // 
            this.dataInDataGridViewTextBoxColumn.DataPropertyName = "DataIn";
            this.dataInDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dataInDataGridViewTextBoxColumn.Name = "dataInDataGridViewTextBoxColumn";
            // 
            // s1DataGridViewTextBoxColumn
            // 
            this.s1DataGridViewTextBoxColumn.DataPropertyName = "s1";
            this.s1DataGridViewTextBoxColumn.HeaderText = "P3-208 (A+)";
            this.s1DataGridViewTextBoxColumn.Name = "s1DataGridViewTextBoxColumn";
            // 
            // s2DataGridViewTextBoxColumn
            // 
            this.s2DataGridViewTextBoxColumn.DataPropertyName = "s2";
            this.s2DataGridViewTextBoxColumn.HeaderText = "P4-104 (A+)";
            this.s2DataGridViewTextBoxColumn.Name = "s2DataGridViewTextBoxColumn";
            // 
            // s3DataGridViewTextBoxColumn
            // 
            this.s3DataGridViewTextBoxColumn.DataPropertyName = "s3";
            this.s3DataGridViewTextBoxColumn.HeaderText = "P2-301 (A+)";
            this.s3DataGridViewTextBoxColumn.Name = "s3DataGridViewTextBoxColumn";
            // 
            // s4DataGridViewTextBoxColumn
            // 
            this.s4DataGridViewTextBoxColumn.DataPropertyName = "s4";
            this.s4DataGridViewTextBoxColumn.HeaderText = "P6-172 (A+)";
            this.s4DataGridViewTextBoxColumn.Name = "s4DataGridViewTextBoxColumn";
            // 
            // s5DataGridViewTextBoxColumn
            // 
            this.s5DataGridViewTextBoxColumn.DataPropertyName = "s5";
            this.s5DataGridViewTextBoxColumn.HeaderText = "P1-220 (A+)";
            this.s5DataGridViewTextBoxColumn.Name = "s5DataGridViewTextBoxColumn";
            // 
            // s6DataGridViewTextBoxColumn
            // 
            this.s6DataGridViewTextBoxColumn.DataPropertyName = "s6";
            this.s6DataGridViewTextBoxColumn.HeaderText = "P5-210 (A+)";
            this.s6DataGridViewTextBoxColumn.Name = "s6DataGridViewTextBoxColumn";
            // 
            // s7DataGridViewTextBoxColumn
            // 
            this.s7DataGridViewTextBoxColumn.DataPropertyName = "s7";
            this.s7DataGridViewTextBoxColumn.HeaderText = "P3-208 (R+)";
            this.s7DataGridViewTextBoxColumn.Name = "s7DataGridViewTextBoxColumn";
            // 
            // s8DataGridViewTextBoxColumn
            // 
            this.s8DataGridViewTextBoxColumn.DataPropertyName = "s8";
            this.s8DataGridViewTextBoxColumn.HeaderText = "P4-104 (R+)";
            this.s8DataGridViewTextBoxColumn.Name = "s8DataGridViewTextBoxColumn";
            // 
            // s9DataGridViewTextBoxColumn
            // 
            this.s9DataGridViewTextBoxColumn.DataPropertyName = "s9";
            this.s9DataGridViewTextBoxColumn.HeaderText = "P2-301 (R+)";
            this.s9DataGridViewTextBoxColumn.Name = "s9DataGridViewTextBoxColumn";
            // 
            // s10DataGridViewTextBoxColumn
            // 
            this.s10DataGridViewTextBoxColumn.DataPropertyName = "s10";
            this.s10DataGridViewTextBoxColumn.HeaderText = "P6-318 (R+)";
            this.s10DataGridViewTextBoxColumn.Name = "s10DataGridViewTextBoxColumn";
            // 
            // s11DataGridViewTextBoxColumn
            // 
            this.s11DataGridViewTextBoxColumn.DataPropertyName = "s11";
            this.s11DataGridViewTextBoxColumn.HeaderText = "P1-220 (R+)";
            this.s11DataGridViewTextBoxColumn.Name = "s11DataGridViewTextBoxColumn";
            // 
            // s12DataGridViewTextBoxColumn
            // 
            this.s12DataGridViewTextBoxColumn.DataPropertyName = "s12";
            this.s12DataGridViewTextBoxColumn.HeaderText = "P5-210 (R+)";
            this.s12DataGridViewTextBoxColumn.Name = "s12DataGridViewTextBoxColumn";
            // 
            // s13DataGridViewTextBoxColumn
            // 
            this.s13DataGridViewTextBoxColumn.DataPropertyName = "s13";
            this.s13DataGridViewTextBoxColumn.HeaderText = "P3-208 (R-)";
            this.s13DataGridViewTextBoxColumn.Name = "s13DataGridViewTextBoxColumn";
            // 
            // s14DataGridViewTextBoxColumn
            // 
            this.s14DataGridViewTextBoxColumn.DataPropertyName = "s14";
            this.s14DataGridViewTextBoxColumn.HeaderText = "P4-104 (R-)";
            this.s14DataGridViewTextBoxColumn.Name = "s14DataGridViewTextBoxColumn";
            // 
            // s15DataGridViewTextBoxColumn
            // 
            this.s15DataGridViewTextBoxColumn.DataPropertyName = "s15";
            this.s15DataGridViewTextBoxColumn.HeaderText = "P2-301 (R-)";
            this.s15DataGridViewTextBoxColumn.Name = "s15DataGridViewTextBoxColumn";
            // 
            // s16DataGridViewTextBoxColumn
            // 
            this.s16DataGridViewTextBoxColumn.DataPropertyName = "s16";
            this.s16DataGridViewTextBoxColumn.HeaderText = "P6-318 (R-)";
            this.s16DataGridViewTextBoxColumn.Name = "s16DataGridViewTextBoxColumn";
            // 
            // s17
            // 
            this.s17.DataPropertyName = "s17";
            this.s17.HeaderText = "P1-220 (R-)";
            this.s17.Name = "s17";
            // 
            // s18
            // 
            this.s18.DataPropertyName = "s18";
            this.s18.HeaderText = "P5-210 (R-)";
            this.s18.Name = "s18";
            // 
            // schetchik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "schetchik";
            this.Text = "Показания счетчика";
            this.Load += new System.EventHandler(this.schetchik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchetchikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseDataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource SchetchikBindingSource;
        private dbaseDataSet dbaseDataSet;
        private viewer2.dbaseDataSetTableAdapters.SchetchikTableAdapter schetchikTableAdapter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker end;
        private System.Windows.Forms.DateTimePicker begin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s8DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s9DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s11DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s12DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s13DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s14DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s15DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s16DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn s17;
        private System.Windows.Forms.DataGridViewTextBoxColumn s18;
    }
}