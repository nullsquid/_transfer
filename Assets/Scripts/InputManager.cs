using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*public enum commandState{
	idle,
	help,
	connect,
	find,
	search,
	clear,

};*/
public class InputManager : MonoBehaviour{

	public CharacterMananger cManager;
	public PlayerCharacter player;
	public string commandParam;
	public Character character;
	public InputField field;
	public Text inputText;
	public TextManager textManager;
	public Canvas canvas;
	public float padding = 5.0f;
	public InputCapture input;
	public string newCommand;


	//public 

	//public commandState state = new commandState();

	// Use this for initialization
	void Start () {

		//during runtime, add optional parameters to list and then check
		//to see if the parameter can do anything

	}
	
	// Update is called once per frame
	void Update () {
		newCommand = input.commandWithoutParam;
		HandleInput(newCommand);

	}

	public void HandleInput(string command){
		switch(command){
		case "help":
			Debug.Log("Helping");
			break;
		case "connect":
			Debug.Log ("Connected");
			if(input.newParameters.Count == 0){
				Debug.Log ("cannot comply");
			}
			else if(player.KnownCharacters.ContainsKey(input.newParameters[0])){
				Debug.Log ("it's MEMM!");
			}
			else{
				Debug.Log("It's not MEMM :( ");
			}
			break;
		}
	}





	public void IdleState(){
		//textManager.displayText.text = "";

	}

	public void HelpState(){

		


	}

	public void ConnectState(string connection){

	}
}
