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
    public partial class transaction : Form
    {
        DataTable dbdataset;
        public transaction()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            table();

        }

        public void table()
        {
            MySqlConnection con = new MySqlConnection(mycon.conn);
          /*  MySqlCommand cmdDatabase = new MySqlCommand("select tid as ' TID', pid as ' PID', Custid as 'Customer',pname as 'Name',ptype as 'Type', pbrand as 'Brand',pqty as 'Quant',total as 'Total', tdate as 'DateToday', staff as 'Staff' from sales.transaction ;", con);*/
            MySqlCommand cmdDatabase = new MySqlCommand("select transaction.total, transaction.tdate,customer.cname, customer.paymenttype from customer inner join transaction on customer.custId = transaction.Custid ;", con);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            admin ad = new admin();
            ad.Show();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            admin q = new admin();
            q.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
