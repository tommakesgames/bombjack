using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float jumpForceReset;
	public float jumpForceExtra;
	public float jumpForce = 0;			//How high the player jumps/the upwards force
	public float moveSpeed;				//How fast the player moves side to side
	public float miniJump;				//How much the little mid-air jump is.
	private Transform groundCheck;		//A position where the groundCheck item is - it's underneath the player. Used for 2D Linecast.

	public bool grounded = false;		//Checks to see that player is on the ground (used for jumping)
	public bool jump = false;
	public bool midAirJump = false;

	private Vector2 zero = new Vector2(0,0);	//Used to reset velocity when jump is pressed mid-air.


	private UI UI;

	private Coroutine PlayerDeath;

	public AudioClip jumpSound;
	public AudioClip miniJumpSound;

	void Awake(){

		groundCheck = transform.Find("groundCheck");



		UI = GameObject.Find("controller").GetComponent<UI>();

		jumpForce = jumpForceReset;

	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Does a linecast between the player position. Will return true if it hits something on 'ground' layer.
		//Linecast is between player and empty GameObject just under player.

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));

		//If up arrow is pressed, add to jumpForce
		if (Input.GetButton("Fire1") && grounded)
		{
			jumpForce = jumpForceReset + jumpForceExtra;
			//Debug.Log("Extra jump (jumpForce = " + (jumpForceReset+jumpForceExtra) + ")");
		}
		else 
		{
			jumpForce = jumpForceReset;
		}

		//Jumps
		//Need to put actual jump instructions in FixedUpdate() because the player is a 2DPhysics.Rigidbody.

		if (Input.GetButtonDown("Jump") && grounded)
			jump = true;

		//However, I'm using physics instructions in here to create unique jumping controls where
		//a second press of jump mid-air shorts the jump and allows the player to 'hop' through air.
		if (Input.GetButtonDown("Jump") && !grounded)
		{
			rigidbody2D.velocity = zero;
			rigidbody2D.AddForce(new Vector2(0f, miniJump));
			audio.PlayOneShot(miniJumpSound, 0.5f);
			//Debug.Log("Mid-air jump");
		}

		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}

	//For physicsy things and rigidbodies
	void FixedUpdate(){

		//Sideways motion
		float speed = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
		transform.Translate(speed, 0, 0);


		if (jump)
		{
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			//Debug.Log("Jumped");
			jump = false;
			audio.PlayOneShot(jumpSound);

		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "walker" || other.gameObject.tag == "bouncer")
		{
			//Debug.Log("Calling UI.PlayerDeath");
			UI.StartDeath(this.gameObject, other.gameObject);


		}
	}



}

