using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using dbaseADO;

namespace viewer2
{
    public partial class SchetchikReport : Form
    {
        public SchetchikReport(string beg,string end)
        {
            beginstr = beg;
            endstr = end;
            InitializeComponent();
        }
        
        private string beginstr, endstr;

        private void SchetchikReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbaseDataSet.Schetchik' table. You can move, or remove it, as needed.
            this.SchetchikTableAdapter.Fill(this.dbaseDataSet.Schetchik);
            ADOWork schetchik1 = new ADOWork();
            schetchik1.OpenBase();
            schetchik1.LoadBase(beginstr, endstr, "Schetchik");
            SchetchikBindingSource.DataSource = schetchik1.ds;//.Tables["schetchik"];
         //   dataGridView1.DataSource = SchetchikBindingSource;
            // dataGridView1.Refresh();
            
            this.reportViewer1.RefreshReport();
            schetchik1.CloseBase();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}