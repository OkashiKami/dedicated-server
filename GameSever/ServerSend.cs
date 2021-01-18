using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
	class ServerSend
	{
		public static void Welcome(int _toClient, string _msg)
		{
			using (Packet _packet = new Packet((int)ServerPackets.welcome))
			{
				_packet.Write(_msg);
				_packet.Write(_toClient);

				SendTCPData(_toClient, _packet);
			}
		}

		/// <summary>This method prepares the packet to be sent</summary>
		private static void SendTCPData(int _toClient, Packet _packet)
		{
			_packet.WriteLength(); //length of bytelist inserted at beginning of the packet
			Server.clients[_toClient].tcp.SendData(_packet);
		}

		private static void SendTCPDataToAll(Packet _packet)
		{
			_packet.WriteLength();
			for (int i = 1; i <= Server.MaxPlayers; i++)
			{
				Server.clients[i].tcp.SendData(_packet);
			}
		}
		private static void SendTCPDataToAll(int _exceptClient, Packet _packet)
		{
			_packet.WriteLength();
			for (int i = 1; i <= Server.MaxPlayers; i++)
			{
				if (i != _exceptClient)
				{
					Server.clients[i].tcp.SendData(_packet);
				}
			}
		}
	}
} 
