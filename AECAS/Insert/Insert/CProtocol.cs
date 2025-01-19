using System;
using System.IO.Ports;
using serialPortCreate;
using System.Runtime.InteropServices;


namespace Protocol
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    /// 
  
	public class CProtocol  
	{
        public CProtocol() 
		{}
        public int Canals=64; //количество каналов;
        public int Groups = 32; //количество групп учета
        public int Days = 60; //количество дней хранения информации
        public int Tarifs = 4; //количество тарифов
        public int KoefPreobr = 500;//коэффициент преобразования

       

        #region commands
        //  команды для подсчета энергии //
        protected byte[] com_A = new byte[] { 0x1B, 0x41, 0x0D };  //звуковой сигнал
        protected byte[] com_B = new byte[] { 0x1B, 0x42, 0x0D };  //энергия за предыдущие сутки всего
        protected byte[] com_C = new byte[] { 0x1B, 0x43, 0x0D };  //энергия за предыдущие сутки в пиках
        protected byte[] com_D = new byte[] { 0x1B, 0x44, 0x0D };  //энергия за предыдущие сутки в полупике
        protected byte[] com_E = new byte[] { 0x1B, 0x45, 0x0D };  //энергия за предыдущие сутки в ночном провале
        protected byte[] com_F = new byte[] { 0x1B, 0x46, 0x0D };  //энергия за предыдущий месяц всего
        protected byte[] com_G = new byte[] { 0x1B, 0x47, 0x0D };  //энергия за предыдущий месяц в пиках
        protected byte[] com_H = new byte[] { 0x1B, 0x48, 0x0D };  //энергия за предыдущий месяц в полупике
        protected byte[] com_I = new byte[] { 0x1B, 0x49, 0x0D };  //энергия за предыдущий месяц в ночном провале
   	
	    protected byte[] com_b = new byte[] { 0x1B, 0x62, 0x0D };  //энергия за текущие сутки всего
        protected byte[] com_c = new byte[] { 0x1B, 0x63, 0x0D };  //энергия за текущие сутки в пиках
        protected byte[] com_d = new byte[] { 0x1B, 0x64, 0x0D };  //энергия за текущие сутки в полупике
        protected byte[] com_e = new byte[] { 0x1B, 0x65, 0x0D };  //энергия за текущие сутки в ночном провале
        protected byte[] com_f = new byte[] { 0x1B, 0x66, 0x0D };  //энергия за текущие месяц всего
        protected byte[] com_g = new byte[] { 0x1B, 0x67, 0x0D };  //энергия за текущие месяц в пиках
        protected byte[] com_h = new byte[] { 0x1B, 0x68, 0x0D };  //энергия за текущие месяц в полупике
        protected byte[] com_i = new byte[] { 0x1B, 0x69, 0x0D };  //энергия за текущие месяц в ночном провале

        protected byte[] com_j = new byte[] { 0x1B, 0x6A, 0x0D };  //переход к предыдущим месяцам
        protected byte[] com_K = new byte[] { 0x1B, 0x4B, 0x0D };  //коррекция секунд без ответа
        protected byte[] com_k = new byte[] { 0x1B, 0x6B, 0x0D };  //коррекция секунд c ответом
        protected byte[] com_L = new byte[] { 0x1B, 0x4C, 0x0D };  //количество импульсов за сутки
        protected byte[] com_l = new byte[] { 0x1B, 0x6C, 0x0D };  //переход к более предыдущим суткам
        protected byte[] com_N = new byte[] { 0x1B, 0x4E, 0x0D };  //3-х минутная мощность
        protected byte[] com_n = new byte[] { 0x1B, 0x6E, 0x0D };  //количество импульсов за 2  3-х минутных интервала
        protected byte[] com_M = new byte[] { 0x1B, 0x4D, 0x0D };  //количество импульсов за текущий и предыдущий месяц                     
        protected byte[] com_m = new byte[] { 0x1B, 0x6D, 0x0D };  //количество импульсов за 40 3-х минутных интервалов
        protected byte[] com_O = new byte[] { 0x1B, 0x4F, 0x0D };  //максимумы  мощности  по  группе 1 после ограничения за предыдущий месяц
        protected byte[] com_o = new byte[] { 0x1B, 0x6F, 0x0D };  //максимумы  мощности  по  группе 1 после ограничения за текущий месяц
        protected byte[] com_P = new byte[] { 0x1B, 0x50, 0x0D };  //количество импульсов за 96 получасовых интервалов
        protected byte[] com_p = new byte[] { 0x1B, 0x70, 0x0D };  //получасовая мощность за текущие и предыдущие  полчаса
        protected byte[] com_Q = new byte[] { 0x1B, 0x51, 0x0D };  //график получасовой мощности за предыдущие сутки
        protected byte[] com_q = new byte[] { 0x1B, 0x71, 0x0D };  //график получасовой мощности за текущие сутки
        protected byte[] com_t = new byte[] { 0x1B, 0x74, 0x0D };  //переход к следующему получасу
        protected byte[] com_T = new byte[] { 0x1B, 0x54, 0x0D };  //текущее  время  и  дата
        protected byte[] com_R = new byte[] { 0x1B, 0x52, 0x0D };  //номер версии программы  
        protected byte[] com_r = new byte[] { 0x1B, 0x72, 0x0D };  //максимумы  мощности  по  группе  1 после ограничения за текущие сутки
        protected byte[] com_S = new byte[] { 0x1B, 0x53, 0x0D };  //текущие показания счетчиков
        protected byte[] com_s = new byte[] { 0x1B, 0x73, 0x0D };  //"сброс" максимумов  мощности
        protected byte[] com_V = new byte[] { 0x1B, 0x56, 0x0D };  //показания счетчиков за месяц
        protected byte[] com_v = new byte[] { 0x1B, 0x76, 0x0D };  //переход к предыдущим  месяцам

        protected byte[] com_W = new byte[] { 0x1B, 0x57, 0x0D };  //технологические параметры
        protected byte[] com_w = new byte[] { 0x1B, 0x77, 0x0D };  //параметры программирования
        protected byte[] com_aster = new byte[] { 0x1B, 0x2A, 0x0D }; //параметры программирования
       	protected byte[] com_X = new byte[] { 0x1B, 0x58, 0x0D };  //максимумы мощности за текущий и предыдущий месяц по группам 1, 2
        protected byte[] com_x = new byte[] { 0x1B, 0x78, 0x0D };  //максимумы мощности за текущие и  предыдущие сутки по группам 1, 2
        protected byte[] com_Y = new byte[] { 0x1B, 0x59, 0x0D };  //максимумы мощности за предыдущие сутки  по группам 1...6
        protected byte[] com_y = new byte[] { 0x1B, 0x79, 0x0D };  //максимумы мощности за текущие сутки по группам 1...6
        protected byte[] com_Z = new byte[] { 0x1B, 0x5A, 0x0D };  //максимумы мощности за предыдущий месяц  по группам 1...6
        protected byte[] com_z = new byte[] { 0x1B, 0x7A, 0x0D };  //максимумы мощности за текущий месяц  по группам 1...6
        protected byte[] com_dollar = new byte[] { 0x1B, 0x24, 0x0D };//график получасовой мощности за сутки
        protected byte[] com_1 = new byte[] { 0x1B, 0x31, 0x0D };  //установление связи сумматора N1  с ПЭВМ
        protected byte[] com_2 = new byte[] { 0x1B, 0x32, 0x0D };  //установление связи сумматора N1  с ПЭВМ
        protected byte[] com_3 = new byte[] { 0x1B, 0x33, 0x0D };  //установление связи сумматора N1  с ПЭВМ
   //        ...                                          ...
        protected byte[] com_8 = new byte[] { 0x1B, 0x38, 0x0D };  //установление связи сумматора N8  с ПЭВМ
        protected byte[] com_9 = new byte[] { 0x1B, 0x39, 0x0D };  //установление связи сумматора N9  с ПЭВМ
        protected byte[] com_dvoetoch = new byte[] { 0x1B, 0x3A, 0x0D };//установление связи сумматора N10 с ПЭВМ
        protected byte[] com_tochzap = new byte[] { 0x1B, 0x3B, 0x0D };//установление связи сумматора N11 с ПЭВМ
        protected byte[] ctrlZ = new byte[] { 0x1A };
   /*      *Esc  < (1B 3C)   установление связи сумматора N12 с ПЭВМ
         *Esc  = (1B 3D)   установление связи сумматора N13 с ПЭВМ
         *Esc  > (1B 3E)   установление связи сумматора N14 с ПЭВМ
         *Esc  ? (1B 3F)   установление связи сумматора N15 с ПЭВМ
         *Esc  @ (1B 40)   установление связи сумматора N16 с ПЭВМ
   
           <CTRL>S         приостановить передачу из сумматора
           <CTRL>Q         продолжить передачу из сумматора
           <CTRL>Z         прекратить обмен
    */
		//Команды, используемые только в сетевом режиме
        protected byte[] com_a = new byte[] { 0x1B, 0x61, 0x0D };   // выбор графика сумматора нижнего уровня
        protected byte[] com_proc = new byte[] { 0x1B, 0x25, 0x0D };//вывод суточного графика получасовой мощности
        protected byte[] com_sharp= new byte[] { 0x1B, 0x23, 0x0D }; //параметры программирования
        #endregion
        //	энергия за предыдущие сутки //
		public double[] EscB = new double[6]; //всего
		public double[] EscC = new double[6]; //в пиках
		public double[] EscD = new double[6]; //в полупике
		public double[] EscE = new double[6]; //в ночном провале
        public int[,] EscL = new int[48, 16]; //kolichestvo impulsov 
        public SerialPort serialPort1=new SerialPort("COM1",9600,Parity.None,8,StopBits.One);  
		//  methods  //
        public void OpenComPort()
        {
            serialPort1.ReadTimeout = 60000;
            serialPort1.Open();           
        }
        public void CloseComPort()
        {
            serialPort1.Close();
        }
        public int ATDConnect(string telefon)
        {
            int flag=0;
            string tel = "ATD";
            tel = tel + telefon;
            byte[] com_0D = new byte[] { 0x0D };
            int[] flagin = new int[54];
            serialPort1.WriteLine(tel);
            flagin[20] = 0;
            serialPort1.Write(com_0D, 0, 1);
            for (int i = 0; i < 28; i++)
            {
                flagin[i] = serialPort1.ReadByte();
                
                    if ((flagin[20] == 78) /*|| (flagin[21] == 78) || (flagin[22] == 78)*/)
                    {
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                     
                        byte[] com_2B = new byte[] { 0x2B, 0x2B, 0x2B };
                        serialPort1.Write(com_2B, 0, 3);                      
                        System.Threading.Thread.Sleep(1000 * 10);
                        serialPort1.WriteLine("ATH0");
                        serialPort1.Write(com_0D, 0, 1);
                        CloseComPort();
                        flag = 0;
                        break;
                    }
               
                    if (flagin[20] != 0)
                    {
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                        flag = serialPort1.ReadByte();
                       
                        flag = 1;
                        break;
                    }            
            }
            return flag;
        
        }
        public int ATDDisconnect()
        {
            byte[] com_0D = new byte[] { 0x0D };          
            byte[] com_2B = new byte[] { 0x2B, 0x2B, 0x2B };
            serialPort1.Write(com_2B,0,3);
            System.Threading.Thread.Sleep(1000 * 10);          
            serialPort1.WriteLine("ATH0");
            serialPort1.Write(com_0D, 0, 1);
            CloseComPort();
            return 0;
        }
		protected void devide24 (string input,ref double[] A)
		{ 
			// 6 groups
			for (int i=0;i<5;i++)
			{
				A[i]=convert( input.Substring(i*8,8) );
			}
        }  
        protected void devide1152(string input, ref double[,] A)
        {
            string temp;
            //make function!!!!!!!!!!!!!!!!!
            for (int i=0;i<48;i++)
            {
                for (int j=0;j<6;j++)
                {
                    temp = input.Substring(i * 48 + j * 8, 8);
                    A[i,j]=convert(temp);
                }
            }
        }
        //    protected void devide
        private double convert(string input)
			{
				string sInput=input;			 
				string s1,s2,s3,s4;
				int i;
	
				ushort first,second,therd,forth;
					
				s1="0x";
				s1=s1+sInput[0];
				s1=s1+sInput[1];
				s2="0x";
				s2=s2+sInput[2];
				s2=s2+sInput[3];
				s3="0x";
				s3=s3+sInput[4];
				s3=s3+sInput[5];
				s4="0x";
				s4=s4+sInput[6];
				s4=s4+sInput[7];
				
				first=Convert.ToUInt16(s1,16);
				second=Convert.ToUInt16(s2,16);
				therd=Convert.ToUInt16(s3,16);
				forth=Convert.ToUInt16(s4,16);
		
				double result,sdvig,key;
			    int max,znak,intfirst;
				sdvig=1;
				
				max=first;
				intfirst=first>>7;//проверка куда сдвигать точку
				max=max&127;//на сколько сдвигать точку
				if (intfirst==0)
				{
					max=max*(-1);
				}

				znak=second>>7;
	
				for (i=1;i<(23+max);i++) 
				{
					sdvig=sdvig*2;
				}
		
				key=(second*65536+therd*256+forth);
				result=key/sdvig;
				if (znak==1) {result=result*(-1);}
				
				return result;

			}
		private double CRC(int iSize)
		{
			////////////////////////////////////////
			///
			ushort[]  mpbCRCHi= new ushort[0x100]{
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81,
0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
0x40
};

ushort[]  mpbCRCLo= new ushort[0x100]{
0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4,
0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD,
0x1D, 0x1C, 0xDC, 0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 0x36, 0xF6, 0xF7,
0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE,
0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2,
0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB,
0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0, 0x50, 0x90, 0x91,
0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88,
0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80,
0x40
} ;

//    CRC должно быть     54 01
	ushort [] mpbT=new ushort[] {0x00, 0x00, 0x07, 0x00, 0x01};
//			ushort [] mpbT=new ushort[6];
//	int cwSize=6;
//    CRC должно быть     89 CE
//	ushort [] mpbT=new ushort{0x00 ,0x00 ,  0x0D ,0x00 ,  0xFF ,0xDC ,0x02 , 0xF4 ,0x78 ,0x00 ,0x00};
//	int cwSize=11;

  //  iSize=5;
	int cwSize=iSize;
	int bCRCHi;
	int bCRCLo;
	int i,j;
	bCRCHi = 0xFF;
	bCRCLo = 0xFF;

	for (i=0;i<cwSize;i++)
	{
		j= bCRCHi^mpbT[i];
		bCRCHi = bCRCLo ^ mpbCRCHi[j];
		bCRCLo = mpbCRCLo[j] ;
	}
            
    return bCRCHi*0x100 + bCRCLo;
}

        protected int Com25(ref byte[] command, ref double[] Esc_input)
        {
            string aaa = ""; int test;
            double[] EscE = new double[6];
            char[] input = new char[25];
            serialPort1.Write(command, 0, 3);
          
            for (int i = 0; i < 25; i++)
            {
                test = serialPort1.ReadByte();
                if (test < 10) aaa = aaa + "0" + Convert.ToString(test, 16);
                else aaa = aaa + Convert.ToString(test, 16);
            }
             
            devide24(aaa, ref Esc_input);
            return 0;
        }
        public int Com1152(/*ref byte[] command,*/ ref double[,] Esc_input)
        {
            string aaa = ""; int test;
         //   double[] EscE = new double[6];
         //   char[] input = new char[25];
            byte[] command = new byte[3];
            byte[] inp = new byte[1153];
            command[0]=0x1B;
            command[1]=0x24;
            command[2]=0x0D;
            serialPort1.Write(command, 0, 3);

            for (int i = 0; i < 1153; i++)
            {
                test = serialPort1.ReadByte();
                if (test < 16) 
                    aaa = aaa + "0" + Convert.ToString(test, 16);
                else aaa = aaa + Convert.ToString(test, 16);
            }
            int j = aaa.Length;
            devide1152(aaa, ref Esc_input);
            return 0;
        }
        public int SendCtrlZ()
        {
            int test=0;
            byte[] ctrlZ = new byte[] { 0x1A };
            serialPort1.Write(ctrlZ, 0, 1); 
            return test;
        }

        private int Error()
        {
            byte[] com_0D = new byte[] { 0x0D };            
            byte[] com_2B = new byte[] { 0x2B, 0x2B, 0x2B };
            serialPort1.Write(com_2B, 0, 3);
            System.Threading.Thread.Sleep(1000 * 10);
            serialPort1.WriteLine("ATH0");
            serialPort1.Write(com_0D, 0, 1);
            CloseComPort();
            return 1;
        }
        protected int Com2(ref byte[] command)
        {
            int test; 
            
            serialPort1.Write(command, 0, 3);
            
            test = serialPort1.ReadByte();
            test = serialPort1.ReadByte(); 
            return test;
        }
        protected int Com3(ref byte[] command)
        {
            int[] test = new int[3];
            int error = 0;

            serialPort1.Write(command, 0, 3);

            test[0] = serialPort1.ReadByte();
            test[1] = serialPort1.ReadByte();
            //test
            error = 0;
            test[2] = serialPort1.ReadByte();
            if (test[2] > 6) error = 1; //error

            return test[1];
        }
        protected int Com7(ref byte[] command,ref int[] Esc_input)
        {           
            int test,temp;
            double[] EscE = new double[6];
            char[] input = new char[7];
            serialPort1.Write(command, 0, 3);

            for (int i = 0; i < 7; i++)
            {
                test = serialPort1.ReadByte();              
                if (i == 6) break;
                if (test < 10)
                {                 
                    Esc_input[i] = Convert.ToInt32(Convert.ToString(test, 16));
                }
                else
                {                 
                   temp = Convert.ToInt32(Convert.ToString(test, 16));
                   Esc_input[i] = temp;
                }
            }      
            return 0;
        }
        protected int Com1536(ref byte[] command, ref int[] Esc_input)
        {            
            int test, temp;
            double[] EscE = new double[6];
            char[] input = new char[7];
            serialPort1.Write(command, 0, 3);

            for (int i = 0; i < 7; i++)
            {
                test = serialPort1.ReadByte();                
                if (i == 6) break;
                if (test < 10)
                {                    
                    Esc_input[i] = Convert.ToInt32(Convert.ToString(test, 16));
                }
                else
                {
                    temp = Convert.ToInt32(Convert.ToString(test, 16));
                    Esc_input[i] = temp;
                }
            }            
            return 0;
        }
        protected int Com0(ref byte[] command)
        {
            serialPort1.Write(command, 0, 3);       
            return 0;
        }
        public int SendCommand(char command)
        {
            int test = 0;
            switch (command)
            {
                case 'A': test = Com0(ref com_A); break;
                case 'k': test = Com3(ref com_k); break;
                case 'l': test = Com3(ref com_l); break;
            };
            return test;
        }
        public int SendCommand(char command, ref double[] export)
        {
            int test = 0;
            switch (command)
            {
                case 'A': test = Com25(ref com_A,ref export); break;
                case 'B': test = Com25(ref com_B, ref export); break;
                case 'C': test = Com25(ref com_C, ref export); break;
                case 'D': test = Com25(ref com_D, ref export); break;
                case 'E': test = Com25(ref com_E, ref export); break;       
            };
            return test;
        }
        //time
        public int SendCommand(char command,ref int[] export)
        {
            int test = 0;
            switch (command)
            {                
                case 'T': test = Com7(ref com_T,ref export); break;
            };
            return test;
        }
        public int TimeCorrection(ref CProtocol exportP)
        {
            SystemTime st = new SystemTime();
            LibWrap.GetSystemTime(st);
            int[] EscT = new int[7];            
            int[] NowT = new int[7];
            int k;
            System.Threading.Thread.Sleep(1000 * (59 - st.second));

            k = exportP.SendCommand('T', ref EscT);
            
            NowT[0] = st.second;
            NowT[1] = st.minute;
            NowT[2] = st.hour;            

            int dt = (EscT[1] - NowT[1]) * 60 + (EscT[0] - NowT[0]);
       
            if (dt > 0)
            {
                if ((NowT[1] == EscT[1]) && ((EscT[0] - NowT[0]) < 30))
                {
                    k = exportP.SendCommand('k');
                    
                }
                if ((NowT[1] == EscT[1]) && ((EscT[0] - NowT[0]) < 59 && (EscT[0] - NowT[0]) > 30))
                {
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 4);
                    k = exportP.SendCommand('k');
                   
                }
                if (((EscT[1] - NowT[1]) == 1) && ((EscT[0] - NowT[0]) < 30))
                {
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 4);
                    k = exportP.SendCommand('k');

                   
                }
                if (((NowT[1] - EscT[1]) == 1) && ((EscT[0] - NowT[0]) < 59 && (EscT[0] - NowT[0]) > 30))
                {
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 7);
                    k = exportP.SendCommand('k');
                    
                }
                if (((NowT[1] - EscT[1]) == 2) && ((EscT[0] - NowT[0]) < 30))
                {
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 28);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 7);
                    k = exportP.SendCommand('k');
                    
                }
            }
            if (dt < 0)
            {
                if ((NowT[1] == EscT[1]) && ((NowT[0] - EscT[0]) < 30))
                {
                    k = exportP.SendCommand('k');
                   
                }
                if ((NowT[1] == EscT[1]) && ((NowT[0] - EscT[0]) < 59) && ((NowT[0] - EscT[0]) > 30))
                {
                    System.Threading.Thread.Sleep(1000 * (32 - EscT[0]));
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * (60 - 32 + EscT[0]));
                    k = exportP.SendCommand('k');
                   
                }
                if (((NowT[1] - EscT[1]) == 1) && ((NowT[0] - EscT[0]) < 30))
                {
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 32);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 32);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 58);
                    k = exportP.SendCommand('k');
           
                }
                if (((NowT[1] - EscT[1]) == 1) && ((NowT[0] - EscT[0]) < 59 && (NowT[0] - EscT[0]) > 30))
                {
                    System.Threading.Thread.Sleep(1000 * (32 - EscT[0]));
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 32);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * 32);
                    k = exportP.SendCommand('k');
                    System.Threading.Thread.Sleep(1000 * (30 - EscT[0]));
                    k = exportP.SendCommand('k');                    
                }                
            }         
            return 0;
        }

/// ///////////////////////////////////////////////////////
        public int SendCanal(int canal)
        {
            int testday = 0;
            try
            {
                switch (canal)
                {
                    case 1:
                        serialPort1.Write(com_1, 0, 2);
                        testday = serialPort1.ReadByte();
                        testday = serialPort1.ReadByte();
                        //   start = 0;
                        break;
                    case 2:
                        serialPort1.Write(com_2, 0, 2);
                        testday = serialPort1.ReadByte();
                        testday = serialPort1.ReadByte();
                        //   start = 16;
                        break;
                    case 3:
                        serialPort1.Write(com_3, 0, 2);
                        testday = serialPort1.ReadByte();
                        testday = serialPort1.ReadByte();
                        //    start = 32;
                        break;
                }
            }
            catch (TimeoutException)
            {
                canal = 99;
            }
            return canal;

        }

        #region Impulsy
        // накопление импульсов за сутки
        public int SumL(ref int[,] input, double KoefPreobr, ref double[] export)
        {           
            for (int j = 0; j < 32; j++)
            {
                export[j] = 0;
                for (int i = 0; i < 48; i++)
                { 
                    export[j] += Convert.ToDouble(input[i, j]) / KoefPreobr;
                }
            }
            return 0;
        }
        public int SendL(ref int[,] Esc_input)
        {
            int test,i,j,error=0;
            Esc_input[0, 0] = 0;
            serialPort1.Write(com_L, 0, 3);
            for (i = 0; i < 48; i++)
                for (j = 0; j < 16; j++)
                {
                    try
                    {
                        string bbb = "", aaa = "0x";
                        test = serialPort1.ReadByte();
                        if (test < 16) bbb = "0" + Convert.ToString(test, 16);
                        else bbb = Convert.ToString(test, 16);

                        test = serialPort1.ReadByte();
                        if (test < 16) aaa = aaa + "0" + Convert.ToString(test, 16);
                        else aaa = aaa + Convert.ToString(test, 16);
                        aaa = aaa + bbb;

                        Esc_input[i, j] = Convert.ToUInt16(aaa, 16);
                    }
                    catch (TimeoutException)
                    {
                        Esc_input[i, j] = 0;
                        error = Error();
                    }
                }
            
            test = serialPort1.ReadByte();            
            return error;
        }

        public int SendL(ref int[,] Esc_input, int canal)
        {
            int test, i, j, start = 0,error=0;
            Esc_input[0, 0] = 0;
            switch (canal)
            {
                case 1:
                       start = 0;
                    break;
                case 2:
                      start = 16;
                    break;
                case 3:
                        start = 32;
                    break;
            }
            serialPort1.Write(com_L, 0, 3);
            for (i = 0; i < 48; i++)
                for (j = start; j < (start+16); j++)
                {
                    try
                    {
                        string bbb = "", aaa = "0x";
                        test = serialPort1.ReadByte();
                        if (test < 16) bbb = "0" + Convert.ToString(test, 16);
                        else bbb = Convert.ToString(test, 16);

                        test = serialPort1.ReadByte();
                        if (test < 16) aaa = aaa + "0" + Convert.ToString(test, 16);
                        else aaa = aaa + Convert.ToString(test, 16);
                        aaa = aaa + bbb;
                        Esc_input[i, j] = Convert.ToUInt16(aaa, 16);
                    }
                    catch (TimeoutException)
                    {
                        Esc_input[i, j] = 0;
                        error = Error();
                    }
                }
            test = serialPort1.ReadByte();
            //      devide24(aaa, ref Esc_input);
            return error;
        }
        #endregion

/// ///////////////////////////////////////////////////////

        #region Power30
        public int SendDollar(ref double[,] Esc_input)
        {
            string aaa = "";             
            byte[] command = new byte[3];
            int[] inp = new int[1153];
            double[] ddtemp = new double[288];
            command[0] = 0x1B;
            command[1] = 0x24;
            command[2] = 0x0D;
            serialPort1.Write(command, 0, 3);

            for (int i = 0; i < 48; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    aaa = "";
                    
                    inp[0] = serialPort1.ReadByte();
                    inp[1] = serialPort1.ReadByte();
                    inp[2] = serialPort1.ReadByte();
                    inp[3] = serialPort1.ReadByte();
                    if (inp[0] < 16)
                        aaa = aaa + "0" + Convert.ToString(inp[0], 16);
                    else aaa = aaa + Convert.ToString(inp[0], 16);
                    if (inp[1] < 16)
                        aaa = aaa + "0" + Convert.ToString(inp[1], 16);
                    else aaa = aaa + Convert.ToString(inp[1], 16);
                    if (inp[2] < 16)
                        aaa = aaa + "0" + Convert.ToString(inp[2], 16);
                    else aaa = aaa + Convert.ToString(inp[2], 16);
                    if (inp[3] < 16)
                        aaa = aaa + "0" + Convert.ToString(inp[3], 16);
                    else aaa = aaa + Convert.ToString(inp[3], 16);

                    Esc_input[i, j] = convert(aaa);
                }
            }

            int k = serialPort1.ReadByte();
            
            return 0;
        } 
        public int SendDollar(ref double[,] Esc_input, int canal)
        {
            string aaa = "";
            int start=0,error=0;
            
            byte[] command = new byte[3];
            int[] inp = new int[1153];

            switch (canal)
            {
                case 1:
                    start = 0;
                    break;
                case 2:
                    start = 6;
                    break;
                case 3:
                    start = 12;
                    break;
            }

            double[] ddtemp = new double[288];
            command[0] = 0x1B;
            command[1] = 0x24;
            command[2] = 0x0D;
            serialPort1.Write(command, 0, 3);

            for (int i = 0; i < 48; i++)
                for (int j = start; j < (start + 6); j++)
                {
                    try
                    {
                        aaa = "";
                        
                        inp[0] = serialPort1.ReadByte();
                        inp[1] = serialPort1.ReadByte();
                        inp[2] = serialPort1.ReadByte();
                        inp[3] = serialPort1.ReadByte();
                        if (inp[0] < 16)
                            aaa = aaa + "0" + Convert.ToString(inp[0], 16);
                        else aaa = aaa + Convert.ToString(inp[0], 16);
                        if (inp[1] < 16)
                            aaa = aaa + "0" + Convert.ToString(inp[1], 16);
                        else aaa = aaa + Convert.ToString(inp[1], 16);
                        if (inp[2] < 16)
                            aaa = aaa + "0" + Convert.ToString(inp[2], 16);
                        else aaa = aaa + Convert.ToString(inp[2], 16);
                        if (inp[3] < 16)
                            aaa = aaa + "0" + Convert.ToString(inp[3], 16);
                        else aaa = aaa + Convert.ToString(inp[3], 16);

                        Esc_input[i, j] = convert(aaa);
                    }
                    catch (TimeoutException)
                    {
                        
                        Esc_input[i, j] = 0;
                        error = Error();
                    }
                }
            try
            {
                int k = serialPort1.ReadByte();
            }
            catch (TimeoutException)
            {               
                error = Error();
            }           

            return error;
        } 
        #endregion

/// ///////////////////////////////////////////////////////
      
        #region POKAZANIA Schetchik
        public int SendS(ref double[] export)
         {
             string aaa = ""; int test;
             double[] EscS = new double[64];
             char[] input = new char[64 + 1];
             serialPort1.Write(com_S, 0, 3);
             for (int i = 0; i < (64 + 1); i++)
             {
                 try
                 {
                     test = serialPort1.ReadByte();
                     if (test < 16) aaa = aaa + "0" + Convert.ToString(test, 16);
                     else aaa = aaa + Convert.ToString(test, 16);
                 }
                 catch (TimeoutException)
                 {
                     test = 0;
                     if (test < 16) aaa = aaa + "0" + Convert.ToString(test, 16);
                     else aaa = aaa + Convert.ToString(test, 16);
                 };

                 
             }
             for (int i = 0; i < 16; i++)
             {
                 export[i] = convert(aaa.Substring(i * 8, 8));
             }
             return 0;
         }

        public int SendS(ref double[] export, int canal)
        {
            string aaa = ""; int test,error=0;
            int start = 0;
            
            byte[] command = new byte[3];
            switch (canal)
            {
                case 1:
                    start = 0;
                    break;
                case 2:
                    start = 16;
                    break;
                case 3:
                    start = 32;
                    break;
            }
            double[] EscS = new double[64];
            char[] input = new char[64 + 1];
            serialPort1.Write(com_S, 0, 3);
            for (int i = 0; i < (64 + 1); i++)
            {
                try
                {
                    test = serialPort1.ReadByte();
                    if (test < 16) aaa = aaa + "0" + Convert.ToString(test, 16);
                    else aaa = aaa + Convert.ToString(test, 16);
                }
                catch (TimeoutException)
                {
                    test = 0;
                    if (test < 16) aaa = aaa + "0" + Convert.ToString(test, 16);
                    else aaa = aaa + Convert.ToString(test, 16);
                    error = Error();
                };
            }
            int j = aaa.Length;
            for (int i = start; i < (start+16); i++)
            {                
                export[i] = convert(aaa.Substring((i-start) * 8, 8));
            }
            return error;
        }        
         #endregion
    }
}

