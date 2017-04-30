using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : Card {

	public  Clown() {
		name = "The Clown";
		health = 3;
		damage = 2;
		description = "Swaps its health and damage every roll";
	}

	public override int RollDie ()
	{
		int roll = Random.Range (1, 7);

		damage = health;
		health = roll;


		return health;
	}
	

}



