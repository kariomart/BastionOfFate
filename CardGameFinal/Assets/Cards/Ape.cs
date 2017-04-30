using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ape : Card {

	public  Ape() {
		name = "The Ape";
		health = 6; 
		description = "Roll a 3 and gain 2 damage. Roll a 6 and take 1 damage.";
	}

	public override int RollDie () {
		int roll = Random.Range (1, 7);

		if (roll == 3) {
			damage += 2;
		}

		if (roll == 6) {
			health --;
		}

		return roll;
	}
 

}



