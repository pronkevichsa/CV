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
    public partial class EnergyReport : Form
    {
        public EnergyReport(string begin, string end)
        {
            begindate = begin;
            enddate = end;
            InitializeComponent();
        }

        private string begindate, enddate;

        private void EnergyReport_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'dbaseDataSet.Energy' table. You can move, or remove it, as needed.
          
            this.EnergyTableAdapter.Fill(this.dbaseDataSet.Energy);
            ADOWork gridrep = new ADOWork();
            gridrep.OpenBase();
            gridrep.LoadBase(begindate, enddate);
            EnergyBindingSource.DataSource = gridrep.ds;
            this.reportViewer1.RefreshReport();
            gridrep.CloseBase();

            this.reportViewer1.RefreshReport();
        }
    }
}