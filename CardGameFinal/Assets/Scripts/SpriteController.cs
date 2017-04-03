using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

	public Rigidbody2D rigid;
	public BoxCollider2D collider;
	public SpriteRenderer sprite;
	//public ParticleSystem particles;
	public Vector2 location;
	public Vector2 speed;
	int horizontal;
	int vertical;
	List<Card> inventory;
	Animator anim;
	public AudioClip overworldMusic;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		collider = GetComponent<BoxCollider2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		// particles = GetComponent<ParticleSystem> ();
		inventory = Global.me.inventory;
		anim = GetComponent<Animator> ();
	}



	void FixedUpdate() {
		
//		Debug.Log (speed);
		speed = new Vector2 (horizontal, vertical);
		speed.Normalize();
		rigid.velocity = new Vector2 (0, 0);
		rigid.MovePosition (rigid.position + speed * 8 * Time.deltaTime);

	}
		


	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
		if (Input.GetKey (KeyCode.D)) {
		//	Debug.Log ("right");
			horizontal = 1;
			anim.SetBool("walk_sideways", true);
			sprite.flipX = false;
		}
			
		if (Input.GetKey (KeyCode.A)) {
		//	Debug.Log ("left");
			horizontal = -1;
			anim.SetBool ("walk_sideways", true);
			sprite.flipX = true;
		}

		if (((!Input.GetKey (KeyCode.D))) && (!Input.GetKey (KeyCode.A))) {
			horizontal = 0;
			anim.SetBool ("walk_sideways", false);
		}


		if (Input.GetKey (KeyCode.W)) {
		//	Debug.Log ("right");
			vertical = 1;
			anim.SetBool ("walk_backwards", true);
		}

		if (Input.GetKey (KeyCode.S)) {
		//	Debug.Log ("left");
			vertical = -1;
			anim.SetBool ("walk_forwards", true);

		}

		if (((!Input.GetKey (KeyCode.W))) && (!Input.GetKey (KeyCode.S))) {
			vertical = 0;
			anim.SetBool ("walk_forwards", false);
			anim.SetBool ("walk_backwards", false);

		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			collider.isTrigger = true;
			//particles.Play ();

		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			collider.isTrigger = false;
			//particles.Stop ();
		}

		anim.SetFloat ("speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));


			
	}

}
