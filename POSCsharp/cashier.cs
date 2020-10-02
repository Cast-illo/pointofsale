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
using System.Windows.Forms;
using System.IO;

namespace POSCsharp
{
    public partial class cashier : Form
    {
        public cashier()
        {
            InitializeComponent();
            table1(); table2(); table3(); table4(); table5(); table6();
            loadName();
            idtxt();
            custId();
            //qtyProd();
            lvP();
            this.dateTimePicker1.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;

        }
        DataTable dbdataset;
        int ns, cntr = 0;
        string idd, Stock1;

        #region NextId - Transaction

        void idtxt()
        {
            connDB gnum = new connDB();
            gnum.ntid();
            int recentID = Int32.Parse(loginfo.tid) + 1;
            idd = recentID.ToString();
            // label14.Text = idd;
        }


        #endregion

        #region next cust ID
        void custId()
        {
            connDB gnum = new connDB();
            gnum.nexcust();
            int nextCust = Int32.Parse(loginfo.custId) + 1;
            custID.Text = nextCust.ToString();
            loginfo.custId1 = custID.Text;
            loginfo.custId2 = loginfo.custId1;
        }

        #endregion

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
                label12.Text = myReader["fname"].ToString() + " " + myReader["lname"].ToString();

            }
            myConn.Close();
        }

        #endregion

        #region LVProperties
        public void lvP()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            //columns
            listView1.Columns.Add("TID", 50);
            listView1.Columns.Add("PID", 50);
            listView1.Columns.Add("Product", 100);
            listView1.Columns.Add("type", 50);
            listView1.Columns.Add("brand", 50);
            listView1.Columns.Add("price", 50);
            listView1.Columns.Add("stock", 50);
            listView1.Columns.Add("qty", 50);
            listView1.Columns.Add("total", 50);
        }


        #endregion

        #region AddRow to List Box
        private void Addrow(String id, String cid, String name, String type, String brand, String pric, String stck, String qty, String ttl)
        {
            String[] row = { id, cid, name, type, brand, pric, stck, qty, ttl };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);

        }

        #endregion

        #region ADD TOTAL
        public void addtotal()
        {
            double sum;
            sum = loginfo.Finaltotal + loginfo.semitotal;
            loginfo.Finaltotal = sum;
            label7.Text = sum.ToString();
        }

        #endregion

        #region LOAD ALL PRODUCTS
        //  
        public void table1()
        {
            MySqlConnection con = new MySqlConnection(mycon.conn);
            MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price' from sales.products where ptype='Frozen';", con);

            try
            {
                // Frozen //
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
        }//
        // ---------------------------------------------------------------------//

        public void table2()
        {
            MySqlConnection con = new MySqlConnection(mycon.conn);
            MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price' from sales.products where ptype='Dairy';", con);

            try
            {
                // Dairy //
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                myDataAdapter.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView4.DataSource = bSource;
                myDataAdapter.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //

        // ---------------------------------------------------------------------//
        public void table3()
        {
            MySqlConnection con = new MySqlConnection(mycon.conn);
            MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price' from sales.products where ptype='Drinks';", con);

            try
            {
                // Drinks //
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                myDataAdapter.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView5.DataSource = bSource;
                myDataAdapter.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //

        // ---------------------------------------------------------------------//
        public void table4()
        {
            MySqlConnection con = new MySqlConnection(mycon.conn);
            MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price' from sales.products where ptype='Fruits';", con);

            try
            {
                // FRUITS //
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                myDataAdapter.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView6.DataSource = bSource;
                myDataAdapter.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //

        // ---------------------------------------------------------------------//

        public void table5()
        {
            MySqlConnection con = new MySqlConnection(mycon.conn);
            MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price' from sales.products where ptype='Vegetables';", con);

            try
            {
                // Vegetables //
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                myDataAdapter.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView7.DataSource = bSource;
                myDataAdapter.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //

        // ---------------------------------------------------------------------//
        public void table6()
        {
            MySqlConnection con = new MySqlConnection(mycon.conn);
            MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price' from sales.products where ptype='Others';", con);

            try
            {
                // others //
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                myDataAdapter.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView8.DataSource = bSource;
                myDataAdapter.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region TALBLE CLICK
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int i;
            qty.Visible = true;
            i = dataGridView1.CurrentRow.Index;
            id.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            brand.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            price.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            id.Visible = true;
            //  loginfo.tid = id.Text;
            // 
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            int i;
            qty.Visible = true;
            i = dataGridView4.CurrentRow.Index;
            id.Text = dataGridView4.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView4.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView4.Rows[i].Cells[2].Value.ToString();
            brand.Text = dataGridView4.Rows[i].Cells[3].Value.ToString();
            price.Text = dataGridView4.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView4.Rows[i].Cells[4].Value.ToString();
            id.Visible = true;
        }

        private void dataGridView5_Click(object sender, EventArgs e)
        {
            int i;
            qty.Visible = true;
            i = dataGridView5.CurrentRow.Index;
            id.Text = dataGridView5.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView5.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView5.Rows[i].Cells[2].Value.ToString();
            brand.Text = dataGridView5.Rows[i].Cells[3].Value.ToString();
            price.Text = dataGridView5.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView5.Rows[i].Cells[4].Value.ToString();
            id.Visible = true;
        }

        private void dataGridView6_Click(object sender, EventArgs e)
        {
            int i;
            qty.Visible = true;
            i = dataGridView6.CurrentRow.Index;
            id.Text = dataGridView6.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView6.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView6.Rows[i].Cells[2].Value.ToString();
            brand.Text = dataGridView6.Rows[i].Cells[3].Value.ToString();
            price.Text = dataGridView6.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView6.Rows[i].Cells[4].Value.ToString();
            id.Visible = true;
        }

        private void dataGridView7_Click(object sender, EventArgs e)
        {
            int i;
            qty.Visible = true;
            i = dataGridView7.CurrentRow.Index;
            id.Text = dataGridView7.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView7.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView7.Rows[i].Cells[2].Value.ToString();
            brand.Text = dataGridView7.Rows[i].Cells[3].Value.ToString();
            price.Text = dataGridView7.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView7.Rows[i].Cells[4].Value.ToString();
            id.Visible = true;
        }

        private void dataGridView8_Click(object sender, EventArgs e)
        {
            int i;
            qty.Visible = true;
            i = dataGridView8.CurrentRow.Index;
            id.Text = dataGridView8.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView8.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView8.Rows[i].Cells[2].Value.ToString();
            brand.Text = dataGridView8.Rows[i].Cells[3].Value.ToString();
            price.Text = dataGridView8.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView8.Rows[i].Cells[4].Value.ToString();
            id.Visible = true;
        }//
        #endregion

        #region CART MANIP
        //ADD TO CART //
        private void button1_Click(object sender, EventArgs e)
        {

            if ((qty.Text == ""))
            {
                MessageBox.Show("Please Enter Purchase Quantity");
            }
            else
            {

                // ADD TO "CART" //
                Addrow(idd, id.Text, name.Text, type.Text, brand.Text, price.Text, stock.Text, qty.Text, total.Text);
                //listBox1.Items.Add(idd.PadRight(10) + id.Text.PadRight(10) + name.Text.PadRight(30) + price.Text.PadRight(30) + qty.Text.PadRight(30) + total.Text.PadRight(0));


                String ID, CID, PID, PNAME, PTYPE, PBRAND, PQTY, TOTAL, Date, ST;
                ID = idd;
                PID = id.Text;
                CID = loginfo.custId2;
                PNAME = name.Text;
                PTYPE = type.Text;
                PBRAND = brand.Text;
                PQTY = qty.Text;
                TOTAL = total.Text;
                ST = label12.Text;
                Date = this.dateTimePicker1.Text;

                // LESS STOCK VAUES - PER ADD TO CART //
                int a, b;
                a = Convert.ToInt32(stock.Text);
                b = Convert.ToInt32(PQTY);
                ns = a - b;
                Stock1 = ns.ToString();
                // label15.Text = Stock1;

                try
                {
                    connDB connect = new connDB();
                    connect.transac(ID, CID, PID, PNAME, PTYPE, PBRAND, PQTY, TOTAL, this.dateTimePicker1.Text, ST);
                    connect.hist(ID, CID, PNAME, PTYPE, PBRAND, PQTY, TOTAL, Date);
                    idtxt();
                    //     compt();

                    String PID1, PNAME1, PTYPE1, PBRAND1, PQTY1, PPRICE1;
                    PID1 = id.Text;
                    PNAME1 = name.Text;
                    PTYPE1 = type.Text;
                    PBRAND1 = brand.Text;
                    PQTY1 = Stock1;
                    PPRICE1 = price.Text;
                    addtotal();
                    try
                    {
                        connDB connect1 = new connDB();
                        connect1.updateStock(PID1, PNAME1, PTYPE1, PBRAND1, PQTY1, PPRICE1);
                        id.Text = null;
                        name.Text = null;
                        type.Text = null;
                        brand.Text = null;
                        qty.Text = null;
                        total.Text = null;
                        price.Text = null;
                        stock.Text = null;
                        table1(); table2(); table3(); table4(); table5(); table6();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "2");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "error1");
                }
            }
        }
        //qty validation //
        private void qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        //COMPUTE TOTAL PER ITEM //
        private void qty_TextChanged(object sender, EventArgs e)
        {
            if ((qty.Text == null) || (qty.Text == ""))
            {
                total.Text = "0";
            }
            else
            {
                double qty1, price1;
                qty1 = Convert.ToDouble(qty.Text);
                price1 = Convert.ToDouble(price.Text);

                double amount = price1 * qty1;
                total.Text = amount.ToString();
                //   compt();
                loginfo.semitotal = amount;
                //   addtotal();
            }
        }


        #endregion

        #region select row
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            label6.Text = listView1.SelectedItems[0].SubItems[0].Text;
            cid.Text = listView1.SelectedItems[0].SubItems[1].Text;
            cname.Text = listView1.SelectedItems[0].SubItems[2].Text;
            ctype.Text = listView1.SelectedItems[0].SubItems[3].Text;
            cbrand.Text = listView1.SelectedItems[0].SubItems[4].Text;
            cprice.Text = listView1.SelectedItems[0].SubItems[5].Text;
            label14.Text = listView1.SelectedItems[0].SubItems[6].Text;
            cqty.Text = listView1.SelectedItems[0].SubItems[7].Text; // stock
            ctotal.Text = listView1.SelectedItems[0].SubItems[8].Text;
            // SelectCart();
            qty.Visible = false;
            cqty.Visible = true;
            button1.Enabled = true;
            // Remove.Visible = true;

            int a, b, c;
            a = Convert.ToInt32(label14.Text);
            b = Convert.ToInt32(cqty.Text);
            label18.Text = (a - b).ToString();
            c = Convert.ToInt32(label18.Text) + Convert.ToInt32(cqty.Text);
            label19.Text = c.ToString();
            cstock.Text = label18.Text;
            qty2.Text = cstock.Text;
        }//end select row

        private void button3_Click(object sender, EventArgs e)
        {
            //  label21.Text = label7.Text;
            if (label29.ForeColor == Color.Red)
            {

                MessageBox.Show("Invalid");
            }
            else
            {

                groupBox6.Visible = true;
                receipt r = new receipt();
                r.Show();
                this.Close();

            }


        }



        private void button4_Click(object sender, EventArgs e)
        {
            double a1, b2;
            a1 = Convert.ToDouble(label7.Text);
            b2 = Convert.ToDouble(payment.Text);

            if (b2 < a1)
            {
                MessageBox.Show("Insufficient Amount Sirs!");
            }
            else
            {
                double d = b2 - a1;
                MessageBox.Show("Total Change: PHP" + d);


            }
        }

        private void payment_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if ((payment.Text == "") || (payment.Text == null))
                {
                    label29.Text = "Please Provide Payment!";

                } //end else if 

                else
                {
                    double a1, b2;
                    a1 = Convert.ToDouble(label7.Text);
                    b2 = Convert.ToDouble(payment.Text);

                    // if (b2 > a1)
                    //{
                    double d = b2 - a1;
                    label29.Text = d.ToString();
                    loginfo.payment = payment.Text;
                    loginfo.change = label29.Text;

                    if (d < 0)
                    {
                        label29.ForeColor = Color.Red;
                    }
                    else
                    {
                        label29.ForeColor = Color.Black;
                    }
                    //}
                    //else
                    //{
                    //   MessageBox.Show("Insufficient Amount Sirs!");
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            cashierHome er = new cashierHome();
            er.Show();
            this.Close();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // UPDATE CART //
        //private void button4_Click_1(object sender, EventArgs e)
        //{
        //    cntr++;
        //    switch (cntr)
        //    {
        //        case 1:
        //            cqty.Visible = true;
        //        //    button4.Text = "SAVE";
        //            cntr++;
        //            break;

        //        case 2:
        //            int q1, q2, ans;
        //            q1 = Convert.ToInt32(label14.Text);
        //            q2 = Convert.ToInt32(cqty.Text);
        //            if (q2 < q1) // add to db  - less to transac
        //            {
        //                ans = q2 + q1;

        //                MySqlConnection connection = new MySqlConnection("dataSource = localhost; Initial Catalog = pos; username = root; Password = ");
        //                MySqlCommand command;
        //                String query = "update pos.products set  pqty =@pqty1 where pid= @pid1 ";
        //                MySqlConnection myCon = new MySqlConnection(mycon.conn);
        //                MySqlCommand myComm = new MySqlCommand(query, myCon);

        //                try
        //                {
        //                    connection.Open();
        //                    command = new MySqlCommand(query, connection);
        //                    command.Parameters.Add("@pid1", MySqlDbType.Int32, 11);


        //                    command.Parameters.Add("@pqty1", MySqlDbType.Int32, 11);



        //                    command.Parameters["@pid1"].Value = label14.Text;
        //                    command.Parameters["@pqty1"].Value = ans;



        //                    if (command.ExecuteNonQuery() == 1)
        //                    {
        //                        MessageBox.Show("Data Inserted");
        //                    }

        //                    connection.Close();


        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.ToString());

        //                }
        //            }
        //            else if (q2 > q1) // less to db add to transact
        //            {
        //                ans = q1 - q2;

        //                MySqlConnection connection = new MySqlConnection("dataSource = localhost; Initial Catalog = pos; username = root; Password = ");
        //                MySqlCommand command;
        //                String query = "update pos.products set  pqty =@pqty1 where pid= @pid1 ";
        //                MySqlConnection myCon = new MySqlConnection(mycon.conn);
        //                MySqlCommand myComm = new MySqlCommand(query, myCon);

        //                try
        //                {
        //                    connection.Open();
        //                    command = new MySqlCommand(query, connection);
        //                    command.Parameters.Add("@pid1", MySqlDbType.Int32, 11);
        //                    command.Parameters.Add("@pqty1", MySqlDbType.Int32, 11);



        //                    command.Parameters["@pid1"].Value = label14.Text;
        //                    command.Parameters["@pqty1"].Value = ans;



        //                    if (command.ExecuteNonQuery() == 1)
        //                    {
        //                       // MessageBox.Show("Data Inserted");
        //                    }

        //                    connection.Close();


        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.ToString());

        //                }

        //            }
        //            break;
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            //UPDATE DB PRODUCTS //
            String PID1, PNAME1, PTYPE1, PBRAND1, PQTY1, PPRICE1;
            PID1 = cid.Text;
            PNAME1 = cname.Text;
            PTYPE1 = ctype.Text;
            PBRAND1 = cbrand.Text;
            PQTY1 = label19.Text;
            PPRICE1 = cprice.Text;
            double a, b;
            b = Convert.ToDouble(cprice.Text) * Convert.ToDouble(cqty.Text);
            a = Convert.ToDouble(label7.Text) - b;
            label7.Text = a.ToString();
            //addtotal();
            try
            {
                connDB connect1 = new connDB();
                connect1.updateDel(PID1, PNAME1, PTYPE1, PBRAND1, PQTY1, PPRICE1);

                table1(); table2(); table3(); table4(); table5(); table6();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "3");
            }
            // DELETE TO TRANSACTION
            String id;
            id = label6.Text;
            try
            {
                connDB conn = new connDB();
                conn.delTrans(id);
                MessageBox.Show("Cart no: " + id + " has been Deleted");
                // LoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //delete to dataGrid
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            cid.Text = null;
            cname.Text = null;
            ctype.Text = null;
            cbrand.Text = null;
            cqty.Text = null;
            ctotal.Text = null;
            cprice.Text = null;
            cstock.Text = null;
        }


        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                String name = textBox1.Text;
                String choice = comboBox1.Text;


                MySqlConnection con = new MySqlConnection(mycon.conn);
                con.Open();
                if (comboBox1.SelectedItem == "ID")
                {
                    MySqlCommand cmdDatabase = new MySqlCommand("select * from sales.products where pid='" + name + "'", con);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    myDataAdapter.SelectCommand = cmdDatabase;
                    dbdataset = new DataTable();
                    myDataAdapter.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;
                    myDataAdapter.Update(dbdataset);
                }

                else if (comboBox1.SelectedItem == "Name")
                {
                    MySqlCommand cmdDatabase = new MySqlCommand("select * from sales.products where pname='" + name + "'", con);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    myDataAdapter.SelectCommand = cmdDatabase;
                    dbdataset = new DataTable();
                    myDataAdapter.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;
                    myDataAdapter.Update(dbdataset);
                }
                else if (comboBox1.SelectedItem == "Brand")
                {
                    MySqlCommand cmdDatabase = new MySqlCommand("select * from sales.products where pbrand='" + name + "'", con);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    myDataAdapter.SelectCommand = cmdDatabase;
                    dbdataset = new DataTable();
                    myDataAdapter.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;
                    myDataAdapter.Update(dbdataset);
                }
                else if (comboBox1.SelectedItem == "Type")
                {
                    MySqlCommand cmdDatabase = new MySqlCommand("select * from sales.products where ptype='" + name + "'", con);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    myDataAdapter.SelectCommand = cmdDatabase;
                    dbdataset = new DataTable();
                    myDataAdapter.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;
                    myDataAdapter.Update(dbdataset);
                }

                //select * from eztan.products where pname='Milk'

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("dataSource = localhost; Initial Catalog = sales; username = root; Password = ");
                MySqlCommand command;
                MySqlDataAdapter da;
                connection.Open();
                String sqlquery = "Select * from sales.products where pid='" + id.Text + "'";
                command = new MySqlCommand(sqlquery, connection);
                MySqlDataReader dataread = command.ExecuteReader();
                dataread.Read();

                if (dataread.HasRows)
                {

                    byte[] images = ((byte[])dataread[6]);

                    if (images == null)
                    {
                        pictureBox1.Image = null;
                    }

                    else
                    {
                        MemoryStream mstream = new MemoryStream(images);
                        pictureBox1.Image = Image.FromStream(mstream);

                    }

                }
                else
                {


                }
                connection.Close();
            }
            catch (ArgumentException ex)
            {
                pictureBox1.Image = null;
            }
        }

        private void cashier_Load(object sender, EventArgs e)
        {

        }

        private void custID_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void payment_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }
    }
}

        

     
// end of file


