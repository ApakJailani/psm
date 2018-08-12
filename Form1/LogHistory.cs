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
    public partial class LogHistory : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
        DataTable table = new DataTable();

        public LogHistory()
        {
            InitializeComponent();
        }

        private void LogHistory_Load(object sender, EventArgs e)
        {
            fillData();
        }

        public void fillData()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command;

            string query = "SELECT ID, Name, CardID as 'Card ID', VehicleID, Time, Status from log";
            command = new MySqlCommand(query, connection);
            adapter.SelectCommand = command;
            adapter.Fill(table); 
            dataGridView1.DataSource = table;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(table);
            dv.RowFilter = string.Format("VehicleID LIKE '%{0}%'", txtSearch.Text);
            dataGridView1.DataSource = dv;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
