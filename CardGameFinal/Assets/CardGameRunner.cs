using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameRunner : MonoBehaviour {

	public GameObject cardBase;
	List<CardAsset> inventory;

	// Use this for initialization
	void Start () {
		inventory = Global.me.inventory;
		SetupGame ();

	}

	void Awake() {
	}


	// Update is called once per frame
	void Update () {
		
	}


	public void SetupGame() {
		int count = 0;

		foreach (CardAsset ca in inventory) {
			Instantiate (cardBase, new Vector3(-7 + (1 * count), -3, 0), Quaternion.identity);
			CardDisplay display = cardBase.GetComponent<CardDisplay> ();
			display.card = ca;
			display.ChangeName();
			count += 1;
	
		}

	}
}
