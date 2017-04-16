using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Card {

	public  Sniper() {
		name = "The Sniper";
		health = 3; 
		damage = 2;
		description = "its low rolls are lower \nand its high rolls are higher";
	}

	public override int RollDie () {
		int roll = Random.Range (1, 7);

		if (roll == 2 || roll == 3) {
			roll = 1;
		}

		if (roll == 4 || roll == 5) {
			roll = 6;
		}

		return roll;
	}
 

}



