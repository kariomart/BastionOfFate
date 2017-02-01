using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviourSingleton <Global> {

	public static Global me;
	public PanelController battlefieldPanel;
	public PlayerController Player;
	public CardController Card;




	public Global Get() {
		if (me == null) {
			me = (Global)FindObjectOfType(typeof(Global));
		}

		return me;
	}


	void Awake() {
		Get ();
	}



	// Use this for initialization
	void Start () {
		SetupGame ();
	}

	void SetupGame() {
		Player.Draw(5);
	}



	
	// Update is called once per frame
	void Update () {
		
	}
}
