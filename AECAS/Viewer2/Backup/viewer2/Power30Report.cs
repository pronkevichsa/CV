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
    public partial class Power30Report : Form
    {
        public Power30Report(DateTime beg, DateTime en)
        {
            begin = beg;
            end = en;
            InitializeComponent();
            
        }
       
        DateTime begin = new DateTime();
        DateTime end = new DateTime();
     
        private void Power30Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbaseDataSet.Power30' table. You can move, or remove it, as needed.
            this.Power30TableAdapter.Fill(this.dbaseDataSet.Power30);
         
           
            string beginstr, endstr;
            beginstr = begin.Month.ToString() + "/" + begin.Day.ToString() + "/" + begin.Year.ToString();
            endstr = end.Month.ToString() + "/" + end.Day.ToString() + "/" + end.Year.ToString();
            ADOWork mypow30 = new ADOWork();
            mypow30.OpenBase();
            mypow30.LoadBase(beginstr, endstr, "Power30","2");
            Power30BindingSource.DataSource = mypow30.ds;
            DataSet InsertSet = new DataSet("dbaseDataSet");
       //     
            InsertSet = mypow30.EnergyMaxDaySet(begin, end);
            //Power30BindingSource.DataSource = mypow30.EnergyMaxDaySet(begin, end);
    //        mypow30.ds = InsertSet;
            Power30BindingSource.DataSource = InsertSet;

       //     Power30BindingSource.DataSource

            //ADOWork p30base = new ADOWork();
            //p30base.OpenBase();
            //p30base.LoadBase(beginstr, endstr, "power30");
          //  Power30BindingSource.DataSource = p30base.ds;
            
            //Power30BindingSource.DataSource = dbase1.ds.Tables["power30"];
            //power30BindingSource.DataSource = dbase1.EnergyMaxDaySet(begin.Value, end.Value);
        //    Power30BindingSource.DataSource = mypow30.EnergyMaxDaySet(begin, end);
            
       //     this.reportViewer1.RefreshReport();
            
            //p30base.CloseBase();

             this.reportViewer1.RefreshReport();
            mypow30.CloseBase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}