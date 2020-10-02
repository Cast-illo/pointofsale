using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace POSCsharp
{
    public partial class EditProfile : Form
    {
        int cntr = 0;
        public EditProfile()
        {
            InitializeComponent();
            LoadProfile();
        }


        ///load all profile details
        #region LoadProfile

            private void LoadProfile()
        {
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand("SELECT * FROM accounts WHERE uname = '" + loginfo.uname + "';", myConn);
            MySqlDataAdapter sDA = new MySqlDataAdapter();
            MySqlDataReader myReader;

            myConn.Open();
            myReader = myComm.ExecuteReader();
            int counter = 0;
            while (myReader.Read())
                counter++;
            if (counter == 1)
            {
                txtID.Text = myReader["ID"].ToString();
                fname1.Text = myReader["fname"].ToString();
                lname1.Text = myReader["lname"].ToString();
                uname1.Text = myReader["uname"].ToString();
                pass1.Text = myReader["pass"].ToString();

            }
            myConn.Close();

        }


        #endregion

        private void EditProfile_Load(object sender, EventArgs e)
        {
           
        }

        //edit profile
        private void button1_Click(object sender, EventArgs e)
        {
            ++cntr;
            switch (cntr)
            {
                case 1:
                    fname1.Enabled = true;
                    lname1.Enabled = true;
                    uname1.Enabled = true;
                    pass1.Enabled = true;
                    
                    break;

                default:
                    if ((fname1.Text == "") || (lname1.Text == "") || (uname1.Text == "") || (pass1.Text == ""))
                    {
                        MessageBox.Show("Please Fill Up Informations!");
                    }
                    else
                    {
                        String id, fname, lname, uname, pass;
                        id = txtID.Text;
                        fname = fname1.Text;
                        lname = lname1.Text;
                        uname = uname1.Text;
                        pass = pass1.Text;

                        try
                        {
                            connDB connect = new connDB();
                            connect.editAcc(id, fname, lname, uname, pass);
                            MessageBox.Show("Account has been updated");

                            fname1.Enabled = false;
                            lname1.Enabled = false;
                            uname1.Enabled = false;
                            pass1.Enabled = false;                      
                            cntr = 0;
                            LoadProfile();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }




                    break;
                    }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            Login er = new Login();
            er.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (loginfo.counter == 1)
            {
                admin er = new admin();
                er.Show();
                this.Close();
            }else if (loginfo.counter == 2)
            {
                cashierHome ass = new cashierHome();
                ass.Show();
                this.Close();
            }
           
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pass1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }

