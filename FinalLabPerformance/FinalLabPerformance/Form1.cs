using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using System.Data.SqlClient;

namespace FinalLabPerformance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Hide();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            SqlConnection conn = new SqlConnection("Data Source=ANONYMOUS\\MSSQLSERVER2022;Initial Catalog=FinalLabPerformance;Persist Security Info=True;User ID=sa;Password=5321;Encrypt=True;TrustServerCertificate=True");
            string CommandText = "SELECT * FROM userList WHERE email='" + email + "' AND password='" + password + "'";

            conn.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandText, conn);
            sqlDataAdapter.Fill(dataTable);
            conn.Close();

            if (dataTable.Rows.Count == 1)
            {
                Hide();
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }

            else
            {
                MessageBox.Show("Your Credintials Are Wrong");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
