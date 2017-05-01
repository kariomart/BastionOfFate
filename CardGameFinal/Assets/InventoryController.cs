using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

	public GameObject InventoryOrb;
	bool inventoryDisplayed = false;
	public int firstindex = -1;
	public int secondindex = -1;
	List<InventoryOrbController> orbs = new List<InventoryOrbController>();



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (firstindex != -1 && secondindex != -1) {
			Card firstcard = Global.me.inventory [firstindex];
			Card secondcard = Global.me.inventory [secondindex];
			Global.me.inventory.Remove (firstcard);
			Global.me.inventory.Remove (secondcard);
			Global.me.inventory.Insert (secondindex, firstcard);
			Global.me.inventory.Insert (firstindex, secondcard);
			firstindex = -1;
			secondindex = -1;
			removeInventory ();
			displayInventory();
		}

	}



	void OnMouseDown() {

		if (!inventoryDisplayed) {
			displayInventory ();

		}
	}


	public void displayInventory() {


			inventoryDisplayed = true;
			int count = 1;

			foreach (Card card in Global.me.inventory) {
				GameObject orb = Instantiate (InventoryOrb, new Vector2(Global.me.player.transform.position.x + (2 * count), Global.me.player.transform.position.y), Quaternion.identity);
				orb.transform.localScale = new Vector2 (3f, 3f);
				orbs.Add (orb.GetComponent<InventoryOrbController>());
				orb.GetComponent<InventoryOrbController>().dad = this;
				InventoryOrbController orbController = orb.GetComponent<InventoryOrbController> ();
				orbController.SetValues (card);
				count ++;

			}


		}

	public void removeInventory() {
		foreach (InventoryOrbController orb in orbs) {
			Destroy (orb.gameObject);

		}


	}


}
