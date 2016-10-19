using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TransferInput;
public class TerminalCommandParser : MonoBehaviour {

    string _terminalCommand;
    List<string> _commandArgs = new List<string>();

    InputController input;
    //might need to seperate the data being submitted from the keys being pressed?
    //not sure how
    void Awake()
    {
        
    }

    void Update()
    {
        if (input == null)
        {
            input = new InputController();
            Debug.Log(input);

        }
        for(int i = 0; i < input.commands.Count; i++)
        {
            Debug.Log("commands are " + input.commands[i]);
        }
        if (input.commands.Count > 0) {
            
            Debug.Log(input.CommandRoot);
        }

        
    }
    
}
