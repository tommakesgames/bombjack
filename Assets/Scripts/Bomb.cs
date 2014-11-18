using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	

    public GameObject controller;
    private UI UI;
    private int _bombscore = 100;

	// Use this for initialization
	void Start () {

		controller = GameObject.Find("controller");
        UI = controller.gameObject.GetComponent<UI>();
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter2D (Collider2D col) 
	{
		if (col.tag == "Player")
		{
			UI.BombCheck();
			UI.Score += _bombscore;
			Destroy (gameObject);        

		}
	}
}
