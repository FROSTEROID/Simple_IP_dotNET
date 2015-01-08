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
			this.tb_messageBox_tcp = new System.Windows.Forms.TextBox();
			this.CB_send_tcp = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.gB_tcp = new System.Windows.Forms.GroupBox();
			this.gB_udp = new System.Windows.Forms.GroupBox();
			this.tb_messagebox_udp = new System.Windows.Forms.TextBox();
			this.CB_send_udp = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.CB_peerOut = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.nUD_peerLocalPort = new System.Windows.Forms.NumericUpDown();
			this.nUD_peedDestPort = new System.Windows.Forms.NumericUpDown();
			this.tb_peerDestIP = new System.Windows.Forms.TextBox();
			this.CB_peerIn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nUD_listnPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD_connectPort)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gB_tcp.SuspendLayout();
			this.gB_udp.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD_peerLocalPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD_peedDestPort)).BeginInit();
			this.SuspendLayout();
			// 
			// CB_server
			// 
			this.CB_server.Location = new System.Drawing.Point(6, 71);
			this.CB_server.Name = "CB_server";
			this.CB_server.Size = new System.Drawing.Size(109, 23);
			this.CB_server.TabIndex = 0;
			this.CB_server.Text = "Become Server";
			this.CB_server.UseVisualStyleBackColor = true;
			this.CB_server.Click += new System.EventHandler(this.CB_server_Click);
			// 
			// tb_listnIP
			// 
			this.tb_listnIP.Location = new System.Drawing.Point(6, 19);
			this.tb_listnIP.Name = "tb_listnIP";
			this.tb_listnIP.Size = new System.Drawing.Size(109, 20);
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
			this.nUD_listnPort.Size = new System.Drawing.Size(109, 20);
			this.nUD_listnPort.TabIndex = 2;
			this.nUD_listnPort.Value = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			// 
			// CB_client
			// 
			this.CB_client.Location = new System.Drawing.Point(6, 71);
			this.CB_client.Name = "CB_client";
			this.CB_client.Size = new System.Drawing.Size(109, 23);
			this.CB_client.TabIndex = 3;
			this.CB_client.Text = "Become Client";
			this.CB_client.UseVisualStyleBackColor = true;
			this.CB_client.Click += new System.EventHandler(this.CB_client_Click);
			// 
			// nUD_connectPort
			// 
			this.nUD_connectPort.Location = new System.Drawing.Point(6, 45);
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
			this.nUD_connectPort.Size = new System.Drawing.Size(109, 20);
			this.nUD_connectPort.TabIndex = 5;
			this.nUD_connectPort.Value = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			// 
			// tb_connectIP
			// 
			this.tb_connectIP.Location = new System.Drawing.Point(6, 19);
			this.tb_connectIP.Name = "tb_connectIP";
			this.tb_connectIP.Size = new System.Drawing.Size(109, 20);
			this.tb_connectIP.TabIndex = 4;
			this.tb_connectIP.Text = "127.0.0.1";
			// 
			// tb_messageBox_tcp
			// 
			this.tb_messageBox_tcp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tb_messageBox_tcp.Enabled = false;
			this.tb_messageBox_tcp.Location = new System.Drawing.Point(6, 156);
			this.tb_messageBox_tcp.Multiline = true;
			this.tb_messageBox_tcp.Name = "tb_messageBox_tcp";
			this.tb_messageBox_tcp.Size = new System.Drawing.Size(324, 249);
			this.tb_messageBox_tcp.TabIndex = 6;
			// 
			// CB_send_tcp
			// 
			this.CB_send_tcp.Location = new System.Drawing.Point(6, 129);
			this.CB_send_tcp.Name = "CB_send_tcp";
			this.CB_send_tcp.Size = new System.Drawing.Size(324, 23);
			this.CB_send_tcp.TabIndex = 7;
			this.CB_send_tcp.Text = "Send";
			this.CB_send_tcp.UseVisualStyleBackColor = true;
			this.CB_send_tcp.Click += new System.EventHandler(this.CB_send_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CB_server);
			this.groupBox1.Controls.Add(this.nUD_connectPort);
			this.groupBox1.Controls.Add(this.tb_listnIP);
			this.groupBox1.Location = new System.Drawing.Point(35, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(122, 104);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Server";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.nUD_listnPort);
			this.groupBox2.Controls.Add(this.tb_connectIP);
			this.groupBox2.Controls.Add(this.CB_client);
			this.groupBox2.Location = new System.Drawing.Point(189, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(121, 104);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Client";
			// 
			// gB_tcp
			// 
			this.gB_tcp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gB_tcp.Controls.Add(this.groupBox1);
			this.gB_tcp.Controls.Add(this.groupBox2);
			this.gB_tcp.Controls.Add(this.tb_messageBox_tcp);
			this.gB_tcp.Controls.Add(this.CB_send_tcp);
			this.gB_tcp.Location = new System.Drawing.Point(12, 12);
			this.gB_tcp.Name = "gB_tcp";
			this.gB_tcp.Size = new System.Drawing.Size(336, 412);
			this.gB_tcp.TabIndex = 10;
			this.gB_tcp.TabStop = false;
			this.gB_tcp.Text = "TCP";
			// 
			// gB_udp
			// 
			this.gB_udp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gB_udp.Controls.Add(this.tb_messagebox_udp);
			this.gB_udp.Controls.Add(this.CB_send_udp);
			this.gB_udp.Controls.Add(this.groupBox3);
			this.gB_udp.Location = new System.Drawing.Point(354, 12);
			this.gB_udp.Name = "gB_udp";
			this.gB_udp.Size = new System.Drawing.Size(336, 412);
			this.gB_udp.TabIndex = 11;
			this.gB_udp.TabStop = false;
			this.gB_udp.Text = "UDP";
			// 
			// tb_messagebox_udp
			// 
			this.tb_messagebox_udp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tb_messagebox_udp.Location = new System.Drawing.Point(6, 157);
			this.tb_messagebox_udp.Multiline = true;
			this.tb_messagebox_udp.Name = "tb_messagebox_udp";
			this.tb_messagebox_udp.Size = new System.Drawing.Size(324, 249);
			this.tb_messagebox_udp.TabIndex = 11;
			// 
			// CB_send_udp
			// 
			this.CB_send_udp.Location = new System.Drawing.Point(6, 130);
			this.CB_send_udp.Name = "CB_send_udp";
			this.CB_send_udp.Size = new System.Drawing.Size(324, 23);
			this.CB_send_udp.TabIndex = 12;
			this.CB_send_udp.Text = "Send";
			this.CB_send_udp.UseVisualStyleBackColor = true;
			this.CB_send_udp.Click += new System.EventHandler(this.CB_send_udp_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.CB_peerOut);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.nUD_peerLocalPort);
			this.groupBox3.Controls.Add(this.nUD_peedDestPort);
			this.groupBox3.Controls.Add(this.tb_peerDestIP);
			this.groupBox3.Controls.Add(this.CB_peerIn);
			this.groupBox3.Location = new System.Drawing.Point(48, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(236, 104);
			this.groupBox3.TabIndex = 10;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Peer";
			// 
			// CB_peerOut
			// 
			this.CB_peerOut.Location = new System.Drawing.Point(121, 71);
			this.CB_peerOut.Name = "CB_peerOut";
			this.CB_peerOut.Size = new System.Drawing.Size(109, 23);
			this.CB_peerOut.TabIndex = 8;
			this.CB_peerOut.Text = "Configure sender";
			this.CB_peerOut.UseVisualStyleBackColor = true;
			this.CB_peerOut.Click += new System.EventHandler(this.CB_peerOut_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(190, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "destiny";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "local";
			// 
			// nUD_peerLocalPort
			// 
			this.nUD_peerLocalPort.Location = new System.Drawing.Point(6, 45);
			this.nUD_peerLocalPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			this.nUD_peerLocalPort.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.nUD_peerLocalPort.Name = "nUD_peerLocalPort";
			this.nUD_peerLocalPort.Size = new System.Drawing.Size(109, 20);
			this.nUD_peerLocalPort.TabIndex = 5;
			this.nUD_peerLocalPort.Value = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			// 
			// nUD_peedDestPort
			// 
			this.nUD_peedDestPort.Location = new System.Drawing.Point(121, 45);
			this.nUD_peedDestPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			this.nUD_peedDestPort.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.nUD_peedDestPort.Name = "nUD_peedDestPort";
			this.nUD_peedDestPort.Size = new System.Drawing.Size(109, 20);
			this.nUD_peedDestPort.TabIndex = 2;
			this.nUD_peedDestPort.Value = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			// 
			// tb_peerDestIP
			// 
			this.tb_peerDestIP.Location = new System.Drawing.Point(68, 19);
			this.tb_peerDestIP.Name = "tb_peerDestIP";
			this.tb_peerDestIP.Size = new System.Drawing.Size(109, 20);
			this.tb_peerDestIP.TabIndex = 4;
			this.tb_peerDestIP.Text = "127.0.0.1";
			// 
			// CB_peerIn
			// 
			this.CB_peerIn.Location = new System.Drawing.Point(6, 71);
			this.CB_peerIn.Name = "CB_peerIn";
			this.CB_peerIn.Size = new System.Drawing.Size(109, 23);
			this.CB_peerIn.TabIndex = 3;
			this.CB_peerIn.Text = "Configure receiver";
			this.CB_peerIn.UseVisualStyleBackColor = true;
			this.CB_peerIn.Click += new System.EventHandler(this.CB_peerIn_Click);
			// 
			// SimpleIPTestingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(699, 436);
			this.Controls.Add(this.gB_udp);
			this.Controls.Add(this.gB_tcp);
			this.Name = "SimpleIPTestingForm";
			this.Text = "SimpleIP tester";
			((System.ComponentModel.ISupportInitialize)(this.nUD_listnPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD_connectPort)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.gB_tcp.ResumeLayout(false);
			this.gB_tcp.PerformLayout();
			this.gB_udp.ResumeLayout(false);
			this.gB_udp.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nUD_peerLocalPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nUD_peedDestPort)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CB_server;
		private System.Windows.Forms.TextBox tb_listnIP;
		private System.Windows.Forms.NumericUpDown nUD_listnPort;
		private System.Windows.Forms.Button CB_client;
		private System.Windows.Forms.NumericUpDown nUD_connectPort;
		private System.Windows.Forms.TextBox tb_connectIP;
		private System.Windows.Forms.TextBox tb_messageBox_tcp;
		private System.Windows.Forms.Button CB_send_tcp;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox gB_tcp;
		private System.Windows.Forms.GroupBox gB_udp;
		private System.Windows.Forms.TextBox tb_messagebox_udp;
		private System.Windows.Forms.Button CB_send_udp;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.NumericUpDown nUD_peedDestPort;
		private System.Windows.Forms.TextBox tb_peerDestIP;
		private System.Windows.Forms.Button CB_peerIn;
		private System.Windows.Forms.NumericUpDown nUD_peerLocalPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button CB_peerOut;
	}
}

