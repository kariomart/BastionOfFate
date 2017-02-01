using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour {

	public Rigidbody2D rigid;


	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
	}



	void FixedUpdate() {
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			Debug.Log("right");
			rigid.MovePosition (transform.position + transform.forward);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			Debug.Log ("left");
			rigid.MovePosition (transform.position - transform.forward);
		}
	}



	// Update is called once per frame
	void Update () {
		
	}
}
