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
        const string InsertEnergyQuery = "INSERT INTO Energy (DataIn, E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,E12,E13,E14,E15,E16,E17,E18) VALUES (@DataIn, @E1, @E2, @E3, @E4, @E5, @E6, @E7, @E8, @E9, @E10, @E11, @E12, @E13, @E14, @E15, @E16,@E17,@E18)";
        const string UpdateEnergyQuery = "Update Energy SET E17=@E17, E18=@E18 WHERE (DataIn=@DataIn)";
        const string UpdateEnergy30Query = "Update Energy30 SET I17=@I17, I18=@I18 WHERE ((DataIn=@DataIn) AND (TimeIn=@TimeIn))";
        const string InsertEnergy30Query = "INSERT INTO Energy30 (DataIn, TimeIn, I1,I2,I3,I4,I5,I6,I7,I8,I9,I10,I11,I12,I13,I14,I15,I16,I17,I18,I19,I20,I21,I22,I23,I24,I25,I26,I27,I28,I29,I30,I31,I32) VALUES (DataIn, TimeIn, @I1,@I2,@I3,@I4,@I5,@I6,@I7,@I8,@I9,@I10,@I11,@I12,@I13,@I14,@I15,@I16,@I17,@I18,@I19,@I20,@I21,@I22,@I23,@I24,@I25,@I26,@I27,@I28,@I29,@I30,@I31,@I32)";
        const string InsertPower30Query = "INSERT INTO Power30 (DataIn, TimeIn, P1,P2,P3,P4,P5,P6,P7,P8,P9,P10,P11,P12,P13,P14,P15,P16,P17,P18) VALUES (@DataIn, @TimeIn, @P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17,P18)";
        const string UpdatePower30Query = "UPDATE Power30 SET P7=@P7, P8=@P8, P9=@P9, P10=@P10, P11=@P11, P12=@P12 WHERE ((DataIn=@DataIn) AND (TimeIn=@TimeIn))";
        const string InsertPower3Query = "INSERT INTO Power3 (DataIn, TimeIn, Power3) VALUES (@DataIn, @TimeIn, @Power3)";
        const string InsertSchetchik = "INSERT INTO Schetchik (DataIn, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18) VALUES (@DataIn, @s1, @s2, @s3, @s4, @s5, @s6, @s7, @s8, @s9, @s10, @s11, @s12, @s13, @s14, @s15, @s16, @s17, @s18)";
        const string UpdateTTT = "UPDATE ttt SET ttt3=@ttt3 WHERE (ttt2=1)";
      		
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
        public int UpdateT(DateTime DateIn)
        {
            int k;
            OleDbCommand cmd = new OleDbCommand(UpdateTTT, myConnection);
            
         //   cmd.Parameters.AddWithValue("@ttt1", "asd");
        //    cmd.Parameters.AddWithValue(
            string hello="hello";
            cmd.Parameters.AddWithValue("@ttt3", DateIn);
            cmd.Parameters.AddWithValue("@ttt1", hello);
       //     cmd.Parameters.AddWithValue("@ttt2", 1);
            k = cmd.ExecuteNonQuery();
            return k;
        }

        public int InsertEnergy(DateTime DateIn, ref double[] Energy )
        {
            string column = "";           
            DateTime day = DateIn;
            string DateString = "#" + day.Month.ToString() + "/" + day.Day.ToString() + "/" + day.Year.ToString() + "#";
            string KillSchetchik = "DELETE FROM Energy WHERE DataIn=" + DateString;
            OleDbCommand killcmd = new OleDbCommand(KillSchetchik, myConnection);
            killcmd.ExecuteNonQuery();
            OleDbCommand cmd = new OleDbCommand(InsertEnergyQuery, myConnection);
            cmd.Parameters.AddWithValue("@DataIn", DateIn);
            for (int i = 1; i < 19; i++)
            {
                column = "E";
                column = column + i.ToString();
                cmd.Parameters.AddWithValue(column, Energy[i - 1]);
            }
            int k = cmd.ExecuteNonQuery();
            return k;
        }
        public int InsertEnergy(DateTime DateIn, ref double[] Energy, int canal)
        {
            string column = "";
            int start = 0;
            int k=0;
            switch (canal)
            {
                case 1: start = 0; break;
                case 2: start = 17; break;
            }
            if (canal == 1)
            {
                DateTime day = DateIn;
                string DateString = "#" + day.Month.ToString() + "/" + day.Day.ToString() + "/" + day.Year.ToString() + "#";
                string KillSchetchik = "DELETE FROM Energy WHERE DataIn=" + DateString;
                OleDbCommand killcmd = new OleDbCommand(KillSchetchik, myConnection);
                killcmd.ExecuteNonQuery();
                OleDbCommand cmd = new OleDbCommand(InsertEnergyQuery, myConnection);
                cmd.Parameters.AddWithValue("@DataIn", DateIn);
                for (int i = 1; i < 19; i++)
                {
                    column = "E";
                    column = column + i.ToString();
                    cmd.Parameters.AddWithValue(column, Energy[i - 1]);
                }
                k = cmd.ExecuteNonQuery();
            }
            if (canal == 2)
            {
                string test;
                //    test= UpdateEnergyQuery;
                test = "Update Energy SET E17=@E17, E18=@E18 WHERE (DataIn=@DataIn)";
                OleDbCommand cmd = new OleDbCommand(test, myConnection);                
                for (int i = 17; i < 19; i++)
                {
                    column = "E";
                    column = column + i.ToString();
                    cmd.Parameters.AddWithValue(column, Energy[i - 1]);
                }
                cmd.Parameters.AddWithValue("@DataIn", DateIn);
                k = cmd.ExecuteNonQuery();
            }
                
                return k;
        }
        public int InsertEnergy30(DateTime DateIn, DateTime TimeIn, ref double[] Impulsy)
        {
          //  int Canals = 32;
            string column = "";
            OleDbCommand cmd = new OleDbCommand(InsertEnergy30Query, myConnection);
            cmd.Parameters.AddWithValue("@DataIn", DateIn);
            cmd.Parameters.AddWithValue("@TimeIn", TimeIn);
            for (int i = 1; i < 20; i++)
            {
                column = "I";
                column = column + i.ToString();
                cmd.Parameters.AddWithValue(column, Impulsy[i - 1]);
            }
            for (int i = 20; i < 32 + 1; i++)
            {
                column = "I";
                column = column + i.ToString();
                cmd.Parameters.AddWithValue(column, 0);
            }
            int k = cmd.ExecuteNonQuery();
            return k;

        }

        public int InsertEnergy30(DateTime DateIn, DateTime TimeIn, ref double[] Impulsy,int canal)
        {
            //  int Canals = 32;
            string column = "";
            int k = 0;

            if (canal==1)
            {
                OleDbCommand cmd = new OleDbCommand(InsertEnergy30Query, myConnection);
                cmd.Parameters.AddWithValue("@DataIn", DateIn);
                cmd.Parameters.AddWithValue("@TimeIn", TimeIn);
                for (int i = 1; i < 20; i++)
                {
                    column = "I";
                    column = column + i.ToString();
                    cmd.Parameters.AddWithValue(column, Impulsy[i - 1]);
                }
                for (int i = 20; i < 32 + 1; i++)
                {
                    column = "I";
                    column = column + i.ToString();
                    cmd.Parameters.AddWithValue(column, 0);
                }
                k = cmd.ExecuteNonQuery();
            }

            if (canal == 2)
            {
                OleDbCommand cmd = new OleDbCommand(UpdateEnergy30Query, myConnection);
                
                for (int i = 17; i < 19; i++)
                {
                    column = "I";
                    column = column + i.ToString();
                    cmd.Parameters.AddWithValue(column, Impulsy[i - 1]);
                }
                cmd.Parameters.AddWithValue("@DataIn", DateIn);
                cmd.Parameters.AddWithValue("@TimeIn", TimeIn);

                k = cmd.ExecuteNonQuery();
            }

            
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
            for (int i = 6; i < 18 + 1; i++)
            {
                column = "P";
                column = column + i.ToString();
                cmd.Parameters.AddWithValue(column, 0);
            }
            int k = cmd.ExecuteNonQuery();
            return k;

        }
        public int InsertPower30(DateTime DateIn, DateTime TimeIn, ref double[] Power30, int canal)
        {
            int k = 0;
            string column = "";
            OleDbCommand cmd = new OleDbCommand(UpdatePower30Query, myConnection);
            if (canal == 2)
            {
                
                for (int i = 7; i < 13; i++)
                {
                    column = "P";
                    column = column + i.ToString();
                    cmd.Parameters.AddWithValue(column, Power30[i - 1]);
                }
                for (int i = 13; i < 18 + 1; i++)
                {
                    column = "P";
                    column = column + i.ToString();
                    cmd.Parameters.AddWithValue(column, 0);
                }                
            }
            if (canal == 3)
            {
                for (int i = 13; i < 18 + 1; i++)
                {
                    column = "P";
                    column = column + i.ToString();
                    cmd.Parameters.AddWithValue(column, 0);
                }
            }
            cmd.Parameters.AddWithValue("@DataIn", DateIn);
            cmd.Parameters.AddWithValue("@TimeIn", TimeIn);
            k = cmd.ExecuteNonQuery();                
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
        public int InsertPower3(DateTime DateIn, DateTime TimeIn, double Power30, int canal)
        {
            int k=0;
            if (canal == 2)
            {
                OleDbCommand cmd = new OleDbCommand(InsertPower3Query, myConnection);
                cmd.Parameters.AddWithValue("@DataIn", DateIn);
                cmd.Parameters.AddWithValue("@TimeIn", TimeIn);
                cmd.Parameters.AddWithValue("@Power3", Power30);
                k = cmd.ExecuteNonQuery();
                
            }
            return k;
        }
        public int InsertSchetshic(ref double[] export)
        {
            int Canals = 18; string column = "";
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
        public int InsertFullDayEnergy30(DateTime DateIn, ref int[,] export,double KoefPreobr)
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
            int k,canals=32;
            TimeSpan HalfHour = new TimeSpan(0, 30, 0);
            DateTime Clock = new DateTime(DateIn.Year, DateIn.Month, DateIn.Day, 0, 0, 0);
            double[] half = new double[canals];
            DeleteRecords(DateIn, "Energy30");
            for (int i = 0; i < 48; i++)
            {
                for (int j = 0; j < canals; j++)
                    half[j] = ((double)export[i, j])/((double)KoefPreobr);
                k=InsertEnergy30(DateIn, Clock, ref half);
                Clock = Clock + HalfHour;
            }
            return 0;
        }
        public int InsertFullDayEnergy30(DateTime DateIn, ref int[,] export, double KoefPreobr, int canal)
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
            if (canal == 2)
            {
                int k, canals = 32;
                TimeSpan HalfHour = new TimeSpan(0, 30, 0);
                DateTime Clock = new DateTime(DateIn.Year, DateIn.Month, DateIn.Day, 0, 0, 0);
                double[] half = new double[canals];
                //   DeleteRecords(DateIn, "Energy30");
                for (int i = 0; i < 48; i++)
                {
                    for (int j = 0; j < canals; j++)
                        half[j] = ((double)export[i, j]) / ((double)KoefPreobr);
                    k = InsertEnergy30(DateIn, Clock, ref half, canal);
                    Clock = Clock + HalfHour;
                }
            }
               return 0;
        }
        public int InsertFullDayPower30(DateTime DateIn, ref double[,] export, double KoefPreobr)
        {
            int k;
            TimeSpan HalfHour = new TimeSpan(0, 30, 0);
            DateTime Clock = new DateTime(DateIn.Year, DateIn.Month, DateIn.Day, 0, 0, 0);
            double[] half = new double[6];
            DeleteRecords(DateIn, "Power30");
            for (int i = 0; i < 48; i++)
            {
                for (int j = 0; j < 6; j++)
                    half[j] = export[i, j]*KoefPreobr;
                k = InsertPower30(DateIn, Clock, ref half);
                Clock = Clock + HalfHour;
            }
            return 0;
        }
        public int InsertFullDayPower30(DateTime DateIn, ref double[,] export, int canal)
        {
            int k;
            TimeSpan HalfHour = new TimeSpan(0, 30, 0);
            DateTime Clock = new DateTime(DateIn.Year, DateIn.Month, DateIn.Day, 0, 0, 0);
            double[] half = new double[6];
         //   DeleteRecords(DateIn, "Power30");
            if (canal == 2)
            {
                for (int i = 0; i < 48; i++)
                {
                    for (int j = 0; j < 6; j++)
                        half[j] = export[i, j];
                    k = InsertPower30(DateIn, Clock, ref half, canal);
                    Clock = Clock + HalfHour;
                }
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
    }
}
