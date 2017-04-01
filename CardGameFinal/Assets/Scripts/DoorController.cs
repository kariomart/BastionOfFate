using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public BoxCollider2D collider;
	bool doorOpened = false;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		doorOpened = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (doorOpened) {
			collider.isTrigger = false;
		}


	}
}
