namespace Form1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtUid = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCarid = new System.Windows.Forms.TextBox();
            this.lblInOut = new System.Windows.Forms.Label();
            this.lblUid = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCarid = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(44, 6);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(121, 21);
            this.cboPort.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(181, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(262, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(197, 165);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(100, 20);
            this.txtUid.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(209, 318);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(375, 9);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(33, 13);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.Text = "Timer";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(197, 213);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 7;
            // 
            // txtCarid
            // 
            this.txtCarid.Location = new System.Drawing.Point(197, 263);
            this.txtCarid.Name = "txtCarid";
            this.txtCarid.Size = new System.Drawing.Size(100, 20);
            this.txtCarid.TabIndex = 7;
            // 
            // lblInOut
            // 
            this.lblInOut.AutoSize = true;
            this.lblInOut.Location = new System.Drawing.Point(234, 101);
            this.lblInOut.Name = "lblInOut";
            this.lblInOut.Size = new System.Drawing.Size(19, 13);
            this.lblInOut.TabIndex = 9;
            this.lblInOut.Text = "....";
            // 
            // lblUid
            // 
            this.lblUid.AutoSize = true;
            this.lblUid.Location = new System.Drawing.Point(120, 168);
            this.lblUid.Name = "lblUid";
            this.lblUid.Size = new System.Drawing.Size(43, 13);
            this.lblUid.TabIndex = 10;
            this.lblUid.Text = "Card ID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(120, 216);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Name";
            // 
            // lblCarid
            // 
            this.lblCarid.AutoSize = true;
            this.lblCarid.Location = new System.Drawing.Point(120, 266);
            this.lblCarid.Name = "lblCarid";
            this.lblCarid.Size = new System.Drawing.Size(56, 13);
            this.lblCarid.TabIndex = 10;
            this.lblCarid.Text = "Vehicle ID";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(396, 443);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 495);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblCarid);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblUid);
            this.Controls.Add(this.lblInOut);
            this.Controls.Add(this.txtCarid);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cboPort);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCarid;
        private System.Windows.Forms.Label lblInOut;
        private System.Windows.Forms.Label lblUid;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCarid;
        private System.Windows.Forms.Button btnLogin;
    }
}

