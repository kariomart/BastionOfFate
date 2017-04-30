using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Card {

	public  Paladin() {
		name = "The Paladin";
		health = 4;
		damage = 1;
		description = "Can only roll 1-3, but heals the roll amount up to 10 max health.";
	}

	public override int RollDie ()
	{

		int roll = Random.Range (1, 4);

		if (health < 10) {
			health += roll;
		}

		return roll;


	}
	

}



