using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalLabPerformance
{
    public partial class DeleteUserDialogue : Form
    {
        public static string deleteEmail;
        private readonly SqlConnection conn = new SqlConnection("Data Source=ANONYMOUS\\MSSQLSERVER2022;Initial Catalog=FinalLabPerformance;Persist Security Info=True;User ID=sa;Password=5321;Encrypt=True;TrustServerCertificate=True");
        public DeleteUserDialogue()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteUserDialogue_Load(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            string CommandText = "SELECT * FROM userList WHERE email='"+ deleteEmail +"'";

            conn.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandText, conn);
            sqlDataAdapter.Fill(dataTable);
            conn.Close();

            dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string CommandText = "DELETE FROM userList WHERE email='" + deleteEmail + "'";
            conn.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CommandText, conn);
            sqlDataAdapter.Fill(dataTable);
            conn.Close();

            Hide();
        }
    }
}
