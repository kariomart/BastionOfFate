using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magikarp : Card {

	public  Magikarp() {
		name = "Magikarp";
		health = 5;
		damage = 0;
		description = "Does nothing unless you get lucky";
	}

	public override int RollDie ()
	{
		int roll = Random.Range (1, 7);


		int roll1 = Random.Range (1, 5);
		int roll2 = Random.Range (1, 5);
		int roll3 = Random.Range (1, 5);

		if (roll1 == roll2 && roll2 == roll3) {
			CardGameRunner game = Global.me.cardGameRunner.GetComponent<CardGameRunner> ();
			game.AnimateText ("MAGIKARP EVOLVED INTO GYARADOS", game.battleInfo);
			health = 10;
			damage = 10;
		}


		return roll;

	}
	

}



