using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
	public static NetworkManager instance;
	public GameObject playerPrefab;

	public int maxPlayers = 50;
	public int port = 42069;
	public int targetFrameRate = 30;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Debug.Log("Instance already exists, destroying object!");
			Destroy(this);
		}
	}

	private void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = targetFrameRate;

		Server.Start(maxPlayers, port);
	}

	private void OnApplicationQuit()
	{
		Server.Stop();
	}

	public Player InstantiatePlayer()
	{
		return Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Player>();
	}
}
