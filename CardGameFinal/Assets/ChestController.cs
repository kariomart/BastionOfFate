using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	public Sprite open;
	public Sprite closed;
	public Card loot;
	public bool chestOpen = false;
	public GameObject notification;
	List<Card> inventory;
	List<Card> cards;


	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		inventory = Global.me.inventory;
		cards = Global.me.cards;


		int rand = Random.Range (0, cards.Count - 1);
		loot = cards[rand];
//		Debug.Log (loot.name);

		}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!chestOpen) {
			spriteRenderer.sprite = open;
			inventory.Add (loot);

			GameObject n = Instantiate (notification, new Vector3 (-1, 1, 3), Quaternion.identity);
			GameObject nc = n.transform.GetChild (2).gameObject;
			TextMesh nct = nc.GetComponent<TextMesh> ();
			nct.text = "You've obtained " + loot.name + "!";
			chestOpen = true;
		}

	}
}
