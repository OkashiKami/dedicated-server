using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace GameServer
{
	class Player
	{
		public int id;
		public string username;

		public Vector3 position;
		public Quaternion rotation;

		public Player(int _id, string _username, Vector3 _spawnedPosition)
		{
			id = _id;
			username = _username;
			position = _spawnedPosition;
			rotation = Quaternion.Identity;
		}
	}
}
