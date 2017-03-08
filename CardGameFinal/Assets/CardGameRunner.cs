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
	public int friendlyDeaths = 0;
	public int dmg;


	// Use this for initialization
	void Start () {
		inventory = Global.me.inventory;
		enemies = Global.me.enemiesTransfer;

		SetupGame ();
		StartGame ();
		PlayerTurn ();

		foreach (Card card in inventory) {
			card.inPlay = false;
		}
			

	}
		

	// Update is called once per frame
	void Update () {

		if (cardsThatHaveAttacked == cardsInPlay && cardsInPlay > 0)
			CycleTurn ();

		if ((Input.GetKey (KeyCode.A) && cardCurrentlySelected && !cardSelected.usedAbility)) {
			Debug.Log (cardSelected.name + " used its ability");
			cardSelected.usedAbility = true;
		}

		// if (Input.GetKey (KeyCode.R) || friendlyDeaths == 3 || enemiesDead == 100) {
		if (Input.GetKey (KeyCode.R) ){

			Debug.Log ("ED " + enemiesDead + " EC " + enemies.Count);
			if (enemiesDead == enemies.Count) {
				Card reward = Global.me.GetRandomCard();
				inventory.Add (reward);
			}

			Debug.Log ("LATER");
			Global.me.inventory = inventory;
			UnityEngine.SceneManagement.SceneManager.LoadScene("basic_level");

		}
			
		if (Input.GetKeyDown (KeyCode.E)) {
			CycleTurn ();
		}

		foreach (Card card in inventory) {
			if (card.health < 1) {
				card.dead = true;
				cardsInPlay--;
				friendlyDeaths++;
				Debug.Log (card.name + " has died!");
			}
		}
			

//		Debug.Log ("length of inventory: " + inventory.Count);
		for (int i = 0; i < inventory.Count; i ++) {
// 			Debug.Log (inventory [i].name + " " + inventory [i].health);
			if (inventory[i].dead) {
				inventory.RemoveAt (i);
				Debug.Log (inventory [i].name + " removed from inventory");
				friendlyDeaths++;
			}

		


		}


		// IF FRIENDLY DIES, SUBTRACT ONE FROM CARDSINPLAY SO IT CYCLES PROPERLY
	}



	public void SetupGame() {
		enemiesDead = 0;
		cardsInPlay = 0;
		cardsThatHaveAttacked = 0;

		int count = 0;

		foreach (Card ca in inventory) {
			GameObject bloop = Instantiate (cardBase, new Vector3(-7 + (2 * count), -3, 0), Quaternion.identity);
			CardDisplay display = bloop.GetComponent<CardDisplay> ();
			display.card = ca;
			display.ChangeName();
			count += 1;
	
		}

		count = 0;
		foreach (Card car in enemies) {
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

	public void Combat(Card enemy) {

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

			// do damage stuff


		}


		/*

		if (card.inPlay && card.hasAttacked && !card.isEnemyCard) {
			Debug.Log ("This card has already attacked this turn!");
		}


		if (card.isEnemyCard && inCombat) {
			Debug.Log (card.name + " has taken " + dmg + " damage");
			card.TakeDamage (dmg);
		//	UpdateDisplay ();
			inCombat = false;
		}

*/
			
		// Debug.Log (card.name + " " + card.inPlay + " " + card.isEnemyCard);



	}


	public void StartGame() {
		Debug.Log ("PHASE 1: PLACE UP TO 3 CARDS ONTO THE BATTLEFIELD");

	}

	public void PlayerTurn() {
		Debug.Log ("PHASE 2: YOUR TURN. CLICK ANY OF YOUR CARDS AND THEN AN ENEMY CARD TO ATTACK IT. CARDS CAN ONLY ATTACK ONCE PER TURN.");



	}

	public void EnemyTurn() {



	}



}
