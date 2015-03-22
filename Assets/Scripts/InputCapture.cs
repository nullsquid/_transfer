using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum commandState{
	idle,
	help,
	connect,
	find,
	search,
    clear
    
};

public class InputCapture : MonoBehaviour {
	[SerializeField]
	private InputField commandInputField = null;
	public commandState state = new commandState();
	public string rawCommand;
	//put the base command in the command variable
	public string command;

	// Use this for initialization
	void Start () {
		InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
		submitEvent.AddListener(SubmitCommand);
		commandInputField.onEndEdit = submitEvent;

	}

	private void SubmitCommand(string command)
	{
		//Debug.Log(command);

		/*switch(command){
		case "help":
			Debug.Log("Help");
			state = commandState.help;
			break;
		case "search":
			Debug.Log ("Search");
			state = commandState.search;
			break;
		case "connect":
			Debug.Log("connect");
			state = commandState.connect;
			break;
		default:
			Debug.Log("nope");
			break;
		}
		//Debug.Log(state);
		*/
		rawCommand = command;
		Debug.Log(rawCommand);
	}
	
	#region command methods
	void ComConnect(string name){
		
	}
	
	void ComSearch(){
		
	}
	
	void ComHelp(string moreInfo){
		
	}
	
	void ComRun(){
		
	}
	
	void ComPackage(){
		//this is probably run also
		//maybe lets you see what packages you have
	}
	//methods for file system//hierarchy
	#endregion
}
