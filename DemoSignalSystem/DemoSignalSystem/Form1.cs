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
            TrafficLight trafA = new TrafficLight(true, true, true, false, true, false, "car");
            
            trafA.rightOn();
            trafA.forwardOff();
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
