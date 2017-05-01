using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleChest : MonoBehaviour {


	List<Card> cards;
	public List<Card> enemies = new List<Card>();
	public Rigidbody2D rigid;
	public SpriteRenderer sprite;
	int speed = 20;

	// Use this for initialization
	void Start () {
		Global.me.battleChest = this.gameObject;
		cards = Global.me.cards;
		rigid = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();


		for(int i = 0; i < Random.Range(2, 4); i++){
			Card ca = Global.me.GetRandomCard ();
			enemies.Add(ca);
		}
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 force = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
		rigid.AddForce (force);

		int rand = Random.Range (0, 30);

		if (rand == 10) {	
			if (sprite.flipX = true)
				sprite.flipX = false;
			else
				sprite.flipX = true;
		}
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			if (Global.me.inCardGame == false) {
				Global.me.CurrentBattle (enemies);
				Global.me.RunCardGame ();
				Global.me.enemyBattled = this.gameObject;

				//Destroy (this.gameObject);
			}
		}

		// UnityEngine.SceneManagement.SceneManager.LoadScene ("CardGame");
	}
}
