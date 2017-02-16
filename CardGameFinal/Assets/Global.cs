using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviourSingleton <Global> {

	public static Global me;
//	public PanelController battlefieldPanel;
//	public PlayerController Player;
//	public CardController Card;
//	public GameObject HandDisplay;
	public List<Card> inventory;
	public List<Card> cards;
	public int CardsInPlay;



	public Global Get() {
		if (me == null) {
			me = (Global)FindObjectOfType(typeof(Global));
		}

		return me;
	}
		



	void Awake() {
		Get ();
		DontDestroyOnLoad(transform.gameObject);

		cards = new List<Card> ();
		inventory = new List<Card> ();

		cards.Add (new Joker());
		cards.Add (new General());
		cards.Add (new Zombie());

	}
		





	// Use this for initialization
	void Start () {

	}
		

	
	// Update is called once per frame
	void Update () {
		// Debug.Log (inventory.Count);
		// Debug.Log (cards.Count);
	}
}
