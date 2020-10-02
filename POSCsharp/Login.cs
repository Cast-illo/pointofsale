using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSCsharp
{
    public partial class Login : Form
    {
        int ctr = 3;
        bool login = false;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ctr == 2)
            {

                MessageBox.Show("you have one try left to login");
                ctr--;


            }

            if (ctr == 0)
            {
                MessageBox.Show("You have tried to Login Many Times, What's Wrong with you?");
                this.Close();
            }


            else if (textBox1.Text != "" && textBox2.Text != "")
            {
                // CASHIER
                if (comboBox1.Text == "Cashier")
                {
                    try
                    {
                        if (connDB.Clogin(textBox1.Text, textBox2.Text,comboBox1.Text))
                        {

                            loginfo.uname = textBox1.Text;
                            MessageBox.Show("Welcome Cashier: " + textBox1.Text.ToUpper());
                            cashierHome cs = new cashierHome();
                            cs.Show();
                            this.Hide();
                            login = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (login == false)
                    {
                        --ctr;
                        MessageBox.Show("Invalid Login Details");
                      
                    }
                }

                    //ADMIN
                if (comboBox1.Text == "Admin")
                    {
                        try
                        {
                        if (connDB.Clogin(textBox1.Text, textBox2.Text,comboBox1.Text))
                            {
                                loginfo.uname = textBox1.Text;
                                MessageBox.Show("Welcome Admin: "+ textBox1.Text.ToUpper());
                                admin ad = new admin();
                                ad.Show();
                                this.Hide();
                                login = true;
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

            } 
            else
            {
                MessageBox.Show("Logging in without details? BRUHHH.");
                ctr--;
            }





        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
