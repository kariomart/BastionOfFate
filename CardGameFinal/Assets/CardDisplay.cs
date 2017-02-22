using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour {

	public TextMesh nameMesh;
	public TextMesh tokenMesh;
	public TextMesh healthMesh;
	public CardGameRunner game;

	Vector2 originalPos;
	bool inPlay = false;
	public Card card;																			
	public bool isEnemyCard = false;

	// Use this for initialization
	void Start () {

		originalPos = new Vector2 (transform.position.x, transform.position.y); 
		GameObject n = transform.GetChild (0).gameObject;
		nameMesh = n.GetComponent<TextMesh> ();

		GameObject t = transform.GetChild (1).gameObject;
		tokenMesh = t.GetComponent<TextMesh> ();

		GameObject d = transform.GetChild (2).gameObject;
		healthMesh = d.GetComponent<TextMesh> ();

		GameObject g = GameObject.Find ("CardGameRunner");
		game = g.GetComponent<CardGameRunner> ();

	}

	public void UpdateDisplay() {
		tokenMesh.text = ("tokens: " + (card.tokens));
		healthMesh.text = ("health: " + (card.health));
	}
		

	public void ChangeName () {

		nameMesh.text = card.name;
		tokenMesh.text = ("tokens: " + (card.tokens));
		healthMesh.text = ("health: " + (card.health));

	}

	public void OnMouseOver() {
		if (!isEnemyCard) {
			if ((transform.position.y < originalPos.y + 1) && (!inPlay)) {
				transform.Translate (0, 1, 0);
			}
		}
	}

	public void OnMouseExit() {
		if (!isEnemyCard) {
			if ((transform.position.y > originalPos.y) && (!inPlay)) {
				transform.Translate (0, -1, 0);
			}
		}
	}



	public void OnMouseDown() {
			

		if (inPlay && card.hasAttacked && !isEnemyCard) {
			Debug.Log ("This card has already attacked this turn!");
		}


		if (inPlay && !card.hasAttacked && !isEnemyCard) {
				Debug.Log ("You have selected " + card.name);
				game.Combat (card);
			}
			

		if (isEnemyCard && game.inCombat) {
			Debug.Log (card.name + " has taken " + game.dmg + " damage");
			card.TakeDamage (game.dmg);
			UpdateDisplay ();
			game.inCombat = false;
		}

		if (!inPlay && !isEnemyCard) {
			Global.me.CardsInPlay++;
			transform.position = new Vector3 (-7 + (2 * Global.me.CardsInPlay), 2, 0);
			card.hasAttacked = false;
			inPlay = true;
		}
			
	}


		
	
	// Update is called once per frame
	void Update () {
		// UpdateDisplay ();

		if (card.health < 1) {
			Destroy (this);

		}
		
	}
}
