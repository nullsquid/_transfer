using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputCapture : MonoBehaviour {
	[SerializeField]
	private InputField commandInputField = null;
	
	
	// Use this for initialization
	void Start () {
		InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
		submitEvent.AddListener(SubmitCommand);
		commandInputField.onEndEdit = submitEvent;
	}

	void Update(){

	}

	private void SubmitCommand(string command)
	{
		switch(command){
		case "help":
			Debug.Log("Help");
			break;
		case "search":
			Debug.Log ("Search");
			break;
		case "connect":
			Debug.Log("connect");
			break;
		default:
			Debug.Log("nope");
			break;
		}
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
