using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joker : Card {

	public  Joker() {
		name = "Joker";
		health = 2;
		damage = 3;
		description = "If rolls 3, rolls again. If rolls 1, roll is set to 7";
	}

	public override int RollDie ()
	{
		int roll = Random.Range (1, 7);

		if (roll == 3) {
			roll = Random.Range (1, 7);
		}


		if (roll == 1) {
			roll = 7;
		}

		return roll;
	}
	

}



