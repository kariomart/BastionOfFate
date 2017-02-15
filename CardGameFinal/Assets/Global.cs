using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviourSingleton <Global> {

	public static Global me;
//	public PanelController battlefieldPanel;
//	public PlayerController Player;
//	public CardController Card;
//	public GameObject HandDisplay;
	public List<CardAsset> inventory;
	public List<CardAsset> cards;
	public int CardsInPlay;
	// public List<Items> Inventory;



	public Global Get() {
		if (me == null) {
			me = (Global)FindObjectOfType(typeof(Global));
		}

		return me;
	}
		



	void Awake() {
		Get ();
		DontDestroyOnLoad(transform.gameObject);

	}
		





	// Use this for initialization
	void Start () {
		
	}
		

	
	// Update is called once per frame
	void Update () {
		
	}
}
