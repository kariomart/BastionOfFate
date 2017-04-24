using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplayNew : MonoBehaviour {

	//	public TextMesh nameMesh;
	//	public TextMesh damageMesh;
	//	public TextMesh healthMesh;
	public CardGameRunner game;
	public SpriteRenderer sprite;
	public GameObject orbTextObj;
	public TextMesh orbText;
	public GameObject currentlyDisplayedText;

	public GameObject explosion;


	//Vector2 originalPos;
	public Card card;			
	public Screenshake cam;
	public float count = 0;
	public bool hovering = false;
	public bool isTextDisplayed = false;
	public float orbitSpeed;
	public float orbitRadi;




	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer> ();
		GameObject g = GameObject.Find ("CardGame");
		cam = GameObject.Find ("CardCamera").GetComponent<Screenshake>();
		game = g.GetComponent<CardGameRunner> ();

		orbitSpeed = Random.Range(1f, 2f);
		orbitRadi = Random.Range(2f, 4f);


	}

	void Orbit() {
		
		Vector2 orbitPos = game.cardGamePlayer.transform.position;
		transform.position = orbitPos + (MagicSpells.ToVect((MagicSpells.ToAng(orbitPos, transform.position) + orbitSpeed)) * orbitRadi);

	}
		


	public void OnMouseOver() {

		hovering = true;
		sprite.sortingOrder = 3;
		DisplayInfo ();
		//OrbShake ();



	}


	public void OnMouseExit() {

		hovering = false;
		Global.me.RemoveCardInfo ();
		count = 0;
		RemoveCardInfo ();
		sprite.sortingOrder = 0;
		// delete the alert
		
	}



	public void OnMouseDown() {

		game.CardClicked (card, this.transform);
		//Instantiate (explosion, this.transform);
		if (!card.isEnemyCard){
			
		Debug.Log (card.name + " CLICKED");
		game.ChangePlayer (card);


		}
	}

	public void DisplayInfo() {

		if (!isTextDisplayed) {
			isTextDisplayed = true;
			currentlyDisplayedText = Instantiate (orbTextObj);
			orbText = currentlyDisplayedText.GetComponent<TextMesh> ();
			orbText.text = card.name + "\n" + "damage: " + card.damage + "\n" + "health: " + card.health;

			if (!card.isEnemyCard)
				orbText.color = new Color (.2f, .2f, .9f, .6f);
		}

	}



	public void RemoveCardInfo() {

		Destroy (currentlyDisplayedText);
		isTextDisplayed = false;

	}

	public void OrbShake() {

		count += 0.35f;
		cam.SetScreenshake (.005f * count, .1f);


	}


	// Update is called once per frame
	void Update () {

		if (!card.isEnemyCard && !hovering)
			Orbit ();

		if (card.dead) {
			Destroy (currentlyDisplayedText);
			//Destroy (selectedText);
			Instantiate (explosion, this.transform.position, Quaternion.identity);

			Destroy (this.gameObject);
		}

		if (isTextDisplayed) {
			orbText.text = card.name + "\n" + "damage: " + card.damage + "\n" + "health: " + card.health;
			
		}





//		if (game.card.display == this) {
//			Global.me.PlayParticleEffect (Global.me.wispParticle, Global.me.cardGamePlayer.transform, game.cardSelected.color);
//
//		}

	}
}
