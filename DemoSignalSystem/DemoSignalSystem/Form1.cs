using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


using System.Windows.Forms;

namespace DemoSignalSystem
{
    public partial class Form1 : Form
    {
        //variable Declaration
        bool isRunning = false;
        double numSeconds = 0.0;
        double multiplier = 1;
        int hours, minutes, seconds = 0;

        //Lights are set up as TrafficLight(bool hasForward, bool forward, bool hasRight, bool right, bool hasLeft, bool left, string type)

        //Initialize a and d intersection lights starting at B5 of the light pattern description
        TrafficLight dLightSouthbound = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight aLightEastbound = new TrafficLight(true, false, true, false, false, false, "car");
        TrafficLight aLightWestbound = new TrafficLight(true, false, false, false, true, false, "car");

        //Initialize b and c intersection lights starting at B5 of the light pattern description
        TrafficLight bLightNorthbound = new TrafficLight(true, false, true, false, true, false, "car");
        TrafficLight cLightEastbound = new TrafficLight(true, false, false, false, true, false, "car");
        TrafficLight cLightWestbound = new TrafficLight(true, false, true, false, false, false, "car");

        System.Timers.Timer globalTimer = new System.Timers.Timer();

        public Form1()
        {
            InitializeComponent();
            initializeTimer();
        }

        public void initializeTimer()
        {
            globalTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            //Set time interval event trigger to 1000ms or 1 second
            globalTimer.Interval = 1000;
            globalTimer.Enabled = false;
        }

        public void startTimer()
        {
            numSeconds = 0.0;
            globalTimer.Start();
        }
        public void stopTimer()
        {
            globalTimer.Stop();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            numSeconds += 1;
            if (numSeconds >= 3600.0)
            {
                hours = Convert.ToInt32(Math.Floor(numSeconds / 3600.0));
                SetControlText(hoursTextBox2, hours.ToString());
                SetControlText(hoursTextBox, hours.ToString());
            }
            if (numSeconds >= 60.0)
            {
                minutes = Convert.ToInt32(Math.Floor((numSeconds / 60.0) % 60));
                SetControlText(minutesTextBox2, minutes.ToString());
                SetControlText(minutesTextBox, minutes.ToString());
            }
            seconds = Convert.ToInt32(Math.Floor(numSeconds%60));

            SetControlText(secondsTextBox2, seconds.ToString());
            SetControlText(secondsTextBox, seconds.ToString());
        }

        public void SetControlText(Control control, string s)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<Control, string>(SetControlText), new object[] { control, s });
                }
                else
                {
                    control.Text = s;
                }
            }
            catch (Exception ex)
            {
                
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //test
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabLightPattern_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            aLightButton2.BackColor = Color.Red;
            
        }

        private void F_Click(object sender, EventArgs e)
        {
            aLightButton2.BackColor = Color.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lightCycleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timeMultiBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                startStopButton.Text = "Stop";
                startStopButton2.Text = "Stop";
                startTimer();
            }
            else
            {
                isRunning = false;
                startStopButton.Text = "Start";
                startStopButton2.Text = "Start";
                stopTimer();
            }

        }

        private void lightCycleComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timeMultiTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void startStopButton2_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                startStopButton.Text = "Stop";
                startStopButton2.Text = "Stop";
                startTimer();
            }
            else
            {
                isRunning = false;
                startStopButton.Text = "Start";
                startStopButton2.Text = "Start";
                stopTimer();
            }
        }
    }
}
