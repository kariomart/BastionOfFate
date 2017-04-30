using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambler : Card {

	public  Gambler() {
		name = "The Gambler";
		health = 5; 
		damage = 2;
		description = "If rolls less than 4, takes 1 damage and rolls again";
	}

	public override int RollDie () {
		int roll = Random.Range (1, 7);

		while (roll < 4) {
			roll = Random.Range (1, 7);
			health--;
		}

		return roll;
	}
 

}



