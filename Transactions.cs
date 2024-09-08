using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand cnn = new SqlCommand("insert into transactions values(@transaction_id,@transaction_type,@amount,@date,@account_id)", conn);
            cnn.Parameters.AddWithValue("@transaction_id", int.Parse(txtTransactionID.Text));
            cnn.Parameters.AddWithValue("@transaction_type", dropdownType.Text);
            cnn.Parameters.AddWithValue("@amount", float.Parse(txtAmount.Text));
            cnn.Parameters.AddWithValue("@date", date.Value);
            cnn.Parameters.AddWithValue("@account_id", int.Parse(txtAccountID.Text));
            // v Balance update v
            SqlCommand getBalance = new SqlCommand("select balance from accounts where account_id=@account_id", conn);
            SqlCommand updateBalance = new SqlCommand("update accounts set balance=@balance where account_id=@account_id", conn);

            getBalance.Parameters.AddWithValue("@account_id", int.Parse(txtAccountID.Text));
            updateBalance.Parameters.AddWithValue("@account_id", int.Parse(txtAccountID.Text));

            double currBalance = Convert.ToDouble(getBalance.ExecuteScalar());
            double newBalance = 0.0;

            if (dropdownType.Text.ToLower() == "deposit")
            {
                newBalance = currBalance + Convert.ToDouble(txtAmount.Text);
            } else if (dropdownType.Text.ToLower() == "withdrawal" || dropdownType.Text == "payment")
            {
                newBalance = currBalance - Convert.ToDouble(txtAmount.Text);
            }

            updateBalance.Parameters.AddWithValue("@balance", newBalance);
            try
            {
                updateBalance.ExecuteNonQuery();
            } catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            // ^ Balance update ^
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
            SqlCommand cnn = new SqlCommand("select * from transactions", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cnn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            tableTransactions.DataSource = dataTable;
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand cnn = new SqlCommand("update transactions set transaction_type=@transaction_type,amount=@amount,date=@date,account_id=@account_id where transaction_id=@transaction_id", conn);
            cnn.Parameters.AddWithValue("@transaction_id", int.Parse(txtTransactionID.Text));
            cnn.Parameters.AddWithValue("@transaction_type", dropdownType.Text);
            cnn.Parameters.AddWithValue("@amount", int.Parse(txtAmount.Text));
            cnn.Parameters.AddWithValue("@date", date.Value);
            cnn.Parameters.AddWithValue("@account_id", int.Parse(txtAccountID.Text));
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
            SqlCommand cnn = new SqlCommand("delete transactions where transaction_id=@transaction_id", conn);
            cnn.Parameters.AddWithValue("@transaction_id", int.Parse(txtTransactionID.Text));
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
