using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;
public class InputManager : MonoBehaviour{
    private Queue<char> inputBuffer = new Queue<char>();
    private char _inputString;
    public string _newString;
    private bool _canType;
    private bool _canReturn;
    private int _curIndex;
    private int _curChar;
    public List<char> Text = new List<char>();
    public char InputString {
        get {
            return _inputString;
        }
        set {
            _inputString = value;
        }

    }
    public string NewString {
        get {
            return _newString;
        }
        set {
            _newString = value;
        }
    }
    
    void Update() {

        //TODO ALL OF THIS NEEDS TO BE OPTIMIZED
        //So many loops and calls and coroutines ugh
        if (Input.inputString == "\b") {
            NewString = "";
            if (Text.Count > 0) {
                StartCoroutine("DirtyRemove");
                StartCoroutine("UpdateString");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return)) {
            //will probably be a coroutine
            ReturnPressEvent();
            StartCoroutine("UpdateString");
        }
        else {
            NewString = "";
            StartCoroutine("DirtyInput");
            StartCoroutine("UpdateString");
       }
        



        //}


    }
    IEnumerator UpdateString() {
        // while (Text.Count != 0) {
        //NewString = "";
        for (int i = 0; i < Text.Count; i++) {
            //this routine has to fire after all the other ones go
            NewString += Text[i];
            Debug.Log(NewString);
            //yield return new WaitForEndOfFrame();
            yield return null;
           // yield return new WaitForSeconds(.02f);
            


        }
        
    }
    IEnumerator DirtyRemove() {

        foreach(char letter in Text) {
            if(letter == Text[Text.Count - 1]) {
                Text.Remove(letter);
                break;
            }
            yield return new WaitForSeconds(0.002f);
            
        }
     

    }
    IEnumerator DirtyInput() {
        Text.Add(Input.inputString[0]);

        
        yield return new WaitForSeconds(.04f);
    }
    
    
   
    string KeyPressEvent() {
        
        return null;
    }

    string AddTextPressEvent() {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(vKey) != Input.GetKeyDown(KeyCode.Backspace)) {
                inputBuffer.Enqueue(Input.inputString[0]);
            }
        }
        Text.Add(inputBuffer.Dequeue());

        return null;

    }

    string BackspacePressEvent() {
        
        
        char lastChar = Text[Text.Count - 1];
        if (Input.GetKeyDown(KeyCode.Backspace)) {

            for(int i = 0; i < Text.Count; i++) {

                if(Text[i] == lastChar) {

                    Text.RemoveAt(i);
                    Debug.Log(Text[i]);

                }

            }

            
            return NewString;

        }
      
        return null;
    }
    
    void ReturnPressEvent() {
        Text.Clear();
    }
    
    /*
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

	private UnityAction commandEnableListener;
	private UnityAction commandDisableListener;


	void Awake(){
		commandEnableListener = new UnityAction(EnableCommand);
		commandDisableListener = new UnityAction(DisableCommand);
	}
	void OnEnable(){
		EventManager.StartListening("enableCommand", commandEnableListener);
		EventManager.StartListening("disableCommand", commandDisableListener);
	}
	void OnDisable(){
		EventManager.StopListening("enableCommand", commandEnableListener);
		EventManager.StopListening("disableCommand", commandDisableListener);
	}
	//bool connectionInterfaceExists = false;
	public void DisableCommand(){
		canWriteCommand = false;
	}

	public void EnableCommand(){
		//input.enabled = true;
		canWriteCommand = true;
	}

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
			//player = cManager.charPlayer;
		}
		//Debug.Log(input.commandWithoutParam);


	}



	public IEnumerator HandleInput(string command){
		//yield return new WaitForSeconds(0.1f);
		yield return null;
		//canWriteCommand = true;
		//yield return null;
//		Debug.Log("input");
		//Debug.Log(command);
		if(canWriteCommand){
		switch(command){
		case "0":
		case "1":
		case "2":
		case "3":
		case "4":
		case "5":
		case "6":
		case "7":
		case "8":
		case "9":
			int newCommandResponse;
			if(Int32.TryParse(command, out newCommandResponse)){
				traversal.LoadNewNode(traversal.curTree, newCommandResponse);
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
				/*
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
			}*/
            /*
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
    */
}
