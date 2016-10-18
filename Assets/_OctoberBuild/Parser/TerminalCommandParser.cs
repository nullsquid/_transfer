using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TransferInput;
public class TerminalCommandParser : MonoBehaviour {

    string _terminalCommand;
    List<string> _commandArgs = new List<string>();

    InputController input;

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

        
    }
    
}
