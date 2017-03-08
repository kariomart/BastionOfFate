using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		Global.me.apple = this.gameObject;

	

		}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Global.me.playerHealth += Random.Range (1, 3);
		Destroy (gameObject);


	}
}


