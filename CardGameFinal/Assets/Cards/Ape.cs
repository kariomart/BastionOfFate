using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ape : Card {

	public  Ape() {
		name = "The Ape";
		health = 6; 
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



