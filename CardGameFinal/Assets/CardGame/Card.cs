using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {


	public int health;
	public int tokens;
	public int damage = 1;
	public string name;
	public SpriteRenderer cardBase;


	// public string state = "inHand";
	public bool inPlay = false;
	public bool hasAttacked = false;
	public bool isEnemyCard = false;
	public bool selected = false;
	public bool usedAbility = false; 
	public bool dead = false;

	// abilities
	public bool a1_winsTies = false;
	public bool a2_reduceRoll = false;
	public bool a3_heal = false;
	public bool a4_doubleDamageBothWays = false;
	public bool a5_killingBlow = false;
	public bool a6_dealRollTakeRoll = false;


	public Card() {
	}

	public Card(Card crd) {
		health = crd.health;
		tokens = crd.tokens;
		name = crd.name;
		inPlay = crd.inPlay;
		hasAttacked = crd.hasAttacked;
		isEnemyCard = crd.isEnemyCard;
		selected = crd.selected;
		dead = crd.dead;

		a1_winsTies = crd.a1_winsTies;
		a2_reduceRoll = crd.a2_reduceRoll;
		a3_heal = crd.a3_heal;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public virtual int RollDie() {
		int rand = Random.Range (1, 7);
//		Debug.Log ("generic roll");
		// Debug.Log (name + " has rolled a " + rand);
		return rand;
	}
		

	public virtual void TakeDamage(int dmg) {
		health -= dmg;
	}

	public virtual void WinTies() {
		Debug.Log ("Tie won ability activated");

	}

	public virtual void ReduceRoll() {
		Debug.Log ("Roll reduced ability activated");

	}
		
	public virtual void Heal() {
		Debug.Log ("Heal Ability Activated");

	}
		

		



}
/*
public class Card {

	public int heath;
	public int tokens;
	public string name;
	public SpriteRenderer cardBase;

	public Card(CardAsset c)
	{
		int health = c.health;
		int tokens = c.tokens;
		string name = c.name;
		cardBase = c.cardBase;
	}
		

}
*/