using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplayNew : MonoBehaviour {

	//	public TextMesh nameMesh;
	//	public TextMesh damageMesh;
	//	public TextMesh healthMesh;
	public CardGameRunner game;


	public SpriteRenderer sprite;
	//Vector2 originalPos;
	public Card card;			
	public Screenshake cam;
	public float count = 0;
	public bool hovering = false;
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
		count += 0.35f;
		//Debug.Log ("HOVERING " + card.name);
		Global.me.DisplayCardInfo (card);
		cam.SetScreenshake (.005f * count, .1f);

		// instantiate a new alert thingy based on this cards class

	}


	public void OnMouseExit() {

		hovering = false;
		Global.me.RemoveCardInfo ();
		count = 0;
		// delete the alert
		
	}



	public void OnMouseDown() {

		game.CardClicked (card, this.transform.position);

		if (!card.isEnemyCard){
			
		Debug.Log (card.name + " CLICKED");
		game.ChangePlayer (card);
		// change player to a different color
		// shoot out particles and stuff

		}
	}





	// Update is called once per frame
	void Update () {

		if (!card.isEnemyCard && !hovering)
			Orbit ();

		if (card.dead) {
			Destroy (this.gameObject);

		}

	}
}
