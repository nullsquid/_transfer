using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TransferInput;
public class TerminalCommandParser : MonoBehaviour {

    string _terminalCommand;
    string _rawCommand;
    string _newText;
    List<string> _commandArgs = new List<string>();

    UIMainInput uiInput;

    void OnEnable()
    {
        InputController.OnReturnPressed += CaptureCommand;
    }

    void OnDisable()
    {
        InputController.OnReturnPressed -= CaptureCommand;
    }
    //might need to seperate the data being submitted from the keys being pressed?
    //not sure how

    void CaptureCommand()
    {
        _rawCommand = _newText;
        Debug.Log("event invoked");
        //Debug.Log("command is " + uiInput.newText);
    }

    void Update()
    {
        if(uiInput == null)
        {
            uiInput = new UIMainInput();
        }
        if (uiInput != null)
        {
            //_newText = uiInput.newText;
            _newText = uiInput.GetNewText();
        }
        Debug.Log("new text is " + _newText);

    }

}
