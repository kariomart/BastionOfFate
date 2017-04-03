using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplayNew : MonoBehaviour {

	//	public TextMesh nameMesh;
	//	public TextMesh damageMesh;
	//	public TextMesh healthMesh;
	public CardGameRunner game;


	public SpriteRenderer sprite;
	//Vector2 originalPos;
	public Card card;			


	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer> ();

		GameObject g = GameObject.Find ("CardGame");
		game = g.GetComponent<CardGameRunner> ();



	}
		


	public void OnMouseOver() {

		//Debug.Log ("HOVERING " + card.name);
		Global.me.DisplayCardInfo (card);
		// instantiate a new alert thingy based on this cards class

	}


	public void OnMouseExit() {

		Global.me.RemoveCardInfo ();
		// delete the alert
		
	}



	public void OnMouseDown() {

		game.CardClicked (card);

		if (!card.isEnemyCard){
			
		Debug.Log (card.name + " CLICKED");
		game.ChangePlayer (card);
		// change player to a different color
		// shoot out particles and stuff

		}
	}





	// Update is called once per frame
	void Update () {

		if (card.dead) {
			Destroy (this.gameObject);

		}

	}
}
