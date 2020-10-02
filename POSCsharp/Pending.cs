using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;


namespace POSCsharp
{
    public partial class Pending : Form
    {
        MySqlConnection connection = new MySqlConnection("dataSource = localhost; Initial Catalog = sales; username = root; Password = ");
        MySqlCommand command;
        public Pending()
        {
            InitializeComponent();
            table7();
            this.dateTimePicker1.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;

        }

        DataTable dbdataset;
        public void table7()
        {
            MySqlConnection con = new MySqlConnection(mycon.conn);
            MySqlCommand cmdDatabase = new MySqlCommand("select pdid as ' ID', pdname as ' Name', pdbrand as 'Brand',pdtype as 'Type',pdqty as 'Quantity', pdprice as 'Price',approval as 'Appr' from sales.pendingdelivery ;", con);

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
       

        private void EditProfile_Load(object sender, EventArgs e)
        {
           
        }

        //edit profile
        private void button1_Click(object sender, EventArgs e)
        {
           
            }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

       
        

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            string id, name, brand, type, qty, price, approval;
            loginfo.pdid1 = this.id.Text;
            loginfo.pdname = this.name.Text;
            loginfo.pdbrand = this.brand.Text;
            loginfo.pdtype = this.type.Text;
            loginfo.pdqty = this.qty.Text;
            loginfo.pdprice = this.price.Text;
            loginfo.time = this.dateTimePicker1.Text;
            approval b = new approval();
            b.Show();

          /*  connDB connect = new connDB();
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
            connect.pendingtodelivery(id, name , brand, type, qty, price , this.dateTimePicker1.Text, nice,loginfo.pdid);*/

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            int i;
            i = dataGridView1.CurrentRow.Index;
            id.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            brand.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            type.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            qty.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            price.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            appr.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            admin a = new admin();
            a.Show();
        }
    }
    }

