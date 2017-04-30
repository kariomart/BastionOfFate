using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshController : MonoBehaviour {

	public int counter = 0;
	public string text;
	public float oldTime = 0;
	public float duration;
	public bool hovering = false;

	// Use this for initialization
	void Start () {

		duration = Random.Range(0.01f, 0.03f);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (counter != 0) {


			this.gameObject.GetComponent<TextMeshPro> ().SetText (text.Substring (0, counter));
	
			if (counter < text.Length && Time.time > oldTime + duration) { 
				counter++; 
				oldTime = Time.time;
			}

			if (counter >= text.Length) 
				hovering = true;

		}


	}


}
