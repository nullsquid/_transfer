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
	public List<string> newParameters = new List<string>();

	//public 

	//public commandState state = new commandState();
	void Awake(){

	}
	// Use this for initialization
	void Start () {
		newParameters.RemoveRange(0, newParameters.Count);
		//during runtime, add optional parameters to list and then check
		//to see if the parameter can do anything
		//CONSIDER:: putting this in InputCapture
	}
	
	// Update is called once per frame
	void Update () {


	}
	/*public void HandleInput(string command){
		Debug.Log(command);
	}*/
	/*public void OnSubmit(string command){
		//command.Replace("\n", "");
		string newCommand = command.Replace ("\r", "").Replace("\n", ""); 
		if(newCommand == "help"){
			state = commandState.help;
			Debug.Log("is helping");
		}
		else if (newCommand == "connect "){
			Debug.Log ("is connected");
		}
		else if (newCommand == "clear"){
			state = commandState.idle;

		}
		else{
			//this is to catch and better give info for commands that require parameters/things that players can forget, etc.
			switch(newCommand){
			case "connect":
				Debug.Log("cannot complete request--connect command takes one parameter");
            	break;
            default:
				Debug.Log("command not recognized");
            	break;
			}

		}
		Debug.Log(newCommand);


	}*/





	public void IdleState(){
		//textManager.displayText.text = "";

	}

	public void HelpState(){

		


	}

	public void ConnectState(string connection){

	}
}
