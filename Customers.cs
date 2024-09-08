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

namespace BMS
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand cnn = new SqlCommand("insert into customers values(@customer_id,@customer_name,@phone,@email,@address)", conn);
            cnn.Parameters.AddWithValue("@customer_id", int.Parse(txtCustomerID.Text));
            cnn.Parameters.AddWithValue("@customer_name", txtCustomerName.Text);
            cnn.Parameters.AddWithValue("@phone", txtPhone.Text);
            cnn.Parameters.AddWithValue("@email", txtEmail.Text);
            cnn.Parameters.AddWithValue("@address", txtAddress.Text);
            try
            {
                cnn.ExecuteNonQuery();
                MessageBox.Show("Record saved");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand cnn = new SqlCommand("select * from customers", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cnn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            tableCustomers.DataSource = dataTable;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand cnn = new SqlCommand("update customers set customer_name=@customer_name,phone=@phone,email=@email,address=@address where customer_id=@customer_id", conn);
            cnn.Parameters.AddWithValue("@customer_id", int.Parse(txtCustomerID.Text));
            cnn.Parameters.AddWithValue("@customer_name", txtCustomerName.Text);
            cnn.Parameters.AddWithValue("@phone", txtPhone.Text);
            cnn.Parameters.AddWithValue("@email", txtEmail.Text);
            cnn.Parameters.AddWithValue("@address", txtAddress.Text);
            try
            {
                cnn.ExecuteNonQuery();
                MessageBox.Show("Record updated");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand cnn = new SqlCommand("delete customers where customer_id=@customer_id", conn);
            cnn.Parameters.AddWithValue("@customer_id", int.Parse(txtCustomerID.Text));
            try
            {
                cnn.ExecuteNonQuery();
                MessageBox.Show("Record deleted");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            conn.Close();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }
    }
}
