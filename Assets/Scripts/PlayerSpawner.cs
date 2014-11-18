using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject player;
	private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {

		spawnPoint = transform.position;

		Spawn();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn()
	{
		Debug.Log("Player Spawned");
		Instantiate(player, spawnPoint, Quaternion.identity);
	}

}
