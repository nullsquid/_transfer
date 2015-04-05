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


	//public 

	//public commandState state = new commandState();

	// Use this for initialization
	void Start () {

		//during runtime, add optional parameters to list and then check
		//to see if the parameter can do anything
		//player = cManager.
		//player = cManager.charPlayer;
		//player = FindObjectOfType<PlayerCharacter>();

	}
	//need to set these variables at runtime
	// Update is called once per frame
	void Update () {
		newCommand = input.commandWithoutParam;
		HandleInput(newCommand);
		if(player == null){
			player = cManager.charPlayer;
		}


	}

	public void HandleInput(string command){
		//canWriteCommand = true;
		switch(command){
		case "help":
			Debug.Log("Helping");
			break;
		case "connect":
			Debug.Log ("Connected");
			if(input.newParameters.Count == 0){
				Debug.Log ("cannot comply");
			}
			//else if (player.KnownCharacters.
			else if(player.KnownCharacters.ContainsKey(input.newParameters[0])){

				Debug.Log (player.KnownCharacters[input.newParameters[0]]);

				Debug.Log ("it's MEMM!");
				textManager.displayText.text = "It's MEMM!";

				//newText = Instantiate(textManager.displayText, textManager.canvas.transform.position, transform.rotation) as GameObject;
				//newText.transform.parent = textManager.canvas.transform;

				//cManager.SendMessage("Connect");
			}
			else{
				Debug.Log("It's not MEMM :( ");
				Debug.Log(input.newParameters[0]);
			}
			break;
		case "make": 
			//int directoryCount;
			//int newDirectoryCount;
			Debug.Log("Making");
			if(input.newParameters.Count == 0){
				Debug.Log ("requires parameter: cannot comply");
			}
			else if (input.newParameters[0] == "dir"){
				MakingState(input.newParameters[0]);
			//IdleState();

			}
			break;
		}
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
}
