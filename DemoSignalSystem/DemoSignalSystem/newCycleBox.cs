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
    public partial class newCycleBox : Form
    {
        public newCycleBox()
        {
            InitializeComponent();
        }

        public string newCycleName;

        //Called when user clicks save, returns the value in the text box as the name for the new cycle
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.newCycleName = textBoxNewCycleName.Text;
            this.DialogResult = DialogResult.OK;
        }
        //Called when user clicks cancel, closes the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
