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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand getTotalCustomers = new SqlCommand("select count(*) from customers",conn);
            SqlCommand getTotalEmployees = new SqlCommand("select count(*) from employees",conn);
            SqlCommand getTotalAccounts = new SqlCommand("select count(*) from accounts",conn);
            SqlCommand getTotalTransactions = new SqlCommand("select count(*) from transactions",conn);
            SqlCommand getTotalLoans = new SqlCommand("select count(*) from loans",conn);

            txtCustomers.Text = getTotalCustomers.ExecuteScalar().ToString();
            txtEmployees.Text = getTotalEmployees.ExecuteScalar().ToString();
            txtAccounts.Text = getTotalAccounts.ExecuteScalar().ToString() ;
            txtTransactions.Text = getTotalTransactions.ExecuteScalar().ToString();
            txtLoans.Text = getTotalLoans.ExecuteScalar().ToString();

            conn.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Dashboard_Load(sender, e);
        }
    }
}
