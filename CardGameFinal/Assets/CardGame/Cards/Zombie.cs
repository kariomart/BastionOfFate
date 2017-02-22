using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Card {

	public  Zombie() {
		name = "Zombie";
		tokens = 0;
		health = 2; 
	}

	public override int RollDie () {
		int rand = Random.Range (1, 6);

		if (rand == 6) {
			rand = 1;	
		}

		return rand;
	}
 


	public void Power1 () {

		// you only take damage when you roll a 1

	}

	public void Power2 () {

		// reduce opponents roll by 1 
		tokens --;
	}
}



