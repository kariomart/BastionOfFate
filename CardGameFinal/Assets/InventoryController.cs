using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

	public GameObject InventoryOrb;
	bool inventoryDisplayed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void OnMouseDown() {

		if (!inventoryDisplayed) {
			
			inventoryDisplayed = true;
			int count = 0;

			foreach (Card card in Global.me.inventory) {
				GameObject orb = Instantiate (InventoryOrb, new Vector2(Global.me.player.transform.position.x + (2 * count), Global.me.player.transform.position.y), Quaternion.identity);
				InventoryOrbController orbController = orb.GetComponent<InventoryOrbController> ();
				orbController.SetValues (card);
				count ++;


			}


		}
	}


}
