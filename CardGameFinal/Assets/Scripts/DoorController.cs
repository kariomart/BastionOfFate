using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public BoxCollider2D collider;
	public SpriteRenderer sprite;
	bool doorOpened = false;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		doorOpened = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (doorOpened && other.name == "Player") {
			//collider.isTrigger = false;
			sprite.color = new Color (0, 255, 255);

		}


	}
}
