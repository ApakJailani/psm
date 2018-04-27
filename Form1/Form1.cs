using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Form1
{
    delegate void SetTextCallback(string txtUid);
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void SetText(string text)
        {
            this.txtUid.Text = text;
        }
        private void SetName(string Nama)
        {
            this.txtName.Text = Nama;
        }
       
        private void SetCarId(string carid)
        {
            this.txtCarid.Text = carid;
        }
        private void SetInOut(string InOut)
        {
            this.lblInOut.Text = InOut;
        }
        private void SetName2(string Nama2)
        {
            this.txtName.Text = Nama2;
        }
       
        private void SetCarId2(string carid2)
        {
            this.txtCarid.Text = carid2;
        }
        private void SetInOut2(string InOut2)
        {
            this.lblInOut.Text = InOut2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
            //cboPort.SelectedIndex = 0;
            btnClose.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btnClose.Enabled = true;
            try
            {
                serialPort1.PortName = cboPort.Text;
                serialPort1.Open();
                Thread workerThread = new Thread(dataLoop);
                workerThread.Start();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void dataLoop()
        {
            //Thread.Sleep(5000);
            string txtUid, txtName, txtCarid, lblInOut;
            if (serialPort1.IsOpen)
            {

                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { txtUid = serialPort1.ReadLine() });
                //serialPort1.Close();
                //txtUid.Text = entrada;
                //this.Invoke(d, new object[] { text + " (Invoke)" });

                MySqlConnection sqlconn = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
                MySqlCommand command;
                MySqlDataReader mdr;
                //try
                //{
                    
                    sqlconn.Open();
                    //string selectQuery = string.Format("SELECT * FROM user WHERE uid LIKE '%{0}%'",txtUid.Text);
                    string selectQuery = string.Format("SELECT * FROM user WHERE uid = '" + txtUid + "' and status = 'OUT'");
                    command = new MySqlCommand(selectQuery, sqlconn);
                    

                    mdr = command.ExecuteReader();
                    if (mdr.Read())
                    {
                        SetTextCallback Nama = new SetTextCallback(SetName);
                        this.Invoke(Nama, new object[] { txtName = mdr.GetString("name") });
                        SetTextCallback Carid = new SetTextCallback(SetCarId);
                        this.Invoke(Carid, new object[] { txtCarid = mdr.GetString("carid") });
                        SetTextCallback InOut = new SetTextCallback(SetInOut);
                        this.Invoke(InOut, new object[] { lblInOut = "IN" });
                        sqlconn.Close();

                        sqlconn.Open();
                        string query = string.Format("UPDATE user set status = 'IN' WHERE uid = '" + txtUid + "'");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, sqlconn);
                        DataTable tb = new DataTable();
                        adapter.Fill(tb);

                        sqlconn.Close();

                        sqlconn.Open();
                        string cons = string.Format("INSERT INTO log(Name,CardID,Status,Time,VehicleID)VALUES('" + txtName + "','" + txtUid + "','" + lblInOut + "','" + DateTime.Now.ToString("dd-MM-yyyy--h:m:tt", System.Globalization.CultureInfo.InvariantCulture) + "','" + txtCarid + "')");
                        adapter = new MySqlDataAdapter(cons, sqlconn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);


                        sqlconn.Close();

                        MessageBox.Show("Success");

                    }
                        

               //}
               // catch (Exception t)
               // {
                    
                   //     MessageBox.Show(t.Message);
                  //  }

                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            try
            {
                serialPort1.Close();
                MessageBox.Show("Port Close");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUid.Clear();
            txtName.Clear();
            txtCarid.Clear();
            lblInOut.Text = "......";
            Thread workerThread = new Thread(dataLoop);
            workerThread.Start();
            //if (serialPort1.IsOpen)
               // serialPort1.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lblTimer.Text = dateTime.ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormLogin fl = new FormLogin();
            fl.Show();
            this.Hide();
        }

       
    }
}
