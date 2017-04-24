using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour {

//	public TextMesh nameMesh;
//	public TextMesh damageMesh;
//	public TextMesh healthMesh;
	public CardGameRunner game;


	public SpriteRenderer sprite;
	Vector2 originalPos;
	public Card card;			


	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer> ();

//		originalPos = new Vector2 (transform.position.x, transform.position.y); 
//		GameObject n = transform.GetChild (0).gameObject;
//		damageMesh = n.GetComponent<TextMesh> ();
//
//		GameObject t = transform.GetChild (1).gameObject;
//		healthMesh = t.GetComponent<TextMesh> ();
//
//		GameObject d = transform.GetChild (2).gameObject;
//		nameMesh = d.GetComponent<TextMesh> ();

		//GameObject r = transform.GetChild (3).gameObject;
		//rightArrow = r.GetComponent<BoxCollider2D> ();

		//GameObject l = transform.GetChild (4).gameObject;
		//leftArrow = l.GetComponent<BoxCollider2D> ();

		GameObject g = GameObject.Find ("CardGame");
		game = g.GetComponent<CardGameRunner> ();

	

	}

	public void UpdateDisplay() {
		//damageMesh.text = ("" + (card.damage));
		//healthMesh.text = ("" + (card.health));

//		if (game.cardCurrentlySelected && !card.isEnemyCard) {
//			sprite.color = new Color (0, 0, 255);
//		}
//
//		if(!game.cardCurrentlySelected && !card.isEnemyCard)
//			sprite.color = new Color (0, 255, 0);

		if(card.health <= 0 && !card.dead) {
			card.dead = true;
			sprite.color = new Color (0, 0, 0);
			if (card.isEnemyCard)
				game.enemiesDead++;
				
			
			if (!card.isEnemyCard) {
				//game.friendliesDead++;
				//game.cardsInPlay--;
				Debug.Log (card.name + " has died!");
			}
		}
	}
		

	public void ChangeName () {

		//nameMesh.text = card.name;
		//damageMesh.text = ("" + card.damage);
		//healthMesh.text = ("" + card.health);

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
		game.CardClicked (card, this.transform);

		if (card.inPlay == false && !card.isEnemyCard && game.cardsInPlay < 4) {
		card.inPlay = true;
// 		Debug.Log (game.cardsInPlay);
		transform.position = new Vector3 (39 + (2 * game.cardsInPlay), 2, 0);
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
