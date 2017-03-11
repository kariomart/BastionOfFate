using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleChest : MonoBehaviour {


	List<Card> cards;
	public List<Card> enemies = new List<Card>();

	// Use this for initialization
	void Start () {
		Global.me.battleChest = this.gameObject;
		cards = Global.me.cards;

		for(int i = 0; i < Random.Range(2, 4); i++){
			Card ca = Global.me.GetRandomCard ();
			enemies.Add(ca);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Global.me.CurrentBattle (enemies);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("CardGame");
	}
}
