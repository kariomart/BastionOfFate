using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGamePlayerController : MonoBehaviour {

	public CardGameRunner game;

	// Use this for initialization
	void Start () {

		//game = GameObject.Find ("CardGame").GetComponent<CardGameRunner> ();
		
	}
	
	// Update is called once per frame
	void Update () {



	}

	public void OnMouseOver() {


	}

	public void OnMouseExit() {

		Global.me.RemoveCardInfo ();
		// delete the alert

	}


}
