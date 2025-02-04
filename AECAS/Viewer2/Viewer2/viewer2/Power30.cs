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
    public partial class Power30 : Form
    {
        public Power30()
        {
            InitializeComponent();
        }
        //private struct PowMax
        //{
        //    DateTime DateT;
        //    DateTime DTime;
        //    double value;
        //};
        private string beginstr, endstr;
        private BindingSource ToReport=new BindingSource();
        private DataTable ExportTable = new DataTable();
        private void Power30_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbaseDataSet.Power30' table. You can move, or remove it, as needed.
            this.power30TableAdapter.Fill(this.dbaseDataSet.Power30);
            DateTime t = DateTime.Now;
            beginstr = t.Month.ToString() + "/1/" + t.Year.ToString();
            endstr = t.Month.ToString() + "/" + t.Day.ToString() + "/" + t.Year.ToString();
            ADOWork dbase2 = new ADOWork();
            dbase2.OpenBase();
            dbase2.LoadBase(beginstr, endstr, "power30","2",1);

            power30BindingSource.DataSource = dbase2.ds.Tables["power30"];
            dataGridView1.DataSource = power30BindingSource;
            dbase2.CloseBase();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //мощность за текущий мес€ц
            DateTime t = DateTime.Now;            
            beginstr = t.Month.ToString() + "/1/" + t.Year.ToString();           
            endstr = t.Month.ToString() + "/" + t.Day.ToString() + "/" + t.Year.ToString();
            ADOWork dbase2 = new ADOWork();
            dbase2.OpenBase();
            dbase2.LoadBase(beginstr, endstr, "power30","2",1);
            
            power30BindingSource.DataSource = dbase2.ds.Tables["power30"];
            
            dataGridView1.DataSource = power30BindingSource;
            dbase2.CloseBase();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //за период
            beginstr = begin.Value.Month.ToString() + "/" + begin.Value.Day.ToString() + "/" + begin.Value.Year.ToString();
            endstr = end.Value.Month.ToString() + "/" + end.Value.Day.ToString() + "/" + end.Value.Year.ToString();
            //MessageBox.Show(beg);
            ADOWork dbase1 = new ADOWork();
            dbase1.OpenBase();
            dbase1.LoadBase(beginstr, endstr,"power30","2",1);
         //   power30BindingSource.DataSource = dbase1.ds.Tables["power30"];

        //    power30BindingSource.DataSource = dbase1.EnergyMaxDaySet(begin.Value, end.Value);
          
            power30BindingSource.DataSource = dbase1.EnergyMaxDay(begin.Value, end.Value);
            ToReport.DataSource = dbase1.EnergyMaxDay(begin.Value, end.Value);
            ExportTable = dbase1.EnergyMaxDay(begin.Value, end.Value);
           
            //dataGridView1.DataSource = power30BindingSource;
            //dataGridView1.DataSource = ToReport;
            dataGridView1.DataSource = ExportTable;
            //dataGridView1.DataSource = dbase1.EnergyMaxDay(begin.Value, end.Value);
            dbase1.CloseBase();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //за сутки
            beginstr = dateDay.Value.Month.ToString() + "/" + dateDay.Value.Day.ToString() + "/" + dateDay.Value.Year.ToString();
            endstr = dateDay.Value.Month.ToString() + "/" + dateDay.Value.Day.ToString() + "/" + dateDay.Value.Year.ToString();
            //MessageBox.Show(beg);
            ADOWork dbase1 = new ADOWork();
            dbase1.OpenBase();
            //dbase1.LoadBase(beginstr, endstr, "power30", "2", 1);
            //power30BindingSource.DataSource = dbase1.ds.Tables["power30"];

           
           dataGridView1.DataSource=dbase1.EnergyMaxDay(beginstr);
            
           
            //       dataGridView1.DataSource = power30BindingSource;
            dbase1.CloseBase();

        }
        private void MaxPower(string beginstrinput, string endstrinput)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Power30Report myPower30Report = new Power30Report(begin.Value, end.Value);
            myPower30Report.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}