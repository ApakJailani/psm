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
            this.txtInOut.Text = InOut;
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
            this.txtInOut.Text = InOut2;
        }
        private void SetPark(string park)
        {
            this.txtParking.Text = park;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
            //serialPort1.DtrEnable = true;
            //serialPort1.RtsEnable = true;
            //cboPort.SelectedIndex = 0;
            btnClose.Enabled = false;

            MySqlConnection sqlconn = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
            MySqlCommand command;
            sqlconn.Open();
            MySqlDataReader mdr;
            string parkk = string.Format("SELECT QtyParking FROM parking");
            command = new MySqlCommand(parkk, sqlconn);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                SetTextCallback park = new SetTextCallback(SetPark);
                this.Invoke(park, new object[] { txtParking.Text = mdr.GetString("QtyParking") });
            }
            mdr.Close();
            sqlconn.Close();

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
            string txtUid, txtName, txtCarid, txtInOut;
            if (serialPort1.IsOpen)
            {
                //serialPort1.DiscardInBuffer();
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { txtUid = serialPort1.ReadLine() });
                //serialPort1.Close();
                //txtUid.Text = entrada;
                //this.Invoke(d, new object[] { text + " (Invoke)" });
                MySqlConnection sqlconn = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
                MySqlCommand command;

                sqlconn.Open();
                DataSet ds = new DataSet();
                



                //try
                //{
                //sqlconn.Open();
                //string selectQuery = string.Format("SELECT * FROM user WHERE uid LIKE '%{0}%'",txtUid.Text);
                string Query = string.Format("SELECT uid FROM user WHERE uid = '" + txtUid + "'");
                MySqlDataAdapter da = new MySqlDataAdapter(Query, sqlconn);
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {

 
                    //serialPort1.Close();
                    string check = string.Format("SELECT status FROM user WHERE uid = '" + txtUid + "'");
                    command = new MySqlCommand(check, sqlconn);
                    MySqlDataReader drr;
                    drr = command.ExecuteReader();
                    //txtInOut = "status";
                    drr.Read();
                    
                        SetTextCallback InOut = new SetTextCallback(SetInOut);
                        this.Invoke(InOut, new object[] { txtInOut = drr.GetString("status") });
                        drr.Close();
                    if (txtInOut == "OUT")
                    {
                        string selectQuery = string.Format("SELECT * FROM user WHERE uid = '" + txtUid + "' and status = 'OUT'");
                        command = new MySqlCommand(selectQuery, sqlconn);

                        //MySqlDataReader mdr;
                        drr = command.ExecuteReader();
                        if (drr.Read())
                        {
                            //Lock = 0;
                            //Con = 0;


                            SetTextCallback Nama = new SetTextCallback(SetName);
                            this.Invoke(Nama, new object[] { txtName = drr.GetString("name") });
                            SetTextCallback Carid = new SetTextCallback(SetCarId);
                            this.Invoke(Carid, new object[] { txtCarid = drr.GetString("carid") });
                            SetTextCallback InOut2 = new SetTextCallback(SetInOut2);
                            this.Invoke(InOut2, new object[] { txtInOut = "IN" });
                            sqlconn.Close();

                            sqlconn.Open();
                            MySqlCommand cmd = sqlconn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE parking set QtyParking = QtyParking-1";
                            cmd.ExecuteNonQuery();
                            
                            
                            //SetTextCallback park = new SetTextCallback(SetPark);
                            //this.Invoke(park, new object[] { lblParking.Text = dd.GetString("QtyParking") });
                            sqlconn.Close();

                            sqlconn.Open();
                            string query = string.Format("UPDATE user set status = 'IN' WHERE uid = '" + txtUid + "'");
                            MySqlDataAdapter adapter = new MySqlDataAdapter(query, sqlconn);
                            DataTable tb = new DataTable();
                            adapter.Fill(tb);
                            sqlconn.Close();


                            sqlconn.Open();
                            string cons = string.Format("INSERT INTO log(Name,CardID,Status,Time,VehicleID)VALUES('" + txtName + "','" + txtUid + "','" + txtInOut + "','" + DateTime.Now.ToString("dd-MM-yyyy--h:m:tt", System.Globalization.CultureInfo.InvariantCulture) + "','" + txtCarid + "')");
                            adapter = new MySqlDataAdapter(cons, sqlconn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            sqlconn.Close();

                            

                            MessageBox.Show("Success IN");

                            //serialPort1.Write("1");

                        }
                    }
                    else
                    {
                        
                        string selectQuery2 = string.Format("SELECT * FROM user WHERE uid = '" + txtUid + "' and status = 'IN'");
                        command = new MySqlCommand(selectQuery2, sqlconn);

                        //MySqlDataReader md;
                        drr = command.ExecuteReader();
                        if (drr.Read())
                        {
                            //Lock = 0;
                            //Con = 1;
                            

                            SetTextCallback Nama = new SetTextCallback(SetName);
                            this.Invoke(Nama, new object[] { txtName = drr.GetString("name") });
                            SetTextCallback Carid = new SetTextCallback(SetCarId);
                            this.Invoke(Carid, new object[] { txtCarid = drr.GetString("carid") });
                            SetTextCallback InOut2 = new SetTextCallback(SetInOut2);
                            this.Invoke(InOut2, new object[] { txtInOut = "OUT" });
                            sqlconn.Close();

                            sqlconn.Open();
                            MySqlCommand cmd = sqlconn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE parking set QtyParking = QtyParking+1";
                            //MySqlDataReader dd;
                            cmd.ExecuteNonQuery();
                            //dd = cmd.ExecuteReader();

                            //SetTextCallback park = new SetTextCallback(SetPark);
                            //this.Invoke(park, new object[] { lblParking.Text = dd.GetString("QtyParking") });
                            sqlconn.Close();

                            sqlconn.Open();
                            string query = string.Format("UPDATE user set status = 'OUT' WHERE uid = '" + txtUid + "'");
                            MySqlDataAdapter adapter = new MySqlDataAdapter(query, sqlconn);
                            DataTable tb = new DataTable();
                            adapter.Fill(tb);

                            sqlconn.Close();

                            sqlconn.Open();
                            string cons = string.Format("INSERT INTO log(Name,CardID,Status,Time,VehicleID)VALUES('" + txtName + "','" + txtUid + "','" + txtInOut + "','" + DateTime.Now.ToString("dd-MM-yyyy--h:m:tt", System.Globalization.CultureInfo.InvariantCulture) + "','" + txtCarid + "')");
                            adapter = new MySqlDataAdapter(cons, sqlconn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);


                            sqlconn.Close();
                            MessageBox.Show("Success OUT");

                            //serialPort1.Write("2");

                        }

                    } 
                    drr.Close();
                    serialPort1.WriteLine("1");
                }
                else
                {
                    //txtUid = "";
                    serialPort1.Write("2");
                    MessageBox.Show("Invalid Card");
                }

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
            txtInOut.Clear();
            txtParking.Clear();

            MySqlConnection sqlconn = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
            MySqlCommand command;
            sqlconn.Open();
            MySqlDataReader mdr;
            string parkk = string.Format("SELECT QtyParking FROM parking");
            command = new MySqlCommand(parkk, sqlconn);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                SetTextCallback park = new SetTextCallback(SetPark);
                this.Invoke(park, new object[] { txtParking.Text = mdr.GetString("QtyParking") });
            }
            mdr.Close();
            sqlconn.Close();

            Thread workerThread = new Thread(dataLoop);
            workerThread.Start();

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
            //this.Hide();
        }
    
    }
}
