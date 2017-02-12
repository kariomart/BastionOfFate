using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour {

	public TextMesh nameMesh;
	public TextMesh tokenMesh;

	public CardAsset card;																			

	// Use this for initialization
	void Start () {


		GameObject n = transform.GetChild (0).gameObject;
		nameMesh = n.GetComponent<TextMesh> ();

		GameObject t = transform.GetChild (1).gameObject;
		tokenMesh = t.GetComponent<TextMesh> ();

	}

	public void ChangeName () {

		nameMesh.text = card.name;
		tokenMesh.text = ("tokens: " + (card.tokens));

	}
		
	
	// Update is called once per frame
	void Update () {
		
	}
}
