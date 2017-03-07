﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameRunner : MonoBehaviour {

	public GameObject cardBase;
	List<Card> inventory;
	List<Card> enemies;

	public bool playerTurn = true;
	public bool enemyTurn = false;
	public int enemiesDead = 0;
	public bool cardCurrentlySelected = false;
	public Card cardSelected;
	public int cardsInPlay = 0;
	public int cardsThatHaveAttacked = 0;
	public int dmg;


	// Use this for initialization
	void Start () {
		inventory = Global.me.inventory;
		enemies = Global.me.enemiesTransfer;

		SetupGame ();
		StartGame ();
		PlayerTurn ();
	}
		

	// Update is called once per frame
	void Update () {

//		if(enemiesDead == enemies.Count){
//			UnityEngine.SceneManagement.SceneManager.LoadScene ("basic_level");
//		}
//
//		if ((Input.GetKey (KeyCode.A))
//			Debug.Log("ability used");
//
//		}
//
	}

	public void SetupGame() {
		int count = 0;

		foreach (Card ca in inventory) {
			GameObject bloop = Instantiate (cardBase, new Vector3(-7 + (2 * count), -3, 0), Quaternion.identity);
			CardDisplay display = bloop.GetComponent<CardDisplay> ();
			display.card = ca;
			display.ChangeName();
			count += 1;
	
		}


		foreach (Card car in enemies) {
			GameObject blooop = Instantiate (cardBase, new Vector3 (0 + (2 * count), 0, 0), Quaternion.identity);
			CardDisplay display = blooop.GetComponent<CardDisplay> ();
			SpriteRenderer displaySprite = blooop.GetComponent<SpriteRenderer> ();

			displaySprite.color = new Color (255, 0, 0);
			display.card = car;
			display.ChangeName ();
			display.card.isEnemyCard = true;

			count += 1;
		}

	}	

	public void Combat(Card enemy) {

		int playerRoll = cardSelected.RollDie ();
		int enemyRoll = enemy.RollDie ();
		Debug.Log(cardSelected.name + " has rolled " + playerRoll + ". " + enemy.name + " has rolled " + enemyRoll);

		if (playerRoll > enemyRoll) {
			enemy.TakeDamage (cardSelected.damage);
			Debug.Log (cardSelected.name + "has dealt " + cardSelected.damage + " to the " + enemy.name);
		}
		
		if (enemyRoll > playerRoll) {
			cardSelected.TakeDamage (enemy.damage);
			Debug.Log (enemy.name + "has dealt " + enemy.damage + " to the " + cardSelected.name);
		}

		if (enemyRoll == playerRoll)
			Debug.Log("No damage has been dealt!");

		}
					

	public void CardClicked(Card card) {

		if (!card.inPlay && !card.isEnemyCard) {
			cardsInPlay++;
			Debug.Log ("i'm incrementing stuff");
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
