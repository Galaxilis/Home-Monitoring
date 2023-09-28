using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoGuiProject
{
    public partial class FormCheck : Form
    {

        public Thread ThreadC;                  //Giver Thread classen nyt "kalde navn"
        public bool ThreadCheckIsAlive = false;

        double correction = 0;                  //correction faktor UDP = 4ms, TCP = 4,8ms

        decimal TXRX = 0;                       //decimal der bruges til at tælle antal TX-RX (send og receive)
        decimal CountOK = 0;                    //decimal der bruges til at tælle antal ok TX-RX
        decimal CountErrors = 0;                //decimal der bruges til at tælle antal errors TX-RX
        string ResponstidResultatStr = "";      //string der bruges i visning af Responstid  
        decimal ResponstidResultat = 0;         //decimal der bruges til beregning af responstid
        decimal StartUp = 0;                    //decimal der bruges til fravalg at de først 10 målinger i responstid og check
        bool TimerStop = false;                 //bool der viser hvor når check periode er færdig 

        public FormCheck()
        {
            InitializeComponent();
        }

        private void FormCheck_Load(object sender, EventArgs e)
        {

            timer1.Interval = 10000;
            timer2.Interval = 2000;
        }

        private void BtnCheckConnection_Click(object sender, EventArgs e)
        {
            ThreadC = new Thread(ThreadCheck);              //Opretter en Thread med navn ThreadG
            ThreadCheckIsAlive = true;                      //Sætter en bool for at Thread er aktiv
            ThreadC.Start();                                //Starter Thread

            TXRX = 0;                                       //Sætter alle tæller til nul for at buttonCheck kan startets igen
            CountOK = 0;
            CountErrors = 0;
            StartUp = 0;
            TimerStop = false;

            correction = 4.0;                           //Sætter corerection faktor, der er delay på 4 ms i arduino


            HomeMonitoring.Send("C,abcdef,");                    //Sender test string

            timer1.Enabled = true;                          //Enabler og starter timer1, timer1 er check tiden på 10 sek.
            timer1.Start();
            BtnCheckConnection.Enabled = false;                    //Sætter buttonCheck til false for at der ikke kan trykkes  
            BtnCheckConnection.BackColor = Color.LightSalmon;      //undervejs i testen og farmen er lyse rød
        }

        public void ThreadCheck() //Thread
        {
            while (true)
            {
                while (!this.IsHandleCreated)               //Forhindre at Threaden går ned
                    Thread.Sleep(5);                            //Asynkron delay, 100 på langsomme netwærk eller MCér 

                this.Invoke(new MethodInvoker(delegate ()
                {
                    switch (HomeMonitoring.returnData0)              //Modtager data fra FormN (netværk)
                    {
                        case "C":

                            if ((HomeMonitoring.returnData1 == "abcdef") && (TimerStop == false))
                            {
                                if (StartUp > 5) { TXRX++; };       //Tømmer RX buffer før SendData
                                if (StartUp > 5) { CountOK++; };    //Tømmer RX buffer før SendData
                                                                    //ved at læse 10 gange uden dektering
                                TxtCheckConnection.Text = "Numbers of TX-RX over 10 sec. :  " + TXRX.ToString();
                                HomeMonitoring.Send("C,abcdef,");
                            } else if ((HomeMonitoring.returnData1 != "abcdef") && (TimerStop == false))
                            {
                                if (StartUp > 10) { TXRX++; };          //Tømmer RX buffer før SendData
                                if (StartUp > 10) { CountErrors++; };   //Tømmer RX buffer før SendData
                                                                        //ved at læse 10 gange uden dektering 
                                HomeMonitoring.Send("C,abcdef,");
                            } else if (TimerStop == true)
                            {   //10000 / med antal TXRX
                                ResponstidResultat = decimal.Divide(10000, TXRX) - Convert.ToDecimal(correction);
                                ResponstidResultatStr = String.Format("{0:0.000}", ResponstidResultat); //Sætter format 0.000
                                TxtCheckConnection.Text = "Numbers of TX-RX over 10 sec.:           " + TXRX.ToString() + "\r\n";
                                TxtCheckConnection.Text += "Response time for one TX-RX:              " + ResponstidResultatStr + " ms" + "\r\n";                                 //ResponstidResultat
                                TxtCheckConnection.Text += "Numbers of OK TX-RX over 10 sec.:     " + CountOK.ToString() + "\r\n";
                                TxtCheckConnection.Text += "Numbers of errors TX-RX over 10 sec.: " + CountErrors.ToString();
                                HomeMonitoring.Send("Stop,,"); //Sender stop til Arduino
                            }
                            StartUp++;
                            break;
                    }
                    HomeMonitoring.returnData0 = null;   //Når returData0 er læst null stilles den
                    HomeMonitoring.returnData1 = null;   //Når returData1 er læst null stilles den
                }));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerStop = true;                           //bool for at de er gået 10 sek sætte til true
            timer1.Stop();                              //Stopper timer1
            timer2.Enabled = true;                      //Enabler og starter timer2, som er på 2 sek.
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();                              //Stopper timer2
            if (ThreadCheckIsAlive)                     //Er Thread er i live?
            {
                ThreadC.Abort(new object());            //Stopper Thread
            }
            BtnCheckConnection.Enabled = true;                 //Set af buttonCheck
            BtnCheckConnection.BackColor = Color.LightGreen;
        }

        private void FormCheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ThreadCheckIsAlive)                         //Er Thread i live
            {
                ThreadC.Abort(new object());                //Stopper Thread hvis den er i live
            }
        }
    }
}
