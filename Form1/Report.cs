using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;


namespace Form1
{
    public partial class Report : Form
    {
       
        //MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
        //DataTable table = new DataTable();
        //DataSet ds = new DataSet();
        //MySqlDataAdapter adapter;
        //MySqlCommand command;
        
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            //connection.Open();
            //string sql = " SELECT Name , CardID , VehicleID ,Date, min(Time) as 'IN' , max(Time) as 'OUT', ((max(Time)-min(Time))%(60*60*24))/(60*60) as 'TOTAL'from log group by Name, Date order by Date";
            ////string sql = " SELECT Name , CardID , VehicleID , Date, min(Time) as 'IN' , max(Time) as 'OUT', (((max(Time)) - (min(Time))) % (60*60*24)) /(60*60) as 'HOURS', ((((max(Time)) - (min(Time))) % (60*60*24)) % (60*60))/(60) as 'MINUTE' from log group by Name";
            ////string sql = " SELECT Name , CardID , VehicleID ,Date, min(Time) as 'IN' , max(Time) as 'OUT', (((max(Time)) - (min(Time))) % (60*60*24)) /(60*60) as 'TOTAL' from log group by Name ,Date order by Date";
            ////string sql = " SELECT Name , CardID , VehicleID ,Date, min(Time) as 'IN' , max(Time) as 'OUT', ((((max(Time)) - ((min(Time))) % (60*60*24)) % (60*60))/60) as 'TOTAL' from log group by Name ,Date order by Date";
            //command = new MySqlCommand(sql, connection);
            //command.ExecuteNonQuery();
            //adapter = new MySqlDataAdapter(command);
            //adapter.Fill(table);
            //dataGridView1.DataSource = table;

            //connection.Open();
            //DateTime date2 = Convert.ToDateTime("min(Time)");
            //DateTime date1 = Convert.ToDateTime("SELECT min(Time) from log group by Name");

            //    //TimeSpan span = date2 - date1;
            //    //int hours = span.Hours;
            //    //int minute = span.Minutes;
            //    //txt1.Text = hours.ToString();
            //    //txt2.Text = minute.ToString();

            //    //string query = " SELECT Name , CardID , VehicleID , " + date1 + " as 'IN' , " + date2 + " as 'OUT' , " + hours.ToString() + " as 'HOURS' ," + minute.ToString() + " as 'MINUTE' from log group by Name";
            //    string query = " SELECT Name , CardID , VehicleID , "+DateTime.MaxValue+"," + date2.Subtract(date1).Hours + " as 'HOURS' ," + date2.Subtract(date1).Minutes + " as 'MINUTE' from log ";
            //    command = new MySqlCommand(query, connection);
            //    command.ExecuteNonQuery();
            //    adapter = new MySqlDataAdapter(command);
            //    adapter.Fill(table);
            //    dataGridView1.DataSource = table;

            try
            {
                string sql = " select Name , Date, CardID , VehicleID , min( Time) as 'IN' , max( Time) as 'OUT' , " +
                             " CAST(TIMESTAMPDIFF(HOUR,min(Time),max(Time))/60 + TIMESTAMPDIFF(MINUTE,min(Time),max(Time)) AS SIGNED)  as 'Total in Minute' " +
                             //" CAST(TIMESTAMPDIFF(MINUTE,min(Time),max(Time)) AS TIME) as 'HOURS - HH:MM' " +
                             " from log  group by Name ,Date order by Date";




                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                dataGridView1.DataSource = dt1;
            }
            catch (Exception errr)
            {
                MessageBox.Show("Error " + errr.Message);
            }
        } 
            
    }
}

