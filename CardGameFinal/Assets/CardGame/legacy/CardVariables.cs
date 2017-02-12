using UnityEngine;
using System.Collections.Generic;

public class CardVariables : MonoBehaviour {

	public List<string> Names;
	public List<int> Health;
	public List<int> Tokens;
	int rand;
	public string CardName;
	public int CardHealth;
	public int CardTokens;



	// Use this for initialization
	void Start () {
		rand = Random.Range(0, 3);
		Names.Add ("a");
		Names.Add ("b");
		Names.Add ("c");
		Names.Add ("d");

		Health.Add (1);
		Health.Add (2);
		Health.Add (3);
		Health.Add (4);

		Tokens.Add (2);
		Tokens.Add (2);
		Tokens.Add (2);
		Tokens.Add (2);

		getCharacterStats ();
	}

	void getCharacterStats() {
		CardName = Names [rand];
		CardHealth = Health [rand];
		CardTokens = Tokens [rand];
	}

}


