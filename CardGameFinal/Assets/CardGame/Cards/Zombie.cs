﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Card {

	public  Zombie() {
		name = "Zombie";
		health = 10; 
	}

	public override int RollDie () {
		int roll = Random.Range (1, 7);

		if (roll == 6) {
			health = 0;
		}

		return roll;
	}
 

}



