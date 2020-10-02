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
using System.IO;


namespace POSCsharp
{
    public partial class inventory : Form
    {
        public inventory()
        {
            InitializeComponent();
            table1(); table2(); table3(); table4(); table5(); table6();
            this.dateTimePicker1.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
            table1(); table2(); table3(); table4(); table5(); table6();

        }
        int cntr = 0;
        DataTable dbdataset;

        #region nextId
        void idtxt()
        {
            connDB gnum = new connDB();
            gnum.npid();
            int recentID = Int32.Parse(loginfo.pid) + 1;
            id.Text = recentID.ToString();
        }

        #endregion

        #region LoadTables

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
            MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price'from sales.products where ptype='Dairy';", con);

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




            #endregion

            #region LOAD TABLES

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try { 
            int i;
            i = dataGridView1.CurrentRow.Index;
            id.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            brand.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            price.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            }catch(Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            int i;
            i = dataGridView4.CurrentRow.Index;
            id.Text = dataGridView4.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView4.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView4.Rows[i].Cells[3].Value.ToString();
            brand.Text = dataGridView4.Rows[i].Cells[2].Value.ToString();
            price.Text = dataGridView4.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView4.Rows[i].Cells[4].Value.ToString();
        }

        private void dataGridView5_Click(object sender, EventArgs e)
        {
            int i;
            i = dataGridView5.CurrentRow.Index;
            id.Text = dataGridView5.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView5.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView5.Rows[i].Cells[3].Value.ToString();
            brand.Text = dataGridView5.Rows[i].Cells[2].Value.ToString();
            price.Text = dataGridView5.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView5.Rows[i].Cells[4].Value.ToString();
        }

        private void dataGridView6_Click(object sender, EventArgs e)
        {
            int i;
            i = dataGridView6.CurrentRow.Index;
            id.Text = dataGridView6.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView6.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView6.Rows[i].Cells[3].Value.ToString();
            brand.Text = dataGridView6.Rows[i].Cells[2].Value.ToString();
            price.Text = dataGridView6.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView6.Rows[i].Cells[4].Value.ToString();
        }

        private void dataGridView7_Click(object sender, EventArgs e)
        {
            int i;
            i = dataGridView7.CurrentRow.Index;
            id.Text = dataGridView7.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView7.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView7.Rows[i].Cells[3].Value.ToString();
            brand.Text = dataGridView7.Rows[i].Cells[2].Value.ToString();
            price.Text = dataGridView7.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView7.Rows[i].Cells[4].Value.ToString();
        }

        private void dataGridView8_Click(object sender, EventArgs e)
        {
            int i;
            i = dataGridView8.CurrentRow.Index;
            id.Text = dataGridView8.Rows[i].Cells[0].Value.ToString();
            name.Text = dataGridView8.Rows[i].Cells[1].Value.ToString();
            type.Text = dataGridView8.Rows[i].Cells[3].Value.ToString();
            brand.Text = dataGridView8.Rows[i].Cells[2].Value.ToString();
            price.Text = dataGridView8.Rows[i].Cells[5].Value.ToString();
            stock.Text = dataGridView8.Rows[i].Cells[4].Value.ToString();
        }


        #endregion

        #region STOCK MANIPULATION
        // EDIT STOCK //
        private void button1_Click(object sender, EventArgs e)
        {
            
            ++cntr;
     
            switch (cntr)
            {
                case 1:
                    name.Enabled = true;
                    type.Enabled = true;
                    comboBox1.Visible = true;
                    brand.Enabled = true;
                    price.Enabled = true;
                    stock.Enabled = true;
                    type.Visible = true;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = true;
                    button1.Text = "SAVE";
                    break;

                default:

                    DialogResult dialogResult = MessageBox.Show("Do you Approve of this order?", "Approval ", MessageBoxButtons.YesNo);

                 /*   if (int.Parse(loginfo.stock) < int.Parse(this.stock.Text))
                    {
                        MessageBox.Show("you cannot lessen the current stocks");
                    }*/

                    if ((name.Text == "") || (type.Text == "") || (brand.Text == "") || (price.Text == "") || (stock.Text == ""))
                    {

                        MessageBox.Show("Please Fill Up Informations!");
                    }

                    else if  ( dialogResult == DialogResult.Yes)
                        {

                        String PID, PNAME, PTYPE, BRAND, PQTY, PPRICE;
                        PID = id.Text;
                        PNAME = name.Text;
                        PTYPE = brand.Text;
                        BRAND = type.Text;
                        PQTY = stock.Text;
                        PPRICE = price.Text;


                        try
                        {
                            MemoryStream ms = new MemoryStream();
                            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                            byte[] img = ms.ToArray();



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
                            int price1 = int.Parse(PQTY) * int.Parse(PPRICE);


                            connDB connect = new connDB();
                            connect.editIn(PID, PNAME, PTYPE, BRAND, PQTY, PPRICE, img);
                            connect.adddelivery(PID,PNAME,BRAND,PTYPE,PQTY,price1.ToString(),this.dateTimePicker1.Text,nice);
                            MessageBox.Show("Product ID no: " + id.Text + " has been updated");

                            name.Enabled = false;
                            type.Enabled = false;
                            brand.Enabled = false;
                            price.Enabled = false;
                            stock.Enabled = false;
                            button2.Enabled = true;
                            button3.Enabled = true;
                            type.Visible = true;
                            pictureBox1.Visible = false;
                            button4.Enabled = false;
                            comboBox1.Visible = false;
                            cntr = 0;
                            table1(); table2(); table3(); table4(); table5(); table6();
                            button1.Text = "UPDATE";

                        }

                        catch (System.NullReferenceException)
                        {
                            MessageBox.Show("Insert an image");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        String PID, PNAME, PTYPE, BRAND, PQTY, PPRICE,APPR;
                        PID = id.Text;
                        PNAME = name.Text;
                        PTYPE = brand.Text;
                        BRAND = type.Text;
                        PQTY = stock.Text;
                        PPRICE = price.Text;
                        APPR = "Pending";
                        loginfo.pdid = PID;
                        int price1 = int.Parse(PQTY) * int.Parse(PPRICE);
                        connDB connect = new connDB();
                        connect.pendingdelivery(int.Parse(PID), PNAME, PTYPE, BRAND, int.Parse(PQTY), price1,APPR);
                    }

                    break;
            }
        }
        // DELETE STOCK - PULL OUT ITEMS //
        private void button2_Click(object sender, EventArgs e)
        {

            String id1;
            id1 = id.Text;
            try
            {
                connDB conn = new connDB();
                conn.delIn(id1);
                MessageBox.Show("Product no: " + id.Text + " has been Deleted");
                table1(); table2(); table3(); table4(); table5(); table6();

                id.Text = null;
                name.Text = null;
                type.Text = null;
                brand.Text = null;
                price.Text = null;
                stock.Text = null;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //ADD ITEMS - STOCKS TO DATABASE //
        private void button3_Click(object sender, EventArgs e)
        {
            idtxt();
            ++cntr;
            dataGridView1.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;
            // id.Text = null;


            switch (cntr)
            {
                case 1:
                    name.Text = null;
                    type.Text = null;
                    brand.Text = null;
                    price.Text = null;
                    stock.Text = null;

                    pictureBox1.Image = null;
                    name.Enabled = true;
                    type.Visible = false;
                    comboBox1.Visible = true;
                    brand.Visible = false;
                    brand.Enabled = false;
                    price.Enabled = true;
                    stock.Enabled = true;
                    type.Visible = true;
                    type.Enabled = true;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button4.Enabled = true;
                    pictureBox1.Visible = true;
                    button3.Text = "SAVE";
                    break;

                default:


                    if ((name.Text == "") || (comboBox1.Text == "") || (price.Text == "") || (stock.Text == ""))
                    {
                        MessageBox.Show("Please Fill Up Informations!");
                    }
                    else
                    {

                        String pname, ptype, pbrand, pqty, pprice,
                        pid = id.Text;
                        pname = name.Text;
                        ptype = comboBox1.Text;
                        pbrand = type.Text;
                        pqty = stock.Text;
                        pprice = price.Text;



                        try
                        {
                            MemoryStream ms = new MemoryStream();
                            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                            byte[] img = ms.ToArray();


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

                            connDB connect = new connDB();

                           
                            int price1 = int.Parse(pqty) * int.Parse(pprice);
                            connect.additemsnew(pid, pname, ptype, pbrand, pqty, pprice, img);
                            connect.adddelivery(pid, pname, pbrand, ptype, pqty,price1.ToString(), this.dateTimePicker1.Text, nice);
                            MessageBox.Show("Product ID no: " + id.Text + " has been added");

                            name.Enabled = false;
                            type.Enabled = false;
                            brand.Enabled = false;
                            price.Enabled = false;
                            stock.Enabled = false;
                            button1.Enabled = true;
                            button2.Enabled = true;
                            button3.Enabled = true;
                            button4.Enabled = true;
                            type.Visible = true;
                            button4.Enabled = false;
                            pictureBox1.Visible = false;
                            pictureBox1.Image = null;
                            comboBox1.Visible = false;
                            //status editor //

                            //---//
                            name.Text = null;
                            type.Text = null;
                            brand.Text = null;
                            price.Text = null;
                            stock.Text = null;
                            //
                            cntr = 0;
                            table1(); table2(); table3(); table4(); table5(); table6();
                            button3.Text = "Add Items";

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }

                    }

                    break;

            }// end of switch

        }//

        #endregion

        #region Validations 
        // TYPE KEYPRESS - VALIDATION /
        private void type_KeyPress(object sender, KeyPressEventArgs e)
        {
            //      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //(e.KeyChar != '.'))
            //      {
            //          e.Handled = true;
            //      }
        }

        // PRICE KEYPRESS - VALIDATION //
        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        // STOCK KEYPRESS - VALIDATION //
        private void stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        ( e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            string stock = this.stock.Text;
            loginfo.stock = stock;
        }

        #endregion

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (comboBox3.Text == "ID")
            // {
            //     DataView dv = new DataView(dbdataset);
            //     dv.RowFilter = string.Format("[Product ID] LIKE '%{0}%'", textBox1.Text);
            //     dataGridView1.DataSource = dv;
            //     dataGridView4.DataSource = dv;
            //     dataGridView5.DataSource = dv;
            //     dataGridView6.DataSource = dv;
            //     dataGridView7.DataSource = dv;
            //     dataGridView8.DataSource = dv;

            // }
            // else if (comboBox3.Text == "Name")
            // {
            //     DataView dv = new DataView(dbdataset);
            //     dv.RowFilter = string.Format(" [Product Name] LIKE '%{0}%'", textBox1.Text);
            //     dataGridView1.DataSource = dv;
            //     dataGridView4.DataSource = dv;
            //     dataGridView5.DataSource = dv;
            //     dataGridView6.DataSource = dv;
            //     dataGridView7.DataSource = dv;
            //     dataGridView8.DataSource = dv;
            // }
            // else if (comboBox3.Text == "Brand")
            // {
            //     DataView dv = new DataView(dbdataset);
            //     dv.RowFilter = string.Format(" Brand LIKE '%{0}%'", textBox1.Text);
            //     dataGridView1.DataSource = dv;
            //     dataGridView4.DataSource = dv;
            //     dataGridView5.DataSource = dv;
            //     dataGridView6.DataSource = dv;
            //     dataGridView7.DataSource = dv;
            //     dataGridView8.DataSource = dv;
            // }
            // else if (comboBox3.Text == "Status")
            // {
            //     DataView dv = new DataView(dbdataset);
            //     dv.RowFilter = string.Format(" Status LIKE '%{0}%'", textBox1.Text);
            //     dataGridView1.DataSource = dv;
            //     dataGridView4.DataSource = dv;
            //     dataGridView5.DataSource = dv;
            //     dataGridView6.DataSource = dv;
            //     dataGridView7.DataSource = dv;
            //     dataGridView8.DataSource = dv;
            // }// end of else
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login a = new Login();
            a.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String name = textBox1.Text;
                String choice = comboBox1.Text;


                MySqlConnection con = new MySqlConnection(mycon.conn);
                con.Open();
                if (comboBox3.SelectedItem == "ID")
                {
                    MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price' from sales.products where pid='" + name + "'", con);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    myDataAdapter.SelectCommand = cmdDatabase;
                    dbdataset = new DataTable();
                    myDataAdapter.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;
                    myDataAdapter.Update(dbdataset);
                }

                else if (comboBox3.SelectedItem == "Name")
                {
                    MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price' from sales.products where pname='" + name + "'", con);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    myDataAdapter.SelectCommand = cmdDatabase;
                    dbdataset = new DataTable();
                    myDataAdapter.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;
                    myDataAdapter.Update(dbdataset);
                }
                else if (comboBox3.SelectedItem == "Brand")
                {
                    MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price' from sales.products where pbrand='" + name + "'", con);
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                    myDataAdapter.SelectCommand = cmdDatabase;
                    dbdataset = new DataTable();
                    myDataAdapter.Fill(dbdataset);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = dbdataset;
                    dataGridView1.DataSource = bSource;
                    myDataAdapter.Update(dbdataset);
                }
                else if (comboBox3.SelectedItem == "Type")
                {
                    MySqlCommand cmdDatabase = new MySqlCommand("select pid as 'Product ID', pname as 'Product Name', ptype as 'Type',pbrand as 'Brand', pqty as 'Stocks',pprice as 'Price' from sales.products where ptype='" + name + "'", con);
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

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            --cntr;
            button1.Text = "UPDATE";
            button3.Text = "ADD ITEMS";
            dataGridView1.Visible = true;
            dataGridView4.Visible = true;
            dataGridView5.Visible = true;
            dataGridView6.Visible = true;
            dataGridView7.Visible = true;
            dataGridView8.Visible = true;

            pictureBox1.Image = null;
            id.Text = null;
            name.Text = null;
            type.Text = null;
            brand.Text = null;
            price.Text = null;
            stock.Text = null;

            comboBox1.Enabled = false;
            name.Enabled = false;
            type.Enabled = false;
            brand.Enabled = false;
            price.Enabled = false;
            stock.Enabled = false;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void stock_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}    
     // public partial
      
     // end of code

