using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {


	public int health;
	public int tokens;
	public string name;
	public SpriteRenderer cardBase;

	public bool hasAttacked = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual int RollDie() {
		int rand = Random.Range (1, 7);
		// Debug.Log (name + " has rolled a " + rand);
		return rand;
	}
		

	public virtual void TakeDamage(int dmg) {
		health -= dmg;
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