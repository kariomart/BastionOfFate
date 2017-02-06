using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

	public PlayerController Player;

	public List<string> Names;
	public List<int> Health;
	public List<int> Tokens;
	int rand;
	public int CardNumber = 1;

	public string CardName;
	public int CardHealth;
	public int CardTokens;


	public RectTransform CardDisplay;
	public Text Title;
	public Text Description;
	public GameObject hand;


	// Use this for initialization
	void Start () {
		hand = Global.me.HandDisplay;

		rand = Random.Range(0, 4);
		Names.Add ("a");
		Names.Add ("b");
		Names.Add ("c");
		Names.Add ("d");

		Health.Add (1);
		Health.Add (2);
		Health.Add (3);
		Health.Add (4);

		Tokens.Add (2);
		Tokens.Add (2);
		Tokens.Add (2);
		Tokens.Add (2);

		getCharacterStats ();
		setCardDisplay ();
		transform.SetParent (hand.transform, false);


	}

	void getCharacterStats() {
		CardName = Names [rand];
		CardHealth = Health [rand];
		CardTokens = Tokens [rand];
	}

	void setCardDisplay () {
		Title.text = CardName;
		Description.text = "Health: " + CardHealth + " Tokens: " + CardTokens;
	}
		


	public void OnPointerEnter(PointerEventData eventData) {
		if (CardDisplay.transform.position.y < 300) {
			CardDisplay.Translate (0, 20, 0);
		}
	}




	public void OnPointerExit(PointerEventData eventData) {
		if (CardDisplay.transform.position.y > 250) {
			CardDisplay.Translate (0, -20, 0);
		}
	}
		

//	public void Rotate() {
//			int middle = (Player.HandSize / 2);
//			Debug.Log (middle);
//			int Rotation = (CardNumber - Player.Hand [middle].CardNumber) * 15;
//			Debug.Log (Rotation);
//			CardDisplay.transform.Rotate (Rotation, 0, 0);
//	}



	void Update () {
//		if (EventSystem.current.IsPointerOverGameObject ()) {
//			if (CardDisplay.transform.position.y < 300) {
//				CardDisplay.Translate (0, 1, 0);
//			}
//		} 
//			
//		else if (CardDisplay.transform.position.y > 250) {
//				CardDisplay.Translate (0, -1, 0);
//		}
//
//	}
	
	}

}