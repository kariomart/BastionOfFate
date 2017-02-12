using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardAsset : ScriptableObject {


	public int health;
	public int tokens;
	public string name;
	public SpriteRenderer cardBase;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

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
