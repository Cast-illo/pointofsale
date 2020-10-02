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
    public partial class approval : Form
    {
        public approval()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        int ctr = 3;
        bool login = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (ctr == 2)
            {

                MessageBox.Show("you have one try left to login");
                ctr--;


            }

            if (ctr == 0)
            {
                MessageBox.Show("You have tried to Login Many Times, What's Wrong with you?");
                this.Close();
            }


            string ad = "admin";
            try
            {
                if (connDB.Clogin(textBox1.Text, textBox2.Text, ad))
                {
                    loginfo.uname = textBox1.Text;
                    MessageBox.Show("APPROVED");
                    connDB connect = new connDB();
                    string id, name, brand, type, qty, price, approval;
               
                    Random rnd = new Random();
                    int dice = rnd.Next(1, 7);
                    DateTime myDateTime = DateTime.Now;
                    String sqlFormattedDate = myDateTime.Date.ToString("yyyy-mm-dd");

                    DateTime dateTime = new DateTime();
                    dateTime = DateTime.Now;
                    DateTime newDateTime = new DateTime();
                    TimeSpan NumberOfDays = new TimeSpan(dice, 0, 0, 0, 0);
                    newDateTime = dateTime.Add(NumberOfDays);
                    string nice = newDateTime.ToString();
                    login = true;
                    connect.pendingtodelivery(loginfo.pdid1, loginfo.pdname, loginfo.pdbrand, loginfo.pdtype, loginfo.pdqty, loginfo.pdprice, loginfo.time, nice);
                    connect.deletepending(loginfo.pdid1);
                    this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (login == false)
            {
                ctr--;
                MessageBox.Show("Invalid Login Details");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
