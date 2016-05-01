using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoSignalSystem
{
    public partial class Rlogin : Form
    {
        public Rlogin()
        {
            InitializeComponent();
        }

        //Calls checkCredentials, and if user is found returns credential level to main program
        private void Login_Click(object sender, EventArgs e)
        {

            string username, password, cred;

            username = txtBoxUser.Text;
            password = textBoxPass.Text;

            cred = checkCredentials(username, password);

            if (cred == "notfound") MessageBox.Show("User Not Found");
            else if (cred == "incorrectPass") MessageBox.Show("Incorrect Password");
            else {

                Form1 f1 = new Form1(cred);
                f1.Show();
                this.Close();
            }
        }

        //Searches for username and password, if found, returns their credential level
        private string checkCredentials (String userName, String password)
        {
            string line, thisUser, thisPass, thisCred;
            System.IO.StreamReader file = new System.IO.StreamReader("users.txt");
            while ((line = file.ReadLine()) != null)
            {
                thisUser = line;
                thisPass = file.ReadLine();
                thisCred = file.ReadLine();
                line = file.ReadLine(); //to skip blank line

                if (thisUser.ToLower() == userName.ToLower())
                {
                    if (thisPass == password) return thisCred;
                    else return "incorrectPass";
                }
            }
            return "notfound";
        }

        //Called when close button is clicked, ends prorgram
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region unusedfunctions
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }
}
