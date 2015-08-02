using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;
public class InputManager : MonoBehaviour{


	public CharacterMananger cManager;
	public PlayerCharacter player;
	//public string commandParam;
	public Character character;
	public InputField field;
	public Text inputText;
	public TextManager textManager;
	//public Canvas canvas;
	//public float padding = 5.0f;
	public InputCapture input;
	public string newCommand;
	public Directory dirPrefab;
	public bool canWriteCommand = true;
	//public GameObject connectionInterface;
	//public GameObject normalInterface;
	//HACK
	public TreeTraversal traversal;




	//bool connectionInterfaceExists = false;


	//public 

	//public commandState state = new commandState();

	// Use this for initialization
	IEnumerator InputBuffer(){
		if(!canWriteCommand){
			yield return new WaitForSeconds(2f);
			canWriteCommand = true;
		}
	}
	void Start(){
		//StartCoroutine("HandleInput", input.commandWithoutParam);
	}
	
	//need to set these variables at runtime
	// Update is called once per frame
	void Update () {
		newCommand = input.commandWithoutParam;
		//HandleInput(newCommand);
		//HACK
		if(Input.GetKeyUp(KeyCode.Return)){
			StartCoroutine("HandleInput",newCommand);
			//HandleInput(newCommand);

		}
		if(player == null){
			player = cManager.charPlayer;
		}
		//Debug.Log(input.commandWithoutParam);


	}



	public IEnumerator HandleInput(string command){
		//yield return new WaitForSeconds(0.1f);
		yield return null;
		//canWriteCommand = true;
		//yield return null;
		Debug.Log("input");
		//Debug.Log(command);
		switch(command){
		case "0":
			int newCommandResponse;
			if(Int32.TryParse(command, out newCommandResponse)){
				traversal.NodeChange(traversal.curTree, newCommandResponse);
			}

			break;
		case "HELP":
			Debug.Log("Helping");
			break;
		case "CONNECT":
			Debug.Log ("Connected");
			if(input.newParameters.Count == 0){
				Debug.Log ("cannot comply");
			}
			else if(input.newParameters[0] == "EXIT"){
				EventManager.TriggerEvent("exitConnected");
			}
			//else if (player.KnownCharacters.
			else if(player.KnownCharacters.ContainsKey(input.newParameters[0])){

				Debug.Log (player.KnownCharacters[input.newParameters[0]]);
				//TODO should probably actually decouple this and send a message to another object that controls the interface
				//rather than having everything up in here
				Debug.Log ("it's MEMM!");
				//textManager.displayText.text = "It's MEMM!";

				EventManager.TriggerEvent("connected");

				

				//newText = Instantiate(textManager.displayText, textManager.canvas.transform.position, transform.rotation) as GameObject;
				//newText.transform.parent = textManager.canvas.transform;

				//cManager.SendMessage("Connect");
			}
			else{
				Debug.Log("It's not MEMM :( ");
				Debug.Log(input.newParameters[0]);
			}
			break;
		case "MAKE": 
			//int directoryCount;
			//int newDirectoryCount;
			Debug.Log("Making");
			if(input.newParameters.Count == 0){
				Debug.Log ("requires parameter: cannot comply");
			}
			else if (input.newParameters[0] == "DIR"){

				MakingState(input.newParameters[0]);

			}
			break;
			//TODO make this convert string ToInt and then do the opperations on them
		case "CALC":
			if(input.newParameters.Count == 0){
				Debug.Log ("requires parameter: cannot comply");
			}
			//else if do math stuff
			break;
		}

		//yield return null;

	}





	public void IdleState(){
		//textManager.displayText.text = "";
		canWriteCommand = true;

	}

	public void HelpState(){

		


	}

	public void ConnectState(string connection){

	}



	public void MakingState(string newObject){
	//	canWriteCommand = true;
		if(newObject == "dir"){
		//	int dirCount = 0;
		//	int newDirCount = 0;
			if(canWriteCommand){
				Directory newDir = Instantiate(dirPrefab, transform.position, transform.rotation) as Directory;
				newDir.transform.parent = player.transform;
				canWriteCommand = false;
			}
		
		
		}
	}

	public int Response(int numOfResponse){

		return 0;
	}
}
