using System;
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
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            initializeLights();
           
        }


        private void initializeLights()
        {
            //Lights are set up as TrafficLight(bool hasForward, bool forward, bool hasRight, bool right, bool hasLeft, bool left, bool hasCycle, bool cycle, string type)

            //Initialize a and d intersection lights
            TrafficLight dLightSouthbound = new TrafficLight(true, false, true, false, true, false, true, false, "car");
            TrafficLight aLightEastbound = new TrafficLight(true, true, true, false, true, false, true, true, "car");
            TrafficLight aLightWestbound = new TrafficLight(true, true, true, false, true, false, true, true, "car");

            //Initialize b and c intersection lights
            TrafficLight bLightNorthbound = new TrafficLight(true, false, true, false, true, false, true, false, "car");
            TrafficLight cLightEastbound = new TrafficLight(true, true, true, false, true, false, true, true, "car");
            TrafficLight cLightWestbound = new TrafficLight(true, true, true, false, true, false, true, true, "car");

            //trafA.rightOn();
            //trafA.forwardOff();
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
    }
}
