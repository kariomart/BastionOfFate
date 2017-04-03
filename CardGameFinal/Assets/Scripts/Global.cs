using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviourSingleton <Global> {

	public int playerHealth = 2;

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
	public TextMesh console;

	public GameObject cardGameRunner; 
	public GameObject overworld;


	string a1 = "this ability wins ties";
	string a2 = "this ability reduces enemy roll by 1";
	string a3 = "this ability heals friendlies each turn";
	string a4 = "this card deals double damage but also takes double damage";

	public GameObject chest;
	public GameObject battleChest;
	public GameObject wall;
	public GameObject apple;
	public GameObject player;
	public Camera playerCam;
	public Camera cardCam;

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
			return new Ape ();
		else if (i == 1)
			return new Armadillo ();
		else if (i == 2)
			return new Blackjack ();
		else if (i == 3)
			return new Cat ();
		else if (i == 4)
			return new Clown ();
		else if (i == 5)
			return new Gabe ();
		else if (i == 6)
			return new Gambler ();
		else if (i == 7)
			return new General ();
		else if (i == 8)
			return new Joker ();
		else if (i == 9)
			return new Magikarp ();
		else if (i == 10)
			return new Martyr ();
		else if (i == 11)
			return new Paladin ();
		else if (i == 12)
			return new Phoenix ();
		else if (i == 13)
			return new Sniper ();
		else if(i == 14) 
			return new Zombie ();


		 else
			return new Card ();




	}

	void Awake() {
		Debug.Log ("GLOBAL AWAKE");
		Debug.Log ("PLAYER HEALTH: " + playerHealth);


		CheckWinCondition ();

		if (playerHealth < 1) {
			Application.LoadLevel (Application.loadedLevel);
		}


		if (me != null)
			Destroy (gameObject);

		Get ();

		DontDestroyOnLoad(transform.gameObject);

		//chest = GameObject.Find ("soul");
		battleChest = GameObject.Find ("enemy");
		wall = GameObject.Find ("wall");
		apple = GameObject.Find ("apple");
		player = GameObject.Find ("Player");

		GameObject p = player.transform.GetChild (0).gameObject;
		playerCam = p.GetComponent<Camera> ();

		//GameObject c = GameObject.Find ("CardCamera");
		// cardCam = c.GetComponent<Camera> ();


		// cardGameRunner = GameObject.Find ("CardGame");
		// overworld = GameObject.Find ("overworld");


		cards = new List<Card> ();
		inventory = new List<Card> ();

		cards.Add (new Ape());
		cards.Add (new Armadillo());
		cards.Add (new Blackjack());
		cards.Add (new Cat ());
		cards.Add (new Clown ());
		cards.Add (new Gabe ());
		cards.Add (new Gambler ());
		cards.Add (new General ());
		cards.Add (new Joker ());
		cards.Add (new Magikarp ());
		cards.Add (new Martyr ());
		cards.Add (new Paladin ());
		cards.Add (new Phoenix ());
		cards.Add (new Sniper ());
		cards.Add (new Zombie ());



		abilities.Add (a1);
		abilities.Add (a2);
		abilities.Add (a3);
		abilities.Add (a4);

		//GenerateOverworld ();
		//GiveDefaultCards ();


	}


	public void CheckWinCondition () {
		



	}

	public void GiveDefaultCards() 

	{
		for(int i = 0; i < 5; i ++)
		{
			Card c = GetRandomCard ();
			inventory.Add (c);
		}
	}


	public void RunCardGame() {
		Debug.Log ("CARD GAME RUNNING");
		// Debug.Log (cardGameRunner);
		playerCam.gameObject.SetActive(false);
		cardCam.gameObject.SetActive(true);
		cardGameRunner.SetActive (true);
		//overworld.gameObject.SetActive (false);

	}




//
//	public void GenerateOverworld() {
//		int bounds = 30; 
//		for (int i = 0; i < Random.Range (5, 10); i++) 
//		{
//			Instantiate (chest, new Vector2 (Random.Range (-bounds, bounds), (Random.Range (-bounds, bounds))), Quaternion.identity);
//		}
//
//		for (int i = 0; i < Random.Range (5, 10); i++) 
//		{
//			Instantiate (battleChest, new Vector2 (Random.Range (-bounds, bounds), (Random.Range (-bounds, bounds))), Quaternion.identity);
//		}
//
//		for (int i = 0; i < Random.Range (50, 60); i += 1) 
//		{
//			Instantiate (wall, new Vector2 (Random.Range (-bounds, bounds), (Random.Range (-bounds, bounds))), Quaternion.identity);
//			Instantiate (wall, new Vector2 (Random.Range (-bounds, bounds), (Random.Range (-bounds, bounds))), Quaternion.Euler (0, 0, 90));
//
//			}
//
//		for (int i = 0; i < Random.Range (5, 10); i += 1) 
//		{
//			Instantiate (apple, new Vector2 (Random.Range (-bounds, bounds), (Random.Range (-bounds, bounds))), Quaternion.identity);
//		}
//
//	}
//		
//
//
//
//


	// Use this for initialization
	void Start () {

	}
		

	
	// Update is called once per frame
	void Update () {
		// Debug.Log (inventory.Count);
		// Debug.Log (cards.Count);
	}
}
