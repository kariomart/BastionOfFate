﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Card {

	public  Sniper() {
		name = "The Sniper";
		health = 3; 
		damage = 2;
		description = "rolls 2 and 3 are set to 1, but 4 and 5 are set to 6.";
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



