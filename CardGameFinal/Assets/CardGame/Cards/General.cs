using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : Card {

	public  General() {
		name = "General";
		tokens = 3;
		health = 4; 
	}

	/* public int RollDie () {


	}
*/ 


	public void Power1 () {

		// always wins ties

	}

	public void Power2 () {

		// reduce opponents roll by 1 
		tokens --;
	}
}



