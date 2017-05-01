using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenController : MonoBehaviour {

	public AudioSource startSound;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (startSound.gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {

			startSound.Play ();
			Application.LoadLevel(1);



		}
		
	}
}
