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
    public partial class schetchik : Form
    {
        public schetchik()
        { 
           
            InitializeComponent();
                     
        }
        private string beginstr, endstr;
        private void schetchik_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbaseDataSet.Schetchik' table. You can move, or remove it, as needed.
            this.schetchikTableAdapter.Fill(this.dbaseDataSet.Schetchik);
        //    beginstr = begin.Value.Month.ToString() + "/" + begin.Value.Day.ToString() + "/" + begin.Value.Year.ToString();
        //    endstr = end.Value.Month.ToString() + "/" + end.Value.Day.ToString() + "/" + end.Value.Year.ToString();
            DateTime begin1 = DateTime.Today;
            DateTime end1 = DateTime.Today;


            beginstr = begin1.Month.ToString() + "/" + "1" + "/" + begin1.Year.ToString();
            endstr = end1.Month.ToString() + "/" + end1.Day.ToString() + "/" + end1.Year.ToString();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SchetchikReport mySchetchikReport = new SchetchikReport(beginstr, endstr);
            mySchetchikReport.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //энергия за период
            beginstr = begin.Value.Month.ToString() + "/" + begin.Value.Day.ToString() + "/" + begin.Value.Year.ToString();
            endstr = end.Value.Month.ToString() + "/" + end.Value.Day.ToString() + "/" + end.Value.Year.ToString();
            //MessageBox.Show(beg);
            ADOWork dbase1 = new ADOWork();
            dbase1.OpenBase();
            dbase1.LoadBase(beginstr, endstr, "schetchik");
            SchetchikBindingSource.DataSource = dbase1.ds.Tables["schetchik"];
            dataGridView1.DataSource = SchetchikBindingSource;
           // dataGridView1.Refresh();
            dbase1.CloseBase();
        }
    }
}