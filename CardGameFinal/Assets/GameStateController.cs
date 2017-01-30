using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GameStateController : MonoBehaviour {

	public PlayerController Player;
	public CardController Card;




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
