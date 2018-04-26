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

            string query = "SELECT * from log";
            //string query = "SELECT idlog as 'ID' , name as 'Name' , uid as 'Card ID' , carid as 'Vehicle ID' , status as 'Status' , time as 'Time' from psm.log;";
            command = new MySqlCommand(query, connection);
            
            adapter.SelectCommand = command;
            
           
            /*table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Card ID");
            table.Columns.Add("Vehicle ID");
            table.Columns.Add("Status");
            table.Columns.Add("Time");*/

            adapter.Fill(table); 
            dataGridView1.DataSource = table;
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            DataView dv = new DataView(table);
            //dv.RowFilter = string.Format("'Vehicle ID' LIKE '%{0}%'", txtSearch.Text);
            dv.RowFilter = string.Format("VehicleID LIKE '%{0}%'", txtSearch.Text);
            //dv.RowFilter = string.Format("SELECT * FROM log WHERE carid = " + txtSearch.Text);
            //dataGridView1.DataSource = bs;
            dataGridView1.DataSource = dv;
        }
    }
}
