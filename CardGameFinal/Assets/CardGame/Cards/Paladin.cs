using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Card {

	public  Paladin() {
		name = "The Paladin";
		health = 4;
		damage = 1;
	}

	public override int RollDie ()
	{

		int roll = Random.Range (1, 4);
		health += roll;

		return roll;


	}
	

}



