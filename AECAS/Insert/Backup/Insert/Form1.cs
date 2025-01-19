using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using dbaseADO;
using Protocol;

namespace Insert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileStream fin;

            try
            {
                fin = new FileStream("telefon.txt", FileMode.Open);
                StreamReader strreader = new StreamReader(fin);
                telefon = strreader.ReadLine();
                textBox1.Text = telefon;
            }
            catch (IOException)
            {
                MessageBox.Show("Нет файла telefon.txt");
            }
            //   MessageBox.Show(telefon);
            try
            {
                fin = new FileStream("koef.txt", FileMode.Open);
                StreamReader strreader = new StreamReader(fin);
                Koef = strreader.ReadLine();
                //KoefPreobr = Convert.ToDouble(Koef.Replace('.',','));
            }
            catch (IOException)
            {
                MessageBox.Show("нет файла koef.txt");
            }
            textBox2.Text = Convert.ToString(days);
        }
        CProtocol ComPort = new CProtocol();
        private int chflag = 0;
        static int days;
        private int modem=0;
        double KoefPreobr = 1.0;
        private string telefon = "";
        private string Koef = "1";

        private void button3_Click(object sender, EventArgs e)
        {
            //прочитать все данные или данные за определенное количество дней
            progressBarRead.Minimum = 0;
            progressBarRead.Value = 0;
            progressBarRead.Maximum =2* Convert.ToInt32(textBox2.Text)+1;             
            int k, message=0;
        //    KoefPreobr = 1/1.2/*12000*/;

            KoefPreobr = 1 / Convert.ToDouble(Koef.Replace('.', ','));
            double KoefPreobr2 = Convert.ToDouble(Koef.Replace('.', ','));

            int[,] Impulsy = new int[48, 32];
            double[,] Power30 = new double[48, 32];
            double[] Schetchik = new double[32];
            double[] Energy = new double[32];            
            int[] com_T = new int[6];

            ADOWork MyBase = new ADOWork();
            DateTime Today = DateTime.Today;
            DateTime DataIn = Today;
            TimeSpan DeltaDay;
            DeltaDay = new TimeSpan(1, 0, 0, 0);
            MyBase.OpenBase();

            if (modem != 1)
                ComPort.OpenComPort();
           
            if (chflag == 0)
            {
                days = MyBase.ProverkaBase();
            }
            else
            {
                days = Convert.ToInt32(textBox2.Text);
            }
                //      days=MyBase.ProverkaPower30();
            if (days > 61) days = 61;
            //HalfHour = new TimeSpan(0, 30, 0);
            ComPort.SendCtrlZ();
            ComPort.SendCommand('A');
       //     ComPort.SendCtrlZ();
            k = ComPort.SendCommand('T', ref com_T);
            ComPort.SendCanal(1);
            k = ComPort.SendS(ref Schetchik,1);       
            ComPort.SendCanal(2);
            k = ComPort.SendS(ref Schetchik,2);            
            k = MyBase.InsertSchetshic(ref Schetchik);
            
            ComPort.SendCanal(1);
            for (int ii = 0; ii < days; ii++)
            {
                //#region clear
                //for (int j = 0; j < 32; j++)
                //{
                //    for (int i = 0; i < 47; i++)
                //    {
                //        Power30[i, j] = 0;
                //        Impulsy[i, j] = 0;
                //    }
                //    Energy[j] = 0;
                //}
                //#endregion  
                ComPort.SendDollar(ref Power30,1);
                System.Threading.Thread.Sleep(1000);
                ComPort.SendL(ref Impulsy,1);
                System.Threading.Thread.Sleep(1000);
                ComPort.SumL(ref Impulsy, KoefPreobr, ref Energy);
                System.Threading.Thread.Sleep(1000);
                message=ComPort.SendCommand('l');
                k = MyBase.InsertFullDayEnergy30(DataIn, ref Impulsy, KoefPreobr);
                k = MyBase.InsertFullDayPower30(DataIn, ref Power30, KoefPreobr2*10000);
                k = MyBase.InsertEnergy(DataIn, ref Energy,1);
                DataIn = DataIn - DeltaDay;
                label5.Text = Convert.ToString(message);
                progressBarRead.Value += 1;
                System.Threading.Thread.Sleep(1000);
            }
            
            ComPort.SendCtrlZ();
            System.Threading.Thread.Sleep(1000 * 2);
            ComPort.SendCanal(2);
         //   k = ComPort.SendCommand('T', ref com_T);
            
           DataIn = Today;
         
#region clear
           for (int j = 0; j < 32; j++)
           {
               for (int i = 0; i < 47; i++)
               {
                   Power30[i, j] = 0;
                   Impulsy[i, j] = 0;
               }
               Energy[j] = 0;
           }
#endregion       
           

           for (int ii = 0; ii < days; ii++)
           {                
           //    ComPort.SendDollar(ref Power30, 2);
               ComPort.SendL(ref Impulsy, 2);
               System.Threading.Thread.Sleep(1000);
               ComPort.SumL(ref Impulsy, KoefPreobr, ref Energy);
               System.Threading.Thread.Sleep(1000);
               message = ComPort.SendCommand('l');
               System.Threading.Thread.Sleep(1000);
               k = MyBase.InsertFullDayEnergy30(DataIn, ref Impulsy, KoefPreobr,2);
          //     k = MyBase.InsertFullDayPower30(DataIn, ref Power30);
               k = MyBase.InsertEnergy(DataIn, ref Energy, 2);
               DataIn = DataIn - DeltaDay;

               progressBarRead.Value += 1;
               System.Threading.Thread.Sleep(1000);
           }
        
            ComPort.SendCanal(1);
            ComPort.SendCtrlZ();
    //        k = ComPort.SendCommand('T', ref com_T);
         //   ComPort.CloseComPort();
            MyBase.CloseBase();

            progressBarRead.Value = 2 * Convert.ToInt32(textBox2.Text) + 1; 
            MessageBox.Show("Данные получены");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ATDConnect
            int k;
            ComPort.OpenComPort();
            k=ComPort.ATDConnect("+375291476842");
            if (k==1)
                MessageBox.Show("Connect 9600");
            else
                MessageBox.Show("No carrier");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //прочитать все данные или данные за определенное количество дней
            progressBarRead.Minimum = 0;
            progressBarRead.Maximum = 2 * Convert.ToInt32(textBox2.Text) + 1;

            int k, KoefPreobr = 12500;
            
            //   int[,] Impulsy = new int[48, 16];
            int[,] Impulsy = new int[48, 32];

            double[,] Power30 = new double[48, 32];
            double[] Schetchik = new double[32];
            double[] Energy = new double[32];
            ADOWork MyBase = new ADOWork();
            //CProtocol ComPort = new CProtocol();

            DateTime Today = DateTime.Today;
            
//////////////////////////////////           


            if (modem != 1)
                ComPort.OpenComPort();
          
            MyBase.OpenBase();
            //MyBase.UpdateT(Today);
          //  MyBase.InsertEnergy(Today,ref Energy, 2);
       //     MyBase.InsertFullDayEnergy30(Today,

            MyBase.CloseBase();
          
            if (chflag == 0)
            {
                days = MyBase.ProverkaBase();
            }
            else
            {
                days = Convert.ToInt32(textBox2.Text);
            }
            //      days=MyBase.ProverkaPower30();
            
            DateTime DataIn = Today;
            TimeSpan DeltaDay;
            DeltaDay = new TimeSpan(1, 0, 0, 0);
            //HalfHour = new TimeSpan(0, 30, 0);
          

            int[] com_T = new int[6];
            ComPort.SendCanal(1);
            //for (int ii = 0; ii < days; ii++)
            //{
                ComPort.SendDollar(ref Power30);
                ComPort.SendL(ref Impulsy);
                ComPort.SumL(ref Impulsy, KoefPreobr, ref Energy);
                ComPort.SendCommand('l');
                k = MyBase.InsertFullDayEnergy30(DataIn, ref Impulsy, KoefPreobr);
                k = MyBase.InsertFullDayPower30(DataIn, ref Power30,KoefPreobr*10000);
                k = MyBase.InsertEnergy(DataIn, ref Energy, 1);
                DataIn = DataIn - DeltaDay;

                progressBarRead.Value += 1;
            //}

            ComPort.SendCanal(2);
            DataIn = Today;
            for (int ii = 0; ii < days; ii++)
            {

                ComPort.SendDollar(ref Power30, 2);
                ComPort.SendL(ref Impulsy, 2);
                ComPort.SumL(ref Impulsy, KoefPreobr, ref Energy);
                ComPort.SendCommand('l');
                k = MyBase.InsertFullDayEnergy30(DataIn, ref Impulsy, KoefPreobr);
                k = MyBase.InsertFullDayPower30(DataIn, ref Power30,KoefPreobr*10000);
                k = MyBase.InsertEnergy(DataIn, ref Energy, 2);
                DataIn = DataIn - DeltaDay;

                progressBarRead.Value += 1;
            }

            ComPort.SendCanal(1);
            k = ComPort.SendCommand('T', ref com_T);
            //   ComPort.CloseComPort();
            MyBase.CloseBase();

            progressBarRead.Value = 2 * Convert.ToInt32(textBox2.Text) + 1;
            MessageBox.Show("Данные получены");
            
            /*
            progressBarRead.Minimum = 0;
            progressBarRead.Maximum = 30;

            int days, k, KoefPreobr = 500;
            
            int[,] Impulsy = new int[48, 16];
            double[,] Power30 = new double[48, 6];
            double[] Schetchik = new double[16];
            double[] Energy = new double[16];
            ADOWork MyBase = new ADOWork();
            CProtocol ComPort = new CProtocol();
            
            if (modem!=1) 
                ComPort.OpenComPort();
            MyBase.OpenBase();

            days = MyBase.ProverkaBase();
            //      days=MyBase.ProverkaPower30();

            DateTime Today = DateTime.Today;
            DateTime DataIn = Today;
            TimeSpan DeltaDay;
            
            DeltaDay = Today - dateTimePicker1.Value;
            days = DeltaDay.Days;
            DeltaDay = new TimeSpan(1, 0, 0, 0);

            int[] com_T = new int[6];
            for (int ii = 0; ii < days; ii++)
            {
                //ComPort.SendL(ref Impulsy);
                //ComPort.SumL(ref Impulsy, KoefPreobr, ref Energy);
                //ComPort.SendDollar(ref Power30);
                ComPort.SendCommand('l');
                //k = MyBase.InsertFullDayEnergy30(DataIn, ref Impulsy, KoefPreobr);
                //k = MyBase.InsertFullDayPower30(DataIn, ref Power30);
                //k = MyBase.InsertEnergy(DataIn, ref Energy);
                DataIn = DataIn - DeltaDay;
                progressBarRead.Value += 1;
            }

            ComPort.SendL(ref Impulsy);
            ComPort.SumL(ref Impulsy, KoefPreobr, ref Energy);
            ComPort.SendDollar(ref Power30);
            k = MyBase.InsertFullDayEnergy30(DataIn, ref Impulsy, KoefPreobr);
            k = MyBase.InsertFullDayPower30(DataIn, ref Power30);
            k = MyBase.InsertEnergy(DataIn, ref Energy);

            k = ComPort.SendCommand('T', ref com_T);
            ComPort.CloseComPort();
            MyBase.CloseBase();

            progressBarRead.Value = 30;
            MessageBox.Show("The End");
             * */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //// Получить путь к системной папке.
            //string sysFolder =
            //Environment.GetFolderPath(Environment.SpecialFolder.System);
            ////Создать новую структуру ProcessStartInfo.
            //ProcessStartInfo pInfo = new ProcessStartInfo();
            ////Вставка состовляющих имени файла.
            //pInfo.FileName = sysFolder + @"calc.exe";
            //// Значение структуры UseShellExecute по умолчанию true. Здесь вставлено для иллюстрации.
            //pInfo.UseShellExecute = true;
            //Process p = Process.Start(pInfo);
            Process.Start("viewer2.exe");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ATDDisconnect
            ComPort.ATDDisconnect();
            ComPort.CloseComPort();
            MessageBox.Show("Отключите питание модема");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox2.Checked == true) 
            {
                chflag = 1;
                textBox2.ReadOnly = false;
                textBox2.Text = Convert.ToString(days);
            }
            else
            {
                chflag = 0;
                textBox2.ReadOnly = true;
                days = Convert.ToInt32(textBox2.Text);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Enabled = false;
                groupBox1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox1.Checked = true;
                groupBox1.Enabled = true;
                modem = 1;
               
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}