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
        int numSeconds = 0;
        public Form1()
        {
            InitializeComponent();
            initializeLights();
            initializeTimer();
        }

        private void initializeTimer()
        {
            System.Timers.Timer globalTimer = new System.Timers.Timer();

            globalTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            //Set time interval to 1000ms or 1 second
            globalTimer.Interval = 1000;

            globalTimer.Enabled = true;
        }
        //test
       

        private void initializeLights()
        {
            //Lights are set up as TrafficLight(bool hasForward, bool forward, bool hasRight, bool right, bool hasLeft, bool left, bool hasCycle, bool cycle, string type)

            //Initialize a and d intersection lights starting at B5 of the light pattern description
            TrafficLight dLightSouthbound = new TrafficLight(true, false, true, false, true, false, true, false, "car");
            TrafficLight aLightEastbound = new TrafficLight(true, true, true, false, true, false, true, true, "car");
            TrafficLight aLightWestbound = new TrafficLight(true, true, true, false, true, false, true, true, "car");

            //Initialize b and c intersection lights starting at B5 of the light pattern description
            TrafficLight bLightNorthbound = new TrafficLight(true, false, true, false, true, false, true, false, "car");
            TrafficLight cLightEastbound = new TrafficLight(true, true, true, false, true, false, true, true, "car");
            TrafficLight cLightWestbound = new TrafficLight(true, true, true, false, true, false, true, true, "car");

            //trafA.rightOn();
            //trafA.forwardOff();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            numSeconds += 1;
            if (3600%numSeconds > 0)
            {
                //insert code to update hour section of timer with 3600%numSeconds
            }
            if (60%numSeconds > 0)
            {
                //insert code to update minute section of timer with 60%numSeconds
            }
            if (numSeconds%60 < 60)
            {
                //insert code to update second section of timer with numSeconds%60
            }
            //throw new NotImplementedException();
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
            button3.BackColor = Color.Red;
            
            

        }

        private void F_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.Green;
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
    }
}
