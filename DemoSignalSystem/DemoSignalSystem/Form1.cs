﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSignalSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Text = "CLICK ME!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Changed";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
