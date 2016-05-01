using System;
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
    public partial class Entry : Form
    {
        public Entry()
        {
            InitializeComponent();
        }
        //Opens initial form to enter program
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rlogin rl = new Rlogin();
            rl.Show();
        }
    }
}
