using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour {

	public TextMesh nameMesh;
	public TextMesh tokenMesh;
	Vector2 originalPos;
	bool inPlay = false;

	public CardAsset card;																			

	// Use this for initialization
	void Start () {

		originalPos = new Vector2 (transform.position.x, transform.position.y); 
		GameObject n = transform.GetChild (0).gameObject;
		nameMesh = n.GetComponent<TextMesh> ();

		GameObject t = transform.GetChild (1).gameObject;
		tokenMesh = t.GetComponent<TextMesh> ();

	}

	public void ChangeName () {

		nameMesh.text = card.name;
		tokenMesh.text = ("tokens: " + (card.tokens));

	}

	public void OnMouseOver() {

		if ((transform.position.y < originalPos.y + 1) && (!inPlay)) {
			transform.Translate (0, 1, 0);
		}

	}

	public void OnMouseExit() {
		if ((transform.position.y > originalPos.y) && (!inPlay)) {
			transform.Translate (0, -1, 0);
		}
	}


	public void OnMouseDown() {
		if (inPlay) {
			card.RollDie ();
		}
			
		if (!inPlay) {
			Global.me.CardsInPlay++;
			transform.position = new Vector3 (-7 + (2 * Global.me.CardsInPlay), 2, 0);
			inPlay = true;
		}
	}


		
	
	// Update is called once per frame
	void Update () {
		
	}
}
