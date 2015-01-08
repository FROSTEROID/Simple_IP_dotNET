using System;
using System.Drawing.Text;
using System.Text; // Encoding is there
using System.Windows.Forms; //Timer is there

using System.Net;
using System.Net.Sockets;

/// <summary>
/// Пространство заключает в себе классы, значительно упрощающие работу с .Net-реализацией IP-коммуникации.
/// Для работы с ними также понадобится использование пространства System.Net, чтобы отправлять аргумент типа IPAddress.
/// (UPD: Теперь можно пихать стринги. Но правил	ьность форматирования не проверяется)
/// The namespace is containing classes that make it easier to manipulate .Net classes for IP-communication.
/// You also need to use System.Net in Your code to send to classes IPAddress-arguments. 
/// (UPD: now they can accept IP as a string, but formatting isn't checked)
/// </summary>
namespace SimpleIP {
	/// <summary>
	/// Свой нескушный тип обработчика события для обработки принятия сообщения.
	/// (Да, свой, с делегатом и параметрами!)
	/// </summary>
	public class IPMessageEventArgs{
		public IPMessageEventArgs(byte[] msg, int ln){
			Message = msg;
			Length = ln;
		}
		public byte[] Message;
		public int Length;
	}
	public delegate void IPMessageDelegate(object sender, IPMessageEventArgs e);

	#region TCP
		/// <summary>
		/// Инкапсулировать ещё глубже? Пожалуйста!
		/// Want a deeper incapsulation? Here it is!
		/// </summary>
		class TCPConnection {
			#region States
			public enum ConnectionState {Nothing, ServerWaiting, ServerConnected, ClientConnecting, ClientConnected};
			public ConnectionState State = ConnectionState.Nothing;
			#endregion

			#region Serving objects
				private TCPServer _server;
				private TCPClient _client;
			#endregion

			#region Handling
			/// <summary>
				/// Случается, когда получаем и складываем в массив байтов сообщение от клиента.
				/// Второй аргумент IPMessageEventArgs e содержит параметры Message и length - 
				/// это массив байтов сообщения и его длина соответственно.
				/// Fires when the server gets data from a client and makes a byte array from it.
				/// The second argument IPMessageEventArgs e contains parameters "Message" and "length" - 
				/// byte massiv and it's length.
				/// </summary>
			public event IPMessageDelegate OnMessageReceived;
			/// <summary>
				/// Случается после того, как сервер принимает запрос на подключение от клиента. (Если сервер оного ждёт)
				/// После этого и клиент, и сервер начинают ожидать сообщения и могут их отправлять.
				/// Fires when the server gets a connection request from Client. (only if serv is already waiting for it)
				/// After that they both are waiting for messages and are able to send messages.
				/// </summary>
			public event EventHandler OnConnectionEstablished;

			private void OnInnerMessageReceived(object sender, IPMessageEventArgs e) {
				if (OnMessageReceived != null) OnMessageReceived(sender, e);
			}
			private void OnInnerConnectionEstablished(object sender, EventArgs e) {
				switch (State) {
					case ConnectionState.ServerWaiting:
						State = ConnectionState.ServerConnected;
						break;
					case ConnectionState.ClientConnecting:
						State = ConnectionState.ClientConnected;
						break;
					default:
						throw new Exception("Time to shit bricks.");
				}
				if (OnConnectionEstablished != null) OnConnectionEstablished(sender, e);
			}

			#endregion

			#region Public commands
				public void BecomeAServerAndWait(string ip, int port) {
					switch (State) {
						case ConnectionState.Nothing:
							break;
						case ConnectionState.ServerConnected:
						case ConnectionState.ServerWaiting:
							_server.Close();
							break;
						case ConnectionState.ClientConnected:
						case ConnectionState.ClientConnecting:
							_client.Close();
							break;
					}
					if (ip != "")
						_server = new TCPServer(ip, port);
					else
						_server = new TCPServer(port);
					_server.StartListening();
					_server.OnConnectionEstablished += OnInnerConnectionEstablished;
					_server.OnMessageReceived += OnInnerMessageReceived;

					State = ConnectionState.ServerWaiting;
				}

				public void BecomeAClientAndConnect(string ip, int port) {
					switch (State) {
						case ConnectionState.Nothing:
							break;
						case ConnectionState.ServerConnected:
						case ConnectionState.ServerWaiting:
							_server.Close();
							break;
						case ConnectionState.ClientConnected:
						case ConnectionState.ClientConnecting:
							_client.Close();
							break;
					}
					_client = new TCPClient();
					_client.Connect(ip, port);
					_client.OnConnectionEstablished += OnInnerConnectionEstablished;
					_client.OnMessageReceived += OnInnerMessageReceived;

					State = ConnectionState.ClientConnecting;
				}

				public void Send(byte[] message) {
					switch (State) {
						case ConnectionState.ServerConnected:
							_server.SendMessage(message);
							break;
						case ConnectionState.ClientConnected:
							_client.SendMessage(message);
							break;
						default:
							throw new Exception("Can't send message. No connection.");
					}
				}

				public void Close() {
					switch (State) {
						case ConnectionState.Nothing:
							break;
						case ConnectionState.ServerWaiting:
							_server.Close();
							break;
						case ConnectionState.ServerConnected:
							_server.Close();
							break;
						case ConnectionState.ClientConnected:
							_client.Close();
							break;
					}
					State = ConnectionState.Nothing;
				}

			#endregion
		}

		/// <summary>
		/// Класс, управляющий .Net-классом System.Net.Sockets.TCPListener. Позволяет относительно легко управлять сервером TCP-соединения.
		/// Один экземпляр - одно соединение. После разрыва соединения экземпляр подлежит уничтожению(обнулите ссыль и верьте в силу GC).
		/// A class made to simply communicate with System.Net.Sockets.TCPListener. Making a TCP-server is relationally easy with it.
		/// One object - one connection. After disconnection the object must be killed (assign null to your pointer and believe in GC's power).
		/// </summary>
		class TCPServer {

		#region constants
			private const int WAITING_TIMEOUT = 15000; // waiting iterations
			private const int WAITING_STEP = 100; // iteration's milliseconds
		#endregion

		#region objects
			private TcpListener _tcpListener;
			private TcpClient _acceptedClient;
		
			private NetworkStream _stream;

			private Timer _connectionWaiter;
			private Timer _messageWaiter;
		#endregion

		#region parameters
			private bool _isConnected=false;
			private int _steps=0;
		#endregion

		#region handlers
			/// <summary>
			/// Случается, когда получаем и складываем в массив байтов сообщение от клиента.
			/// Второй аргумент IPMessageEventArgs e содержит параметры Message и length - 
			/// это массив байтов сообщения и его длина соответственно.
			/// Fires when the server gets data from a client and makes a byte array from it.
			/// The second argument IPMessageEventArgs e contains parameters "Message" and "length" - 
			/// byte massiv and it's length.
			/// </summary>
			public event IPMessageDelegate OnMessageReceived;
			/// <summary>
			/// Случается после того, как сервер принимает запрос на подключение от клиента. (Если сервер оного ждёт)
			/// После этого и клиент, и сервер начинают ожидать сообщения и могут их отправлять.
			/// Fires when the server gets a connection request from Client. (only if serv is already waiting for it)
			/// After that they both are waiting for messages and are able to send messages.
			/// </summary>
			public event EventHandler OnConnectionEstablished;

			private void connectionWaiter_Tick(object sender, EventArgs e) { // Тикаем таймером, ожидающим запроса на подключение
				if(_steps < WAITING_TIMEOUT){
					if (_tcpListener.Pending()) {
						AcceptSocket();
						_tcpListener.Stop();
						_connectionWaiter.Stop();
					}
					_steps++;
				} 
				else _connectionWaiter.Stop();
			}
			private void AcceptSocket() { // Принятие запроса (вызывается, когда очередной тик ожидания обнаруживает входящий запрос)
				_acceptedClient = _tcpListener.AcceptTcpClient();
				_stream = _acceptedClient.GetStream();
				_messageWaiter.Start();

				_isConnected = true;
				// Вызываем обработчик события установления соединения:
				OnConnectionEstablished(this, null); 
			}
			void messageWaiter_Tick(object sender, EventArgs e) { // Тикаем таймером, ожидающим сообщения от клиента
				if (_acceptedClient != null && _acceptedClient.Connected) {
					if (_acceptedClient.Available > 0) {
						var length = _acceptedClient.Available;
						var b = new byte[length];
						_stream.Read(b, 0, length);
						// Вызываем обработчик события получения сообщения, (не )присвоенный нам извне:
						OnMessageReceived(this, new IPMessageEventArgs(b, length)); 
					}
				}
			}
		#endregion

		#region Structing
			/// <summary>
			/// Конструктор с заданием IPадреса и порта для последующего ожидания.
			/// Constructor with IPAddress and port setting for following connection.
			/// </summary>
			/// <param name="ipAddress">Адрес</param>
			/// <param name="port">Порт. Рекомендуется использовать число примерно между 46к и 65к (частные порты)</param>
			public TCPServer(String ipAddress, int port){
				Initialize(IPAddress.Parse(ipAddress), port);
			}
			/// <summary>
			/// Конструктор с заданием IPадреса и порта для последующего ожидания.
			/// Constructor with IPAddress and port setting for following connection.
			/// </summary>
			/// <param name="ipAddress">Адрес</param>
			/// <param name="port">Порт. Рекомендуется использовать число примерно между 46к и 65к (частные порты)</param>
			public TCPServer(IPAddress ipAddress, int port) {
				Initialize(ipAddress, port);
			}
			/// <summary>
			/// Конструктор с заданием порта для последующего ожидания(Сервер будет ожидать соединения с любого IP).
			/// Constructor with port setting for following connection(The server will wait for a connection from any IP).
			/// </summary>
			/// <param name="port">Порт. Рекомендуется использовать число примерно между 46к и 65к (частные порты)</param>
			public TCPServer(int port) {
				Initialize(IPAddress.Any, port);
			}

			private void Initialize(IPAddress ipAddress, int port) {
				_tcpListener = new TcpListener(ipAddress, port);

				_connectionWaiter = new Timer {Interval = WAITING_STEP};
				_connectionWaiter.Tick += connectionWaiter_Tick;

				_messageWaiter = new Timer {Interval = WAITING_STEP};
				_messageWaiter.Tick += messageWaiter_Tick;
			}
		#endregion

		#region Public Commands
			#region ClientConnecting
			/// <summary>
			/// Makes server start waiting for a connection from pre-setted IP and port.
			/// </summary>
			public void StartListening(){
				if(_tcpListener!=null){
					_tcpListener.Start();
					_steps = 0;
					_connectionWaiter.Start();
				}
			}
			#endregion

			#region Sending
			/// <summary>
			/// ОТправляет сообщение, котрое уже сформировано в байтовый массив.
			/// Sends a byte massiv.
			/// </summary>
			/// <param name="message">The Message</param>
			public void SendMessage(byte[] message){
				if(_acceptedClient!=null && _acceptedClient.Connected){
					_stream.Write(message, 0, message.Length);
				}
			}
			/// <summary>
			/// ОТправляет сообщение, котрое уже сформировано в байтовый массив.
			/// Sends a byte massiv.
			/// </summary>
			/// <param name="message">The Message</param>
			/// <param name="length">Длина сообщения</param>
			public void SendMessage(byte[] message, int length) {
				if (_acceptedClient != null && _acceptedClient.Connected) {
					_stream.Write(message, 0, length);
				}
			}
			/// <summary>
			/// Отправляет заданную строку символов, предварительно преобразовуя её 
			///  в байтовый массив с использованием эгоистически пендосской кодировки ASCII.
			/// Sends text, preliminarily encoding it to byte array withby ASCII.
			/// </summary>
			/// <param name="message"></param>
			public void SendASCIIString(String message){
				byte[] buffer = Encoding.ASCII.GetBytes(message);
				SendMessage(buffer, message.Length);
			}
			/// <summary>
			/// Отправляет заданную строку символов, предварительно преобразовуя её 
			///  в байтовый массив с использованием Unicode.
			/// Sends text, preliminarily encoding it to byte array withby Unicode.
			/// </summary>
			/// <param name="message"></param>
			public void SendUnicodeString(String message) {
				byte[] buffer = Encoding.Unicode.GetBytes(message);
				SendMessage(buffer, message.Length*2);
			}
			#endregion

			#region Closing
			/// <summary>
			/// Закрывает соединение и делает сервер неиспользовабельным.
			/// Closes connection and makes the server unusable.
			/// </summary>
			public void Close(){
				if(_tcpListener!=null) {
					if (_stream != null) _stream.Close();
					_tcpListener.Stop();
					if(_acceptedClient!=null)
						_acceptedClient.Close();
					_tcpListener.Server.Close();
				}
				_messageWaiter.Stop();
				_messageWaiter.Dispose();
				_connectionWaiter.Stop();
				_connectionWaiter.Dispose();
			}
			#endregion
		#endregion

		#region Gettings
			/// <summary>
			/// Do You really need an explanation for this??
			/// </summary>
			/// <returns></returns>
			public IPAddress GetClientIP(){
				if(_isConnected)
					return ((IPEndPoint)_acceptedClient.Client.LocalEndPoint).Address;
				else
					return null;
			}
			public String GetClientIP_str() {
				if (_isConnected)
					return ((IPEndPoint)_acceptedClient.Client.LocalEndPoint).Address.ToString();
				else
					return null;
			}
		#endregion
		}

		class TCPClient{
		#region constants
			private const int WAITING_TIMEOUT = 15000; // iterations
			private const int WAITING_STEP = 20; // milliseconds
		#endregion

		#region objects
			private TcpClient _tcpClient;
		
			NetworkStream _stream;

			private static Timer _messageWaiter;
		#endregion

		#region parameters
			private bool isConnected=false;
		#endregion

		#region handlers
			/// <summary>
			/// Случается, когда получаем и складываем в массив байтов сообщение от клиента.
			/// Второй аргумент "IPMessageEventArgs e" содержит параметры Message и length - 
			/// Это массив байтов сообщения и его длина соответственно.
			/// </summary>
			public event IPMessageDelegate OnMessageReceived;
			/// <summary>
			/// Случается после того, как сервер принимает запрос на подключение от клиента.
			/// После этого и клиент, и сервер начинают ожидать сообщения и могут их отправлять.
			/// </summary>
			public event EventHandler OnConnectionEstablished;

			void messageWaiter_Tick(object sender, EventArgs e) { // Тикаем таймером, ожидающим сообщения от сервера
				if(isConnected){
					if (_tcpClient != null && _tcpClient.Connected) {
						if (_tcpClient.Available > 0) {
							int length = _tcpClient.Available;
							var b = new byte[length];
							_stream.Read(b, 0, length);
							// Вызываем обработчик события получения сообщения, (не )присвоенный нам извне:
							OnMessageReceived(this, new IPMessageEventArgs(b, length)); 
						}
					}
				}
			}
		#endregion

		#region Structing
			/// <summary>
			/// Создаёт экземпляр клиента для последующего подключения. При подключении необходимо будет указать IP и порт (метод Connect).
			/// Creates a client for following connecting. To connect, You must give it IP and port (Connect method).
			/// </summary>
			public TCPClient() {
				_tcpClient = new TcpClient();

				_messageWaiter = new Timer {Interval = WAITING_STEP};
				_messageWaiter.Tick += messageWaiter_Tick;
				_messageWaiter.Start();
			}
			//public TCPClient(String ipAddress, int port){
			//	Initialize(ipAddress, port);
			//}
			//public TCPClient(IPAddress ipAddress, int port) {
			//	Initialize(ipAddress.ToString(), port);
			//}

			//private void Initialize(String ipAddress, int port) {
			//	tcpClient = new TcpClient(ipAddress, port);
			
			//	messageWaiter = new Timer();
			//	messageWaiter.Interval = WAITING_STEP;
			//	messageWaiter.Tick += messageWaiter_Tick;
			//}
		#endregion

		#region Public Commands
			#region ClientConnecting
			/// <summary>
			/// Отправить серверу запрос на подклюение
			/// Send a connection request to server
			/// </summary>
			/// <param name="ipAddress">IP of the server</param>
			/// <param name="port">Порт сервера. It's recommended to use a number approxly between 45k and 65k</param>
			public void Connect(IPAddress ipAddress, int port) {
				if (_tcpClient != null) {
					_tcpClient.BeginConnect(ipAddress, port, new AsyncCallback(EndConnecting), new object());
				}
			}
			/// <summary>
			/// Отправить серверу запрос на подклюение
			/// Send a connection request to server
			/// </summary>
			/// <param name="ipAddress">IP of the server</param>
			/// <param name="port">Порт сервера. It's recommended to use a number approxly between 45k and 65k</param>
			public void Connect(String ipAddress, int port) {
				if (_tcpClient != null) {
					IPAddress address = IPAddress.Parse(ipAddress);
					_tcpClient.BeginConnect(address, port, new AsyncCallback(EndConnecting), new object());
				}
			}private void EndConnecting(IAsyncResult rez){
				if (rez.IsCompleted) {
					isConnected = true;
					_stream = _tcpClient.GetStream();
					OnConnectionEstablished(this, null);
				}
				else {
				}
			}
			#endregion

			#region Sending
			/// <summary>
			/// ОТправляет сообщение, котрое уже сформировано в байтовый массив.
			/// Sends a byte massiv.
			/// </summary>
			/// <param name="message">The Message</param>
			public void SendMessage(byte[] message){
				if (_tcpClient != null && _tcpClient.Connected) {
					_stream.Write(message, 0, message.Length);
				}
			}
			/// <summary>
			/// ОТправляет сообщение, котрое уже сформировано в байтовый массив.
			/// Sends a byte massiv.
			/// </summary>
			/// <param name="message">The Message</param>
			/// <param name="length">Длина сообщения</param>
			public void SendMessage(byte[] message, int length) {
				if (_tcpClient != null && _tcpClient.Connected) {
					_stream.Write(message, 0, length);
				}
			}
			/// <summary>
			/// Отправляет заданную строку символов, предварительно преобразовуя её 
			///  в байтовый массив с использованием эгоистически пендосской кодировки ASCII.
			/// Sends text, preliminarily encoding it to byte array withby ASCII.
			/// </summary>
			/// <param name="message"></param>
			public void SendASCIIString(String message){
				byte[] buffer = Encoding.ASCII.GetBytes(message);
				SendMessage(buffer, message.Length);
			}
			/// <summary>
			/// Отправляет заданную строку символов, предварительно преобразовуя её 
			///  в байтовый массив с использованием Unicode.
			/// Sends text, preliminarily encoding it to byte array withby Unicode.
			/// </summary>
			/// <param name="message">TryToGuess!</param>
			public void SendUnicodeString(String message) {
				byte[] buffer = Encoding.Unicode.GetBytes(message);
				SendMessage(buffer, message.Length * 2);
			}
			#endregion

			#region Closing
			/// <summary>
			/// Закрывает соединения и делает сервер неиспользовабельным.
			/// Closes connections and makes the server unusable.
			/// </summary>
			public void Close(){
				if(_tcpClient!=null){
					if (_stream != null) _stream.Close();
					_tcpClient.Client.Close();
					_tcpClient.Close();
					_messageWaiter.Stop();
					_messageWaiter.Dispose();
				}

			}
			#endregion
		#endregion

		#region Gettings
			public IPAddress GetServerIP(){
				if(isConnected)
					return ((IPEndPoint)_tcpClient.Client.LocalEndPoint).Address;
				else
					return null;
			}
			public String getServerIP_str() {
				if (isConnected)
					return ((IPEndPoint)_tcpClient.Client.LocalEndPoint).Address.ToString();
				else
					return null;
			}
		#endregion
		}
	#endregion

	#region UDP
		class UDPClient{

			#region	Constants
			public const String DEFAULT_IP_ADDRESS = "127.0.0.1";
			public const int DEFAULT_PORT = 65000;
			#endregion

			#region Parameters
			private int _destPort;
			private IPAddress _destIP;
			private int _listenPort;
			private IPAddress _listenIP;
			#endregion

			#region Serving objects
			private UdpClient _client;
			#endregion

			#region Structing
			public UDPClient() {
				Initialise();
			}
			public UDPClient(int destinationPort) {
				Initialise();
			}
			public UDPClient(String destinataionIPAddress, int destinationPort) {
				Initialise();
			}

			private void Initialise() {
				_client = new UdpClient(new IPEndPoint(_destIP, _destPort));
			}
			#endregion

			public void SetPort(int port) {
				
			}

		}
	#endregion
}
