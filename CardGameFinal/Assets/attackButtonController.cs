using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackButtonController : MonoBehaviour {

	CardGameRunner game;
	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Global.me.cardGameRunner.GetComponent<CardGameRunner> () != null) {
			game = Global.me.cardGameRunner.GetComponent<CardGameRunner>();
		}

		if (game.cardCurrentlySelected && game.enemyCurrentlySelected)
			sprite.color = Color.red;
		else
			sprite.color = Color.blue;
	}

	public void OnMouseDown() {

		Debug.Log ("attack clicked");
		game.AttackButtonClicked ();


	}
}
