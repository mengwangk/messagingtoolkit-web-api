namespace MessagingToolkit.WCF.Demo.WinForms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnHeartBeat = new System.Windows.Forms.Button();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.btnTestGetConfig = new System.Windows.Forms.Button();
            this.btnGenerateJson = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnInvokeService = new System.Windows.Forms.Button();
            this.btnAddGateway = new System.Windows.Forms.Button();
            this.btnWcfCommandService = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHeartBeat
            // 
            this.btnHeartBeat.Location = new System.Drawing.Point(22, 29);
            this.btnHeartBeat.Name = "btnHeartBeat";
            this.btnHeartBeat.Size = new System.Drawing.Size(184, 30);
            this.btnHeartBeat.TabIndex = 0;
            this.btnHeartBeat.Text = "HeartBeat";
            this.btnHeartBeat.UseVisualStyleBackColor = true;
            this.btnHeartBeat.Click += new System.EventHandler(this.btnHeartBeat_Click);
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Location = new System.Drawing.Point(22, 76);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(184, 32);
            this.btnSendSMS.TabIndex = 1;
            this.btnSendSMS.Text = "Send SMS";
            this.btnSendSMS.UseVisualStyleBackColor = true;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // btnTestGetConfig
            // 
            this.btnTestGetConfig.Location = new System.Drawing.Point(22, 123);
            this.btnTestGetConfig.Name = "btnTestGetConfig";
            this.btnTestGetConfig.Size = new System.Drawing.Size(184, 31);
            this.btnTestGetConfig.TabIndex = 2;
            this.btnTestGetConfig.Text = "Test Retrieve Config";
            this.btnTestGetConfig.UseVisualStyleBackColor = true;
            this.btnTestGetConfig.Click += new System.EventHandler(this.btnTestGetConfig_Click);
            // 
            // btnGenerateJson
            // 
            this.btnGenerateJson.Location = new System.Drawing.Point(249, 29);
            this.btnGenerateJson.Name = "btnGenerateJson";
            this.btnGenerateJson.Size = new System.Drawing.Size(199, 30);
            this.btnGenerateJson.TabIndex = 3;
            this.btnGenerateJson.Text = "Get JSON";
            this.btnGenerateJson.UseVisualStyleBackColor = true;
            this.btnGenerateJson.Click += new System.EventHandler(this.btnGenerateJson_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(22, 321);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(628, 171);
            this.txtOutput.TabIndex = 4;
            // 
            // btnInvokeService
            // 
            this.btnInvokeService.Location = new System.Drawing.Point(249, 76);
            this.btnInvokeService.Name = "btnInvokeService";
            this.btnInvokeService.Size = new System.Drawing.Size(199, 32);
            this.btnInvokeService.TabIndex = 5;
            this.btnInvokeService.Text = "Invoke Service";
            this.btnInvokeService.UseVisualStyleBackColor = true;
            this.btnInvokeService.Click += new System.EventHandler(this.btnInvokeService_Click);
            // 
            // btnAddGateway
            // 
            this.btnAddGateway.Location = new System.Drawing.Point(249, 123);
            this.btnAddGateway.Name = "btnAddGateway";
            this.btnAddGateway.Size = new System.Drawing.Size(199, 32);
            this.btnAddGateway.TabIndex = 6;
            this.btnAddGateway.Text = "Add Gateway";
            this.btnAddGateway.UseVisualStyleBackColor = true;
            this.btnAddGateway.Click += new System.EventHandler(this.btnAddGateway_Click);
            // 
            // btnWcfCommandService
            // 
            this.btnWcfCommandService.Location = new System.Drawing.Point(249, 179);
            this.btnWcfCommandService.Name = "btnWcfCommandService";
            this.btnWcfCommandService.Size = new System.Drawing.Size(199, 32);
            this.btnWcfCommandService.TabIndex = 7;
            this.btnWcfCommandService.Text = "Test WCF Command Service";
            this.btnWcfCommandService.UseVisualStyleBackColor = true;
            this.btnWcfCommandService.Click += new System.EventHandler(this.btnWcfCommandService_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(480, 29);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(199, 32);
            this.btnSendMessage.TabIndex = 8;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Check Gateway Status";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 578);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnWcfCommandService);
            this.Controls.Add(this.btnAddGateway);
            this.Controls.Add(this.btnInvokeService);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnGenerateJson);
            this.Controls.Add(this.btnTestGetConfig);
            this.Controls.Add(this.btnSendSMS);
            this.Controls.Add(this.btnHeartBeat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Test Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHeartBeat;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.Button btnTestGetConfig;
        private System.Windows.Forms.Button btnGenerateJson;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnInvokeService;
        private System.Windows.Forms.Button btnAddGateway;
        private System.Windows.Forms.Button btnWcfCommandService;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button button1;
    }
}

