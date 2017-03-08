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

	// Use this for initialization
	void Start () {

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

		inventory = Global.me.inventory;
		enemies = Global.me.enemiesTransfer;
		enemiesDead = 0;
		cardsInPlay = 0;
		cardsThatHaveAttacked = 0;
		int count = 0;
		List<Card> hand = new List<Card> ();

		foreach (Card ca in inventory) 
		
		{
				ca.inPlay = false;
				GameObject bloop = Instantiate (cardBase, new Vector3 (-7 + (2 * count), -3, 0), Quaternion.identity);
				CardDisplay display = bloop.GetComponent<CardDisplay> ();
				display.card = ca;
				display.ChangeName ();
				count += 1;
		}


		count = 0;
		foreach (Card car in enemies) 
		{
			GameObject blooop = Instantiate (cardBase, new Vector3 (3 + (2 * count), 2, 0), Quaternion.identity);
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
		}
		
		if (enemyRoll > playerRoll) {
			cardSelected.TakeDamage (enemy.damage);
			Debug.Log (enemy.name + " has dealt " + enemy.damage + " to the " + cardSelected.name);
		}

		if (enemyRoll == playerRoll)
		if (cardSelected.a1_winsTies) {
			cardSelected.WinTies ();
			enemy.TakeDamage (cardSelected.damage);
			Debug.Log (cardSelected.name + " has dealt " + cardSelected.damage + " to the " + enemy.name);

		} else
			Debug.Log("No damage has been dealt!");


		}

	public void DeathTests() 

	{


		if (enemiesDead == enemies.Count) {
			// Debug.Log ("THIS WORKED WOO");
			GiveReward ();
			EndCardGame();

		}

		if (friendliesDead == 3) {
			EndCardGame();

		}

	}


	public void RemoveDeadCards() 

	{
		// Debug.Log ("length of inventory: " + inventory.Count);
	
		for (int i = 0; i < inventory.Count; i ++) 
		{
			//Debug.Log (inventory [i].name + " " + inventory [i].health);
			if (inventory[i].dead) 
			{
				inventory.RemoveAt (i);
				Debug.Log (inventory [i].name + " removed from inventory");
				Global.me.playerHealth--;
			}
		}
			
		for (int n = 0; n < enemies.Count; n++) 
		{
			// 			Debug.Log (inventory [i].name + " " + inventory [i].health);
			if (enemies [n].dead) 
			{
				enemies.RemoveAt (n);
				Debug.Log (enemies [n].name + " removed from enemies");
			}
		}



	}



	public void CheckKeys() 

	{

		if (cardsThatHaveAttacked == cardsInPlay && cardsInPlay > 0)
			CycleTurn ();
		
		
		if (Input.GetKey (KeyCode.R) )
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
		Global.me.inventory = inventory;
		UnityEngine.SceneManagement.SceneManager.LoadScene("basic_level");

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
				Debug.Log ("this card has already attacked!");



		}

	
	}


	public void StartGame() {
		Debug.Log ("PHASE 1: PLACE UP TO 3 CARDS ONTO THE BATTLEFIELD");

	}

	public void PlayerTurn() {
		Debug.Log ("PHASE 2: YOUR TURN. CLICK ANY OF YOUR CARDS AND THEN AN ENEMY CARD TO ATTACK IT. CARDS CAN ONLY ATTACK ONCE PER TURN.");



	}


}
