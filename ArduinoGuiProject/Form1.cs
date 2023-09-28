using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ArduinoGuiProject
{
    public partial class HomeMonitoring : Form
    {
        public UdpClient UDPListener;           //Giver UdpClient classen nyt "kalde navn"

        public Thread ThreadG;
        public Thread ThreadL;                  //Giver Thread classen nyt "kalde navn"
        public bool ThreadGUIIsAlive;
        public bool ThreadListenerIsAlive = false;//Bool der bruges til status på Thread
        private bool isLocked = false;

        public static string PortN = "8080";             //string til Port 
        public static string IPN = "10.1.1.150";               //string til IP
        public static bool EnN = false;         //bool der er true hvis netwærk er tilgænelig
        public static bool successN;            //Check om der kunne sendes til Arduino 

        public string DataTmp = "";             //Midlertid string til UDP modtaget data
        public static string returnData0 = "";  //string til modtaget data
        public static string returnData1 = "";  //string til modtaget data
        public static string returnData2 = "";  //string til modtaget data

        //Set up camera and face recognition


        bool TL = true;
        bool appRunning = false;

        public HomeMonitoring()
        {
            InitializeComponent();
        }

        private void HomeMonitoring_Load(object sender, EventArgs e)
        {
            StartNetwork();

        }

        private void HomeMonitoring_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopNetwork();
            Application.Exit();                 //Exit af hele programmet
        }

        private void StartNetwork()
        {
            EnN = true;                                         //Sætter bool til true for at netwærk startets

            Send("X,X,");                                       //Er der connection ? successN == true?


            UDPListener = new UdpClient(Convert.ToInt16(PortN));      //Opretter en ny UDPListener

            ThreadL = new Thread(ThreadListener);           //Opretter en Thread med navn ThreadL
            ThreadListenerIsAlive = true;                   //Sætter en bool for at Thread er aktiv
            ThreadL.Start();                                //Starter Thread

            ThreadG = new Thread(ThreadGUI);
            ThreadGUIIsAlive = true;
            appRunning = true;
            ThreadG.Start();
        }

        private void StopNetwork()
        {
            UDPListener.Close();
            if (ThreadListenerIsAlive)          //Er Thread i live
            {
                ThreadL.Abort(new object());    //Stopper Thread hvis den er i live
            }
            if (ThreadGUIIsAlive)
            {
                ThreadG.Abort(new object());
            }
            EnN = false;                        //Disable af send i FormN
        }

        public void ThreadListener() //Thread
        {
            while (true)
            {
                string returnData = null;

                Listener(IPN, PortN, out returnData);

                //Forhindre at Threaden går ned, hvis der ikke er kontakt til MC Arduino
                while (!this.IsHandleCreated)
                    Thread.Sleep(5);  //Asynkron delay, 100 på langsomme netwærk eler MCér  

                this.Invoke(new MethodInvoker(delegate ()
                {
                    string[] returnDataArr;
                    returnDataArr = returnData.Split(',');  //Hver "ord" bliver adskilt med et ,
                    returnData0 = returnDataArr[0];
                    returnData1 = returnDataArr[1];
                    returnData2 = returnDataArr[2];
                }));
            }
        }

        public void ThreadGUI()
        {
            while (true)
            {
                while (!this.IsHandleCreated)
                    Thread.Sleep(5);

                this.Invoke(new MethodInvoker(delegate ()
                {
                    switch (returnData0)
                    {
                        case "M":
                            TxtMotionDetected.Text = "TRUE";
                            returnData0 = null;
                            returnData1 = null;
                            returnData2 = null;
                            break;

                        case "m":
                            TxtMotionDetected.Text = "FALSE";
                            returnData0 = null;
                            returnData1 = null;
                            returnData2 = null;
                            break;
                    }

                }));
            }
        }

        public void Listener(string IPL, string PortL, out string reData)
        {

            IPEndPoint ip = new IPEndPoint((long)Convert.ToDouble(IPL), Convert.ToInt16(PortL));//Variable ip = IP og Port
            Byte[] receiveBytes = UDPListener.Receive(ref ip);      //Modtager data fra Arduino i et Byte Array 
            DataTmp = Encoding.ASCII.GetString(receiveBytes);       //Fra Byte til String 
            
            reData = DataTmp;
        }

        public static void Send(string Val)                             //Her bruges følgende variabler:
        {                                                               //EnN, ProtocolN, string IPN, string PortN og Val0, Val1

            UdpClient UDPSend = new UdpClient();                    //Starter en ny UDPListener Send Client
            UDPSend.Connect(IPN, Convert.ToInt16(PortN));           //Connect med IP og Port
                                                                    //Byte[] senddata = Encoding.ASCII.GetBytes(Val0 + Val1); //Message fra string til array
            Byte[] senddata = Encoding.ASCII.GetBytes(Val);         //Message fra string til array
            UDPSend.Send(senddata, senddata.Length);                //Tager data fra array og sender det via GUI til UDPServer
            UDPSend.Close();
        }

        private void BtnLockUnlock_Click(object sender, EventArgs e)
        {
            if (isLocked == false)
            {
                BtnLockUnlock.BackColor = Color.Red;
                BtnLockUnlock.Text = "LOCKED";

                Send("Servo,Lock,");
                isLocked = true;
            } else if (isLocked == true)
            {
                BtnLockUnlock.BackColor = Color.LimeGreen;
                BtnLockUnlock.Text = "UNLOCKED";

                Send("Servo,Unlock,");
                isLocked = false;
            }
        }

        private void CheckMenu_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<FormCheck>().Any())
            {
                FormCheck FC = new FormCheck();
                FC.Show();
            }
        }

        private void DATAMenu_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<FormDATA>().Any())
            {
                FormDATA FD = new FormDATA();
                FD.Show();
            }
        }
    }
}
