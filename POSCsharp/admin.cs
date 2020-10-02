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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
            loadName();
        }

        #region LOAD CASHIER NAME
        public void loadName()
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
                label3.Text = myReader["fname"].ToString().ToUpper() + " " + myReader["lname"].ToString().ToUpper();

            }
            myConn.Close();
        }

        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            EditProfile ep = new EditProfile();
            ep.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageAccount ma = new ManageAccount();
            ma.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inventory r = new inventory();
            r.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reports r= new Reports();
              r.Show();
             this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            loginfo.counter = 1;
            EditProfile r = new EditProfile();
            r.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ManageAccount r = new ManageAccount();
            r.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Login r = new Login();
            r.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pending a = new Pending();
            a.Show();
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            transaction a = new transaction();
            a.Show();

        }
    }
}
