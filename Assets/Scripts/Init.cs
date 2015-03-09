using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Init : MonoBehaviour {

	#region Public Variables
	public string[] allCharacters = new string[]{"A", "B", "C", "D", "E", "F", "G", "H", "I", "0"};
	public string playerCharacter;
	#endregion

	#region Name Replacement Variables
	public string[] consonent = new string[21]{"b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z"};
	public string[] vowel = new string[5]{"a", "e", "i", "o", "u"};


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
	#endregion
	//public int thread;
	public Dictionary <string, string> pronouns = new Dictionary<string, string>();

	// Use this for initialization
	void Start () {
		//Debug.Log(characters[0]);
		playerCharacter = allCharacters[Random.Range(0, allCharacters.Length)];
		Initialization();
		#region pronoun dictionary
		pronouns.Add("A", PronounGen("A"));
		pronouns.Add("B", PronounGen("B"));
		pronouns.Add("C", PronounGen("C"));
		pronouns.Add("D", PronounGen("D"));
		pronouns.Add("E", PronounGen("E"));
		pronouns.Add("F", PronounGen("F"));
		pronouns.Add("G", PronounGen("G"));
		pronouns.Add("H", PronounGen("H"));
		pronouns.Add("I", PronounGen("I"));
		pronouns.Add("0", PronounGen("0"));
		#endregion
		//need to retrieve this data somehow...
		//perhaps through a foreach loop
	
		#region name generation
		nameA = NameGen(0, 3, 0, 1);
		nameB = NameGen(4, 7, 2, 3);
		nameC = NameGen(7, 9, 0, 4);
		nameD = NameGen(10, 14, 3, 4);
		nameE = NameGen(14, 16, 0, 1);
		nameF = NameGen(17, 18, 2, 3);
		nameG = NameGen(8, 14, 4, 5);
		nameH = NameGen(7, 8, 2, 3);
		nameI = NameGen(9, 10, 1, 2);
		name0 = NameGen(0, 20, 0, 4);
		#endregion

	}
	
	#region Set Up

	string PronounGen(string charID){
		int randNum = Random.Range(0, 4);
		//Debug.Log(randNum);
		switch(randNum){
		case 0:
			
			return "he";
			
		case 1:
			
			return "she";
			
		case 2:
			
			return "they";
			
		case 3:
			
			return "it";
		
		case 4:
			return null;
			
		default:
			Debug.LogWarning("Out of range");
			return null;
		}

	}
	void Initialization(){
	//run at the start of the game
	//
		switch(playerCharacter){

		case "A":
			//do something here

			break;
		case "B":
			//do something here
			//
                break;
		case "C":
			//do something here
			//
                break;
		case "D":
			//do something here
			//
                break;
		case "E":
			//do something here
			//
                break;
		case "F":
			//do something here
			//
                break;
		case "G":
			//do something here
			//
                break;
		case "H":
			//do something here
			//
                break;
		case "0":
			//do something here
			//
                break;
            default:
			break;
		}
	}






	string NameGen(int cMin, int cMax, int vMin, int vMax){
		string name;
		name = consonent[Random.Range(cMin, cMax)].ToUpper()+vowel[Random.Range(vMin, vMax)].ToUpper()+consonent[Random.Range(cMin, cMax)].ToUpper()+consonent[Random.Range(cMin, cMax)].ToUpper();
		return name;
	}

	#endregion
	
}
