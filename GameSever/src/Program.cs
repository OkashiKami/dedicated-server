using System;

namespace GameSever
{
	class Program
	{
		private static string title = "GameServer";
		private static int maxPlayers = 50;
		private static int port = 42069;

		static void Main(string[] args)
		{
			Console.Title = title;

			Server.Start(maxPlayers, port);

			Console.Read();
		}
	}
}
