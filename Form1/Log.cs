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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
            timer1.Start();   
        }


        private void Log_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    serialPort1.Open();
                    string entrada = serialPort1.ReadLine();
                    txtUid.Text = entrada;

                    MySqlConnection sqlconn = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
                    MySqlCommand command;
                    MySqlDataReader mdr;

                    sqlconn.Open();
                    //string selectQuery = string.Format("SELECT * FROM user WHERE uid LIKE '%{0}%'",txtUid.Text);
                    string selectQuery = string.Format("SELECT * FROM user WHERE uid = '" + txtUid.Text + "' and status = 'active'");
                    command = new MySqlCommand(selectQuery, sqlconn);


                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {

                        txtName.Text = mdr.GetString("name");
                        lblStatus.Text = mdr.GetString("status");
                        txtCarid.Text = mdr.GetString("carid");
                        lblInOut.Text = "IN";

                        sqlconn.Close();

                        sqlconn.Open();
                        string cons = string.Format("INSERT INTO log(Name,CardID,Status,Time,VehicleID,StatusCard)VALUES('" + txtName.Text + "','" + txtUid.Text + "','" + lblInOut.Text + "','" + DateTime.Now.ToString("dd-MM-yyyy--h:m:tt", System.Globalization.CultureInfo.InvariantCulture) + "','" + txtCarid.Text + "','" + lblStatus.Text + "')");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cons, sqlconn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        sqlconn.Close();

                        MessageBox.Show("Success");
                        txtName.Text = "";
                        txtUid.Text = "";
                        txtCarid.Text = "";
                        lblInOut.Text = "";
                        lblStatus.Text = "Status";
                    }  
              
                
            }
            catch (Exception x)
            {
                MessageBox.Show("error " + x.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
            }
            catch (Exception errr)
            {
                MessageBox.Show("Error " + errr.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormLogin fl = new FormLogin();
            fl.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lblTimer.Text = dateTime.ToString();
        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }
    }
}
