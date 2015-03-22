using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum commandState{
	idle,
	help,
	connect,
	find,
	search,
	clear,

};
public class InputManager : MonoBehaviour{

	public string commandParam;
	public Character character;
	public InputField field;
	public Text inputText;
	public TextManager textManager;
	public Canvas canvas;
	public float padding = 5.0f;
	public commandState state = new commandState();
	void Awake(){

	}
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		field.ActivateInputField();
		//inputText.rectTransform.position = field.transform.position;
		//inputText.text = ">>";
		state = commandState.idle;

	}
	
	// Update is called once per frame
	void Update () {
		if(!field.isFocused) {
			field.ActivateInputField();
		}
		//Debug.Log (character.charName);
		switch(state){
		case commandState.help:
			HelpState();
			break;
		default:
			break;
		}
	

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
		textManager.displayText.text = "";

	}

	public void HelpState(){

		


	}

	public void ConnectState(string connection){

	}
}
