using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCharacter : Character {
	
	public Character currentlyEngaged;
	//<Character Name, Character ID>; use character manager to find out other info about the character in question
	public Dictionary<string, string> KnownCharacters = new Dictionary<string, string>();
	// Use this for initialization
	void Start () {
		//KnownCharacters.Add
		//KnownCharacters.Add (GetComponentInParent<CharacterMananger>().nameI, GetComponent<Character>().charID);
		KnownCharacters.Add ("MEMM", "I");
		//Debug.Log(KnownCharacters["MEMM"]);

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(KnownCharacters["MEMM"]);

	}
}