using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace formwarmup.NewFolder1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabControl1.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1 SqlConnection
            //2 Command
            //3 SqlDate Reader
            //4 UI Control
            
            
            
            SqlConnection cnn = null;



            try
            {
                cnn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True");
                cnn.Open();
                SqlCommand com = new SqlCommand("Select*from Products", cnn);
                SqlDataReader  dataReader= com.ExecuteReader();
                
                while (dataReader.Read())
                {
                    string s = $"{dataReader["ProductName"],-40}-{dataReader["UnitPrice"]:c2}";
                    //listBox1.Items.Add(dataReader["ProductName"]+" "+ dataReader["UnitPrice"]);
                    listBox1.Items.Add(s);
                }
                
                cnn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(cnn != null)
                {
                    cnn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True");
            SqlDataAdapter adapter = new SqlDataAdapter("select*from Products",conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True");
            SqlDataAdapter adapter = new SqlDataAdapter("select*from Categories", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True");
            SqlDataAdapter adapter = new SqlDataAdapter("select*from Products where UnitPrice > 30", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = AdventureWorks2019; Integrated Security = True");
            //SqlDataAdapter adapter = new SqlDataAdapter("select*from Product(Production) ", conn);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);
            //this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter1.Fill(this.northwindDataSet1.Categories);
            this.dataGridView2.DataSource = this.northwindDataSet1.Categories;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(this.northwindDataSet1.Products);
            this.dataGridView2.DataSource = this.northwindDataSet1.Products;
        }
    }
}
