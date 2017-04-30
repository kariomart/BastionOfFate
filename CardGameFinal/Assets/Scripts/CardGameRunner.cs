﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CardGameRunner : MonoBehaviour {

	public GameObject cardBase;

	List<Card> inventory;
	public List<Card> enemies;
	List<CardDisplayNew> displays = new List<CardDisplayNew>();

	public bool cardCurrentlySelected = false;
	public bool enemyCurrentlySelected = false;
	public Card cardSelected;
	public Card enemySelected;

	public bool inBattle = false;
	public bool postScreen = false;
	public bool accepted = false;

	public int enemiesDead = 0;
	public int cardsInPlay = 0;
	public int cardsThatHaveAttacked = 0;
	public int friendliesDead = 0;
	public int counter = 0;
	public int dmg;

	public GameObject cardGamePlayer;
	public GameObject cardGameEnemy;
	public GameObject notification;
	public GameObject notificationInstance;
	public GameObject explosion; 
	public GameObject attackButton;

	public TextMesh enemyRollText;
	public TextMesh playerRollText;
	public TextMeshPro battleInfo;
	public TextMeshPro extraCardInfo;




	void Awake() {
		Global.me.cardGameRunner = this.gameObject;
	//	gameObject.SetActive (false);
	}


	// Use this for initialization
	void OnEnable () {

		Debug.Log ("on enable");
		SetupGame ();

	}
		

	// Update is called once per frame
	void Update () {
				
		CheckKeys ();
		DeathTests ();
		RemoveDeadCards ();


	}
		


	public void AttackButtonClicked() {
		if (cardCurrentlySelected && enemyCurrentlySelected) {

			Combat (enemySelected);

		}



	}

	// Sets up the basics for the card game
	public void SetupGame() 

	{
		
		inBattle = true;
		battleInfo.SetText ("The battle has begun.");


		inventory = Global.me.inventory;
		enemies = Global.me.enemiesTransfer;
		cardGamePlayer = GameObject.Find ("cardGamePlayer");
		cardGameEnemy = GameObject.Find ("cardGameEnemy");



		enemiesDead = 0;
		int count = 0;

		foreach (Card ca in enemies) {
			Debug.Log (ca.name);
		}
	

		foreach (Card ca in inventory) 
		
		{
				ca.inPlay = false;
				GameObject bloop = Instantiate (cardBase, new Vector3 (41 + (2 * count), -3, 0), Quaternion.identity);
				CardDisplayNew display = bloop.GetComponent<CardDisplayNew> ();
				displays.Add (display);
				ca.display = display;
				ca.display.orbitRadii = (1 + (1.15f * count));
				display.card = ca;
				//display.ChangeName ();
				count += 1;
		}


		count = 0;
		foreach (Card car in enemies) 
		{
			GameObject blooop = Instantiate (cardBase, new Vector3 (cardGamePlayer.transform.position.x + (2 * count), 3.5f, 0), Quaternion.identity);
			CardDisplayNew display = blooop.GetComponent<CardDisplayNew> ();
			SpriteRenderer displaySprite = blooop.GetComponent<SpriteRenderer> ();

			displaySprite.color = new Color (255, 0, 0);
			displays.Add (display);
			car.display = display;
			car.display.orbitRadii = (1 + (1.15f * count));
			display.card = car;
			car.isEnemyCard = true;

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




	public void UpdateBattleInfo(string info) {
		battleInfo.SetText (info);

	}


	public void Combat(Card enemy) 

	{

		int playerRoll = cardSelected.RollDie ();
		int enemyRoll = enemy.RollDie ();

		playerRollText.text = "" + playerRoll;
		enemyRollText.text = "" + enemyRoll;

		if (cardSelected.a2_reduceRoll)
			enemyRoll --;

		string roll = cardSelected.name + " has rolled " + playerRoll + ". \n" + enemy.name + " has rolled " + enemyRoll;

		Debug.Log (roll);
		UpdateBattleInfo (roll);


		if (playerRoll > enemyRoll) {
			Global.me.PlayParticleEffect (cardGamePlayer.transform.position, cardGameEnemy.transform.position, cardSelected.color);  
			enemy.TakeDamage (cardSelected.damage);
			string tempRoll = cardSelected.name + " has dealt " + cardSelected.damage + " damage to the " + enemy.name;
			AnimateText (tempRoll, battleInfo);
			Debug.Log (tempRoll);

			//Global.me.console.text = cardSelected.name + " has dealt " + cardSelected.damage + " to the " + enemy.name;
		}
		
		if (enemyRoll > playerRoll) {
			Global.me.PlayParticleEffect (cardGameEnemy.transform.position, cardGamePlayer.transform.position, enemy.color);  
			cardSelected.TakeDamage (enemy.damage);
			string tempRoll = enemy.name + " has dealt " + enemy.damage + " damage to the " + cardSelected.name;
			Debug.Log (tempRoll);
			AnimateText (tempRoll, battleInfo);
			//Global.me.console.text = enemy.name + " has dealt " + enemy.damage + " to the " + cardSelected.name;
		}

		if (enemyRoll == playerRoll)
		if (cardSelected.a1_winsTies) {
			TieParticleEffect (enemy);
			cardSelected.WinTies ();
			enemy.TakeDamage (cardSelected.damage);
			string tempRoll = cardSelected.name + " has dealt " + cardSelected.damage + " damage to the " + enemy.name;
			Debug.Log(tempRoll);
			AnimateText (tempRoll, battleInfo);
			//Global.me.console.text = cardSelected.name + " has dealt " + cardSelected.damage + " to the " + enemy.name;

		} else
			Debug.Log("No damage has been dealt!");
			


		}


	void TieParticleEffect(Card enemy) {

		Vector2 enemyPos = cardGameEnemy.transform.position;
		Vector2 playerPos = cardGamePlayer.transform.position;
		Vector2 midpoint = playerPos + ((enemyPos - playerPos) * 0.5f);

		Global.me.PlayParticleEffect (enemy.display.transform.position, midpoint, enemy.color);  
		Global.me.PlayParticleEffect (cardGamePlayer.transform.position, midpoint, cardSelected.color);


		//Instantiate (explosion, midpoint, Quaternion.identity);




	}


	public void DeathTests() {

		if (inBattle) {

			foreach (Card ca in inventory) {
//				Debug.Log (ca.name);
				if (ca.health < 1) {
					ca.dead = true;
					cardSelected = null;
				}
			}

			foreach (Card em in enemies) {
				if (em.health < 1) {
					em.dead = true;

				}
			}

		}

	
			
//		Debug.Log (enemies + " Death Tests");
			if (enemiesDead == enemies.Count && inBattle) {
			Debug.Log ("all enemies dead");
			EndCardGame();

			}

			if (inventory.Count < 1) {
			Debug.Log ("GG");
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
				inventory.RemoveAt (i- j);
				friendliesDead++;
				Debug.Log ("FD" + friendliesDead);
				Debug.Log ("INV " + inventory.Count);
				j++;
			}
		}

		int k = 0;
		for (int n = 0; n < enemies.Count - k; n++) 
		{
			// 			Debug.Log (inventory [i].name + " " + inventory [i].health);
			if (enemies [n - k].dead) 
			{
				Debug.Log (enemies [n - k].name + " removed from enemies");
				enemies.RemoveAt (n - k);
				n++;
				//enemiesDead++;
				//Debug.Log ("ED " + enemiesDead + "EC " + enemies.Count);
			}
		}



	}

	public void DisplayHUD() {
		//Debug.Log ("HUD DISPLAYED");

		foreach (Card ca in inventory) 

		{
			//Debug.Log (ca.display);
			ca.display.DisplayExtraInfo ();
			
		}


		foreach (Card ca in enemies) 
		
		{
			ca.display.DisplayExtraInfo ();

		}
			
	}

	public void RemoveHUD() {

		foreach (Card ca in inventory) 

		{
			ca.display.RemoveExtraInfo ();

		}


		foreach (Card ca in enemies) {

		
				ca.display.RemoveExtraInfo ();
		}

	}




	public void CheckKeys() 

	{

		
		if (Input.GetKeyDown (KeyCode.R) )
		{

			//			Debug.Log ("ED " + enemiesDead + " EC " + enemies.Count);
			if (enemies.Count == 0) {
				
				Card reward = Global.me.GetRandomCard();
				inventory.Add (reward);
			}

			EndCardGame ();

		}


		if (Input.GetKeyDown (KeyCode.Space) && postScreen) 
		{
			Transition ();
		}


			

	}

	public void ChangePlayer(Card card) {
		SpriteRenderer sprite = cardGamePlayer.GetComponent<SpriteRenderer> ();
		sprite.color = card.color;

	}
		
					
	public void EndCardGame() {
		
		Debug.Log ("LATER");
		ClearObjects ();
		Global.me.backgroundMusic.clip = Global.me.overworldMusic;
		Global.me.backgroundMusic.Play ();
		DisplayEndOfGame ();

	}

	public void DisplayEndOfGame() {
		postScreen = true;
		inBattle = false;

		Card loot = Global.me.GetRandomCard ();

		notificationInstance = Instantiate (notification, new Vector2(48.6f, 1.7f), Quaternion.identity);
		TextMesh desc = notification.transform.FindChild ("desc").GetComponent<TextMesh>();
		desc.text = "You have recieved " + loot.name + "!\nPress space to continue!";
		inventory.Add (loot);

				

	}

	public void Transition() {

		Destroy (notificationInstance);
		Global.me.cardCam.gameObject.SetActive (false);
		Global.me.playerCam.gameObject.SetActive (true);
		this.gameObject.SetActive (false);
		Global.me.inventory = inventory;
		Global.me.inCardGame = false;


	}

	public void AnimateText(string desc, TextMeshPro textMesh) {

		TextMeshController text = textMesh.GetComponent<TextMeshController> ();
		if (desc != text.text) {
			

			text.hovering = false;
			text.counter = 1;
			text.text = desc;

		}

	}


	public void ClearObjects() {

		foreach (CardDisplayNew display in displays) {
			Debug.Log (display.card.name);

			if (display != null) 
				Destroy (display.gameObject);
		}

		battleInfo.SetText ("");
	}


	public void CardClicked(Card card, Transform position) {


		if (!card.isEnemyCard) {
			AnimateText (("You have selected " + card.name), battleInfo);
			AnimateText (card.name + "\n" + card.description, extraCardInfo);


			ParticleSystem cardGamePlayerParticles = cardGamePlayer.GetComponent<ParticleSystem> ();
			cardCurrentlySelected = true;
			cardSelected = card; 

			ParticleSystem.MainModule settings = cardGamePlayerParticles.GetComponent<ParticleSystem>().main;
			settings.startColor = new ParticleSystem.MinMaxGradient( cardSelected.color );

			if (enemyCurrentlySelected)
				AnimateText(cardSelected.name + " vs " + enemySelected.name, battleInfo);
			
				

		}
			

		if (card.isEnemyCard) {

			enemySelected = card;
			enemyCurrentlySelected = true;
			AnimateText("You have selected " + card.name, battleInfo);
//			Global.me.PlayParticleEffect (position, cardSelected.color);  

			if (cardCurrentlySelected)
				AnimateText(cardSelected.name + " vs " + enemySelected.name, battleInfo);
			

		}

	
	}



}
