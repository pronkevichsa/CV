using System;
using System.Data;
using System.Data.OleDb;


namespace dbaseADO
{
	/// <summary>
	/// Summary description for ADOWork.
	/// </summary>
	public class ADOWork
	{
		public ADOWork()
		{}
		private static string SampleDbPath =@"dbase.mdb"; //устанавливаем путь к соединению
        public int KoefPreobr=500;
        private static OleDbConnection myConnection;
        //protected static OleDbCommand oleDbCommand;
        private OleDbDataAdapter da;
		public DataSet ds;
        const string InsertEnergyQuery = "INSERT INTO Energy (DataIn, E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,E12,E13,E14,E15,E16) VALUES (@DataIn, @E1, @E2, @E3, @E4, @E5, @E6, @E7, @E8, @E9, @E10, @E11, @E12, @E13, @E14, @E15, @E16)";
        const string InsertEnergy30Query = "INSERT INTO Energy30 (DataIn, TimeIn, I1,I2,I3,I4,I5,I6,I7,I8,I9,I10,I11,I12,I13,I14,I15,I16,I17,I18,I19,I20,I21,I22,I23,I24,I25,I26,I27,I28,I29,I30,I31,I32) VALUES (DataIn, TimeIn, @I1,@I2,@I3,@I4,@I5,@I6,@I7,@I8,@I9,@I10,@I11,@I12,@I13,@I14,@I15,@I16,@I17,@I18,@I19,@I20,@I21,@I22,@I23,@I24,@I25,@I26,@I27,@I28,@I29,@I30,@I31,@I32)";
        const string InsertPower30Query = "INSERT INTO Power30 (DataIn, TimeIn, P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,P11,P12,P13,P14,P15,P16) VALUES (@DataIn, @TimeIn, @P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16)";
        const string InsertPower3Query = "INSERT INTO Power3 (DataIn, TimeIn, Power3) VALUES (@DataIn, @TimeIn, @Power3)";
        const string InsertSchetchik = "INSERT INTO Schetchik (DataIn, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16) VALUES (@DataIn, @s1, @s2, @s3, @s4, @s5, @s6, @s7, @s8, @s9, @s10, @s11, @s12, @s13, @s14, @s15, @s16)";
      		
		public void OpenBase()
		{   //открываем базу данных
			myConnection = new OleDbConnection();
			myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SampleDbPath;
			myConnection.Open();
		}
        public void CloseBase()
		{
            myConnection.Close();
		}

        public int InsertEnergy(DateTime DateIn, ref double[] Energy )
        {
            string column = "";
            string sel = "SELECT TOP 1 Energy.DataIn FROM Energy ORDER BY Energy.DataIn DESC";
            DataSet DsEnergy = new DataSet();
            da = new OleDbDataAdapter(sel, myConnection);
            da.Fill(DsEnergy, "Energy");
            DataTable DtEnergy = DsEnergy.Tables["Energy"];
            DateTime DateEnergy = Convert.ToDateTime(DtEnergy.Rows[0][0]);
            string DateString = "#" + DateEnergy.Month.ToString() + "/" + DateEnergy.Day.ToString() + "/" + DateEnergy.Year.ToString() + "#";
            string KillEnergy = "DELETE FROM Energy WHERE DataIn=" + DateString;
            OleDbCommand killcmd = new OleDbCommand(KillEnergy, myConnection);
            killcmd.ExecuteNonQuery();
            OleDbCommand cmd = new OleDbCommand(InsertEnergyQuery, myConnection);
            cmd.Parameters.AddWithValue("@DataIn", DateIn);
            for (int i = 1; i < 17; i++)
            {
                column = "E";
                column = column + i.ToString();
                cmd.Parameters.AddWithValue(column, Energy[i - 1]);
            }
            int k = cmd.ExecuteNonQuery();
            return k;
        }
        public int InsertEnergy30(DateTime DateIn, DateTime TimeIn, ref double[] Impulsy)
        {
           // int Canals = 32;
            string column = "";
            OleDbCommand cmd = new OleDbCommand(InsertEnergy30Query, myConnection);
            cmd.Parameters.AddWithValue("@DataIn", DateIn);
            cmd.Parameters.AddWithValue("@TimeIn", TimeIn);
            for (int i = 1; i < 17; i++)
            {
                column = "I";
                column = column + i.ToString();
                cmd.Parameters.AddWithValue(column, Impulsy[i - 1]);
            }
            for (int i = 17; i < 32 + 1; i++)
            {
                column = "I";
                column = column + i.ToString();
                cmd.Parameters.AddWithValue(column, 0);
            }
            int k = cmd.ExecuteNonQuery();
            return k;

        }
        public int InsertPower30(DateTime DateIn, DateTime TimeIn,ref double[] Power30)
        {
            int Groups = 6; string column = "";
            OleDbCommand cmd = new OleDbCommand(InsertPower30Query, myConnection);
            cmd.Parameters.AddWithValue("@DataIn", DateIn);
            cmd.Parameters.AddWithValue("@TimeIn", TimeIn);
            for (int i = 1; i < Groups + 1; i++)
            {
                column = "P";
                column = column + i.ToString();
                cmd.Parameters.AddWithValue(column, Power30[i - 1]);
            }
            for (int i = 6; i < 16 + 1; i++)
            {
                column = "P";
                column = column + i.ToString();
                cmd.Parameters.AddWithValue(column, 0);
            }
            int k = cmd.ExecuteNonQuery();
            return k;

        }
        public int InsertPower3(DateTime DateIn, DateTime TimeIn, double Power30)
        {
            OleDbCommand cmd = new OleDbCommand(InsertPower3Query, myConnection);
            cmd.Parameters.AddWithValue("@DataIn", DateIn);
            cmd.Parameters.AddWithValue("@TimeIn", TimeIn);
            cmd.Parameters.AddWithValue("@Power3", Power30);
            int k = cmd.ExecuteNonQuery();
            return k;
        }
        public int InsertSchetshic(ref double[] export)
        {
            int Canals = 16; string column = "";
            DateTime Today = DateTime.Today;
            string DateString = "#" + Today.Month.ToString() + "/" + Today.Day.ToString() + "/" + Today.Year.ToString() + "#";
            string KillSchetchik = "DELETE FROM Schetchik WHERE DataIn=" + DateString;
            OleDbCommand killcmd = new OleDbCommand(KillSchetchik, myConnection);
            killcmd.ExecuteNonQuery();
            OleDbCommand cmd = new OleDbCommand(InsertSchetchik, myConnection);
            cmd.Parameters.AddWithValue("@DataIn", Today);
            for (int i = 1; i < Canals + 1; i++)
            {
                column = "s";
                column = column + i.ToString();
                cmd.Parameters.AddWithValue(column, export[i - 1]);
            }
            int k = cmd.ExecuteNonQuery();
            return k;
        } 
		public void LoadBase(string begin,string end)
		{
            string sel = "select * from energy where energy.DataIn between #"+begin+"# and #"+end+"# order by 1";
			da = new OleDbDataAdapter(sel,myConnection);
			ds = new DataSet();
			da.Fill(ds,"Energy");
		}
        public void LoadBase(string begin, string end, string Base)
        {
            string sel;
            sel= "select * from " + Base + " where " + Base + ".DataIn between #" + begin + "# and #" + end + "# order by 1";
           // if (Base=="power30") sel="select max(P1) from power30 where 
            da = new OleDbDataAdapter(sel, myConnection);
            ds = new DataSet();
            da.Fill(ds, Base);
        }
        public void LoadBase(string begin, string end, string Base, string order)
        {
            string sel = "select * from " + Base + " where " + Base + ".DataIn between #" + begin + "# and #" + end + "# order by 1, "+order;
            da = new OleDbDataAdapter(sel, myConnection);
            ds = new DataSet();
            da.Fill(ds, Base);
        }
        public void LoadBase(string begin, string end, string Base,string order, int flag)
        {
            string sel = "select * from " + Base + " where " + Base + ".DataIn between #" + begin + "# and #" + end + "# order by 1, " + order;
        //    if (flag == 1) sel = "SELECT Power30.DataIn, Max(Power30.p1) FROM Power30 where Power30.DataIn between #" + begin + "# and #" + end + "#  GROUP BY Power30.DataIn ORDER BY 1";            
            da = new OleDbDataAdapter(sel, myConnection);
            ds = new DataSet();
            da.Fill(ds, Base);
        }
        public int ProverkaPower30()
        {//ищет последнюю (неполную дату) и удаляет все записи на эту дату
            string sel = "SELECT TOP 1 Power30.DataIn, Power30.TimeIn FROM Power30 GROUP BY Power30.DataIn, Power30.TimeIn ORDER BY Power30.DataIn DESC , Power30.TimeIn DESC;";
            DataSet DsPower30 = new DataSet();
            da = new OleDbDataAdapter(sel, myConnection);
            da.Fill(DsPower30, "Power30");
            DataTable DtPower30 = DsPower30.Tables["Power30"];
            DateTime DatePower = Convert.ToDateTime(DtPower30.Rows[0][0]);
            string DateString = "#" + DatePower.Month.ToString() + "/" + DatePower.Day.ToString() + "/" + DatePower.Year.ToString() + "#";
            string KillPower30= "DELETE FROM Power30 WHERE DataIn=" + DateString;
            OleDbCommand killcmd = new OleDbCommand(KillPower30, myConnection);
            killcmd.ExecuteNonQuery();
            TimeSpan DeltaDays = DateTime.Today.Date - DatePower.Date;
            int delta=(int)DeltaDays.TotalDays;
            return delta;
        }
        public int InsertFullDayEnergy30(DateTime DateIn, ref int[,] export,int KoefPreobr)
        {
            //////////////удаление неполных записей/////////////////////////////////
            //string sel = "SELECT TOP 1 Energy30.DataIn, Energy30.TimeIn FROM Energy30 GROUP BY Energy30.DataIn, Energy30.TimeIn ORDER BY Energy30.DataIn DESC , Energy30.TimeIn DESC;";
            //DataSet DsEnergy30 = new DataSet();
            //da = new OleDbDataAdapter(sel, myConnection);
            //da.Fill(DsEnergy30, "Energy30");
            //DataTable DtEnergy30 = DsEnergy30.Tables["Energy30"];
            //DateTime DateEnergy = Convert.ToDateTime(DtEnergy30.Rows[0][0]);
            //string DateString = "#" + DateEnergy.Month.ToString() + "/" + DateEnergy.Day.ToString() + "/" + DateEnergy.Year.ToString() + "#";
            //string KillEnergy30 = "DELETE FROM Energy30 WHERE DataIn=" + DateString;
            //OleDbCommand killcmd = new OleDbCommand(KillEnergy30, myConnection);
            //killcmd.ExecuteNonQuery();
            //////////////////////////////////////////////////////////////
            int k;
            TimeSpan HalfHour = new TimeSpan(0, 30, 0);
            DateTime Clock = new DateTime(DateIn.Year, DateIn.Month, DateIn.Day, 0, 0, 0);
            double[] half = new double[16];
            DeleteRecords(DateIn, "Energy30");
            for (int i = 0; i < 48; i++)
            {
                for (int j = 0; j < 16; j++)
                    half[j] = ((double)export[i, j])/((double)KoefPreobr);
                k=InsertEnergy30(DateIn, Clock, ref half);
                Clock = Clock + HalfHour;
            }
            return 0;
        }
        public int InsertFullDayPower30(DateTime DateIn, ref double[,] export)
        {
            int k;
            TimeSpan HalfHour = new TimeSpan(0, 30, 0);
            DateTime Clock = new DateTime(DateIn.Year, DateIn.Month, DateIn.Day, 0, 0, 0);
            double[] half = new double[6];
            DeleteRecords(DateIn, "Power30");
            for (int i = 0; i < 48; i++)
            {
                for (int j = 0; j < 6; j++)
                    half[j] = export[i, j];
                k = InsertPower30(DateIn, Clock, ref half);
                Clock = Clock + HalfHour;
            }
            return 0;
        }
        public void DeleteRecords(DateTime DataIn, string Base)
        {
            string DateString = "#" + DataIn.Month.ToString() + "/" + DataIn.Day.ToString() + "/" + DataIn.Year.ToString() + "#";
            string str = "select * from " + Base + " where "+ Base+".DataIn = "+DateString;
           
          //  sel = "select * from " + Base + " where " + Base + ".DataIn between #" + begin + "# and #" + end + "# order by 1";
            // if (Base=="power30") sel="select max(P1) from power30 where 
            da = new OleDbDataAdapter(str, myConnection);
            ds = new DataSet();
            da.Fill(ds, Base);
            DataTable dbIstochnic = ds.Tables[Base];
            int count;
            count = dbIstochnic.Rows.Count;
            //DateTime DtBase = Convert.ToDateTime(dbIstochnic.Rows[0][0]);
            if (count>0)
            {
              //  string DateString = "#" + DataIn.Month.ToString() + "/" + DataIn.Day.ToString() + "/" + DataIn.Year.ToString() + "#";
                string deldays = "delete from " + Base + " where "+Base+".DataIn = " + DateString;
                OleDbCommand killcmd = new OleDbCommand(deldays, myConnection);
               killcmd.ExecuteNonQuery();
            }
            //return 0;
        }
        public int ProverkaBase()
        {
            int days;
            
            string sel = "select top 1 power30.DataIn from power30 group by power30.DataIn order by power30.DataIn desc";
            DataSet DsPower30 = new DataSet();
            da = new OleDbDataAdapter(sel, myConnection);
            da.Fill(DsPower30, "Power30");
            DataTable DtPower30 = DsPower30.Tables["Power30"];
            DateTime DatePower = Convert.ToDateTime(DtPower30.Rows[0][0]);
            DateTime Today = DateTime.Today;
            TimeSpan DeltaTime = Today - DatePower;
            int DaysPowers = DeltaTime.Days;
            
            sel = "select top 1 energy30.DataIn from energy30 group by energy30.DataIn order by energy30.DataIn desc";
            DataSet Dsenergy30 = new DataSet();
            da = new OleDbDataAdapter(sel, myConnection);
            da.Fill(Dsenergy30, "energy30");
            DataTable Dtenergy30 = Dsenergy30.Tables["energy30"];
            DateTime DateEnergy = Convert.ToDateTime(Dtenergy30.Rows[0][0]);
            
            DeltaTime = Today - DatePower;
            int DaysEnergy = DeltaTime.Days;
            
            DeleteRecords(DatePower, "power30");
            DeleteRecords(DateEnergy, "energy30");

            if (DaysEnergy > DaysPowers) days=DaysEnergy;
            else days=DaysPowers;
            if (days > 30) days = 30;

            return days;

        }
        public DataTable EnergyMaxDay(string DateIn)
        {
            this.LoadBase(DateIn, DateIn, "power30", "2", 1);
            //DataSet InsertSet = new DataSet("assa");
            DataTable dbIstochnic = this.ds.Tables["Power30"];
            //ArrayList sumarray = new ArrayList();
            double[] ActPlus = new double[1];
            int maxrow = dbIstochnic.Rows.Count;
         
            int maxcolumns = dbIstochnic.Columns.Count;
            double MaxPower30 = 0;
            DateTime MaxTime = new DateTime();
            DateTime MaxDate = new DateTime();

            for (int rows = 0; rows < dbIstochnic.Rows.Count; rows++)
            {
                if (MaxPower30 < Convert.ToDouble(dbIstochnic.Rows[rows][2]))
                {
                    MaxDate = Convert.ToDateTime(dbIstochnic.Rows[rows][0]);
                    MaxPower30 = Convert.ToDouble(dbIstochnic.Rows[rows][2]);
                    MaxTime = Convert.ToDateTime(dbIstochnic.Rows[rows][1]);
                }
            }

            DataTable InsertTable = new DataTable("MaxPower");
            DataColumn col1 = new DataColumn("DataIn", System.Type.GetType("System.DateTime"));
            DataColumn col2 = new DataColumn("TimeIn", System.Type.GetType("System.DateTime"));
            DataColumn col3 = new DataColumn("P1", System.Type.GetType("System.Double"));
            InsertTable.Columns.Add(col1);
            InsertTable.Columns.Add(col2);
            InsertTable.Columns.Add(col3);
            DataRow row = InsertTable.NewRow();
            for (int i = 0; i < 1; i++)
            {
                row[0] = MaxDate;
                row[1] = MaxTime;
                row[2] = MaxPower30;
                InsertTable.Rows.Add(row);
                row = InsertTable.NewRow();
            }
            return InsertTable;

        }
        public DataTable EnergyMaxDay(DateTime begin,DateTime end)
        {
            TimeSpan DeltaDay = new TimeSpan(1, 0, 0, 0);
            DateTime DataIn=begin;
            string beginstr;
            //DataSet InsertSet = new DataSet("assa");
            DataTable InsertTable = new DataTable("MaxPower");
            DataColumn col1 = new DataColumn("DataIn", System.Type.GetType("System.DateTime"));
            DataColumn col2 = new DataColumn("TimeIn", System.Type.GetType("System.DateTime"));
            DataColumn col3 = new DataColumn("P1", System.Type.GetType("System.Double"));
            
            InsertTable.Columns.Add(col1);
            InsertTable.Columns.Add(col2);
            InsertTable.Columns.Add(col3);
            
            do
            {
                beginstr = DataIn.Month.ToString() + "/" + DataIn.Day.ToString() + "/" + DataIn.Year.ToString();
                this.LoadBase(beginstr, beginstr, "power30", "2", 1);
                //DataSet InsertSet = new DataSet("assa");
                DataTable dbIstochnic = this.ds.Tables["Power30"];
                //ArrayList sumarray = new ArrayList();
                double[] ActPlus = new double[1];
                int maxrow = dbIstochnic.Rows.Count;
            //    if (maxrow == 0) continue;
                int maxcolumns = dbIstochnic.Columns.Count;
                double MaxPower30 = 0;
                DateTime MaxTime = new DateTime();
                DateTime MaxDate = new DateTime();
                for (int rows = 0; rows < dbIstochnic.Rows.Count; rows++)
                {
                    if (MaxPower30 < Convert.ToDouble(dbIstochnic.Rows[rows][2]))
                    {
                        MaxDate = Convert.ToDateTime(dbIstochnic.Rows[rows][0]);
                        MaxPower30 = Convert.ToDouble(dbIstochnic.Rows[rows][2]);
                        MaxTime = Convert.ToDateTime(dbIstochnic.Rows[rows][1]);
                    }
                }
                DataRow row = InsertTable.NewRow();
               // for (int i = 0; i < 1; i++)
              //  {
                    row[0] = MaxDate;
                    row[1] = MaxTime;
                    row[2] = MaxPower30;
                    InsertTable.Rows.Add(row);
                    row = InsertTable.NewRow();
              //  }
                DataIn = DataIn + DeltaDay;
            }
            while (DataIn.Date != end.Date);
            return InsertTable;

        }
        public DataSet EnergyMaxDaySet(DateTime begin, DateTime end)
        {
            TimeSpan DeltaDay = new TimeSpan(1, 0, 0, 0);
            DateTime DateIn = begin;
            string beginstr;
            DataSet InsertSet = new DataSet("dbaseDataSet");
            DataTable InsertTable = new DataTable("Power30");
            DataColumn col1 = new DataColumn("DataIn", System.Type.GetType("System.DateTime"));
            DataColumn col2 = new DataColumn("TimeIn", System.Type.GetType("System.DateTime"));
            DataColumn col3 = new DataColumn("P1", System.Type.GetType("System.Double"));
            DataColumn col4 = new DataColumn("P2", System.Type.GetType("System.Double"));
            DataColumn col5 = new DataColumn("P3", System.Type.GetType("System.Double"));
            DataColumn col6 = new DataColumn("P4", System.Type.GetType("System.Double"));
            DataColumn col7 = new DataColumn("P5", System.Type.GetType("System.Double"));
            DataColumn col8 = new DataColumn("P6", System.Type.GetType("System.Double"));
            DataColumn col9 = new DataColumn("P7", System.Type.GetType("System.Double"));
            DataColumn col10 = new DataColumn("P8", System.Type.GetType("System.Double"));
            DataColumn col11 = new DataColumn("P9", System.Type.GetType("System.Double"));
            DataColumn col12 = new DataColumn("P10", System.Type.GetType("System.Double"));
            DataColumn col13 = new DataColumn("P11", System.Type.GetType("System.Double"));
            DataColumn col14 = new DataColumn("P12", System.Type.GetType("System.Double"));
            DataColumn col15 = new DataColumn("P13", System.Type.GetType("System.Double"));
            DataColumn col16 = new DataColumn("P14", System.Type.GetType("System.Double"));
            DataColumn col17 = new DataColumn("P15", System.Type.GetType("System.Double"));
            DataColumn col18 = new DataColumn("P16", System.Type.GetType("System.Double"));
            DataColumn col19 = new DataColumn("P17", System.Type.GetType("System.Double"));
            DataColumn col20 = new DataColumn("P18", System.Type.GetType("System.Double"));
            InsertTable.Columns.Add(col1);            InsertTable.Columns.Add(col2);
            InsertTable.Columns.Add(col3);            InsertTable.Columns.Add(col4);
            InsertTable.Columns.Add(col5);            InsertTable.Columns.Add(col6);
            InsertTable.Columns.Add(col7);            InsertTable.Columns.Add(col8);
            InsertTable.Columns.Add(col9);            InsertTable.Columns.Add(col10);
            InsertTable.Columns.Add(col11);            InsertTable.Columns.Add(col12);
            InsertTable.Columns.Add(col13);            InsertTable.Columns.Add(col14);
            InsertTable.Columns.Add(col15);            InsertTable.Columns.Add(col16);
            InsertTable.Columns.Add(col17);            InsertTable.Columns.Add(col18);
            InsertTable.Columns.Add(col19);            InsertTable.Columns.Add(col20);

            do
            {
                beginstr = DateIn.Month.ToString() + "/" + DateIn.Day.ToString() + "/" + DateIn.Year.ToString();
                this.LoadBase(beginstr, beginstr, "power30", "2", 1);
                
                DataTable dbIstochnic = this.ds.Tables["Power30"];
                //ArrayList sumarray = new ArrayList();
                double[] ActPlus = new double[1];
                int maxrow = dbIstochnic.Rows.Count;
        //        if (maxrow == 0) continue;
                int maxcolumns = dbIstochnic.Columns.Count;
                double MaxPower30 = 0;
                DateTime MaxTime = new DateTime();
                DateTime MaxDate = new DateTime();
                for (int rows = 0; rows < dbIstochnic.Rows.Count; rows++)
                {
                    if (MaxPower30 < Convert.ToDouble(dbIstochnic.Rows[rows][2]))
                    {
                        MaxDate = Convert.ToDateTime(dbIstochnic.Rows[rows][0]);
                        MaxPower30 = Convert.ToDouble(dbIstochnic.Rows[rows][2]);
                        MaxTime = Convert.ToDateTime(dbIstochnic.Rows[rows][1]);
                    }
                }
                DataRow row = InsertTable.NewRow();
                for (int i = 0; i < 1; i++)
                {
                    row[0] = MaxDate;
                    row[1] = MaxTime;
                    row[2] = MaxPower30;
                    InsertTable.Rows.Add(row);
                    row = InsertTable.NewRow();
                }
                DateIn = DateIn + DeltaDay;
            }
            while (DateIn.Date != end.Date);
            InsertSet.Tables.Add(InsertTable);
   //         InsertSet.Tables.Add(InsertTable);
            return InsertSet;

        }
    }
}
