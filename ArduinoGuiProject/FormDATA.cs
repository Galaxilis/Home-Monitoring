using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoGuiProject
{
    public partial class FormDATA : Form
    {
        public string tempStr;
        public double tempDbl;
        public string humStr;
        public double humDbl;
        public string dateTime;
        public Thread ThreadD;
        public bool ThreadDATAIsAlive;


        public FormDATA()
        {
            InitializeComponent();
        }

        private void FormDATA_Load(object sender, EventArgs e)
        {
            ThreadD = new Thread(ThreadDATA);           //Opretter en Thread med navn ThreadL
            ThreadDATAIsAlive = true;                   //Sætter en bool for at Thread er aktiv
            ThreadD.Start();
        }

        public void ThreadDATA()
        {
            while (true)
            {
                while (!this.IsHandleCreated)
                    Thread.Sleep(5);

                this.Invoke(new MethodInvoker(delegate ()
                {
                    switch (HomeMonitoring.returnData0)
                    {
                        case "T":
                            tempStr = HomeMonitoring.returnData1;
                            humStr = HomeMonitoring.returnData2;

                            double.TryParse(tempStr, out tempDbl);
                            double.TryParse(humStr, out humDbl);


                            dateTime = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}.{DateTime.Now.Second}";

                            tempStr = String.Format("{0:0.0}", tempDbl);
                            humStr = String.Format("{0:0.0}", humDbl);

                            tempStr = tempStr.Replace(',', '.');
                            humStr = humStr.Replace(',', '.');

                            ChartTemp.Series["Temperature"].Points.AddXY(dateTime, tempStr);
                            ChartTemp.Series["Humidity"].Points.AddXY(dateTime, humStr);

                            TxtChartTemp.Text += $"{dateTime}: {tempStr}°C {humStr}%\r\n";
                            TxtChartTemp.SelectionStart = TxtChartTemp.Text.Length;
                            TxtChartTemp.ScrollToCaret();

                            HomeMonitoring.returnData0 = null;
                            HomeMonitoring.returnData1 = null;
                            HomeMonitoring.returnData2 = null;
                            break;
                    }
                }));
            }
        }

        private void ChartTemp_Click(object sender, EventArgs e)
        {

        }

        private void FormDATA_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ThreadDATAIsAlive)          //Er Thread i live
            {
                ThreadD.Abort(new object());    //Stopper Thread hvis den er i live
            }
        }
    }
}
