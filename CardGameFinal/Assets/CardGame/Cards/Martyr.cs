using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martyr : Card {

	public  Martyr() {
		name = "The Martyr";
		health = 10;
		damage = 10;
	}

	public override int RollDie ()
	{
		Debug.Log ("Overridden");
		int roll = Random.Range (1, 7);

		if (roll == 1 || roll == 2 || roll == 3 || roll == 4 || roll == 5) {
			roll = 1;
			health = 0;
		}


		return roll;
	}
	

}



