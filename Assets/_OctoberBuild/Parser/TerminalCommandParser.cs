﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TransferInput;
public class TerminalCommandParser : MonoBehaviour {

    public static TerminalCommandParser instance;

    string _terminalCommand;
    string _rawCommand;
    string _newText;
    List<string> _commandArgs = new List<string>();

    InputController input;
    UIMainInput uiInput;

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
    //might need to seperate the data being submitted from the keys being pressed?
    //not sure how
    void Update()
    {
        if(input == null)
        {
            input = new InputController();
            Debug.Log(input);
        }
        else
        {
            
            _newText = input.GetInputText();
            Debug.Log("converted new text is " + input._inputText);
        }
        //not getting the uimaininput class?
        /*if (uiInput == null)
        {
            uiInput = new UIMainInput();
            Debug.Log(uiInput);
        }
        if (uiInput != null)
        {
            Debug.Log("The sent new text is " + uiInput.newText);
        }*/
        /*
        if(uiInput == null)
        {
            uiInput = new UIMainInput();
        }
        _newText = uiInput.GetNewText();
        Debug.Log(_newText);
        */
    }
    void CaptureCommand()
    {
        _rawCommand = _newText;
        Debug.Log("event invoked");
        Debug.Log("Raw text is " + _rawCommand);
        //Debug.Log("command is " + uiInput.newText);
    }



}
