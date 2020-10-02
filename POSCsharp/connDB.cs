using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace POSCsharp
{
    class connDB
    {
        #region LOGIN CONNECTIONS
        //Cashier Login
        public static bool Clogin(string uname1, string pass, string type)
        {
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand("SELECT * FROM accounts WHERE uname = '" + uname1 + "' AND pass = '" + pass + "' AND type = '" + type + "';", myConn);
            MySqlDataAdapter SDA = new MySqlDataAdapter();
            MySqlDataReader myReader;

            myConn.Open();
            myReader = myComm.ExecuteReader();
            int counter = 0;
            while (myReader.Read())
                counter += 1;
            myConn.Close();
            if (counter == 1)
                return true;
            else
                return false;
        }

        #endregion

        #region ACCOUNT MANIPULATION
        // ID GENETATOR - DISPLAY NEXT ID CONNECTIONS
        public void nextid()
        {
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand("Select ID From sales.accounts", myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            while (myreader.Read())
            {
                loginfo.id = myreader["ID"].ToString();
            }
            myConn.Close();
        }

        // ADD ACCOUNT
        public void addAcc(String id, String fname, String lname, String uname, String pass, String type)
        {
            String query = "insert into sales.accounts values ('" + id + "','" + fname + "','" + lname + "','" + uname + "','" + pass + "','" + type + "')";
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            myConn.Close();
        }

        // EDIT ACCOUNT
        public void editAcc(String id, String fname, String lname, String uname, String pass)
        {
            string query = "update sales.accounts set fname= '" + fname + "', lname='" + lname + "', uname='" + uname + "', pass='" + pass + "' where ID = '" + id + "'";
            MySqlConnection myCon = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myCon);
            MySqlDataReader myReader;

            myCon.Open();
            myReader = myComm.ExecuteReader();
            myCon.Close();
        }

        // Delete Account
        public void delAcc(String id)
        {
            string Query = "delete from sales.accounts where id = '" + id + "'";
            MySqlConnection myCon = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(Query, myCon);
            MySqlDataReader myReader;

            myCon.Open();
            myReader = myComm.ExecuteReader();
            myCon.Close();
        }

        #endregion

        #region SALES MANIPULATION

        // NEXT ID - TRANSACTIONS
        public void ntid()
        {
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand("Select tid From sales.transaction", myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            while (myreader.Read())
            {
                loginfo.tid = myreader["tid"].ToString();
            }
            myConn.Close();
        }



        // ADD TO CART - TRANSACTIONS
        public void transac(String ID, String CID, String PID, String PNAME, String PTYPE, String PBRAND, String PQTY, String TOTAL, String Date, String ST)
        {
            String query = "insert into sales.transaction values ('" + ID + "','" + PID  + "','" + CID + "','" + PNAME + "','" + PTYPE + "','" + PBRAND + "','" + PQTY + "','" + TOTAL + "','" + Date + "','" + ST + "')"; 
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myConn);
            MySqlDataReader myReader;
            myConn.Open();
            myReader = myComm.ExecuteReader();
            myConn.Close();
        }

       


        //LESS TO DB // 
        public void updateStock(String PID1, String PNAME1, String PTYPE1, String PBRAND1, String PQTY1, String PPRICE1)
        {
            string query = "update sales.products set pname= '" + PNAME1 + "', ptype='" + PTYPE1 + "', pbrand='" + PBRAND1 + "', pqty='" + PQTY1 + "', pprice='" + PPRICE1 + "' where pid = '" + PID1 + "'";
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myConn);
            MySqlDataReader myReader;

            myConn.Open();
            myReader = myComm.ExecuteReader();
            myConn.Close();
        }
        #endregion

        #region INVENTORY MANIPULATION
        //NEXT ID //
        public void npid()
        {
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand("Select pid From sales.products", myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            while (myreader.Read())
            {
                loginfo.pid = myreader["pid"].ToString();
            }
            myConn.Close();
        }

        // EDIT STOCKS //
        public void editIn(String PID, String PNAME, String PTYPE, String PBRAND, String PQTY, String PPRICE, byte[] img)
        {
            MySqlConnection connection = new MySqlConnection("dataSource = localhost; Initial Catalog = sales; username = root; Password = ");
            MySqlCommand command;
            string query = "update sales.products set pname=   @PNAME  , ptype= @PTYPE , pbrand= @PBRAND , pqty= @PQTY , pprice= @PPRICE , pic =@img where pid =  @PID  ";
            MySqlConnection myCon = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myCon);

            try
            {
                connection.Open();
                command = new MySqlCommand(query, connection);
                command.Parameters.Add("@PID", MySqlDbType.Int32, 11);
                command.Parameters.Add("@PNAME", MySqlDbType.VarChar, 100);
                command.Parameters.Add("@PTYPE", MySqlDbType.VarChar, 50);
                command.Parameters.Add("@PBRAND", MySqlDbType.VarChar, 50);
                command.Parameters.Add("@PQTY", MySqlDbType.Int32, 11);
                command.Parameters.Add("@PPRICE", MySqlDbType.Int32, 11);
                command.Parameters.Add("@img", MySqlDbType.Blob, 250000);

                command.Parameters["@PID"].Value = PID;
                command.Parameters["@PNAME"].Value = PNAME;
                command.Parameters["@PTYPE"].Value = PTYPE;
                command.Parameters["@PBRAND"].Value = PBRAND;
                command.Parameters["@PQTY"].Value = PQTY;
                command.Parameters["@PPRICE"].Value = PPRICE;
                command.Parameters["@img"].Value = img;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Inserted");
                }

                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }



        //PENDING DELIVERY
        public void pendingdelivery(int pdid,String pdname, String pdbrand, String pdtype, int pdqty, int pdprice, String approval)
        {
            MySqlConnection connection = new MySqlConnection("dataSource = localhost; Initial Catalog = sales; username = root; Password = ");
            MySqlCommand command;
            int id = pdid;
            string name = pdname;
            string brand = pdbrand;
            string type = pdtype;
            int qty = pdqty;
            int price = pdprice;
            string appr = approval;

            string query = "insert into sales.pendingdelivery (pdid,pdname,pdbrand,pdtype,pdqty,pdprice,approval) values (@id,@name,@brand,@type,@qty,@price,@appr)";
            try
            {
                connection.Open();
                command = new MySqlCommand(query, connection);
                command.Parameters.Add("@id", MySqlDbType.Int32, 11);
                command.Parameters.Add("@name", MySqlDbType.VarChar, 100);
                command.Parameters.Add("@brand", MySqlDbType.VarChar, 100);
                command.Parameters.Add("@type", MySqlDbType.VarChar, 100);
                command.Parameters.Add("@qty", MySqlDbType.Int32, 100);
                command.Parameters.Add("@price", MySqlDbType.Int32, 100);
                command.Parameters.Add("@appr", MySqlDbType.Text, 100);

                command.Parameters["@id"].Value = id;
                command.Parameters["@name"].Value = name;
                command.Parameters["@brand"].Value = brand;
                command.Parameters["@type"].Value = type;
                command.Parameters["@qty"].Value = qty;
                command.Parameters["@price"].Value = price;
                command.Parameters["@appr"].Value = appr;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Delivery Pending!");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }




        //adding and removing pending to delivery
        public void pendingtodelivery(String did, String dname, String dbrand, String dtype, String dqty, String dprice, String datepurchased, String datetobedelivered)
        {
            /* //change pending to delivery
             string query = "update pos.pendingdelivery set approval= '" + appr + "' where ID = '" + pdid + "'";
             MySqlConnection myCon = new MySqlConnection(mycon.conn);
             MySqlCommand myComm = new MySqlCommand(query, myCon);
             MySqlDataReader myReader;
             myCon.Open();
             myReader = myComm.ExecuteReader();
             myCon.Close();

         */

            String query = "insert into sales.delivery values ('" + did + "','" + dname + "','" + dbrand + "','" + dtype + "','" + dqty + "','" + dprice + "','" + datepurchased + "','" + datetobedelivered + "')";
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            myConn.Close();



        }



        public void deletepending (String pdid)
        {

            string Query = "delete from sales.pendingdelivery where pdid = '" + pdid + "'";
            MySqlConnection myCon = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(Query, myCon);
            MySqlDataReader myReader;

            myCon.Open();
            myReader = myComm.ExecuteReader();
            myCon.Close();
        }


        public void additemsnew(String pid, String pname, String ptype, String pbrand, String pqty, String pprice, byte[] img)
        {
            MySqlConnection connection = new MySqlConnection("dataSource = localhost; Initial Catalog = sales; username = root; Password = ");
            MySqlCommand command;
            Random rnd = new Random();
            int nice = rnd.Next(52);
            string id = pid;
            string name = pname;
            string Type = ptype;
            string Brand = pbrand;
            string qty = pqty;
            string Price = pprice;

            //MemoryStream ms = new MemoryStream();
            //pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            //byte[] img = ms.ToArray();
            //  String insertQuery = "INSERT INTO Eztan.inventory VALUES ('" + name + "','" + stocks + "','" + img + "','" + id + "')";
            String insertQuery = "INSERT INTO sales.products (pid,pname,ptype,pbrand,pqty,pprice,pic) VALUES(@id, @name, @Type, @Brand, @qty, @Price, @img)";

            try
            {
                connection.Open();
                command = new MySqlCommand(insertQuery, connection);
                command.Parameters.Add("@id", MySqlDbType.Int32, 11);
                command.Parameters.Add("@name", MySqlDbType.VarChar, 100);
                command.Parameters.Add("@Type", MySqlDbType.VarChar, 50);
                command.Parameters.Add("@Brand", MySqlDbType.VarChar, 50);
                command.Parameters.Add("@qty", MySqlDbType.Int32, 11);
                command.Parameters.Add("@Price", MySqlDbType.Int32, 11);

                command.Parameters.Add("@img", MySqlDbType.Blob, 250000);

                command.Parameters["@id"].Value = id;
                command.Parameters["@name"].Value = name;
                command.Parameters["@Type"].Value = Type;
                command.Parameters["@Brand"].Value = Brand;
                command.Parameters["@qty"].Value = qty;
                command.Parameters["@Price"].Value = Price;

                command.Parameters["@img"].Value = img;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Inserted");
                }

                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        public void hist(String hid,String cid, String hname, String htype, String hbrand, String hqty, String htotal, String date)
        {
            String query = "insert into sales.history values ('" + hid + "','" + cid + "','"+ hname + "','" + htype + "','" + hbrand + "','" + hqty + "','" + htotal + "','" + date + "')"; ;
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            myConn.Close();
        }


        public void adddelivery(String did, String dname, String dbrand, String dtype, String dqty,String dprice, String datepurchased, String datetobedelivered)
        {
            String query = "insert into sales.delivery values ('" + did + "','" + dname + "','" + dbrand + "','" + dtype + "','" + dqty + "','" + dprice + "','" + datepurchased + "','" + datetobedelivered + "')";
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            myConn.Close();
        }

        // DELETE STOCKS //
        public void delIn(String id1)
        {
            string Query = "delete from sales.products where pid = '" + id1 + "'";
            MySqlConnection myCon = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(Query, myCon);
            MySqlDataReader myReader;

            myCon.Open();
            myReader = myComm.ExecuteReader();
            myCon.Close();
        }

        // ADD ITEMS //
        public void addItems(String pid, String pname, String ptype, String pbrand, String pqty, String pprice)
        {
            String query = "insert into sales.products values ('" + pid + "','" + pname + "','" + ptype + "','" + pbrand + "','" + pqty + "','" + pprice +  "')";
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            myConn.Close();
        }

        #endregion

        #region UPDATE CART MANIP

        //public void updateDel(String PID1, String PNAME1, String PTYPE1, String PBRAND1, String PQTY1, String PPRICE1)
        //{
        //    string query = "update pos.products set pname= '" + PNAME1 + "', ptype='" + PTYPE1 + "', pbrand='" + PBRAND1 + "', pqty='" + PQTY1 + "', pprice='" + PPRICE1 + "' where pid = '" + PID1 + "'";
        //    MySqlConnection myConn = new MySqlConnection(mycon.conn);
        //    MySqlCommand myComm = new MySqlCommand(query, myConn);
        //    MySqlDataReader myReader;

        //    myConn.Open();
        //    myReader = myComm.ExecuteReader();
        //    myConn.Close();
        //}

        public void updateDel(String PID1, String PNAME1, String PTYPE1, String PBRAND1, String PQTY1, String PPRICE1)
        {
            MySqlConnection connection = new MySqlConnection("dataSource = localhost; Initial Catalog = sales; username = root; Password = ");
            MySqlCommand command;
            String query = "update sales.products set pname=@pname1, ptype =@ptype1, pbrand=@pbrand1 , pqty =@pqty1 ,pprice = @pprice1 where pid= @pid1 ";
            MySqlConnection myCon = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(query, myCon);

            try
            {
                connection.Open();
                command = new MySqlCommand(query, connection);
                command.Parameters.Add("@pid1", MySqlDbType.Int32, 11);
                command.Parameters.Add("@pname1", MySqlDbType.VarChar, 100);
                command.Parameters.Add("@ptype1", MySqlDbType.VarChar, 50);
                command.Parameters.Add("@pbrand1", MySqlDbType.VarChar, 50);
                command.Parameters.Add("@pqty1", MySqlDbType.Int32, 11);
                command.Parameters.Add("@pprice1", MySqlDbType.Int32, 11);


                command.Parameters["@pid1"].Value = PID1;
                command.Parameters["@pname1"].Value = PNAME1;
                command.Parameters["@ptype1"].Value = PTYPE1;
                command.Parameters["@pbrand1"].Value = PBRAND1;
                command.Parameters["@pqty1"].Value = PQTY1;
                command.Parameters["@pprice1"].Value = PPRICE1;


                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Inserted");
                }

                connection.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }


        #endregion

        #region Customer
        public void nexcust()
        {
            MySqlConnection myConn = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand("Select custId From sales.customer", myConn);
            MySqlDataReader myreader;
            myConn.Open();
            myreader = myComm.ExecuteReader();
            while (myreader.Read())
            {
                loginfo.custId = myreader["custId"].ToString();
            }
            myConn.Close();
        }

        #endregion

        #region delete to transaction - Remove Cart
        public void delTrans(String id)
        {
            string Query = "delete from sales.transaction where tid = '" + id + "'";
            MySqlConnection myCon = new MySqlConnection(mycon.conn);
            MySqlCommand myComm = new MySqlCommand(Query, myCon);
            MySqlDataReader myReader;

            myCon.Open();
            myReader = myComm.ExecuteReader();
            myCon.Close();
        }



        #endregion
    }
}


