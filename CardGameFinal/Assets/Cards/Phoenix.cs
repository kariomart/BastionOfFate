﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoenix : Card {

	public  Phoenix() {
		name = "The Phoenix";
		health = 3;
		damage = 3;
		description = "has to take exactly its health as damage to die.";
	}
		

	public override void TakeDamage (int dmg)
	{
		if (dmg == health)
			health -= dmg;
		
	}

	public override int RollDie ()
	{
		
		int roll = Random.Range (1, 5);
		return roll;


	}
	

}



