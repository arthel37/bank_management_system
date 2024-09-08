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
    public partial class Accounts : Form
    {
        public Accounts()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand cnn = new SqlCommand("insert into accounts values(@account_id,@account_type,@balance,@date_opened,@owners_id)", conn);
            cnn.Parameters.AddWithValue("@account_id", int.Parse(txtAccountID.Text));
            cnn.Parameters.AddWithValue("@account_type", dropdownType.Text);
            cnn.Parameters.AddWithValue("@balance", txtBalance.Text);
            cnn.Parameters.AddWithValue("@date_opened", dateOpened.Value);
            cnn.Parameters.AddWithValue("@owners_id", txtOwnersID.Text);
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand cnn = new SqlCommand("select * from accounts", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cnn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            tableAccounts.DataSource = dataTable;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand cnn = new SqlCommand("update accounts set account_type=@account_type,balance=@balance,date_opened=@date_opened,owners_id=@owners_id where account_id=@account_id", conn);
            cnn.Parameters.AddWithValue("@account_id", int.Parse(txtAccountID.Text));
            cnn.Parameters.AddWithValue("@account_type", dropdownType.Text);
            cnn.Parameters.AddWithValue("@balance", float.Parse(txtBalance.Text));
            cnn.Parameters.AddWithValue("@date_opened", dateOpened.Value);
            cnn.Parameters.AddWithValue("@owners_id", int.Parse(txtOwnersID.Text));
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
            SqlCommand cnn = new SqlCommand("delete accounts where account_id=@account_id", conn);
            cnn.Parameters.AddWithValue("@account_id", int.Parse(txtAccountID.Text));
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

        private void Accounts_Load(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand cnn = new SqlCommand("select * from accounts where owners_id=@owners_id", conn);
            if (txtSearchBar.Text == "")
            {
                cnn.Parameters.AddWithValue("@owners_id", DBNull.Value);
            }
            else 
            {
                cnn.Parameters.AddWithValue("@owners_id", int.Parse(txtSearchBar.Text));
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cnn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            conn.Close();
            tableAccounts.DataSource = dataTable;
        }
    }
}
