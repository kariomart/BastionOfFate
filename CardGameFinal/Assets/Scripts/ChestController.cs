using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {

	public SpriteRenderer sprite;
	public Sprite soul;
	public Sprite rubble;
	public Card loot;
	public bool chestOpen = false;
	public bool abilityChosen = false;
	public GameObject notification;
	List<Card> inventory;
	List<Card> cards;
	List<string> abilityStrings;
	GameObject n;
	GameObject player;
	public AudioClip chestOpenSound;
	public Animator anim;
	public ParticleSystem poof;

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find ("Player");
		Global.me.chest = this.gameObject;
		sprite = GetComponent<SpriteRenderer> ();
		inventory = Global.me.inventory;
		cards = Global.me.cards;
		abilityStrings = Global.me.abilities;
		sprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();

		int rand = Random.Range (0, cards.Count - 1);
		loot = Global.me.GetRandomCard ();
//		Debug.Log (loot.name);

		}

	
	// Update is called once per frame
	void Update () {
		if (chestOpen && !abilityChosen) {
			
			if ((Input.GetKeyDown (KeyCode.Alpha1))) {
				Debug.Log ("ability 1 is chosen");
				loot.a1_winsTies = true;
				abilityChosen = true;
				Destroy (n);

			}

			if ((Input.GetKeyDown (KeyCode.Alpha2))) {
				Debug.Log ("ability 2 is chosen");
				loot.a2_reduceRoll = true;
				abilityChosen = true;
				Destroy (n);
			}

			if ((Input.GetKeyDown (KeyCode.Alpha3))) {
				Debug.Log ("ability 3 is chosen");
				loot.a3_heal = true;
				abilityChosen = true;
				Destroy (n);
			}
		
		}

		if (chestOpen && abilityChosen) {

			if (sprite.sprite != rubble) {
				poof.Play();
				anim.Stop ();
				sprite.sprite = rubble;
			}
			
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!chestOpen && other.name == "Player") {
			//spriteRenderer.sprite = open;
			inventory.Add (loot);

			n = Instantiate (notification, new Vector3 (player.transform.position.x, player.transform.position.y, 10), Quaternion.identity);
			GameObject nc = n.transform.GetChild (2).gameObject;
			TextMesh nct = nc.GetComponent<TextMesh> ();
			string a1 = abilityStrings [0];
			string a2 = abilityStrings [1];
			string a3 = abilityStrings [2];
			nct.text = ("You've obtained " + loot.name + "!" + "\n\nWhat ability do you want? These are the options:\n1. " + a1 + "\n2. " + a2 + "\n3. " + a3);

			Debug.Log (SoundController.me);
			SoundController.me.PlaySound (chestOpenSound, 10f);
			chestOpen = true;
		}

	
	
	
	}
			}

