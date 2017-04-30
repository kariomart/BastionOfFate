using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Card {


	int lives = 9;

	public  Cat() {
		name = "The Cat";
		health = 1;
		damage = 1;
		description = "Can only roll 1-4, but has 9 lives!";
	}
		

	public override void TakeDamage (int dmg)
	{
		if (health - damage < 1 && lives > 0)
			lives--;
		if (lives == 0)
			health -= dmg;
	}


	public override int RollDie ()
	{
		
		int roll = Random.Range (1, 5);
		return roll;


	}
	

}



