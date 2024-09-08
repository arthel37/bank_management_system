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
    public partial class Loans : Form
    {
        public Loans()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand insertLoan = new SqlCommand("insert into loans values(@loan_id,@loan_type,@amount,@date,@interest_rate,@customer_id)", conn);
            insertLoan.Parameters.AddWithValue("@loan_id", txtLoanID.Text);
            insertLoan.Parameters.AddWithValue("@loan_type", dropdownType.Text);
            insertLoan.Parameters.AddWithValue("@amount", txtAmount.Text);
            insertLoan.Parameters.AddWithValue("@date", date.Value);
            insertLoan.Parameters.AddWithValue("@interest_rate", txtInterestRate.Text);
            insertLoan.Parameters.AddWithValue("@customer_id", txtCustomerID.Text);
            try
            {
                insertLoan.ExecuteNonQuery();
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
            SqlCommand loadLoans = new SqlCommand("select * from loans", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(loadLoans);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            tableLoans.DataSource = dataTable;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand updateLoan = new SqlCommand("update loans set loan_type=@loan_type,amount=@amount,date=@date,interest_rate=@interest_rate,customer_id=@customer_id where loan_id=@loan_id", conn);
            updateLoan.Parameters.AddWithValue("@loan_id", txtLoanID.Text);
            updateLoan.Parameters.AddWithValue("@loan_type", dropdownType.Text);
            updateLoan.Parameters.AddWithValue("@amount", txtAmount.Text);
            updateLoan.Parameters.AddWithValue("@date", date.Value);
            updateLoan.Parameters.AddWithValue("@interest_rate", txtInterestRate.Text);
            updateLoan.Parameters.AddWithValue("@customer_id", txtCustomerID.Text);
            try
            {
                updateLoan.ExecuteNonQuery();
                MessageBox.Show("Record updated");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            conn.Close();
        }

        private void Loans_Load(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand deleteLoan = new SqlCommand("delete loans where loan_id=@loan_id", conn);
            deleteLoan.Parameters.AddWithValue("@loan_id", txtLoanID.Text);
            try
            {
                deleteLoan.ExecuteNonQuery();
                MessageBox.Show("Record deleted");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            conn.Close();
        }
    }
}
