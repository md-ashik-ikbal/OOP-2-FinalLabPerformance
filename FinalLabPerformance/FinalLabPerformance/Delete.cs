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
    public partial class Delete : Form
    {
        // public string deleteEmail;
        public Delete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteEmail = textBox1.Text;
            // DeleteUserDialogue deleteUserDialogue1 = new DeleteUserDialogue();
            DeleteUserDialogue.deleteEmail = deleteEmail;
            SqlConnection conn = new SqlConnection("Data Source=ANONYMOUS\\MSSQLSERVER2022;Initial Catalog=FinalLabPerformance;Persist Security Info=True;User ID=sa;Password=5321;Encrypt=True;TrustServerCertificate=True");
            string checkEmailCommand = "SELECT * FROM userList WHERE email='" + deleteEmail + "'";

            conn.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(checkEmailCommand, conn);
            sqlDataAdapter.Fill(dataTable);
            conn.Close();

            if (dataTable.Rows.Count == 1 )
            {
                label3.Text = null;
                DeleteUserDialogue deleteUserDialogue = new DeleteUserDialogue();
                deleteUserDialogue.ShowDialog();
            }

            else
            {
                label3.Text = "Email doesn's exist";
            }
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            label3.Text = "";
        }
    }
}
