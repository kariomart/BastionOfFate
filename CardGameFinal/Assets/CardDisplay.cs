using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour {

	public TextMesh nameMesh;
	public TextMesh tokenMesh;
	public TextMesh healthMesh;
	public CardGameRunner game;

	public SpriteRenderer sprite;
	Vector2 originalPos;
	public Card card;			


	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer> ();

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

//		if (game.cardCurrentlySelected && !card.isEnemyCard) {
//			sprite.color = new Color (0, 0, 255);
//		}
//
//		if(!game.cardCurrentlySelected && !card.isEnemyCard)
//			sprite.color = new Color (0, 255, 0);

		if(card.health <= 0) {
			sprite.color = new Color (0, 0, 0);
			game.enemiesDead++;
		}
	}
		

	public void ChangeName () {

		nameMesh.text = card.name;
		tokenMesh.text = ("tokens: " + (card.tokens));
		healthMesh.text = ("health: " + (card.health));

	}

	public void OnMouseOver() {

		// Debug.Log (card.name + " is being hovered, " + "is card in play? " + card.inPlay + " " + "is card enemy card?" + card.isEnemyCard);
		if (!card.inPlay && !card.isEnemyCard) {
			if ((transform.position.y < originalPos.y + 1) && (!card.inPlay)) {
				transform.Translate (0, 1, 0);
			}
		}
	}


	public void OnMouseExit() {
	
		if (!card.inPlay && !card.isEnemyCard) {
			if ((transform.position.y > originalPos.y) && (!card.inPlay)) {
				transform.Translate (0, -1, 0);
			}
		}
	}



	public void OnMouseDown() {
		game.CardClicked (card);

		if (card.inPlay == false && !card.isEnemyCard && game.cardsInPlay < 4) {
		card.inPlay = true;
// 		Debug.Log (game.cardsInPlay);
		transform.position = new Vector3 (-9 + (2 * game.cardsInPlay), 2, 0);
//		Debug.Log (card.name + " inPlay? " + card.inPlay + " isEnemyCard? " + card.isEnemyCard);
		// sprite.sortingOrder = game.cardsInPlay;
		}

	}
		


		
	
	// Update is called once per frame
	void Update () {
		UpdateDisplay ();

		if (card.dead) {
			Destroy (this);

		}
		
	}
}
