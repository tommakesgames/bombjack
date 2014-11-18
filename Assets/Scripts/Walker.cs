using UnityEngine;
using System.Collections;

public class Walker : MonoBehaviour
{

		public float moveSpeed;
		public bool isFacingRight = true;
		public bool grounded = false;
		private bool canPlayFallingSound = true;
		//private Rigidbody2D groundCheck;		//A position where the groundCheck item is - it's underneath the player. 

		public int hitCheck;			//Used to determine when to ignore blockers and drop down.

		private int hitCheckReset;
		public AudioClip fallingSound;

		void Awake ()
		{

				grounded = false;
				hitCheckReset = Random.Range (3, 6);

		}

		// Use this for initialization
		void Start ()
		{

				//groundCheck = transform.Find ("groundCheck").rigidbody2D;
				hitCheck = hitCheckReset;
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				//Old linecast. Okay for player jumping, not for enemies falling off platforms
				//grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("ground"));

				
						

				//Check to see if walker is falling. If so, reset hitCheck values.

				if (transform.rigidbody2D.velocity.y < -1) {			
						hitCheck = hitCheckReset;
						grounded = false;
						
						if (canPlayFallingSound) {
								audio.PlayOneShot (fallingSound, 0.5f);
								canPlayFallingSound = false;
						}
						

				} else {	
						grounded = true;
						canPlayFallingSound = true;
				}


	
		}

		void FixedUpdate ()
		{
				if (grounded) {
						if (isFacingRight) {
								transform.Translate (moveSpeed * Time.deltaTime, 0, 0);
						} else {
								transform.Translate (-moveSpeed * Time.deltaTime, 0, 0);
						}
				}

			


			
		}

		void OnTriggerEnter2D (Collider2D other)
		{

				if (other.tag == "blocker" && hitCheck > 0) {
						//Debug.Log ("Hit a blocker");
						isFacingRight = !isFacingRight;
						hitCheck -= 1;
				}

				

			
		}

		void OnCollisionEnter2D (Collision2D other)
		{
				if (other.gameObject.tag == "walker") {
						hitCheck -= 1;
						isFacingRight = !isFacingRight;
				}
		}

}
