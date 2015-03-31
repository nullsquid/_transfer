using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCharacter : Character {
	public Directory dirPrefab;
	public File filePrefab;
	public Character currentlyEngaged;
	Directory dirSystem;
	Directory dirApps;
	Directory dirDocuments;
	//<Character Name, Character ID>; use character manager to find out other info about the character in question
	public Dictionary<string, string> KnownCharacters = new Dictionary<string, string>();
	// Use this for initialization

	void Start () {


		//KnownCharacters.Add
		//KnownCharacters.Add (GetComponentInParent<CharacterMananger>().nameI, GetComponent<Character>().charID);
		KnownCharacters.Add ("MEMM", "I");
		Debug.Log("Known characters:"+KnownCharacters.Count);
		//Debug.Log("Yes");

		dirSystem = Instantiate(dirPrefab, transform.position, transform.rotation) as Directory;
		dirDocuments = Instantiate(dirPrefab, transform.position, transform.rotation) as Directory;
		dirApps = Instantiate(dirPrefab, transform.position, transform.rotation) as Directory;
		
		dirSystem.transform.parent = transform;
		dirDocuments.transform.parent = transform;
		dirApps.transform.parent = transform;
		
		dirSystem.name = "System";
		dirDocuments.name = "Documents";
		dirApps.name = "Applications";

		Debug.Log("Yes");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(KnownCharacters["MEMM"]);

	}
}