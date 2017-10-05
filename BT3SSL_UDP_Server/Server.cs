using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace BT3SSL_UDP_Server
{
	class Server
	{
		public const string strKey = "duongthanhdung96";
		public const string strMessage = "my message :)";

		Socket serverSock;
		IPEndPoint serverIP;
		byte[] dataSend, dataReceive;

		public Server()
		{
			Console.WriteLine("Server initialising...");
			serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);	//create a socket for server using IPv4, datagram, UDP
			serverIP = new IPEndPoint(IPAddress.Any, 7914);		//listen to all interface at port 1724
			serverSock.Bind(serverIP);		//bind server socket to ip

			dataSend = new byte[1024];		//data send to client, 1Kb buffer
			dataReceive = new byte[1024];	//data receive from client, 1Kb buffer
		}
	}
}