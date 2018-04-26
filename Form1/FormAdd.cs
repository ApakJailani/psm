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
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
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
                string cons = string.Format("INSERT INTO psm.user(name,uid,type,carid,time,status)VALUES('"+ txtName.Text +"','"+ txtUid.Text +"','"+ txtType.Text +"','"+ txtCarid.Text +"','"+ DateTime.Now.ToString("dd-MM-yyyy") + "','"+txtStatus.Text +"')");
                MySqlConnection sqlconn = new MySqlConnection("server=localhost;user id=root;database=psm;password=Abc12345;");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cons, sqlconn);
                //MySqlCommandBuilder comando = new MySqlCommandBuilder(adaptador);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

       
    }
}
