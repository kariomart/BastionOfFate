using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joker : Card {

	public  Joker() {
		name = "Joker";
		tokens = 0;
		health = 1;
	}

	public override int RollDie () {
		return 5;
	}
}

