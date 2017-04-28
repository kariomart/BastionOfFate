using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOrbController : MonoBehaviour {


	public TextMesh nameMesh;
	public TextMesh infoMesh;
	public TextMesh descriptionMesh;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {


		
	}

	public void SetValues(Card card) {
		nameMesh.text = card.name;
		infoMesh.text = card.damage + "D\n" + card.health + "H";



	}
}
