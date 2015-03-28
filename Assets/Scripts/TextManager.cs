using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public TextAsset curText;
	public Text displayHeader;
	public Text displayText;
	public InputManager input;
	public string playerName;
	public CharacterMananger character;

	//IEnumerator TextDisplay(){

	//}
	// Use this for initialization
	void Start () {
		//ISSUE:: Find player name; set player name

		//playerName = 
		//playerName = character.charName;
	}
	
	// Update is called once per frame
	void Update () {
		displayHeader.text = "CURRENTLY LOGGED IN AS " + playerName + ">>\n \nINPUT COMMAND OR TYPE 'HELP' FOR MORE OPTIONS>>";
		/*if(input.newCommand == "help"){
			Instantiate(displayText, displayHeader.transform.position - new Vector3(0, 100, 0), transform.rotation);
			displayText.text = "let me help you";
		}*/
	}


}
