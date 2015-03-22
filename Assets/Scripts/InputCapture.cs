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
	//public string rawCommand;
	//put the base command in the commandWithoutParam variable
	public string commandWithoutParam;
	public string newCommand;
	public List<string> newParameters = new List<string>();

	// Use this for initialization
	void Start () {
		InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
		submitEvent.AddListener(SubmitCommand);
		commandInputField.onEndEdit = submitEvent;

		newParameters.RemoveRange(0, newParameters.Count);

	}

	private void SubmitCommand(string command)
	{

		string[] fields;

		newCommand = command;

		char[] delimeter = {' '};
		fields = newCommand.Split(delimeter);

		commandWithoutParam = fields[0];
		//if(fields.Length > 1){
			for(int i = 1; i <= fields.Length - 1; i++){
		
				Debug.Log(i);
				
				newParameters.Add(fields[i]);

			}
			//fields[0].Remove();

		//}

		//commandInputField.text = null;
		commandInputField.text = "";



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
	void Update(){
		if(commandInputField.isFocused == false){
			commandInputField.Select();
		}
	}
}
