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
    public partial class ManageAccount : Form
    {
        int cntr;
        public ManageAccount()
        {
            InitializeComponent();
            LoadTable();
        }
        DataTable dbdataset;

        #region Load Table
        public void LoadTable()
        {
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand cmdDatabase = new MySqlCommand("select ID as 'Account ID', fname as 'First Name', lname as 'Last Name',uname as 'Username', pass as 'Password' from sales.accounts where type='cashier ';", myConn);

            try
            {

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                myDataAdapter.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                myDataAdapter.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #endregion

        private void ManageAccount_Load(object sender, EventArgs e)
        {

        }
        //Table Click
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            fname1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            lname1.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            uname1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            pass1.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }
        //EDIT ACCOUNT
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
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button1.Text = "Update";
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
                            MessageBox.Show("Account ID no: " + id + " has been updated");

                            fname1.Enabled = false;
                            lname1.Enabled = false;
                            uname1.Enabled = false;
                            pass1.Enabled = false;
                            button2.Enabled = true;
                            button3.Enabled = true;
                            cntr = 0;
                            LoadTable();

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
            Register rg = new Register();
            rg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String id;
            id = txtID.Text;
           try
            {
                connDB conn = new connDB();
                conn.delAcc(id);
                MessageBox.Show("Account ID no: " + id + " has been Deleted");
                LoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login a = new Login();
            a.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
