using MySql.Data.MySqlClient;
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
    public partial class RegisterCustomer : Form
    {
        public RegisterCustomer()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            custId();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

              void custId()
        {
            connDB gnum = new connDB();
            gnum.nexcust();
            int nextCust = Int32.Parse(loginfo.custId) + 1;
            loginfo.custId2 = loginfo.custId1;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try { 
           loginfo.cname = textBox1.Text;
           loginfo.paymentype = comboBox1.SelectedItem.ToString();
           MessageBox.Show("Registered Successful, WELCOME "+ loginfo.cname);
            cashierHome yas = new cashierHome();
            yas.Close();
            cashier yown = new cashier();
            yown.Show();
            this.Close();

            }catch(Exception q)
            {
                MessageBox.Show(q.ToString());
            }
            /*String query = "insert into pos.customer values ('" +loginfo.custId2  + "','" + cname + "','" + paymentype + "','" + date + "')";
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            myConn.Close();*/
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            cashierHome what = new cashierHome();
            what.Show();

        }
    }
}
