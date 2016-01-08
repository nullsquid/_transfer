using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCharacter : Character {
/*<<<<<<< HEAD
    private List<Character> knownCharacters = new List<Character>();
    
    public void AddToList()
    {

    
    }*/
	/*
	public Directory dirPrefab;
	public File filePrefab;
=======
	public Transfer.System.Directory dirPrefab;
	public Transfer.System.File filePrefab;
>>>>>>> 21d4ac06ddc2f6d8fc52faeb1932239001c9bf4e
	public Character currentlyEngaged;
	public CharacterMananger charManager;
	//<Character Name, Character ID>; use character manager to find out other info about the character in question
	public Dictionary<string, string> KnownCharacters = new Dictionary<string, string>();
	// Use this for initialization

	void Start () {

		//KnownCharacters.Add
		//KnownCharacters.Add (GetComponentInParent<CharacterMananger>().nameI, GetComponent<Character>().charID);
		KnownCharacters.Add (GetComponentInParent<CharacterMananger>().nameI, "I");
		//Debug.Log(KnownCharacters["MEMM"]);


		//KnownCharacters.Add ("MEMM", "I");
		charManager = FindObjectOfType<CharacterMananger>();

		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void EncounterOtherCharacter(string name){
		if(!KnownCharacters.ContainsKey(name)){
			for(int i = 0; i <= charManager.characters.Length - 1; i++){
				if(charManager.characters[i].charName == name){
					KnownCharacters.Add(charManager.characters[i].charName, charManager.characters[i].charID);
					charManager.characters[i].hasMetPlayer = true;

				}
			}
		}
		else{
			Debug.Log("Nope");
		}
		Debug.Log(KnownCharacters.Count);

	}
	*/
}
