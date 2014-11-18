using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	private GameObject controller;

	/*private float instrHeight = 50;
	private float instrWidth = 200;
	private float instrY = 150;
	private float instrX = 50;*/

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.S))
		{
			//Leaves previous score and lives left at the top, until next player presses start.
			controller = GameObject.Find("controller");
			Destroy(controller);
			Application.LoadLevel(Application.loadedLevel+1);
		}
	
	}

	
	void OnGUI ()
	{

		
	}

}
