using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{

		private float scoreHeight = 30;
		private float scoreWidth = 100;
		public float scoreY = 20;
		public float scoreX = 150;
		private float livesHeight = 30;
		private float livesWidth = 100;
		public float livesY = 20;
		public float livesX = 250;
		private float _score;
		private int _lives;
		public AudioClip completedSound;
		public AudioClip endedSound;
		public AudioClip bombPickupSound;
		public AudioClip playerDeathSound;


		private PlayerSpawner playerSpawn;

		public float Score {
				get {
						return _score;
				}
				set {
						_score = value;
				}
		}

		public int Lives {
				get {
						return _lives;
				}
				set {
						_lives = value;
				}
		}

		void Awake ()
		{
				DontDestroyOnLoad (transform.gameObject);
		}

		// Use this for initialization
		void Start ()
		{

				Lives = 3;
				playerSpawn = GameObject.Find ("playerSpawner").GetComponent<PlayerSpawner> ();


		}

		// Update is called once per frame
		void Update ()
		{


		}

		void OnGUI ()
		{
				GUI.Label (new Rect (scoreX, scoreY, scoreWidth, scoreHeight), "Score: " + Score);
				GUI.Label (new Rect (livesX, livesY, livesWidth, livesHeight), "Lives: " + Lives);
		}

		public void StartDeath (GameObject player, GameObject other)
		{
				StartCoroutine (PlayerDeath (player, other));
		}

		IEnumerator PlayerDeath (GameObject player, GameObject other)
		{
				if (Lives > 0) {
						//Debug.Log("PlayerDeath Co-routine");
						Destroy (player);
						Destroy (other);
						audio.PlayOneShot (playerDeathSound);
						yield return new WaitForSeconds (2);
						Lives -= 1;
						yield return new WaitForSeconds (1);
						playerSpawn.Spawn ();
				} else {
						yield return new WaitForSeconds (2);
						Application.LoadLevel ("Title");
				}

		}

		public void BombCheck ()
		{
				GameObject[] bombs = GameObject.FindGameObjectsWithTag ("bomb") as GameObject[];
				int numberOfBombsLeft = bombs.Length - 1;
				audio.PlayOneShot (bombPickupSound, 0.3f);


				if (numberOfBombsLeft == 0) {

						if (Application.loadedLevel < 3) {
								audio.PlayOneShot (completedSound);
								Application.LoadLevel (Application.loadedLevel + 1);
						} else {
								audio.PlayOneShot(endedSound);
								Application.LoadLevel ("Title");
						}
				}
		}

}
