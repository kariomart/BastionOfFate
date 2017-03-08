using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviourSingleton <Global> {

	public static Global me;
//	public PanelController battlefieldPanel;
//	public PlayerController Player;
//	public CardController Card;
//	public GameObject HandDisplay;
	public List<Card> inventory;
	public List<Card> cards;
	public List<Card> enemiesTransfer = new List<Card>();
	public List<string> abilities = new List<string> ();
	public int CardsInPlay;

	string a1 = "this ability wins ties";
	string a2 = "this ability reduces enemy roll by 1";
	string a3 = "this ability heals friendlies each turn";
	string a4 = "this card deals double damage but also takes double damage";

	public Global Get() {
		if (me == null) {
			me = (Global)FindObjectOfType(typeof(Global));
		}

		return me;
	}
		

	public void CurrentBattle(List<Card> enemiesInvolved) {
		enemiesTransfer = enemiesInvolved;

	}

	public Card GetRandomCard() {
		int i = Random.Range (0, cards.Count);

		if (i == 0) 
			return new Joker ();
		else if(i == 1) 
			return new General ();
		else if(i == 2) 
			return new Zombie ();
		else if(i == 3) 
			return new Gambler ();
		else if(i == 4) 
			return new Armadillo ();
		else if(i == 5) 
			return new Sniper ();
		else if(i == 6) 
			return new Martyr ();




		 else
			return new Card ();




	}

	void Awake() {
		Debug.Log ("GLOBAL AWAKE");

		if (me != null)
			Destroy (gameObject);

		Get ();

		DontDestroyOnLoad(transform.gameObject);

		cards = new List<Card> ();
		inventory = new List<Card> ();

		cards.Add (new Joker());
		cards.Add (new General());
		cards.Add (new Zombie());
		cards.Add (new Gambler ());
		cards.Add (new Armadillo ());
		cards.Add (new Sniper ());
		cards.Add (new Martyr ());


		abilities.Add (a1);
		abilities.Add (a2);
		abilities.Add (a3);
		abilities.Add (a4);


	}
		






	// Use this for initialization
	void Start () {

	}
		

	
	// Update is called once per frame
	void Update () {
		// Debug.Log (inventory.Count);
		// Debug.Log (cards.Count);
	}
}
