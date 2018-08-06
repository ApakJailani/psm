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
    public partial class Report : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
        DataTable table = new DataTable();
        DataSet ds = new DataSet();
        MySqlDataAdapter adapter;
        MySqlCommand command;

        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            connection.Open();
            //string sql = " SELECT Name , CardID , VehicleID ,Date, min(Time) as 'IN' , max(Time) as 'OUT', (max(Time)-min(Time)) as 'TOTAL'from log group by Name, Date order by Date";
            string sql = " SELECT Name , CardID , VehicleID , Date, min(Time) as 'IN' , max(Time) as 'OUT', " + " (((max(Time)) - (min(Time))) % (60*60*24)) /(60*60) || ':' || ((((max(Time)) - (min(Time))) % (60*60*24)) %(60*60))/60 as 'TOTAL' from log group by Name , Date order by Date";
            //string sql = " SELECT Name , CardID , VehicleID ,Date, min(Time) as 'IN' , max(Time) as 'OUT', (((max(Time)) - (min(Time))) % (60*60*24)) /(60*60) as 'TOTAL' from log group by Name";
            //string sql = " SELECT Name , CardID , VehicleID ,Date, min(Time) as 'IN' , max(Time) as 'OUT', ((((max(Time)) - (min(Time))) % (60*60*24)) % (60*60))/60 as 'TOTAL' from log group by Name";
            command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            
        }

    }
}
