using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	public Sprite open;
	public Sprite closed;
	public CardAsset loot;
	List<CardAsset> inventory;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		inventory = Global.me.inventory;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		spriteRenderer.sprite = open;
		inventory.Add (loot);
	}
}
