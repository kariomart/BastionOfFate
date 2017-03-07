using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	public Sprite open;
	public Sprite closed;
	public Card loot;
	public bool chestOpen = false;
	public bool abilityChosen = false;
	public GameObject notification;
	List<Card> inventory;
	List<Card> cards;
	List<string> abilityStrings;



	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		inventory = Global.me.inventory;
		cards = Global.me.cards;
		abilityStrings = Global.me.abilities;


		int rand = Random.Range (0, cards.Count - 1);
		loot = new Card(cards[rand]);
//		Debug.Log (loot.name);

		}

	
	// Update is called once per frame
	void Update () {
		if (chestOpen && !abilityChosen) {
			
			if ((Input.GetKeyDown (KeyCode.Alpha1))) {
				Debug.Log ("chosen1");
				loot.a1_winsTies = true;
				abilityChosen = true;

			}

			if ((Input.GetKeyDown (KeyCode.Alpha2))) {
				Debug.Log ("chosen2");
				loot.a2_reduceRoll = true;
				abilityChosen = true;
			}

			if ((Input.GetKeyDown (KeyCode.Alpha3))) {
				Debug.Log ("chosen3");
				loot.a3_heal = true;
				abilityChosen = true;
			}
		
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!chestOpen) {
			spriteRenderer.sprite = open;
			inventory.Add (loot);

			GameObject n = Instantiate (notification, new Vector3 (-1, 1, 3), Quaternion.identity);
			GameObject nc = n.transform.GetChild (2).gameObject;
			TextMesh nct = nc.GetComponent<TextMesh> ();
			string a1 = abilityStrings [0];
			string a2 = abilityStrings [1];
			string a3 = abilityStrings [2];
			nct.text = ("You've obtained " + loot.name + "!" + "\n\nWhat ability do you want? These are the options:\n1. " + a1 + "\n2. " + a2 + "\n3. " + a3);

			chestOpen = true;
		}

	
	
	
	}
			}

