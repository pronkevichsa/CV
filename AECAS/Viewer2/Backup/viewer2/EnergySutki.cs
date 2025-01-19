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
    public partial class EnergySutki : Form
    {
        public EnergySutki(string inputDate)
        {
            begindate = inputDate;
            enddate = inputDate;
            InitializeComponent();
        }

        private string begindate,enddate;

        private void EnergySutki_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbaseDataSet.Energy30' table. You can move, or remove it, as needed.
            this.Energy30TableAdapter.Fill(this.dbaseDataSet.Energy30);
            ADOWork gridrep = new ADOWork();
            gridrep.OpenBase();
            gridrep.LoadBase(begindate, enddate, "Energy30","2");
            Energy30BindingSource.DataSource = gridrep.ds;
          //  this.reportViewer1.RefreshReport();
            
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            gridrep.CloseBase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            begindate = dateDay.Value.Month.ToString() + "/" + dateDay.Value.Day.ToString() + "/" + dateDay.Value.Year.ToString();
            enddate = begindate;

            ADOWork gridrep = new ADOWork();
            gridrep.OpenBase();
            gridrep.LoadBase(begindate, enddate, "Energy30","2");
            Energy30BindingSource.DataSource = gridrep.ds;
            //  this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            gridrep.CloseBase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}