using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CardGameRunner : MonoBehaviour {

	public GameObject cardBase;

	List<Card> inventory;
	List<Card> enemies;

	public bool cardCurrentlySelected = false;
	public Card cardSelected;
	public int enemiesDead = 0;
	public int cardsInPlay = 0;
	public int cardsThatHaveAttacked = 0;
	public int friendliesDead = 0;
	public int dmg;
	public int cardsInHand = 0;

	void Awake() {
		Global.me.cardGameRunner = this.gameObject;
	//	gameObject.SetActive (false);


	}

	// Use this for initialization
	void OnEnable () {

		//Debug.Log ("on enable");
		SetupGame ();
		StartGame ();
		PlayerTurn ();


	}
		

	// Update is called once per frame
	void Update () {
				
		CheckKeys ();
		DeathTests ();
		RemoveDeadCards ();

	}


	// Sets up the basics for the card game
	public void SetupGame() 

	{

		// GameObject consoleObject = GameObject.Find ("Console");
		// Global.me.console = consoleObject.GetComponent<TextMesh> ();

		Debug.Log (enemies + " setup game");
		inventory = Global.me.inventory;
		enemies = Global.me.enemiesTransfer;

		enemiesDead = 0;
		friendliesDead = 0;
		cardsInPlay = 0;
		cardsThatHaveAttacked = 0;
		int count = 0;
		// List<Card> hand = new List<Card> ();

		foreach (Card ca in inventory) 
		
		{
				ca.inPlay = false;
				GameObject bloop = Instantiate (cardBase, new Vector3 (41 + (2 * count), -3, 0), Quaternion.identity);
				CardDisplay display = bloop.GetComponent<CardDisplay> ();
				display.card = ca;
				display.ChangeName ();
				count += 1;
		}


		count = 0;
		foreach (Card car in enemies) 
		{
			GameObject blooop = Instantiate (cardBase, new Vector3 (51 + (2 * count), 2, 0), Quaternion.identity);
			CardDisplay display = blooop.GetComponent<CardDisplay> ();
			SpriteRenderer displaySprite = blooop.GetComponent<SpriteRenderer> ();

			displaySprite.color = new Color (255, 0, 0);
			display.card = car;
			display.ChangeName ();
			display.card.isEnemyCard = true;

			count += 1;
		}

	}	

	public void CycleTurn() {

		int dmgRoll = Random.Range (0, 3);
		Debug.Log("Your turn is over and the enemy has dealt " + dmgRoll + " to all the cards in play.");
		Global.me.console.text = "Your turn is over and the enemy has dealt " + dmgRoll + " to all the cards in play.";
		foreach (Card card in inventory){
			if (card.inPlay){
				card.TakeDamage (dmgRoll);
				card.hasAttacked = false;

				if (card.a3_heal) {
					card.health += Random.Range (0, 4);
				}
					
			}

		}
		cardsThatHaveAttacked = 0;


	}

	public void Combat(Card enemy) 

	{

		int playerRoll = cardSelected.RollDie ();
		int enemyRoll = enemy.RollDie ();
		if (cardSelected.a2_reduceRoll)
			enemyRoll --;
		
		Debug.Log(cardSelected.name + " has rolled " + playerRoll + ". " + enemy.name + " has rolled " + enemyRoll);

		if (playerRoll > enemyRoll) {
			enemy.TakeDamage (cardSelected.damage);
			Debug.Log (cardSelected.name + " has dealt " + cardSelected.damage + " to the " + enemy.name);
			Global.me.console.text = cardSelected.name + " has dealt " + cardSelected.damage + " to the " + enemy.name;
		}
		
		if (enemyRoll > playerRoll) {
			cardSelected.TakeDamage (enemy.damage);
			Debug.Log (enemy.name + " has dealt " + enemy.damage + " to the " + cardSelected.name);
			Global.me.console.text = enemy.name + " has dealt " + enemy.damage + " to the " + cardSelected.name;
		}

		if (enemyRoll == playerRoll)
		if (cardSelected.a1_winsTies) {
			cardSelected.WinTies ();
			enemy.TakeDamage (cardSelected.damage);
			Debug.Log (cardSelected.name + " has dealt " + cardSelected.damage + " to the " + enemy.name);
			Global.me.console.text = cardSelected.name + " has dealt " + cardSelected.damage + " to the " + enemy.name;

		} else
			Debug.Log("No damage has been dealt!");
			


		}

	public void DeathTests() 

	{
//		Debug.Log (enemies + " Death Tests");
		if (enemiesDead == enemies.Count) {
			Debug.Log ("all enemies dead");
			GiveReward ();
			EndCardGame();

		}

		if (friendliesDead == 3) {
			Debug.Log ("all friendlies dead");
			EndCardGame();

		}

	}


	public void RemoveDeadCards() 

	{
		// Debug.Log ("length of inventory: " + inventory.Count);
		int j = 0;
		for (int i = 0; i < inventory.Count - j; i ++) 
		{
			// Debug.Log (inventory [i - j].name + " " + inventory [i - j].health);
//			Debug.Log("i " + i + " j" + j + " count " + inventory.Count);
			if (inventory[i - j].dead) 
			{
				Debug.Log (inventory [i - j].name + " removed from inventory");
				Global.me.console.text = (inventory [i - j].name + " removed from inventory");
				inventory.RemoveAt (i- j);
				Global.me.playerHealth--;
				friendliesDead++;
				cardsInPlay--;
				Debug.Log ("FD" + friendliesDead);
				j++;
			}
		}

		int k = 0;
		for (int n = 0; n < enemies.Count - k; n++) 
		{
			// 			Debug.Log (inventory [i].name + " " + inventory [i].health);
			if (enemies [n - k].dead) 
			{
				//Debug.Log (enemies [n - k].name + " removed from enemies");
				//enemies.RemoveAt (n - k);
				n++;
				//enemiesDead++;
				//Debug.Log ("ED " + enemiesDead + "EC " + enemies.Count);
			}
		}



	}



	public void CheckKeys() 

	{

		if (cardsThatHaveAttacked == cardsInPlay && cardsInPlay > 0)
			CycleTurn ();
		
		
		if (Input.GetKeyDown (KeyCode.R) )
		{

			//			Debug.Log ("ED " + enemiesDead + " EC " + enemies.Count);
			if (enemies.Count == 0) {
				Card reward = Global.me.GetRandomCard();
				inventory.Add (reward);
			}

			EndCardGame ();

		}

		if (Input.GetKeyDown (KeyCode.E)) 
		{
			CycleTurn ();
		}
			

	}
		
					
	public void EndCardGame() {
		Debug.Log ("LATER");
		Global.me.cardCam.gameObject.SetActive (false);
		Global.me.playerCam.gameObject.SetActive (true);
		Global.me.inventory = inventory;
		//UnityEngine.SceneManagement.SceneManager.LoadScene("basic_level");

	}

	public void GiveReward() {
		Card loot = Global.me.GetRandomCard ();
		print ("You have been rewarded " + loot.name);
		inventory.Add (loot);

	}


	public void CardClicked(Card card) {

		if (!card.inPlay && !card.isEnemyCard) {
			cardsInPlay++;
		}
			
		if (card.inPlay && !card.hasAttacked && !card.isEnemyCard) {
			Global.me.console.text = ("You have selected " + card.name);
			Debug.Log ("You have selected " + card.name);
			cardCurrentlySelected = true;
			cardSelected = card; 
		}
			

		if (card.isEnemyCard && cardCurrentlySelected) {


			if (!cardSelected.hasAttacked) {
				Combat (card);
				cardSelected.hasAttacked = true;
				cardsThatHaveAttacked++;


			} else
				Debug.Log ("this card has  attacked!");
				// Global.me.console.text =  ("this card has  attacked!");



		}

	
	}


	public void StartGame() {
		Global.me.console.text = ("PHASE 1: PLACE UP TO 3 CARDS ONTO THE BATTLEFIELD");

	}

	public void PlayerTurn() {
		Global.me.console.text = ("PHASE 2: YOUR TURN. CLICK ANY OF YOUR CARDS AND THEN AN ENEMY CARD TO ATTACK IT. CARDS CAN ONLY ATTACK ONCE PER TURN.");



	}


}
