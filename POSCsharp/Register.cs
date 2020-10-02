using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSCsharp
{
    public partial class Register : Form
    {
        int recentID;
        public Register()
        {
            InitializeComponent();
            idtxt();
        }
        
        void idtxt()
        {
            connDB gnum = new connDB();
            gnum.nextid();
            recentID = Int32.Parse(loginfo.id)+ 1;
            txtID.Text = recentID.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if ( (Fname1.Text == "") ||( lname1.Text == "") || (uname1.Text =="") || (pass1.Text == ""))
            {
                MessageBox.Show("Please Fill-up form completely to Register Account!!!");
            }
            else
            {
                String id,fname, lname, uname, pass, type;
                id = txtID.Text;
                fname = Fname1.Text;
                lname = lname1.Text;
                uname = uname1.Text;
                pass = pass1.Text;
                type = type1.Text;


                try
                { 
                    connDB connect = new connDB();
                    connect.addAcc(id,fname, lname, uname, pass, type);
                    MessageBox.Show("New Account Registered!");
                    Fname1.Text = "";
                    lname1.Text = "";
                    uname1.Text = "";
                    pass1.Text = "";
                    idtxt();



                }
                catch (Exception Exception)
                {
                    MessageBox.Show(Exception.Message);
                }
                 
            }
          
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            admin A = new admin();
            A.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login A = new Login();
            A.Show();
            this.Close();
        }

        private void pass1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
