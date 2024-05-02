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

namespace FinalLabPerformance
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string registrationFirstName = textBox4.Text;
            string registrationLastName = textBox3.Text;
            string registrationEmail = textBox1.Text;
            string registrationPassword = textBox2.Text;

            SqlConnection conn = new SqlConnection("Data Source=ANONYMOUS\\MSSQLSERVER2022;Initial Catalog=FinalLabPerformance;Persist Security Info=True;User ID=sa;Password=5321;Encrypt=True;TrustServerCertificate=True");

            string insertQuery = "INSERT INTO userList (firstName, lastName, email, password) VALUES ('" + registrationFirstName + "', '" + registrationLastName + "', '" + registrationEmail + "', '" + registrationPassword + "')";

            if (registrationFirstName.Length > 1 && registrationLastName.Length > 1 && registrationEmail.Length > 1 && registrationPassword.Length > 1)
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(insertQuery, conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                conn.Close();
                MessageBox.Show("Registration Has Been Successfull");
            }

            else
            {
                MessageBox.Show("Enter Valid Information");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
