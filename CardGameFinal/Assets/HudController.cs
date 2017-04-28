using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour {

	public CardGameRunner game;
	public SpriteRenderer sprite;
	public bool hovering;
	public bool clicked = false;

	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (game.inBattle) {
			game.RemoveHUD ();
			sprite.color = Color.magenta;

			if (hovering || clicked) {
				
				game.DisplayHUD ();
				sprite.color = Color.cyan;
			}
		}
		
	}

	void OnMouseOver() {

		hovering = true;

	}

	void OnMouseExit() {

		hovering = false;

	}

	void OnMouseDown() {

		if (!clicked) { clicked = true; }
		else if (clicked) { clicked = false; }

	}
		


}
