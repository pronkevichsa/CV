namespace viewer2
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.energyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbaseDataSet = new viewer2.dbaseDataSet();
            this.energyTableAdapter = new viewer2.dbaseDataSetTableAdapters.EnergyTableAdapter();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.end = new System.Windows.Forms.DateTimePicker();
            this.begin = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.dateDay = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.e1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.energyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // energyBindingSource
            // 
            this.energyBindingSource.DataMember = "Energy";
            this.energyBindingSource.DataSource = this.dbaseDataSet;
            // 
            // dbaseDataSet
            // 
            this.dbaseDataSet.DataSetName = "dbaseDataSet";
            this.dbaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // energyTableAdapter
            // 
            this.energyTableAdapter.ClearBeforeFill = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(619, 442);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(161, 23);
            this.button8.TabIndex = 25;
            this.button8.Text = "Показания счетчиков";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(619, 399);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(161, 23);
            this.button7.TabIndex = 24;
            this.button7.Text = "Мощность";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Сутки: ";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 71);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "Энергия за сутки";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(619, 499);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "Энергия за год";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(619, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Энергия за текущий месяц";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(619, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Отчет";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 118);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(161, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Энергия за период";
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
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataInDataGridViewTextBoxColumn,
            this.e1DataGridViewTextBoxColumn,
            this.E2,
            this.E3});
            this.dataGridView1.DataSource = this.energyBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(595, 549);
            this.dataGridView1.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateDay
            // 
            this.dateDay.Location = new System.Drawing.Point(10, 38);
            this.dateDay.Name = "dateDay";
            this.dateDay.Size = new System.Drawing.Size(160, 20);
            this.dateDay.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateDay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Location = new System.Drawing.Point(609, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 107);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.end);
            this.groupBox2.Controls.Add(this.begin);
            this.groupBox2.Location = new System.Drawing.Point(609, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 159);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // dataInDataGridViewTextBoxColumn
            // 
            this.dataInDataGridViewTextBoxColumn.DataPropertyName = "DataIn";
            this.dataInDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dataInDataGridViewTextBoxColumn.Name = "dataInDataGridViewTextBoxColumn";
            // 
            // e1DataGridViewTextBoxColumn
            // 
            this.e1DataGridViewTextBoxColumn.DataPropertyName = "E1";
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = null;
            this.e1DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.e1DataGridViewTextBoxColumn.FillWeight = 150F;
            this.e1DataGridViewTextBoxColumn.HeaderText = "Активная потребленная (A+)";
            this.e1DataGridViewTextBoxColumn.Name = "e1DataGridViewTextBoxColumn";
            this.e1DataGridViewTextBoxColumn.Width = 150;
            // 
            // E2
            // 
            this.E2.DataPropertyName = "E2";
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.E2.DefaultCellStyle = dataGridViewCellStyle2;
            this.E2.FillWeight = 150F;
            this.E2.HeaderText = "Реактивная потребленная (R+)";
            this.E2.Name = "E2";
            this.E2.Width = 150;
            // 
            // E3
            // 
            this.E3.DataPropertyName = "E3";
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.E3.DefaultCellStyle = dataGridViewCellStyle3;
            this.E3.FillWeight = 150F;
            this.E3.HeaderText = "Реактивная отданная (R-)";
            this.E3.Name = "E3";
            this.E3.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Энергия";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.energyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private dbaseDataSet dbaseDataSet;
        private System.Windows.Forms.BindingSource energyBindingSource;
        private viewer2.dbaseDataSetTableAdapters.EnergyTableAdapter energyTableAdapter;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker end;
        private System.Windows.Forms.DateTimePicker begin;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateDay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn e1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn E2;
        private System.Windows.Forms.DataGridViewTextBoxColumn E3;
    }
}

