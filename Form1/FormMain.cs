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
    public partial class FormMain : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
        DataTable table = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            fillDataUser();
        }

        public void fillDataUser()
        {
            
            MySqlCommand command;
            
            string query = "select name as 'Name', uid as 'Card ID', type as 'Vehicle Type', carid as 'Vehicle ID Number', time as 'Registration Date', status as 'Status' from user";
            command = new MySqlCommand(query, connection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report repo = new Report();
            repo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                serialPort1.Open();
                string entrada = serialPort1.ReadLine();
                serialPort1.Close();
                txtUid.Text = entrada;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cons = string.Format("INSERT INTO psm.user(name,uid,type,carid,time,status)VALUES('" + txtName.Text + "','" + txtUid.Text + "','" + txtType.Text + "','" + txtCarid.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','OUT')");
                //MySqlConnection sqlconn = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
                adapter = new MySqlDataAdapter(cons, connection);
                adapter.Fill(table);
                adapter.Update(table);
                MessageBox.Show("Success");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
            txtName.Clear();
            txtUid.Clear();
            txtType.Clear();
            txtCarid.Clear();

        }

        private void btnLogHistory_Click(object sender, EventArgs e)
        {
            LogHistory lg = new LogHistory();
            lg.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
