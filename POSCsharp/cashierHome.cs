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
    public partial class cashierHome : Form
    {
        public cashierHome()
        {
            InitializeComponent();
            loadName();
            this.dateTimePicker1.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
            loginfo.date = this.dateTimePicker1.Text;
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
            
            RegisterCustomer c = new RegisterCustomer();
            c.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginfo.counter = 2; 
            EditProfile er = new EditProfile();
            er.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login er = new Login();
            er.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
