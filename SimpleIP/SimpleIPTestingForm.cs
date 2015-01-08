using System;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;

using System.Threading;


using System.Text;

namespace SimpleIP {
	public partial class SimpleIPTestingForm : Form {

		private TCPConnection _connection = new TCPConnection();
		public SimpleIPTestingForm() {
			InitializeComponent();
			_connection.OnMessageReceived += OnMessageReceived;
			_connection.OnConnectionEstablished += OnConnectionEstablished;
		}

		#region TCP
			#region Handling
			private void OnConnectionEstablished(object sender, EventArgs e) {
				tb_messageBox_tcp.Enabled = true;
			}
			private void OnMessageReceived(object sender, IPMessageEventArgs e) {
				tb_messageBox_tcp.Text = Convert.ToBase64String(e.Message);
			}
			#endregion
			#region Buttons
			private void CB_server_Click(object sender, EventArgs e) {
				_connection.BecomeAServerAndWait(tb_listnIP.Text, Convert.ToInt32(nUD_listnPort.Value));
			}
			private void CB_client_Click(object sender, EventArgs e) {
				_connection.BecomeAClientAndConnect(tb_connectIP.Text, Convert.ToInt32(nUD_connectPort.Value));
			}
			private void CB_send_Click(object sender, EventArgs e) {
				_connection.Send(Convert.FromBase64String(tb_messageBox_tcp.Text));
			}
			#endregion
		#endregion

		#region UDP
			
			UdpClient _client;

			#region IN
			private void CB_peerIn_Click(object sender, EventArgs e) {

				_client = new UdpClient(Convert.ToInt32(nUD_peerLocalPort.Value));

				Thread receiver = new Thread(ReceivingThread);
				receiver.Start();
			}
			private void ReceivingThread() {
				IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
				while(true){
				byte[] message = _client.Receive(ref remoteEP);
				string text = Encoding.Unicode.GetString(message);
				tb_messagebox_udp.Text += text + Environment.NewLine + remoteEP.Address + ":" + remoteEP.Port;
				}
			}
			#endregion

			#region OUT
			private void CB_peerOut_Click(object sender, EventArgs e) {
				IPAddress addr;
				IPAddress.TryParse(tb_peerDestIP.Text, out addr);

				_client = new UdpClient();
				_client.Connect(new IPEndPoint(addr, Convert.ToInt32(nUD_peedDestPort.Value)));
			}

			private void CB_send_udp_Click(object sender, EventArgs e) {
				byte[] message = Encoding.Unicode.GetBytes(tb_messagebox_udp.Text);
				_client.Send(message, message.Length);
			}
			#endregion


		#endregion


		
	}
}



//_client.Client.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.SendLowWater, "SHIT");