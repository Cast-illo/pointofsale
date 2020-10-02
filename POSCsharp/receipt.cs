using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POSCsharp
{
    public partial class receipt : Form
    {
        public receipt()
        {
            InitializeComponent();
            RefreshList();
            String datepurchased;
            datepurchased = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker1.Value = DateTime.Now;
            this.dateTimePicker1.Enabled = false;
            nextcus(datepurchased);
            reports(datepurchased);
        }

        public void reports(string datepurchased)
        {
            String query1 = "SELECT SUM(numbers) FROM (SELECT total as numbers from sales.transaction where custid=" + loginfo.custId1 + ") as t ;";
            // String query1 = "select sum(total) from eztan.transaction group by tdate='" + datepurchased + "'";
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query1, myConn);
            MySqlDataReader myreader;   
            myConn.Open();
            var obj = myComm.ExecuteScalar();
            int yes = Convert.ToInt32(obj);
          
            String query2 = "insert into sales.reports values ('" + yes + "','" + datepurchased + "')";
            MySqlCommand cmd = new MySqlCommand(query2, myConn);
            myreader = cmd.ExecuteReader();
            myConn.Close();

        }
        //this adds a new customer and date purchased
        private void nextcus(string datepurchased)
        {
         
            DateTime date1 = DateTime.Now;
            int sir =int.Parse(loginfo.custId1);
            String query2 = "insert into sales.customer values('" + sir.ToString() + "','" + loginfo.cname + "','" + loginfo.paymentype + "','" + datepurchased + "')";
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query2, myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            myConn.Close();

        }

       /* public void addimagetrans(byte[] img, String id)
        {
            String query = "update pos.transaction set set receipt= '" + img + "' where cid = '" + id + "'";
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myConn);
            MySqlDataReader myReader;

            myConn.Open();
            myReader = myComm.ExecuteReader();
            myConn.Close();
        }*/

        //MySql.Data.MySqlClient.MySqlException: 'You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near 'where cid = '11'' at line 1'

        private void RefreshList()
        {
            string query = "Select pid as 'Product ID', pname as 'Product', pqty as 'Quantity', total as 'Total' from sales.transaction WHERE custID LIKE '" + loginfo.custId1 + "';";

            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            //for local testing 
            //MySqlConnection myConn = new MySqlConnection("server = localhost; Initial Catalog = esystem; username = root; password =");
            MySqlCommand myComm = new MySqlCommand(query, myConn);
            MySqlDataAdapter SDA = new MySqlDataAdapter();
            try
            {
                SDA.SelectCommand = myComm;
                DataTable dbdataset = new DataTable();
                SDA.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                SDA.Update(dbdataset);
                label2.Text = loginfo.custId1;
                label21.Text = loginfo.Finaltotal.ToString();
                label3.Text = loginfo.payment.ToString();
                label4.Text = loginfo.change.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }
        Bitmap bmp;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //to show the image in print preview
            e.Graphics.DrawImage(bmp, 40, 125);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            MemoryStream mmstream = new MemoryStream();
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            //restrict image selection
            mg.CopyFromScreen(this.Location.X + 10, this.Location.Y + 40, 20, 75, this.Size);
          /*  bmp.Save(mmstream, ImageFormat.Png);
            var png = mmstream.ToArray();
            addimagetrans(png, loginfo.custId1);    */
            printPreviewDialog1.ShowDialog();
            cashier c = new cashier();
            c.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            cashier c = new cashier();
            c.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

   
    }
}
