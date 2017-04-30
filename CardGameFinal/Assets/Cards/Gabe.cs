using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabe : Card {

	public  Gabe() {
		name = "The Gabe";
		health = 5;
		description = "Either rolls a 6 or a 1";
	}

	public override int RollDie ()
	{
		int roll;
		int rand = Random.Range (1, 11);

		if (rand % 2 == 0)
			roll = 6;
		else
			roll = 1;
				
		return roll;
	}



}
