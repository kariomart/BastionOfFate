﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadillo : Card {

	public  Armadillo() {
		name = "The Armadillo";
		health = 8; 
		description = "If his roll is even:\n Roll is set to 3 and he gains 1 max health.";
	}

	public override int RollDie () {
		int roll = Random.Range (1, 7);

		if (roll % 2 != 0) {
			health++;
			roll = 3;
		}

		return roll;
	}
 

}



