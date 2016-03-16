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
            button1.Text = "CLICK ME!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void initializeLights()
        {
            TrafficLight trafA = new TrafficLight(true, true, true, false, true, false);
            
            trafA.rightOn();
            trafA.forwardOff();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
