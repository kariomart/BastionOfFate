using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplayNew : MonoBehaviour {


	public CardGameRunner game;
	public SpriteRenderer sprite;

	public GameObject orbTextObj;
	public GameObject currentlyDisplayedText;

	public TextMesh orbText;
	public TextMesh extraInfo;
	public TextMesh nameInfo;

	public GameObject explosion;
	public GameObject wisp;
	public GameObject wispTemp;


	public Card card;			
	public Screenshake cam;
	public float count = 0;
	public bool hovering = false;
	public bool isTextDisplayed = false;
	public float orbitSpeed;
	public float orbitRadii;




	// Use this for initialization
	void Start () {

		sprite = GetComponent<SpriteRenderer> ();
		GameObject g = GameObject.Find ("CardGame");
		cam = GameObject.Find ("CardCamera").GetComponent<Screenshake>();
		orbText = GameObject.Find ("OrbText").GetComponent<TextMesh> ();
		game = g.GetComponent<CardGameRunner> ();

		orbitSpeed = Random.Range(1f, 1.3f);
		//orbitRadi = Random.Range(2f, 4f);


	}

	void Orbit() {
		
		Vector2 orbitPos = game.cardGamePlayer.transform.position;
		transform.position = orbitPos + (MagicSpells.ToVect((MagicSpells.ToAng(orbitPos, transform.position) + orbitSpeed)) * orbitRadii);

	}
		


	public void OnMouseOver() {

		hovering = true;
		sprite.sortingOrder = 3;
		DisplayInfo ();
		//OrbShake ();



	}

	public void DisplayExtraInfo() {
		extraInfo.text = card.damage + "D\n" + card.health + "H";
		nameInfo.text = card.name;

	}

	public void RemoveExtraInfo() {
		extraInfo.text = "";
		nameInfo.text = "";

	}


	public void OnMouseExit() {

		hovering = false;
		Global.me.RemoveCardInfo ();
		count = 0;
		RemoveCardInfo ();
		//sprite.sortingOrder = 0;
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

		if (!isTextDisplayed && !this.card.isEnemyCard) {
			isTextDisplayed = true;
			orbText.text = card.name + "\n" + card.damage + "D, " + card.health + "H" + "\n" + card.description;
		}

		if (!isTextDisplayed && card.isEnemyCard) {
			orbText.color = new Color (.2f, .2f, .9f, .6f);
			orbText.text = card.name + "\n" + card.damage + "D, " + card.health + "H";
		}
			
	}



	public void RemoveCardInfo() {

		orbText.text = "";
		isTextDisplayed = false;

	}

	public void Wisp() {

		wispTemp = Instantiate (wisp, this.transform.position, Quaternion.identity);

		ParticleSystem wispParticle = wispTemp.GetComponent<ParticleSystem> ();
		ParticleController particleController = wispTemp.GetComponent<ParticleController> ();

		wispParticle.startColor = card.color;
		var shape = wispParticle.shape;
		shape.radius = Random.Range (0.05f, 0.38f);
		//wispParticle.emissionRate = wispParticle.emissionRate * (card.health / 10); 	

		wispParticle.Play ();
		particleController.StartLerping (game.cardGamePlayer.transform.position);
		Destroy (wispTemp, 3);

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

		if (game.cardSelected == this.card) {
			
			Wisp ();

		}







//		if (game.card.display == this) {
//			Global.me.PlayParticleEffect (Global.me.wispParticle, Global.me.cardGamePlayer.transform, game.cardSelected.color);
//
//		}

	}
}
