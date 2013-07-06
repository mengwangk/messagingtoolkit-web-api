namespace MessagingToolkit.Service.ControlPanel
{
    partial class frmControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlPanel));
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lnkWebApiURL = new System.Windows.Forms.LinkLabel();
            this.lnkWebSite = new System.Windows.Forms.LinkLabel();
            this.lblWebApiHostStatus = new System.Windows.Forms.Label();
            this.lblServiceProviderStatus = new System.Windows.Forms.Label();
            this.lnkWebApiHostUrl = new System.Windows.Forms.LinkLabel();
            this.lnkServiceProviderUrl = new System.Windows.Forms.LinkLabel();
            this.txtWebAPIHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtServiceProvider = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInstallService = new System.Windows.Forms.Button();
            this.btnUninstallWindowsServices = new System.Windows.Forms.Button();
            this.btnSampleClient = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(559, 189);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(197, 47);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lnkWebApiURL);
            this.groupBox1.Controls.Add(this.lnkWebSite);
            this.groupBox1.Controls.Add(this.lblWebApiHostStatus);
            this.groupBox1.Controls.Add(this.lblServiceProviderStatus);
            this.groupBox1.Controls.Add(this.lnkWebApiHostUrl);
            this.groupBox1.Controls.Add(this.lnkServiceProviderUrl);
            this.groupBox1.Controls.Add(this.txtWebAPIHost);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtServiceProvider);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 225);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Control";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Project Site";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Default API URL";
            // 
            // lnkWebApiURL
            // 
            this.lnkWebApiURL.AutoSize = true;
            this.lnkWebApiURL.Location = new System.Drawing.Point(144, 112);
            this.lnkWebApiURL.Name = "lnkWebApiURL";
            this.lnkWebApiURL.Size = new System.Drawing.Size(214, 13);
            this.lnkWebApiURL.TabIndex = 11;
            this.lnkWebApiURL.TabStop = true;
            this.lnkWebApiURL.Text = "http://localhost:1689/messagingtoolkit/api/";
            this.lnkWebApiURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lnkWebSite
            // 
            this.lnkWebSite.AutoSize = true;
            this.lnkWebSite.Location = new System.Drawing.Point(144, 139);
            this.lnkWebSite.Name = "lnkWebSite";
            this.lnkWebSite.Size = new System.Drawing.Size(264, 13);
            this.lnkWebSite.TabIndex = 10;
            this.lnkWebSite.TabStop = true;
            this.lnkWebSite.Text = "https://code.google.com/p/messagingtoolkit-web-api/";
            this.lnkWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWebSite_LinkClicked);
            // 
            // lblWebApiHostStatus
            // 
            this.lblWebApiHostStatus.AutoSize = true;
            this.lblWebApiHostStatus.Location = new System.Drawing.Point(387, 66);
            this.lblWebApiHostStatus.Name = "lblWebApiHostStatus";
            this.lblWebApiHostStatus.Size = new System.Drawing.Size(47, 13);
            this.lblWebApiHostStatus.TabIndex = 9;
            this.lblWebApiHostStatus.Text = "Stopped";
            // 
            // lblServiceProviderStatus
            // 
            this.lblServiceProviderStatus.AutoSize = true;
            this.lblServiceProviderStatus.Location = new System.Drawing.Point(387, 35);
            this.lblServiceProviderStatus.Name = "lblServiceProviderStatus";
            this.lblServiceProviderStatus.Size = new System.Drawing.Size(47, 13);
            this.lblServiceProviderStatus.TabIndex = 8;
            this.lblServiceProviderStatus.Text = "Stopped";
            // 
            // lnkWebApiHostUrl
            // 
            this.lnkWebApiHostUrl.AutoSize = true;
            this.lnkWebApiHostUrl.Location = new System.Drawing.Point(144, 112);
            this.lnkWebApiHostUrl.Name = "lnkWebApiHostUrl";
            this.lnkWebApiHostUrl.Size = new System.Drawing.Size(0, 13);
            this.lnkWebApiHostUrl.TabIndex = 7;
            // 
            // lnkServiceProviderUrl
            // 
            this.lnkServiceProviderUrl.AutoSize = true;
            this.lnkServiceProviderUrl.Location = new System.Drawing.Point(144, 55);
            this.lnkServiceProviderUrl.Name = "lnkServiceProviderUrl";
            this.lnkServiceProviderUrl.Size = new System.Drawing.Size(0, 13);
            this.lnkServiceProviderUrl.TabIndex = 6;
            // 
            // txtWebAPIHost
            // 
            this.txtWebAPIHost.Enabled = false;
            this.txtWebAPIHost.Location = new System.Drawing.Point(147, 63);
            this.txtWebAPIHost.Name = "txtWebAPIHost";
            this.txtWebAPIHost.ReadOnly = true;
            this.txtWebAPIHost.Size = new System.Drawing.Size(222, 20);
            this.txtWebAPIHost.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Web API Host";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(253, 174);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(79, 32);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(147, 174);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(77, 32);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtServiceProvider
            // 
            this.txtServiceProvider.Enabled = false;
            this.txtServiceProvider.Location = new System.Drawing.Point(147, 32);
            this.txtServiceProvider.Name = "txtServiceProvider";
            this.txtServiceProvider.ReadOnly = true;
            this.txtServiceProvider.Size = new System.Drawing.Size(222, 20);
            this.txtServiceProvider.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Provider";
            // 
            // btnInstallService
            // 
            this.btnInstallService.Location = new System.Drawing.Point(559, 17);
            this.btnInstallService.Name = "btnInstallService";
            this.btnInstallService.Size = new System.Drawing.Size(197, 46);
            this.btnInstallService.TabIndex = 4;
            this.btnInstallService.Text = "Install as Windows Services";
            this.btnInstallService.UseVisualStyleBackColor = true;
            this.btnInstallService.Click += new System.EventHandler(this.btnInstallService_Click);
            // 
            // btnUninstallWindowsServices
            // 
            this.btnUninstallWindowsServices.Location = new System.Drawing.Point(559, 74);
            this.btnUninstallWindowsServices.Name = "btnUninstallWindowsServices";
            this.btnUninstallWindowsServices.Size = new System.Drawing.Size(197, 46);
            this.btnUninstallWindowsServices.TabIndex = 5;
            this.btnUninstallWindowsServices.Text = "Uninstall Windows Services";
            this.btnUninstallWindowsServices.UseVisualStyleBackColor = true;
            this.btnUninstallWindowsServices.Click += new System.EventHandler(this.btnUninstallWindowsServices_Click);
            // 
            // btnSampleClient
            // 
            this.btnSampleClient.Location = new System.Drawing.Point(559, 133);
            this.btnSampleClient.Name = "btnSampleClient";
            this.btnSampleClient.Size = new System.Drawing.Size(197, 46);
            this.btnSampleClient.TabIndex = 6;
            this.btnSampleClient.Text = "Sample Client";
            this.btnSampleClient.UseVisualStyleBackColor = true;
            this.btnSampleClient.Click += new System.EventHandler(this.btnSampleClient_Click);
            // 
            // frmControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 248);
            this.Controls.Add(this.btnSampleClient);
            this.Controls.Add(this.btnUninstallWindowsServices);
            this.Controls.Add(this.btnInstallService);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Panel - MessagingToolkit Web API ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmControlPanel_FormClosing);
            this.Load += new System.EventHandler(this.frmControlPanel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtServiceProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWebAPIHost;
        private System.Windows.Forms.Label lblWebApiHostStatus;
        private System.Windows.Forms.Label lblServiceProviderStatus;
        private System.Windows.Forms.LinkLabel lnkWebApiHostUrl;
        private System.Windows.Forms.LinkLabel lnkServiceProviderUrl;
        private System.Windows.Forms.Button btnInstallService;
        private System.Windows.Forms.Button btnUninstallWindowsServices;
        private System.Windows.Forms.LinkLabel lnkWebSite;
        private System.Windows.Forms.LinkLabel lnkWebApiURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSampleClient;

    }
}

