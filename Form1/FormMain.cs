using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Form1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FormAdd frmAdd = new FormAdd();
            frmAdd.Show();
        }


        private void btnLogHistory_Click(object sender, EventArgs e)
        {
            LogHistory lh = new LogHistory();
            lh.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report repo = new Report();
            repo.Show();
        }
    }
}
