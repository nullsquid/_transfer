using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TransferInput;
public class TerminalCommandParser : MonoBehaviour {

    public static TerminalCommandParser instance;

    string _terminalCommand;
    string _rawCommand;
    string _newText;
    List<string> _commandArgs = new List<string>();

    InputController inputC;
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

        if (inputC == null)
        {
            inputC = new InputController();
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

        /*
        else
        {
            
            _newText = input.ReturnText;
            Debug.Log("converted new text is " + _newText);
        }*/
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
        
        Debug.Log("test 1: " + inputC.ReturnText);
        
    }

    //ISSUE::this isn't gettin the proper data from InputController
    void CaptureCommand()
    {
        
        //_rawCommand = input.ReturnText;
        //_rawCommand = _newText;
        //Debug.Log("event invoked");
        //Debug.Log("Raw text is " + input.ReturnText);

        //Debug.Log("command is " + uiInput.newText);
    }



}
