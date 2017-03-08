﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joker : Card {

	public  Joker() {
		name = "Joker";
		health = 2;
		damage = 3;
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



