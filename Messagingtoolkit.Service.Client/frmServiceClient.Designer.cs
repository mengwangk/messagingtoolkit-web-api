namespace MessagingToolkit.Service.Client
{
    partial class frmServiceClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceClient));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStopGateway = new System.Windows.Forms.Button();
            this.btnStartGateway = new System.Windows.Forms.Button();
            this.lstGateways = new System.Windows.Forms.ListBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.btnDeleteGateway = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSmsc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkConnectAtStartup = new System.Windows.Forms.CheckBox();
            this.txtGatewayName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPostGateway = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboHandshake = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabSendMessage = new System.Windows.Forms.TabPage();
            this.btnGetSentMessages = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSentMessages = new System.Windows.Forms.ListBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.tabReceiveMessage = new System.Windows.Forms.TabPage();
            this.btnGetReceivedMessages = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstReceivedMessages = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabSendMessage.SuspendLayout();
            this.tabReceiveMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabSendMessage);
            this.tabControl1.Controls.Add(this.tabReceiveMessage);
            this.tabControl1.Location = new System.Drawing.Point(10, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 408);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox3);
            this.tabSettings.Controls.Add(this.groupBox2);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(720, 382);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "Gateway Management";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnStopGateway);
            this.groupBox3.Controls.Add(this.btnStartGateway);
            this.groupBox3.Controls.Add(this.lstGateways);
            this.groupBox3.Controls.Add(this.btnRetrieve);
            this.groupBox3.Controls.Add(this.btnDeleteGateway);
            this.groupBox3.Location = new System.Drawing.Point(6, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 295);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gateway";
            // 
            // btnStopGateway
            // 
            this.btnStopGateway.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStopGateway.Location = new System.Drawing.Point(109, 247);
            this.btnStopGateway.Name = "btnStopGateway";
            this.btnStopGateway.Size = new System.Drawing.Size(97, 28);
            this.btnStopGateway.TabIndex = 9;
            this.btnStopGateway.Text = "Stop";
            this.btnStopGateway.UseVisualStyleBackColor = true;
            this.btnStopGateway.Click += new System.EventHandler(this.btnStopGateway_Click);
            // 
            // btnStartGateway
            // 
            this.btnStartGateway.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStartGateway.Location = new System.Drawing.Point(6, 247);
            this.btnStartGateway.Name = "btnStartGateway";
            this.btnStartGateway.Size = new System.Drawing.Size(97, 28);
            this.btnStartGateway.TabIndex = 8;
            this.btnStartGateway.Text = "Start";
            this.btnStartGateway.UseVisualStyleBackColor = true;
            this.btnStartGateway.Click += new System.EventHandler(this.btnStartGateway_Click);
            // 
            // lstGateways
            // 
            this.lstGateways.FormattingEnabled = true;
            this.lstGateways.Location = new System.Drawing.Point(6, 19);
            this.lstGateways.Name = "lstGateways";
            this.lstGateways.Size = new System.Drawing.Size(201, 173);
            this.lstGateways.TabIndex = 1;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRetrieve.Location = new System.Drawing.Point(6, 213);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(97, 28);
            this.btnRetrieve.TabIndex = 7;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // btnDeleteGateway
            // 
            this.btnDeleteGateway.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDeleteGateway.Location = new System.Drawing.Point(109, 213);
            this.btnDeleteGateway.Name = "btnDeleteGateway";
            this.btnDeleteGateway.Size = new System.Drawing.Size(97, 28);
            this.btnDeleteGateway.TabIndex = 6;
            this.btnDeleteGateway.Text = "Delete ";
            this.btnDeleteGateway.UseVisualStyleBackColor = true;
            this.btnDeleteGateway.Click += new System.EventHandler(this.btnDeleteGateway_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.btnPostGateway);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(241, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 295);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gateway Information";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSmsc);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.chkConnectAtStartup);
            this.groupBox1.Controls.Add(this.txtGatewayName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 86);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identification";
            // 
            // txtSmsc
            // 
            this.txtSmsc.Location = new System.Drawing.Point(63, 47);
            this.txtSmsc.Name = "txtSmsc";
            this.txtSmsc.Size = new System.Drawing.Size(123, 20);
            this.txtSmsc.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "SMSC";
            // 
            // chkConnectAtStartup
            // 
            this.chkConnectAtStartup.AutoSize = true;
            this.chkConnectAtStartup.Location = new System.Drawing.Point(221, 24);
            this.chkConnectAtStartup.Name = "chkConnectAtStartup";
            this.chkConnectAtStartup.Size = new System.Drawing.Size(116, 17);
            this.chkConnectAtStartup.TabIndex = 2;
            this.chkConnectAtStartup.Text = "Connect at start up";
            this.chkConnectAtStartup.UseVisualStyleBackColor = true;
            // 
            // txtGatewayName
            // 
            this.txtGatewayName.Location = new System.Drawing.Point(63, 21);
            this.txtGatewayName.Name = "txtGatewayName";
            this.txtGatewayName.Size = new System.Drawing.Size(152, 20);
            this.txtGatewayName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // btnPostGateway
            // 
            this.btnPostGateway.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPostGateway.Location = new System.Drawing.Point(18, 241);
            this.btnPostGateway.Name = "btnPostGateway";
            this.btnPostGateway.Size = new System.Drawing.Size(97, 28);
            this.btnPostGateway.TabIndex = 4;
            this.btnPostGateway.Text = "Create Gateway";
            this.btnPostGateway.UseVisualStyleBackColor = true;
            this.btnPostGateway.Click += new System.EventHandler(this.btnPostGateway_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cboStopBits);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.cboHandshake);
            this.groupBox4.Controls.Add(this.cboParity);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cboDataBits);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cboBaudRate);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cboPort);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(18, 121);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(356, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Port Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(193, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Stop Bits";
            // 
            // cboStopBits
            // 
            this.cboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Location = new System.Drawing.Point(245, 66);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(83, 21);
            this.cboStopBits.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Handshake";
            // 
            // cboHandshake
            // 
            this.cboHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHandshake.FormattingEnabled = true;
            this.cboHandshake.Location = new System.Drawing.Point(73, 66);
            this.cboHandshake.Name = "cboHandshake";
            this.cboHandshake.Size = new System.Drawing.Size(98, 21);
            this.cboHandshake.TabIndex = 15;
            // 
            // cboParity
            // 
            this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(245, 41);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(83, 21);
            this.cboParity.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(194, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Parity";
            // 
            // cboDataBits
            // 
            this.cboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(245, 17);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(83, 21);
            this.cboDataBits.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Data Bits";
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Location = new System.Drawing.Point(73, 41);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(98, 21);
            this.cboBaudRate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Baud Rate";
            // 
            // cboPort
            // 
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(73, 16);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(98, 21);
            this.cboPort.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port";
            // 
            // tabSendMessage
            // 
            this.tabSendMessage.Controls.Add(this.btnGetSentMessages);
            this.tabSendMessage.Controls.Add(this.label2);
            this.tabSendMessage.Controls.Add(this.lstSentMessages);
            this.tabSendMessage.Controls.Add(this.btnSendMessage);
            this.tabSendMessage.Controls.Add(this.label31);
            this.tabSendMessage.Controls.Add(this.txtMessage);
            this.tabSendMessage.Controls.Add(this.label21);
            this.tabSendMessage.Controls.Add(this.txtPhoneNumber);
            this.tabSendMessage.Location = new System.Drawing.Point(4, 22);
            this.tabSendMessage.Name = "tabSendMessage";
            this.tabSendMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabSendMessage.Size = new System.Drawing.Size(720, 382);
            this.tabSendMessage.TabIndex = 1;
            this.tabSendMessage.Text = "Send Message";
            this.tabSendMessage.UseVisualStyleBackColor = true;
            // 
            // btnGetSentMessages
            // 
            this.btnGetSentMessages.Location = new System.Drawing.Point(422, 184);
            this.btnGetSentMessages.Name = "btnGetSentMessages";
            this.btnGetSentMessages.Size = new System.Drawing.Size(202, 35);
            this.btnGetSentMessages.TabIndex = 24;
            this.btnGetSentMessages.Text = "Get Sent Messages";
            this.btnGetSentMessages.UseVisualStyleBackColor = true;
            this.btnGetSentMessages.Click += new System.EventHandler(this.btnGetSentMessages_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Sent Messages";
            // 
            // lstSentMessages
            // 
            this.lstSentMessages.FormattingEnabled = true;
            this.lstSentMessages.HorizontalScrollbar = true;
            this.lstSentMessages.Location = new System.Drawing.Point(422, 31);
            this.lstSentMessages.Name = "lstSentMessages";
            this.lstSentMessages.ScrollAlwaysVisible = true;
            this.lstSentMessages.Size = new System.Drawing.Size(277, 147);
            this.lstSentMessages.TabIndex = 22;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(99, 180);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(202, 35);
            this.btnSendMessage.TabIndex = 21;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(15, 58);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(50, 13);
            this.label31.TabIndex = 20;
            this.label31.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(99, 41);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(270, 128);
            this.txtMessage.TabIndex = 19;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 13);
            this.label21.TabIndex = 17;
            this.label21.Text = "Phone Number";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(99, 15);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(270, 20);
            this.txtPhoneNumber.TabIndex = 18;
            // 
            // tabReceiveMessage
            // 
            this.tabReceiveMessage.Controls.Add(this.btnGetReceivedMessages);
            this.tabReceiveMessage.Controls.Add(this.label4);
            this.tabReceiveMessage.Controls.Add(this.lstReceivedMessages);
            this.tabReceiveMessage.Location = new System.Drawing.Point(4, 22);
            this.tabReceiveMessage.Name = "tabReceiveMessage";
            this.tabReceiveMessage.Size = new System.Drawing.Size(720, 382);
            this.tabReceiveMessage.TabIndex = 2;
            this.tabReceiveMessage.Text = "Receive Message";
            this.tabReceiveMessage.UseVisualStyleBackColor = true;
            // 
            // btnGetReceivedMessages
            // 
            this.btnGetReceivedMessages.Location = new System.Drawing.Point(48, 199);
            this.btnGetReceivedMessages.Name = "btnGetReceivedMessages";
            this.btnGetReceivedMessages.Size = new System.Drawing.Size(202, 35);
            this.btnGetReceivedMessages.TabIndex = 27;
            this.btnGetReceivedMessages.Text = "Get Received Messages";
            this.btnGetReceivedMessages.UseVisualStyleBackColor = true;
            this.btnGetReceivedMessages.Click += new System.EventHandler(this.btnGetReceivedMessages_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Received Messages";
            // 
            // lstReceivedMessages
            // 
            this.lstReceivedMessages.FormattingEnabled = true;
            this.lstReceivedMessages.HorizontalScrollbar = true;
            this.lstReceivedMessages.Location = new System.Drawing.Point(48, 36);
            this.lstReceivedMessages.Name = "lstReceivedMessages";
            this.lstReceivedMessages.ScrollAlwaysVisible = true;
            this.lstReceivedMessages.Size = new System.Drawing.Size(277, 147);
            this.lstReceivedMessages.TabIndex = 25;
            // 
            // frmServiceClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 443);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServiceClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessagingToolkit Service Client";
            this.Load += new System.EventHandler(this.frmServiceClient_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabSendMessage.ResumeLayout(false);
            this.tabSendMessage.PerformLayout();
            this.tabReceiveMessage.ResumeLayout(false);
            this.tabReceiveMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabSendMessage;
        private System.Windows.Forms.TabPage tabReceiveMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkConnectAtStartup;
        private System.Windows.Forms.TextBox txtGatewayName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSmsc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboHandshake;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPostGateway;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstGateways;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Button btnDeleteGateway;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStopGateway;
        private System.Windows.Forms.Button btnStartGateway;
        private System.Windows.Forms.ListBox lstSentMessages;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetSentMessages;
        private System.Windows.Forms.Button btnGetReceivedMessages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstReceivedMessages;
    }
}

