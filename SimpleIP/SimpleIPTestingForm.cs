using System;
using System.Windows.Forms;

namespace SimpleIP {
	public partial class SimpleIPTestingForm : Form {

		private TCPConnection _connection = new TCPConnection();
		public SimpleIPTestingForm() {
			InitializeComponent();
			_connection.OnMessageReceived += OnMessageReceived;
			_connection.OnConnectionEstablished += OnConnectionEstablished;
		}

		private void OnConnectionEstablished(object sender, EventArgs e) {
			tb_messageBox.Enabled = true;
		}
		private void OnMessageReceived(object sender, IPMessageEventArgs e) {
			tb_messageBox.Text = Convert.ToBase64String(e.Message);
		}
		private void CB_server_Click(object sender, EventArgs e) {
			_connection.BecomeAServerAndWait(tb_listnIP.Text, Convert.ToInt32(nUD_listnPort.Value));
		}
		private void CB_client_Click(object sender, EventArgs e) {
			_connection.BecomeAClientAndConnect(tb_connectIP.Text, Convert.ToInt32(nUD_connectPort.Value));
		}
		private void CB_send_Click(object sender, EventArgs e) {
			_connection.Send(Convert.FromBase64String(tb_messageBox.Text));
		}
	}
}