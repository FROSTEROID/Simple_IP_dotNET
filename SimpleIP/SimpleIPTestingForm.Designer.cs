namespace SimpleIP {
	partial class SimpleIPTestingForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.CB_server = new System.Windows.Forms.Button();
			this.tb_listnIP = new System.Windows.Forms.TextBox();
			this.nUD_listnPort = new System.Windows.Forms.NumericUpDown();
			this.CB_client = new System.Windows.Forms.Button();
			this.nUD_connectPort = new System.Windows.Forms.NumericUpDown();
			this.tb_connectIP = new System.Windows.Forms.TextBox();
			this.tb_messageBox = new System.Windows.Forms.TextBox();
			this.CB_send = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.nUD_listnPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD_connectPort)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// CB_server
			// 
			this.CB_server.Location = new System.Drawing.Point(6, 71);
			this.CB_server.Name = "CB_server";
			this.CB_server.Size = new System.Drawing.Size(126, 23);
			this.CB_server.TabIndex = 0;
			this.CB_server.Text = "Become Server";
			this.CB_server.UseVisualStyleBackColor = true;
			this.CB_server.Click += new System.EventHandler(this.CB_server_Click);
			// 
			// tb_listnIP
			// 
			this.tb_listnIP.Location = new System.Drawing.Point(6, 19);
			this.tb_listnIP.Name = "tb_listnIP";
			this.tb_listnIP.Size = new System.Drawing.Size(152, 20);
			this.tb_listnIP.TabIndex = 1;
			// 
			// nUD_listnPort
			// 
			this.nUD_listnPort.Location = new System.Drawing.Point(6, 45);
			this.nUD_listnPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			this.nUD_listnPort.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.nUD_listnPort.Name = "nUD_listnPort";
			this.nUD_listnPort.Size = new System.Drawing.Size(152, 20);
			this.nUD_listnPort.TabIndex = 2;
			this.nUD_listnPort.Value = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			// 
			// CB_client
			// 
			this.CB_client.Location = new System.Drawing.Point(6, 69);
			this.CB_client.Name = "CB_client";
			this.CB_client.Size = new System.Drawing.Size(91, 23);
			this.CB_client.TabIndex = 3;
			this.CB_client.Text = "Become Client";
			this.CB_client.UseVisualStyleBackColor = true;
			this.CB_client.Click += new System.EventHandler(this.CB_client_Click);
			// 
			// nUD_connectPort
			// 
			this.nUD_connectPort.Location = new System.Drawing.Point(6, 43);
			this.nUD_connectPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			this.nUD_connectPort.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.nUD_connectPort.Name = "nUD_connectPort";
			this.nUD_connectPort.Size = new System.Drawing.Size(120, 20);
			this.nUD_connectPort.TabIndex = 5;
			this.nUD_connectPort.Value = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			// 
			// tb_connectIP
			// 
			this.tb_connectIP.Location = new System.Drawing.Point(6, 17);
			this.tb_connectIP.Name = "tb_connectIP";
			this.tb_connectIP.Size = new System.Drawing.Size(120, 20);
			this.tb_connectIP.TabIndex = 4;
			this.tb_connectIP.Text = "127.0.0.1";
			// 
			// tb_messageBox
			// 
			this.tb_messageBox.Enabled = false;
			this.tb_messageBox.Location = new System.Drawing.Point(27, 135);
			this.tb_messageBox.Multiline = true;
			this.tb_messageBox.Name = "tb_messageBox";
			this.tb_messageBox.Size = new System.Drawing.Size(328, 228);
			this.tb_messageBox.TabIndex = 6;
			// 
			// CB_send
			// 
			this.CB_send.Location = new System.Drawing.Point(150, 369);
			this.CB_send.Name = "CB_send";
			this.CB_send.Size = new System.Drawing.Size(75, 23);
			this.CB_send.TabIndex = 7;
			this.CB_send.Text = "Send";
			this.CB_send.UseVisualStyleBackColor = true;
			this.CB_send.Click += new System.EventHandler(this.CB_send_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.nUD_listnPort);
			this.groupBox1.Controls.Add(this.CB_server);
			this.groupBox1.Controls.Add(this.tb_listnIP);
			this.groupBox1.Location = new System.Drawing.Point(29, 25);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(164, 104);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Server";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tb_connectIP);
			this.groupBox2.Controls.Add(this.CB_client);
			this.groupBox2.Controls.Add(this.nUD_connectPort);
			this.groupBox2.Location = new System.Drawing.Point(199, 29);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(156, 100);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Client";
			// 
			// SimpleIPTestingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(385, 405);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.CB_send);
			this.Controls.Add(this.tb_messageBox);
			this.Name = "SimpleIPTestingForm";
			this.Text = "SimpleIP tester";
			((System.ComponentModel.ISupportInitialize)(this.nUD_listnPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD_connectPort)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CB_server;
		private System.Windows.Forms.TextBox tb_listnIP;
		private System.Windows.Forms.NumericUpDown nUD_listnPort;
		private System.Windows.Forms.Button CB_client;
		private System.Windows.Forms.NumericUpDown nUD_connectPort;
		private System.Windows.Forms.TextBox tb_connectIP;
		private System.Windows.Forms.TextBox tb_messageBox;
		private System.Windows.Forms.Button CB_send;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}

