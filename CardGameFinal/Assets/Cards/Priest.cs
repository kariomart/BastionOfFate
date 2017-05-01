using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : Card {

	public  Priest() {
		name = "The Priest";
		health = 5;
		damage = 0;
		description = "Can only roll 1-3, and heals the card in the upper orbit for that amount";
	}

	public override int RollDie ()
	{

		int roll = Random.Range (1, 4);

		//Debug.Log(Global.me.hand [handIndex + 1]);
		Debug.Log (handIndex);

		if (handIndex != 2) {

			if (!isEnemyCard) {
				Debug.Log (Global.me.hand [handIndex + 1]);
				Global.me.game.AnimateText("The Priest has healed " + Global.me.hand [handIndex + 1].name + " for " + roll, Global.me.game.cardAbilityInfo);
				Global.me.hand [handIndex + 1].health += roll;
			}

			if (isEnemyCard) {
				List<Card> enemies = Global.me.cardGameRunner.GetComponent<CardGameRunner> ().enemies;
				enemies [Random.Range (0, enemies.Count + 1)].health += roll;


			}
		}


		return roll;

	}
	

}



