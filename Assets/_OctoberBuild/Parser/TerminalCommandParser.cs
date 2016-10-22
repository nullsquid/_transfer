using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TransferInput;
public class TerminalCommandParser : MonoBehaviour {

	#region Instance Variable
    public static TerminalCommandParser instance;
	#endregion

	#region Private Data Variables
    string _terminalCommand;
    string _rawCommand;
    string _newText;
	//if this is public, it is for testing purposes
	//public string [] _commandArgs;
	public List<string> _commandArgs = new List<string>();
	string _text;
	#endregion

	#region Private References
    UIMainInput uiInput;
	#endregion

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        if(instance != this)
        {
            Destroy(gameObject);
        }
			

        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        InputController.OnReturnPressed += CaptureCommand;
    }

    void OnDisable()
    {
        InputController.OnReturnPressed -= CaptureCommand;
    }

	void Update(){
		if (uiInput == null) {
			uiInput = GameObject.Find ("MainInput").GetComponent<UIMainInput> ();
		}
		Debug.Log (uiInput);

		if (uiInput != null) {
			_rawCommand = uiInput.ReturnText;
			Debug.Log (_rawCommand);
		}




	}

    void CaptureCommand()
    {
		//ideally I would like this to come from InputController
		ParseCommand(_rawCommand);




    }

	void ParseCommand(string commandToParse){
		/*
		char[] delimiterChars = {' '};

		_text = commandToParse;
		Debug.Log(_text);
		if (_text != null) {
			Debug.Log (_text);
			string[] _commandArgs = _text.Split (delimiterChars);
			foreach (string s in _commandArgs) {
				Debug.Log (s);
			}
		}
		*/
		string word = "";
		for (int i = 0; i < commandToParse.Length; i++) {
			if (commandToParse [i] == ' ') {
				word.TrimEnd ();
				_commandArgs.Add (word);
				word = "";
			} 
			else {
				word += commandToParse [i];
			}

		}

		/*foreach (string s in _commandArgs) {
			Debug.Log (s);
		}*/

		
	}



}
