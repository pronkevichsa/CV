using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using dbaseADO;
using System.Data.OleDb;
using Microsoft.Reporting.WinForms;

namespace viewer2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string beginstr, endstr;

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbaseDataSet.Energy' table. You can move, or remove it, as needed.
         //
            //если закомментировать - при запуске не отображается база в Grid
            DateTime t = DateTime.Now;
          //  beginstr = begin.Value.Month.ToString() + "/" + begin.Value.Day.ToString() + "/" + begin.Value.Year.ToString();
          //  endstr = end.Value.Month.ToString() + "/" + end.Value.Day.ToString() + "/" + end.Value.Year.ToString();
            //MessageBox.Show(beg);
            beginstr = t.Month.ToString() + "/1/" + t.Year.ToString();
            //ne uchityvaetsa kolichestvo dney v mesace
            endstr = t.Month.ToString() + "/"+t.Day.ToString()+"/" + t.Year.ToString();
            ADOWork dbase1 = new ADOWork();
            dbase1.OpenBase();
            dbase1.LoadBase(beginstr, endstr);
            energyBindingSource.DataSource = dbase1.ds;
#region InsertGrid
            DataSet InsertSet = new DataSet("assa");
            DataTable dbIstochnic = dbase1.ds.Tables["Energy"];
            ArrayList sumarray = new ArrayList();
            double[,] ActPlus = new double[dbIstochnic.Rows.Count,3];
            int maxrow = dbIstochnic.Rows.Count;
            int kk = dbIstochnic.Columns.Count;

            for (int rows = 0; rows < dbIstochnic.Rows.Count; rows++)
            {
                sumarray.Add(dbIstochnic.Rows[rows][0]);
                ActPlus[rows,0] = Convert.ToDouble(dbIstochnic.Rows[rows][1])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][2])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][3])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][4])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][5])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][6]);
                ActPlus[rows,1] = Convert.ToDouble(dbIstochnic.Rows[rows][7])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][8])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][9])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][10])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][11])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][12]);
                ActPlus[rows,2] = Convert.ToDouble(dbIstochnic.Rows[rows][13])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][14])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][15])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][16])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][17])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][18]);
            }

            DataTable InsertTable = new DataTable("SumEnergy");
            DataColumn col1 = new DataColumn("DataIn", System.Type.GetType("System.DateTime"));
            DataColumn col2 = new DataColumn("E1", System.Type.GetType("System.Double"));
            DataColumn col3 = new DataColumn("E2", System.Type.GetType("System.Double"));
            DataColumn col4 = new DataColumn("E3", System.Type.GetType("System.Double"));
            InsertTable.Columns.Add(col1);
            InsertTable.Columns.Add(col2);
            InsertTable.Columns.Add(col3);
            InsertTable.Columns.Add(col4);
            DataRow row = InsertTable.NewRow();
            for (int i = 0; i < maxrow; i++)
            {
                row[0] = sumarray[i];
                row[1] = ActPlus[i,0];
                row[2] = ActPlus[i,1];
                row[3] = ActPlus[i,2];
                InsertTable.Rows.Add(row);
                row = InsertTable.NewRow();
            }
            dataGridView1.DataSource = InsertTable;               
#endregion
            dbase1.CloseBase();
        //    this.energyTableAdapter.Fill(this.dbaseDataSet.Energy);           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //энергия за месяц
            DateTime t = DateTime.Now;         
            beginstr = t.Month.ToString() + "/1/" + t.Year.ToString();
            endstr = t.Month.ToString() + "/"+t.Day.ToString()+"/" + t.Year.ToString();
            ADOWork dbase1 = new ADOWork();
            dbase1.OpenBase();
            dbase1.LoadBase(beginstr, endstr,"energy");          
           
#region InsertGrid
            DataSet InsertSet = new DataSet("assa");
            DataTable dbIstochnic = dbase1.ds.Tables["Energy"];
            ArrayList sumarray = new ArrayList();
            double[,] ActPlus = new double[dbIstochnic.Rows.Count,3];
            int maxrow = dbIstochnic.Rows.Count;
            int kk = dbIstochnic.Columns.Count;

            for (int rows = 0; rows < dbIstochnic.Rows.Count; rows++)
            {
                sumarray.Add(dbIstochnic.Rows[rows][0]);
                //здесь добавить каналы учета
                ActPlus[rows, 0] = Convert.ToDouble(dbIstochnic.Rows[rows][1]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][2]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][3]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][4]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][5]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][6]);
                ActPlus[rows, 1] = Convert.ToDouble(dbIstochnic.Rows[rows][7]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][8]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][9]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][10]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][11]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][12]);
                ActPlus[rows, 2] = Convert.ToDouble(dbIstochnic.Rows[rows][13]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][14]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][15]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][16]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][17]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][18]);
            }

            DataTable InsertTable = new DataTable("SumEnergy");
            DataColumn col1 = new DataColumn("DataIn", System.Type.GetType("System.DateTime"));
            DataColumn col2 = new DataColumn("E1", System.Type.GetType("System.Double"));
            DataColumn col3 = new DataColumn("E2", System.Type.GetType("System.Double"));
            DataColumn col4 = new DataColumn("E3", System.Type.GetType("System.Double"));
            InsertTable.Columns.Add(col1);
            InsertTable.Columns.Add(col2);
            InsertTable.Columns.Add(col3);
            InsertTable.Columns.Add(col4);
            DataRow row = InsertTable.NewRow();
            for (int i = 0; i < maxrow; i++)
            {
                row[0] = sumarray[i];
                row[1] = ActPlus[i, 0];
                row[2] = ActPlus[i, 1];
                row[3] = ActPlus[i, 2];
                InsertTable.Rows.Add(row);
                row = InsertTable.NewRow();
            }
            dataGridView1.DataSource = InsertTable;               
#endregion

            dbase1.CloseBase();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //энергия за год
            DateTime t = DateTime.Now;
            beginstr = begin.Value.Month.ToString() + "/" + begin.Value.Day.ToString() + "/" + begin.Value.Year.ToString();
            endstr = end.Value.Month.ToString() + "/" + end.Value.Day.ToString() + "/" + end.Value.Year.ToString();
            //MessageBox.Show(beg);
            beginstr = "01/01/" + t.Year.ToString();
            //ne uchityvaetsa kolichestvo dney v mesace
            endstr = "12/31/" + t.Year.ToString();
            ADOWork dbase1 = new ADOWork();
            dbase1.OpenBase();
            dbase1.LoadBase(beginstr, endstr,"energy");
            //energyBindingSource.DataSource = dbase1.ds;
            //dataGridView1.DataSource = energyBindingSource;
            DataSet InsertSet = new DataSet("assa");
#region InsertGrid
            DataTable dbIstochnic = dbase1.ds.Tables["Energy"];
            ArrayList sumarray = new ArrayList();
            double[,] ActPlus = new double[dbIstochnic.Rows.Count,3];
            int maxrow = dbIstochnic.Rows.Count;
            int kk = dbIstochnic.Columns.Count;

            for (int rows = 0; rows < dbIstochnic.Rows.Count; rows++)
            {
                sumarray.Add(dbIstochnic.Rows[rows][0]);

                ActPlus[rows, 0] = Convert.ToDouble(dbIstochnic.Rows[rows][1]) +
                     Convert.ToDouble(dbIstochnic.Rows[rows][2]) +
                     Convert.ToDouble(dbIstochnic.Rows[rows][3]) +
                     Convert.ToDouble(dbIstochnic.Rows[rows][4]) +
                     Convert.ToDouble(dbIstochnic.Rows[rows][5]) +
                     Convert.ToDouble(dbIstochnic.Rows[rows][6]);
                ActPlus[rows, 1] = Convert.ToDouble(dbIstochnic.Rows[rows][7]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][8]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][9]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][10]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][11]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][12]);
                ActPlus[rows, 2] = Convert.ToDouble(dbIstochnic.Rows[rows][13]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][14]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][15]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][16]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][17]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][18]);
            }

            DataTable InsertTable = new DataTable("SumEnergy");
            DataColumn col1 = new DataColumn("DataIn", System.Type.GetType("System.DateTime"));
            DataColumn col2 = new DataColumn("E1", System.Type.GetType("System.Double"));
            DataColumn col3 = new DataColumn("E2", System.Type.GetType("System.Double"));
            DataColumn col4 = new DataColumn("E3", System.Type.GetType("System.Double"));
            InsertTable.Columns.Add(col1);
            InsertTable.Columns.Add(col2);
            InsertTable.Columns.Add(col3);
            InsertTable.Columns.Add(col4);
            DataRow row = InsertTable.NewRow();
            for (int i = 0; i < maxrow; i++)
            {
                row[0] = sumarray[i];
                row[1] = ActPlus[i, 0];
                row[2] = ActPlus[i, 1];
                row[3] = ActPlus[i, 2];
                InsertTable.Rows.Add(row);
                row = InsertTable.NewRow();
            }
          //  dataGridView1.DataSource = InsertTable;
            InsertSet.Tables.Add(InsertTable);
#endregion

            energyBindingSource.DataSource = InsertSet;
            dbase1.CloseBase();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //энергия за период
            beginstr = begin.Value.Month.ToString() + "/" + begin.Value.Day.ToString() + "/" + begin.Value.Year.ToString();
            endstr = end.Value.Month.ToString() + "/" + end.Value.Day.ToString() + "/" + end.Value.Year.ToString();
            //MessageBox.Show(beg);
            ADOWork dbase1 = new ADOWork();
            dbase1.OpenBase();
            dbase1.LoadBase(beginstr, endstr,"energy");
            energyBindingSource.DataSource = dbase1.ds;
            //dataGridView1.DataSource = energyBindingSource;

#region InsertGrid
            DataTable dbIstochnic = dbase1.ds.Tables["Energy"];
            ArrayList sumarray = new ArrayList();
            double[,] ActPlus = new double[dbIstochnic.Rows.Count,3];
            int maxrow = dbIstochnic.Rows.Count;
            int kk = dbIstochnic.Columns.Count;

            for (int rows = 0; rows < dbIstochnic.Rows.Count; rows++)
            {
                sumarray.Add(dbIstochnic.Rows[rows][0]);
                ActPlus[rows, 0] = Convert.ToDouble(dbIstochnic.Rows[rows][1]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][2]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][3]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][4]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][5]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][6]);
                ActPlus[rows, 1] = Convert.ToDouble(dbIstochnic.Rows[rows][7]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][8]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][9]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][10]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][11]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][12]);
                ActPlus[rows, 2] = Convert.ToDouble(dbIstochnic.Rows[rows][13]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][14]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][15]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][16])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][17])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][18]);
            }

            DataTable InsertTable = new DataTable("SumEnergy");
            DataColumn col1 = new DataColumn("DataIn", System.Type.GetType("System.DateTime"));
            DataColumn col2 = new DataColumn("E1", System.Type.GetType("System.Double"));
            DataColumn col3 = new DataColumn("E2", System.Type.GetType("System.Double"));
            DataColumn col4 = new DataColumn("E3", System.Type.GetType("System.Double"));
            InsertTable.Columns.Add(col1);
            InsertTable.Columns.Add(col2);
            InsertTable.Columns.Add(col3);
            InsertTable.Columns.Add(col4);
            DataRow row = InsertTable.NewRow();
            for (int i = 0; i < maxrow; i++)
            {
                row[0] = sumarray[i];
                row[1] = ActPlus[i, 0];
                row[2] = ActPlus[i, 1];
                row[3] = ActPlus[i, 2];
                InsertTable.Rows.Add(row);
                row = InsertTable.NewRow();
            }
            dataGridView1.DataSource = InsertTable;
#endregion

            dbase1.CloseBase();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //энергия за сутки
           
            //DateTime t = DateTime.Now;
            //beginstr = begin.Value.Month.ToString() + "/" + begin.Value.Day.ToString() + "/" + begin.Value.Year.ToString();
            //endstr = end.Value.Month.ToString() + "/" + end.Value.Day.ToString() + "/" + end.Value.Year.ToString();
            ////MessageBox.Show(beg);
            //beginstr = t.Month.ToString() + "/1/" + t.Year.ToString();
            ////ne uchityvaetsa kolichestvo dney v mesace
            //endstr = t.Month.ToString() + "/"+t.Day.ToString()+"/" + t.Year.ToString();

            beginstr = dateDay.Value.Month.ToString() + "/" + dateDay.Value.Day.ToString() + "/" + dateDay.Value.Year.ToString();
            endstr = beginstr;
                       
            ADOWork dbase1 = new ADOWork();
            dbase1.OpenBase();
            dbase1.LoadBase(beginstr,endstr,"energy","2");
#region InsertGrid
            DataSet InsertSet = new DataSet("assa");
            DataTable dbIstochnic = dbase1.ds.Tables["Energy"];
            ArrayList sumarray = new ArrayList();
            double[,] ActPlus = new double[dbIstochnic.Rows.Count,3];
            int maxrow = dbIstochnic.Rows.Count;
            int kk = dbIstochnic.Columns.Count;

            for (int rows = 0; rows < dbIstochnic.Rows.Count; rows++)
            {
                sumarray.Add(dbIstochnic.Rows[rows][0]);
                ActPlus[rows, 0] = Convert.ToDouble(dbIstochnic.Rows[rows][1]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][2]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][3]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][4]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][5]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][6]);
                ActPlus[rows, 1] = Convert.ToDouble(dbIstochnic.Rows[rows][7]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][8]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][9]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][10]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][11]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][12]);
                ActPlus[rows, 2] = Convert.ToDouble(dbIstochnic.Rows[rows][13]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][14]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][15]) +
                    Convert.ToDouble(dbIstochnic.Rows[rows][16])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][17])+
                    Convert.ToDouble(dbIstochnic.Rows[rows][18]);
            }

            DataTable InsertTable = new DataTable("SumEnergy");
            DataColumn col1 = new DataColumn("DataIn", System.Type.GetType("System.DateTime"));
            DataColumn col2 = new DataColumn("E1", System.Type.GetType("System.Double"));
            DataColumn col3 = new DataColumn("E2", System.Type.GetType("System.Double"));
            DataColumn col4 = new DataColumn("E3", System.Type.GetType("System.Double"));
            InsertTable.Columns.Add(col1);
            InsertTable.Columns.Add(col2);
            InsertTable.Columns.Add(col3);
            InsertTable.Columns.Add(col4);
            DataRow row = InsertTable.NewRow();
            for (int i = 0; i < maxrow; i++)
            {
                row[0] = sumarray[i];
                row[1] = ActPlus[i, 0];
                row[2] = ActPlus[i, 1];
                row[3] = ActPlus[i, 2];

                InsertTable.Rows.Add(row);
                row = InsertTable.NewRow();
            }
            dataGridView1.DataSource = InsertTable;
#endregion
            dbase1.CloseBase();
          //вызов окна энергия за сутки
            EnergySutki myEnergySutky = new EnergySutki(beginstr);
            myEnergySutky.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //отчет
            EnergyReport myEnergyReport = new EnergyReport(beginstr, endstr);
            myEnergyReport.ShowDialog();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            //счетчик
            schetchik myschetchik= new schetchik();
            myschetchik.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //выход
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Мощность
            Power30 myPower30 = new Power30();
            myPower30.ShowDialog();
        }
    }
}