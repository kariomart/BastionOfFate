using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleChest : MonoBehaviour {


	List<Card> cards;
	public List<Card> enemies = new List<Card>();

	// Use this for initialization
	void Start () {
		cards = Global.me.cards;

		for(int i = 0; i < Random.Range(2, 4); i++){
			int rand = Random.Range (0, cards.Count - 1);
			Card ca = new Card (cards [rand]);
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
