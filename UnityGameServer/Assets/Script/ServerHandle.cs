using System;
using UnityEngine;

public class ServerHandle
{
	public static void WelcomeReceived(int _fromClient, Packet _packet)
	{
		int _clientIdCheck = _packet.ReadInt();
		string _username = _packet.ReadString();

		Debug.Log($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected succesfully and is now Client #{_fromClient}");

		if (_fromClient != _clientIdCheck)
		{
			Debug.Log($"Client \"{_username}\" (ID:{_fromClient}) has assumed the wrong client ID of {_clientIdCheck}");
		}

		Server.clients[_fromClient].SendIntoGame(_username);
	}

	public static void PlayerMovement(int _fromtClient, Packet _packet)
	{
		bool[] _inputs = new bool[_packet.ReadInt()];

		for (int i = 0; i < _inputs.Length; i++)
		{
			_inputs[i] = _packet.ReadBool();
		}

		Quaternion _rotation = _packet.ReadQuaternion();

		Server.clients[_fromtClient].player.SetInput(_inputs, _rotation);
	}

	public static void PlayerShoot(int _fromClient, Packet _packet)
	{
		Vector3 _shootDirection = _packet.ReadVector3();

		Server.clients[_fromClient].player.Shoot(_shootDirection);
	}
}
