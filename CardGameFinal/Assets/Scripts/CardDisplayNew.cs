using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplayNew : MonoBehaviour {


	public CardGameRunner game;
	public SpriteRenderer sprite;

	public GameObject orbTextObj;
	public TextMeshPro friendlyOrbInfo;
	public TextMeshPro enemyOrbInfo;
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
		friendlyOrbInfo = GameObject.Find ("friendlyCardText").GetComponent<TextMeshPro> ();
		enemyOrbInfo = GameObject.Find ("enemyCardText").GetComponent<TextMeshPro> ();
		game = g.GetComponent<CardGameRunner> ();

		orbitSpeed = Random.Range(1.1f, 1.2f);
		//orbitRadi = Random.Range(2f, 4f);


	}

	void Orbit() {

		if (!card.isEnemyCard) {
			Vector2 orbitPos = game.cardGamePlayer.transform.position;
			transform.position = orbitPos + (MagicSpells.ToVect ((MagicSpells.ToAng (orbitPos, transform.position) + orbitSpeed)) * orbitRadii);
		}

		if (card.isEnemyCard) {
			Vector2 orbitPos = game.cardGameEnemy.transform.position;
			transform.position = orbitPos + (MagicSpells.ToVect ((MagicSpells.ToAng (orbitPos, transform.position) + orbitSpeed)) * orbitRadii);
		}
	}
		


	public void OnMouseOver() {

		hovering = true;
		sprite.sortingOrder = 3;

		TextMeshController text = game.extraCardInfo.GetComponent<TextMeshController> ();

		if (text.counter == 0) {
			text.hovering = true;
			game.AnimateText (card.name + "\n" + card.description, game.extraCardInfo);
		}
			//OrbShake ();
		DisplayInfo();



	}

	public void DisplayExtraInfo() {

		if (extraInfo && nameInfo != null) {
			extraInfo.text = card.damage + "D\n" + card.health + "H";
			nameInfo.text = card.name;
		}

	}


	public void RemoveExtraInfo() {
		if (extraInfo != null) {
			extraInfo.text = "";
			nameInfo.text = "";
		}

	}


	public void OnMouseExit() {

		//Global.me.RemoveCardInfo ();
		count = 0;
		hovering = false;
		TextMeshController text = game.extraCardInfo.GetComponent<TextMeshController> ();

		if (text.hovering)
			text.counter = 0;
		
		if (!game.cardCurrentlySelected)
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
			friendlyOrbInfo.text = card.name + "\n" + card.damage + "D " + card.health + "H" + "\n";
		}

		if (!isTextDisplayed && card.isEnemyCard) {
			enemyOrbInfo.color = new Color (.2f, .2f, .9f, .6f);
			enemyOrbInfo.text = card.name + "\n" + card.damage + "D " + card.health + "H" + "\n";
		}
			
	}



	public void RemoveCardInfo() {

		friendlyOrbInfo.text = "";
		isTextDisplayed = false;

	}

	public void Wisp() {

		wispTemp = Instantiate (wisp, this.transform.position, Quaternion.identity);

		ParticleSystem wispParticle = wispTemp.GetComponent<ParticleSystem> ();
		WispParticleController particleController = wispTemp.GetComponent<WispParticleController> ();

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

		if (!hovering)
			Orbit ();

		if (card.dead) {
			//Destroy (selectedText);
			Instantiate (explosion, this.transform.position, Quaternion.identity);

			if (!card.isEnemyCard) { game.AnimateText ("\nfriendly " + card.name + " has died!", game.battleInfo); }
			 
			if (card.isEnemyCard) { game.AnimateText ("\nenemy " + card.name + " has died!", game.battleInfo); }

			Destroy (this.gameObject);

			if (!card.isEnemyCard)
				game.cardSelected = null; game.cardCurrentlySelected = false;
 
			if (card.isEnemyCard)
				game.enemySelected = null; game.enemyCurrentlySelected = false;
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
