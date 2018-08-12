using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Form1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlconn = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
            string query = "Select * from login where username = '"+ txtUsername.Text.Trim() + "' and password = '"+txtPassword.Text.Trim() + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, sqlconn);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            if (dtb1.Rows.Count == 1)
            {
                FormMain objFormMain = new FormMain();
                this.Hide();
                objFormMain.Show();
            }
            else
            {
                MessageBox.Show("Check your USERNAME and PASSWORD");
                txtUsername.Text = "";
                txtPassword.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
