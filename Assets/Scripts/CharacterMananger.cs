using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMananger : MonoBehaviour {
	public Init init;
	public TextManager textM;
	public Character[] characters = new Character[10];
	//public Character character;
	public Character characterPrefab;
	public PlayerCharacter pcPrefab;
	//public PlayerCharacter pc;

	public string nameA;
	public string nameB;
	public string nameC;
	public string nameD;
	public string nameE;
	public string nameF;
	public string nameG;
	public string nameH;
	public string nameI;
	public string name0;

	public string genderA;
	public string genderB;
	public string genderC;
	public string genderD;
	public string genderE;
	public string genderF;
	public string genderG;
	public string genderH;
	public string genderI;
	public string gender0;



	// Use this for initialization
	void Start () {


		nameA = init.nameA;
		nameB = init.nameB;
		nameC = init.nameC;
		nameD = init.nameD;
		nameE = init.nameE;
		nameF = init.nameF;
		nameG = init.nameG;
		nameH = init.nameH;
		nameI = init.nameI;
		name0 = init.name0;

		genderA = FindGender("A");
		genderB = FindGender("B");
		genderC = FindGender("C");
		genderD = FindGender("D");
		genderE = FindGender("E");
		genderF = FindGender("F");
		genderG = FindGender("G");
		genderH = FindGender("H");
		genderI = FindGender("I");
		gender0 = FindGender("0");


		string[] names = new string[10]{nameA, nameB, nameC, nameD, nameE, nameF, nameG, nameH, nameI, name0};
		string[] genders = new string[10]{genderA, genderB, genderC, genderD, genderE, genderF, genderG, genderH, genderI, gender0};
		string[] identifiers = new string[10]{"A", "B", "C", "D", "E", "F", "G", "H", "I", "0"};
		//Debug.Log ("names is "+names.Length);
		Character newCharacter = characterPrefab;

		for(int i = 0; i <= characters.Length - 1; i++){
			if(init.playerCharacter != newCharacter.charID){
				newCharacter = Instantiate(characterPrefab, transform.position, transform.rotation) as Character;
				newCharacter.isPlayer = false;
				newCharacter.charName = names[i];
				newCharacter.gender = genders[i];
				newCharacter.charID = identifiers[i];
				newCharacter.pronoun = init.pronouns[newCharacter.charID];
				newCharacter.name = identifiers[i];
				newCharacter.transform.parent = transform;
			}
			else if(init.playerCharacter == newCharacter.charID){
				newCharacter = Instantiate(pcPrefab, transform.position, transform.rotation) as PlayerCharacter;
				newCharacter.isPlayer = true;
				newCharacter.charName = names[i];
				newCharacter.gender = genders[i];
				newCharacter.charID = identifiers[i];
				newCharacter.pronoun = init.pronouns[newCharacter.charID];
				newCharacter.name = identifiers[i];
				newCharacter.transform.parent = transform;
				textM.playerName = newCharacter.charName;
			}


			characters[i] = newCharacter;



		}
	

	}

	string FindGender(string character){
		switch(init.pronouns[character]){
		case "he":
			return("male");
		case "she":
			return("female");
		case "they":
			return("ambiguous");
		case "it":
			return("unknown");
		default:
			return (null);
		}
	}

}
