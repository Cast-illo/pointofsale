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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;



namespace POSCsharp
{
  
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("dataSource = localhost; Initial Catalog = sales; username = root; Password = ");
        MySqlCommand command;
        DataTable dbdataset;
        public Form1()
        {
            InitializeComponent();
        }

        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = this.dateTimePicker1.Text;
        }

        public void table1()
        {
            MySqlConnection con = new MySqlConnection(mycon.conn);
            MySqlCommand cmdDatabase = new MySqlCommand("select did as ' ID', dname as ' Name', dtype as 'Type',dbrand as 'Brand',dtype as 'Type', dqty as 'Stocks',datepurchased as 'Date',datetobedelivered as 'DateDelivery' from sales.delivery ;", con);

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


        private void button1_Click(object sender, EventArgs e)
        {
           DateTime date = this.dateTimePicker1.Value; 
           DateTime date1 = DateTime.Now;
           int res = DateTime.Compare(date, date1);
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("enter a date");
            }
            else { 
                if (res > 0)
                {
                    MessageBox.Show("bruh you a time traveller");
                }
                else
                {
                    Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                    PdfWriter write = PdfWriter.GetInstance(doc, new FileStream("Reports.pdf", FileMode.Create));
                    doc.Open();


                    Paragraph paragraph = new Paragraph("REPORTS    " + date1 + "\n \n");
                    
                    Chunk c1 = new Chunk("ORDERS PURCHASED \n");
                    paragraph.Add(c1);


                    doc.Add(paragraph);
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("show the table");
                    }
                    else
                    {


                        PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            table.AddCell(new Phrase(dataGridView1.Columns[i].HeaderText));
                        }
                        table.HeaderRows = 1;

                        for (int a = 0; a < dataGridView1.Rows.Count; a++)
                        {
                            for (int b = 0; b < dataGridView1.Columns.Count; b++)
                            {
                                if (dataGridView1[b, a].Value != null)
                                {
                                    table.AddCell(new Phrase(dataGridView1[b, a].Value.ToString()));
                                }
                            }
                        }
                        doc.Add(table);


                    }
                    Paragraph para = new Paragraph("NUMBER OF SALES ON RECENT");
                    doc.Add(para);
                    if (chart1.Equals(null))
                    {
                        MessageBox.Show("show the chart");
                    }
                    else
                    {

                        var chartimage = new MemoryStream();
                        chart1.SaveImage(chartimage, ChartImageFormat.Png);
                        iTextSharp.text.Image Chart_Image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
                        doc.Add(Chart_Image);

                       
                    }

                    try
                    {
                        
                        connection.Close(); 
                        connection.Open();
                        MySqlCommand com;
                        //number of overall sum of revenue 
                        Chunk c5 = new Chunk("Overall Sum of Revenue    " + this.dateTimePicker1.Text + "\n");
                        Paragraph para1 = new Paragraph();
                        com = new MySqlCommand("select sum(revenue) from sales.reports where DatePurchased='" + this.dateTimePicker1.Text + "'", connection);
                        var obj = com.ExecuteScalar();
                        int rev = Convert.ToInt32(obj);
                        //MessageBox.Show(rev.ToString());
                        string rev2 = rev.ToString();
                        Chunk c3 = new Chunk(rev2);
                        para1.Add(c5);
                        para1.Add(c3);
                        doc.Add(para1);


                        Paragraph para2 = new Paragraph("Number of Sales  " + this.dateTimePicker1.Text+ "\n");
                        //number of sales
                        com = new MySqlCommand("select count(revenue) from sales.reports where DatePurchased='" + this.dateTimePicker1.Text + "'", connection);
                        var obj1 = com.ExecuteScalar();
                        int rev1 = Convert.ToInt32(obj1);
                        //MessageBox.Show(rev.ToString());
                        string rev3 = rev1.ToString();
                        Chunk c4 = new Chunk(rev3);
                        para2.Add(c4);
                        doc.Add(para2);
                        doc.Close();
                        connection.Close();

                    }
                    catch (System.InvalidCastException)
                    {
                        MessageBox.Show("entered date doesnt have record");
                    }

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Close();
                connection.Open();
                command = new MySqlCommand("select *  from sales.reports", connection);

                MySqlDataReader reader = command.ExecuteReader();
                Series sr = new Series();
                while (reader.Read())
                {
                    //DateTime today = DateTime.Today;
                    //today = reader.GetDateTime("datePurchased");
                    //MessageBox.Show(today.ToShortDateString());

                    this.chart1.Series["SALES"].Points.AddXY(reader.GetDateTime("datePurchased").ToShortDateString(), reader.GetInt32("Revenue"));

                    chart1.ChartAreas[0].AxisX.Title = "Dates";
                    chart1.ChartAreas[0].AxisY.Title = "Sales";
                }
                connection.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            table1();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, 7);
            DateTime myDateTime = DateTime.Now;
            String sqlFormattedDate = myDateTime.Date.ToString("yyyy-mm-dd");
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            DateTime newDateTime = new DateTime();
            TimeSpan NumberOfDays = new TimeSpan(dice, 0, 0, 0, 0);
            newDateTime = dateTime.Add(NumberOfDays);
            String nice = newDateTime.ToString();


            MessageBox.Show(dice.ToString());
            MessageBox.Show(nice);
            MessageBox.Show(myDateTime.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();


        }
    }
    }


