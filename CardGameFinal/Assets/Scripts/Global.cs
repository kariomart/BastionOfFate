using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// godbless you connor lofdahl for making me some sweet tunes.

public class Global : MonoBehaviourSingleton <Global> {


	public static Global me;
	public List<Card> inventory;
	public List<Card> hand;
	public List<Card> cards;
	public List<Card> enemiesTransfer = new List<Card>();

	public List<string> abilities = new List<string> ();
	public int CardsInPlay;
	public TextMesh console;
	public bool inCardGame = false;
	public bool isCardCurrentlyDisplayed = false;
	public GameObject cardCurrentlyDisplayed;
	public GameObject enemyBattled;

	public GameObject cardGameRunner; 
	public CardGameRunner game;
	public GameObject overworld;


	string a1 = "this ability wins ties";
	string a2 = "this ability reduces enemy roll by 1";
	string a3 = "this ability heals friendlies each turn";
	string a4 = "this card deals double damage but also takes double damage";

	public GameObject chest;
	public GameObject battleChest;
	public GameObject wall;
	public GameObject apple;
	public GameObject player;
	public GameObject cardInfo;
	public GameObject cardGamePlayer;
	public GameObject particleObject;
	public GameObject wispParticle;
	public Camera playerCam;
	public Camera cardCam;
	public Screenshake screenshaker;
	public AudioClip bam;

	public AudioSource backgroundMusic;
	public AudioClip overworldMusic;
	public AudioClip battleMusic;


	public Global Get() {
		if (me == null) {
			me = (Global)FindObjectOfType(typeof(Global));
		}

		return me;
	}
		

	public void CurrentBattle(List<Card> enemiesInvolved) {
		enemiesTransfer = enemiesInvolved;

	}

	public Card GetRandomCard() {
		int i = Random.Range (0, cards.Count);

		if (i == 0)
			return new Ape ();
		else if (i == 1)
			return new Armadillo ();
		else if (i == 2)
			return new Blackjack ();
		else if (i == 3)
			return new Cat ();
		else if (i == 4)
			return new Clown ();
		else if (i == 5)
			return new Gabe ();
		else if (i == 6)
			return new Gambler ();
		else if (i == 7)
			return new General ();
		else if (i == 8)
			return new Joker ();
		else if (i == 9)
			return new Magikarp ();
		else if (i == 10)
			return new Martyr ();
		else if (i == 11)
			return new Paladin ();
		else if (i == 12)
			return new Phoenix ();
		else if (i == 13)
			return new Sniper ();
		else if (i == 14)
			return new Zombie ();
		else if (i == 15)
			return new Priest ();

		 else
			return new Card ();




	}

	void Awake() {
		Debug.Log ("GLOBAL AWAKE");
//		Debug.Log ("PLAYER HEALTH: " + playerHealth);
//		Debug.Log (overworldMusic);
//		Debug.Log (battleMusic);
//		Debug.Log (SoundController.me);
		//SoundController.me.PlaySound (overworldMusic, 2f);

		CheckWinCondition ();

		// Application.LoadLevel (Application.loadedLevel);


		if (me != null)
			Destroy (gameObject);

		Get ();

		DontDestroyOnLoad(transform.gameObject);

		//chest = GameObject.Find ("soul");
		battleChest = GameObject.Find ("enemy");
		wall = GameObject.Find ("wall");
		apple = GameObject.Find ("apple");
		player = GameObject.Find ("Player");
		cardGamePlayer = GameObject.Find ("CardGamePlayer");
		game = cardGameRunner.GetComponent<CardGameRunner> ();

		GameObject p = player.transform.GetChild (0).gameObject;
		playerCam = p.GetComponent<Camera> ();
		screenshaker = cardCam.GetComponent<Screenshake> ();


		//GameObject c = GameObject.Find ("CardCamera");
		// cardCam = c.GetComponent<Camera> ();


		// cardGameRunner = GameObject.Find ("CardGame");
		// overworld = GameObject.Find ("overworld");


		cards = new List<Card> ();
		inventory = new List<Card> ();
		hand = new List<Card> ();

		cards.Add (new Ape());
		cards.Add (new Armadillo());
		cards.Add (new Blackjack());
		cards.Add (new Cat ());
		cards.Add (new Clown ());
		cards.Add (new Gabe ());
		cards.Add (new Gambler ());
		cards.Add (new General ());
		cards.Add (new Joker ());
		cards.Add (new Magikarp ());
		cards.Add (new Martyr ());
		cards.Add (new Paladin ());
		cards.Add (new Phoenix ());
		cards.Add (new Sniper ());
		cards.Add (new Zombie ());
		cards.Add (new Priest ());



		abilities.Add (a1);
		abilities.Add (a2);
		abilities.Add (a3);
		abilities.Add (a4);

		//GenerateOverworld ();
		GiveDefaultCards ();


	}


	public void CheckWinCondition () {
		



	}

	public void GiveDefaultCards() 

	{
		for(int i = 0; i < 5; i ++)
		{
			Card c = GetRandomCard ();
			inventory.Add (c);
		}
	}


	public void RunCardGame() {
		Debug.Log ("CARD GAME RUNNING");
		backgroundMusic.Pause ();
		backgroundMusic.clip = battleMusic;
		backgroundMusic.Play ();
		// Debug.Log (cardGameRunner);
		playerCam.gameObject.SetActive(false);
		cardCam.gameObject.SetActive(true);
		cardGameRunner.SetActive (true);
		inCardGame = true;
		//overworld.gameObject.SetActive (false);

	}

	public void PlayParticleEffect(Vector2 destination, Color color) {

		SoundController.me.PlaySound (bam, 10f);
		GameObject partObj = Instantiate (particleObject, cardGamePlayer.transform.position, Quaternion.identity);
		ParticleSystem particle = partObj.GetComponent<ParticleSystem> ();
		ParticleController particleController = partObj.GetComponent<ParticleController> ();
		ParticleSystem.MainModule settings = particle.GetComponent<ParticleSystem>().main;
		settings.startColor = new ParticleSystem.MinMaxGradient( color );
	

		particle.Play ();
		particleController.StartLerping (destination);
	}

	public void PlayParticleEffect(Vector2 origin, Vector2 destination, Color color) {

		SoundController.me.PlaySound (bam, 10f);
		GameObject partObj = Instantiate (particleObject, origin, Quaternion.identity);
		ParticleSystem particle = partObj.GetComponent<ParticleSystem> ();
		ParticleController particleController = partObj.GetComponent<ParticleController> ();
		ParticleSystem.MainModule settings = particle.GetComponent<ParticleSystem>().main;
		settings.startColor = new ParticleSystem.MinMaxGradient( color );


		particle.Play ();
		particleController.StartLerping (destination);
	}

	public void PlayParticleEffect(GameObject particleSystem, Vector2 destination, Color color) {

		//SoundController.me.PlaySound (bam, 10f);
		GameObject partObj = Instantiate (particleSystem, cardGamePlayer.transform.position, Quaternion.identity);
		ParticleSystem particle = partObj.GetComponent<ParticleSystem> ();
		ParticleController particleController = partObj.GetComponent<ParticleController> ();
		ParticleSystem.MainModule settings = particle.GetComponent<ParticleSystem>().main;
		settings.startColor = new ParticleSystem.MinMaxGradient(color);


		particle.Play ();
		particleController.StartLerping (destination);
	}




	public void ShakeScreen (float magnitude, float duration) {

		screenshaker.SetScreenshake (magnitude, duration);
	}


	public void DoStuffAfterParticleLands () {
		ShakeScreen (Random.Range(1f, 4f), .25f);



	}


	public void DisplayCardInfo(Card card) {

		if (!isCardCurrentlyDisplayed) {
			
			GameObject display = Instantiate (cardInfo, new Vector3 (45, 2, 0), Quaternion.identity);
			TextMesh name = display.transform.FindChild ("name").GetComponent<TextMesh> ();
			//textMesh name = n.GetComponent<TextMesh> ();

			TextMesh health = display.transform.FindChild ("health").GetComponent<TextMesh> ();
			//textMesh health = h.GetComponent<TextMesh> ();

			TextMesh description = display.transform.FindChild ("description").GetComponent<TextMesh> ();
			//textMesh description = d.GetComponent<TextMesh> ();

			name.text = card.name;
			health.text = "" + card.health;
			description.text = card.description;
			isCardCurrentlyDisplayed = true;
			cardCurrentlyDisplayed = display;

		}
	}


	public void RemoveCardInfo() {

		Destroy (cardCurrentlyDisplayed);
		isCardCurrentlyDisplayed = false;

	}
		

	// Use this for initialization
	void Start () {
		//SoundController.me.PlaySound (overworldMusic, 2f);
		backgroundMusic.clip = overworldMusic;
		backgroundMusic.Play ();
	}
		

	
	// Update is called once per frame
	void Update () {


	}
}
