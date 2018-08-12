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
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = " select Name , Date, CardID , VehicleID , CAST(min( Time) AS TIME) as 'IN' , CAST(max( Time) AS TIME) as 'OUT' , " +
                             " CAST(TIMESTAMPDIFF(HOUR,min(Time),max(Time))/60 + TIMESTAMPDIFF(MINUTE,min(Time),max(Time)) AS SIGNED)  as 'Total in Minute' " +
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
            
    }
}

