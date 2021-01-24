using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
	class ServerHandle
	{
		public static void WelcomeReceived(int _fromClient, Packet _packet)
		{
			int _clientIdCheck = _packet.ReadInt();
			string _username = _packet.ReadString();

			Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected succesfully and is now Client #{_fromClient}");

			if(_fromClient != _clientIdCheck)
			{
				Console.WriteLine($"Client \"{_username}\" (ID:{_fromClient}) has assumed the wrong client ID of {_clientIdCheck}");
			}

			// TODO: send client into game
		}

		public static void UDPTestReceived(int _fromClient, Packet _packet)
		{
			string _msg = _packet.ReadString();
			Console.WriteLine($"Reading packet via UDP. Contains message: {_msg}");
		}
	}
}
