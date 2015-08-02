using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class InputCapture : MonoBehaviour {
	[SerializeField]
	private InputField commandInputField = null;
	//public commandState state = new commandState();
	//public string rawCommand;
	//put the base command in the commandWithoutParam variable
	public string commandWithoutParam;
	public string newCommand;
	public List<string> newParameters = new List<string>();

	void OnEnable(){

	}

	void OnDisable(){

	}

	void OnAwake(){

	}
	// Use this for initialization
	void Start () {
		InputField.OnChangeEvent changeEvent = new InputField.OnChangeEvent();
		InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
		submitEvent.AddListener(SubmitCommand);
		//changeEvent.AddListener(UpdateText);
		commandInputField.onEndEdit = submitEvent;


		//newParameters.RemoveRange(0, newParameters.Count);

	}
	void Update(){
		//InputField.OnChangeEvent()
		commandInputField.text = commandInputField.text.ToUpper();

	}
	void UpdateText(){

	}
	private void SubmitCommand(string command)
	{

		newParameters.Clear();
		string[] fields;

		newCommand = command;

		char[] delimeter = {' '};
		fields = newCommand.Split(delimeter);

		commandWithoutParam = fields[0];
		//if(fields.Length > 1){
			for(int i = 1; i <= fields.Length - 1; i++){
		
				//Debug.Log(i);
				
				newParameters.Add(fields[i]);

			}
			//fields[0].Remove();

		//}

		//commandInputField.text = null;
		commandInputField.text = "";
		this.commandInputField.ActivateInputField();


	}
	//void Update(){
		//commandInputField.text.ToUpper();
	//}
	//i think that this whole region is going to go into input manager

	#region command methods
	void ComConnect(string name){
		
	}
	
	void ComSearch(){
		
	}
	
	void ComHelp(string moreInfo){
		
	}
	
	void ComRun(){
		
	}

	void ComSave(){

	}

	
	void ComPackage(){
		//this is probably run also
		//maybe lets you see what packages you have
	}
	//methods for file system//hierarchy
	#endregion

}
