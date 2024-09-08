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
    public partial class Employees : Form
    {
        public Employees()
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
            SqlCommand saveEmployee = new SqlCommand("insert into employees values(@employee_id,@full_name,@position,@date_started,@salary)", conn);
            saveEmployee.Parameters.AddWithValue("@employee_id", txtEmployeeID.Text);
            saveEmployee.Parameters.AddWithValue("@full_name", txtFullName.Text);
            saveEmployee.Parameters.AddWithValue("@position", txtPosition.Text);
            saveEmployee.Parameters.AddWithValue("@date_started", dateStarted.Text);
            saveEmployee.Parameters.AddWithValue("@salary", float.Parse(txtSalary.Text));
            try
            {
                saveEmployee.ExecuteNonQuery();
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
            SqlCommand loadEmployees = new SqlCommand("select * from employees", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(loadEmployees);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            tableEmployees.DataSource = dataTable;
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2RQBE0K\LOCAL_TESTING;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand updateEmployee = new SqlCommand("update employees set full_name=@full_name,position=@position,date_started=@date_started,salary=@salary where employee_id=@employee_id", conn);
            updateEmployee.Parameters.AddWithValue("@employee_id", txtEmployeeID.Text);
            updateEmployee.Parameters.AddWithValue("@full_name", txtFullName.Text);
            updateEmployee.Parameters.AddWithValue("@position", txtPosition.Text);
            updateEmployee.Parameters.AddWithValue("@date_started", dateStarted.Text);
            updateEmployee.Parameters.AddWithValue("@salary", float.Parse(txtSalary.Text));
            try
            {
                updateEmployee.ExecuteNonQuery();
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
            SqlCommand deleteEmployee = new SqlCommand("delete employees where employee_id=@employee_id", conn);
            deleteEmployee.Parameters.AddWithValue("@employee_id", txtEmployeeID.Text);
            try
            {
                deleteEmployee.ExecuteNonQuery();
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
