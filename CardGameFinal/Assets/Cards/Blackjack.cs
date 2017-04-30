using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackjack : Card {

	public  Blackjack() {
		name = "The Blackjack";
		health = 4;
		damage = 2;
		description = "Rolls twice, if the combined roll is higher than 6 his roll gets set to 0, otherwise he gets the combined roll.";
	}

	public override int RollDie ()
	{
		int roll;

		int roll1 = Random.Range (1, 7);

		if (roll1 < 4) {
			int roll2 = Random.Range (1, 7);

			if (roll1 + roll2 > 6) {
				roll = 0;
			} else
				roll = roll1 + roll2;


		} else
			roll = roll1;

		return roll;

	}
	

}



