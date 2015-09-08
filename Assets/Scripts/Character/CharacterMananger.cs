using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
//TODO: add more specific control for who a player can be (for the prototype)
//TODO: Get functionality out of start and into its own function(s) :: modularize and genericize if possible
//TODO: restructure how i find player => return a string rather than an index integer? So that i can control what characters come out
public class CharacterMananger : MonoBehaviour {
	private static CharacterMananger _instance;

	public static CharacterMananger Instance{
		get{
			if(_instance == null){
				_instance = GameObject.FindObjectOfType<CharacterMananger>();
			}
			return _instance;
		}
	}

	public void GetCharacters(){

	}

	private void GetCharacterNames(){

	}

	private void GetCharacterGenders(){

	}
	/*

	public Init init;
	public TextManager textM;
	public InputManager inputM;
	public string[] possiblePlayers = new string[10];
	public Character[] characters = new Character[10];
	//public booleans
	public bool isLive;
	//public Character character;
	public int setPlayerIndex;
	public Character characterPrefab;
	public PlayerCharacter pcPrefab;
	public PlayerCharacter charPlayer;
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
	

	int playerIndex;

	private UnityAction sendCharacterListener;

	void Awake () {//switch back to start if this doesn't work

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

		//HACK need to modify for full version
		if(isLive){
			int shortPlayerIndex;
			shortPlayerIndex = Random.Range(0, 4);
			Debug.Log(shortPlayerIndex);
			switch(shortPlayerIndex){
			case 0:
				playerIndex = 0;
				break;
			case 1:
				playerIndex = 4;
				break;
			case 2:
				playerIndex = 8;
				break;
			case 3:
				playerIndex = 9;
				break;
		
			}
			//playerIndex = Random.Range (0, characters.Length);
		}
		else if (!isLive){
			playerIndex = setPlayerIndex;
		}

		string[] names = new string[10]{nameA, nameB, nameC, nameD, nameE, nameF, nameG, nameH, nameI, name0};
		string[] genders = new string[10]{genderA, genderB, genderC, genderD, genderE, genderF, genderG, genderH, genderI, gender0};
		string[] identifiers = new string[10]{"A", "B", "C", "D", "E", "F", "G", "H", "I", "0"};


		Character newCharacter = characterPrefab;


		for(int i = 0; i <= (characters.Length - 1); i++){

			if(i != playerIndex){
				characters[i] = Instantiate(characterPrefab, transform.position, transform.rotation) as Character;
				characters[i].isPlayer = false;
				characters[i].charName = names[i];
				characters[i].gender = genders[i];
				characters[i].charID = identifiers[i];
				characters[i].pronoun = init.pronouns[newCharacter.charID];
				characters[i].name = identifiers[i];
				characters[i].transform.parent = transform;
			}
			else if(i == playerIndex){
				characters[i] = Instantiate(pcPrefab, transform.position, transform.rotation) as PlayerCharacter;
				characters[i].isPlayer = true;
				characters[i].charName = names[i];
				characters[i].gender = genders[i];
				characters[i].charID = identifiers[i];
				characters[i].pronoun = init.pronouns[newCharacter.charID];
				characters[i].name = identifiers[i];
				characters[i].transform.parent = transform;
				textM.playerName = characters[i].charName;
				charPlayer = characters[i] as PlayerCharacter;
				Debug.Log(charPlayer);
			}


		}
	

	}




	public string FindGender(string character){
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

	private string CreateCharacters(string[] thePlayers){

		return null;
	}

*/

}
