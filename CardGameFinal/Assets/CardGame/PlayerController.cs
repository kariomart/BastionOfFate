using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {


	public CardController Card;
	//public List<CardController> Deck;
	public List<CardController> Hand;
	public Canvas Canvas;
	public int DeckSize = 30;
	public int HandSize = 0;

	// Use this for initialization
	void Start () {
	}

//	void CreateDeck () {
//		for (int x = 1; x <= 10; x += 1) {
//			Object obj = Instantiate (Card.gameObject, new Vector3 (400, -200, 0), Quaternion.identity);
//			CardController c = ((GameObject)obj).GetComponent<CardController> ();
//			Deck.Add (c);
//			c.transform.SetParent (DeckDisplay.transform, false);
//		}
//	}


	public void Draw (int amount) {
		for(int x=0; x < amount; x++) {
			GenerateCard ();
			HandSize ++;
			Card.CardNumber ++;
			DeckSize --;
			// TiltCards ();
		}
	}


//	void TiltCards()
//	{
//		//Loop through each card in the hand...
//		foreach (CardController c in Hand) {
//			float handIndex = Hand.IndexOf (c);//This tells us where in the hand the card is.
//			float totalCards = Hand.Count; //The total number of cards in the hand--needed to know relative position.
//			Vector3 rot = Vector3.zero; //Make a rotation to adjust...
//			//Use Mathf.Lerp to make it the appropriate number between 25 and -25.
//			rot.z = Mathf.Lerp (25f, -25f, handIndex / totalCards);
//			c.transform.rotation = Quaternion.Euler (rot); //And apply it.
//		}
//	}


	public void GenerateCard() {
		//Object card = Instantiate (Card.gameObject, new Vector3 (0 + (110 * Hand.Count), -200, 0), Quaternion.identity);
		Object card = Instantiate (Card.gameObject, new Vector3 (245 + (11 * Hand.Count) , -200, 0), Quaternion.identity);
		CardController c = ((GameObject)card).GetComponent<CardController> ();
		Hand.Add (c);
		// c.transform.SetParent (Global.HandDisplay);
		// c.Rotate();
	}

	public void PrintHand() {
		foreach (CardController Card in Hand) {
			Debug.Log (Card);
		}
	}




			





	// Update is called once per frame
	void Update () {
	//	Debug.Log (HandSize);
	}
}
