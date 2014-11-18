using UnityEngine;
using System.Collections;

public class WalkerSpawner : MonoBehaviour {

	public float waitTime = 10;
	public GameObject walker;

	// Use this for initialization
	void Start () {

		Spawn ();
		//Turns off renderer during gameplay.
		transform.renderer.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn()
	{
		Instantiate(walker, transform.position, Quaternion.identity);
		//waitTime = Random.Range(1, 5);
		Debug.Log("Spawned. Now waiting for " + waitTime + " seconds.");
		StartCoroutine("SpawnDelay");
	}

	IEnumerator SpawnDelay()
	{
		yield return new WaitForSeconds(waitTime);
		Spawn ();
	}


}
