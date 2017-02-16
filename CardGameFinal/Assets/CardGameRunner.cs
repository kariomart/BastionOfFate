using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameRunner : MonoBehaviour {

	public GameObject cardBase;
	List<Card> inventory;


	// Use this for initialization
	void Start () {
		inventory = Global.me.inventory;
		SetupGame ();

	}
		

	// Update is called once per frame
	void Update () {
		
	}


	public void SetupGame() {
		int count = 0;

		foreach (Card ca in inventory) {
			GameObject bloop = Instantiate (cardBase, new Vector3(-7 + (1 * count), -3, 0), Quaternion.identity);
			CardDisplay display = bloop.GetComponent<CardDisplay> ();
			display.card = ca;
			display.ChangeName();
			count += 1;
	
		}

	}
}
