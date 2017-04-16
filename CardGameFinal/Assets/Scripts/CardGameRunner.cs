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
	public bool inBattle = false;

	public int enemiesDead = 0;
	public int cardsInPlay = 0;
	public int cardsThatHaveAttacked = 0;
	public int friendliesDead = 0;
	public int dmg;

	public GameObject cardGamePlayer;

	void Awake() {
		Global.me.cardGameRunner = this.gameObject;
	//	gameObject.SetActive (false);


	}

	// Use this for initialization
	void OnEnable () {

		//Debug.Log ("on enable");
		SetupGame ();
		StartGame ();


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
		
		inBattle = true;
		Debug.Log (enemies + " setup game");
		inventory = Global.me.inventory;
		enemies = Global.me.enemiesTransfer;
		cardGamePlayer = GameObject.Find ("CardGamePlayer");

		enemiesDead = 0;
		int count = 0;
	

		foreach (Card ca in inventory) 
		
		{
				ca.inPlay = false;
				GameObject bloop = Instantiate (cardBase, new Vector3 (41 + (2 * count), -3, 0), Quaternion.identity);
				CardDisplayNew display = bloop.GetComponent<CardDisplayNew> ();
				display.card = ca;
				//display.ChangeName ();
				count += 1;
		}


		count = 0;
		foreach (Card car in enemies) 
		{
			GameObject blooop = Instantiate (cardBase, new Vector3 (51 + (2 * count), 2, 0), Quaternion.identity);
			CardDisplayNew display = blooop.GetComponent<CardDisplayNew> ();
			SpriteRenderer displaySprite = blooop.GetComponent<SpriteRenderer> ();

			displaySprite.color = new Color (255, 0, 0);
			display.card = car;
			//display.ChangeName ();
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
			//Global.me.console.text = cardSelected.name + " has dealt " + cardSelected.damage + " to the " + enemy.name;
		}
		
		if (enemyRoll > playerRoll) {
			cardSelected.TakeDamage (enemy.damage);
			Debug.Log (enemy.name + " has dealt " + enemy.damage + " to the " + cardSelected.name);
			//Global.me.console.text = enemy.name + " has dealt " + enemy.damage + " to the " + cardSelected.name;
		}

		if (enemyRoll == playerRoll)
		if (cardSelected.a1_winsTies) {
			cardSelected.WinTies ();
			enemy.TakeDamage (cardSelected.damage);
			Debug.Log (cardSelected.name + " has dealt " + cardSelected.damage + " to the " + enemy.name);
			//Global.me.console.text = cardSelected.name + " has dealt " + cardSelected.damage + " to the " + enemy.name;

		} else
			Debug.Log("No damage has been dealt!");
			


		}



	public void DeathTests() 

	{

		foreach (Card ca in inventory) {
			if (ca.health < 1) {
				ca.dead = true;

			}

			foreach (Card em in enemies) {
				if (em.health < 1) {
					em.dead = true;

				}
		}
			
//		Debug.Log (enemies + " Death Tests");
			if (enemiesDead == enemies.Count && inBattle) {
			Debug.Log ("all enemies dead");
			GiveReward ();
			EndCardGame();

			}

			if (inventory.Count < 1) {
			Debug.Log ("GG");
			EndCardGame();

			}

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


		if (Input.GetKeyDown (KeyCode.E)) 
		{
			CycleTurn ();
		}
			

	}

	public void ChangePlayer(Card card) {
		SpriteRenderer sprite = cardGamePlayer.GetComponent<SpriteRenderer> ();
		sprite.color = card.color;

	}
		
					
	public void EndCardGame() {
		
		Debug.Log ("LATER");
		Global.me.backgroundMusic.clip = Global.me.overworldMusic;
		Global.me.backgroundMusic.Play ();
		Global.me.cardCam.gameObject.SetActive (false);
		Global.me.playerCam.gameObject.SetActive (true);
		Global.me.inventory = inventory;
		Global.me.inCardGame = false;
		inBattle = false;

	}

	public void GiveReward() {
		Card loot = Global.me.GetRandomCard ();
		print ("You have been rewarded " + loot.name);
		inventory.Add (loot);

	}


	public void CardClicked(Card card, Vector2 position) {


		if (!card.isEnemyCard) {
			Debug.Log ("You have selected " + card.name);
			cardCurrentlySelected = true;
			ParticleSystem cardGamePlayerParticles = cardGamePlayer.GetComponent<ParticleSystem> ();
			cardSelected = card; 

			ParticleSystem.MainModule settings = cardGamePlayerParticles.GetComponent<ParticleSystem>().main;
			settings.startColor = new ParticleSystem.MinMaxGradient( cardSelected.color );
		}
			

		if (card.isEnemyCard && cardCurrentlySelected ) {

			Combat (card);
			Global.me.PlayParticleEffect (Global.me.attackParticle, position, cardSelected.color);  

		}

	
	}


	public void StartGame() {


	}



}
