using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conservative : Card {

	public  Conservative() {
		name = "The Consertive";
		health = 4;
		damage = 1;
	}

	public override int RollDie ()
	{

		int roll = Random.Range (1, 7);
		if (roll == 1) {
			health *= 2;
		}




		return roll;
	}
	

}



