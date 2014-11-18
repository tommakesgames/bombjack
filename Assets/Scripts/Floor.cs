using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

	public GameObject bouncer;
	public AudioClip changeSound;

	// Use this for initialization
	void Start () {

		transform.renderer.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "walker")
		{
			Debug.Log("Walker has hit the floor");
			Instantiate(bouncer, other.transform.position, Quaternion.identity);
			Destroy(other.gameObject);
		}
	}
}
