using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOrbController : MonoBehaviour {


	public TextMesh nameMesh;
	public TextMesh infoMesh;
	public TextMesh descriptionMesh;
	public SpriteRenderer sprite;
	public int index;
	public int counter = 0;
	public InventoryController dad;
	public Card card;

	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer> ();
	

	}


	
	// Update is called once per frame
	void Update () {


		Color tmp = sprite.color;
		tmp.a = (float)card.health / 5;
		sprite.color = tmp;

		
	}

	public void SetValues(Card ca) {
	
		card = ca;
		nameMesh.text = card.name;
		infoMesh.text = card.damage + "D\n" + card.health + "H";


	}

	public void OnMouseDown() {

		if (Global.me.hand.Count < 3) {

			card.handIndex = Global.me.hand.Count;
			Global.me.hand.Add (card);
			sprite.color = Color.cyan;
			print (Global.me.hand.Count + " CARD ADDED");


		}
	}

	public void ClearInventory() {



	}


}
