using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Transfer.Input;
using Transfer.Data;
namespace Transfer.System
{
    public class TerminalCommandParser : MonoBehaviour
    {



        #region Private Data Variables
        string _terminalCommand;
        string _rawCommand;
        string _newText;
        List<string> _commandArgs = new List<string>();
        string _text;
        #endregion

        #region Public Accessors
        /*public string RootCommand
        {
            get
            {
                return _commandArgs[0];
            }
        }*/
        #endregion

        #region Private References
        UIMainInput uiInput;
        TerminalCommandWrapper wrapper;
        #endregion
        
        #region Unity Callbacks

        void OnEnable()
        {
            Transfer.System.EventManager.StartListening("ProcessCommand", ProcessCommandWrapper);
        }

        void OnDisable()
        {
            Transfer.System.EventManager.StopListening("ProcessCommand", ProcessCommandWrapper);
        }

        void Update()
        {
            if (uiInput == null)
            {
                //ideally I would like this to come from InputController
                uiInput = GameObject.Find("MainInput").GetComponent<UIMainInput>();
            }

            if(wrapper == null)
            {
                wrapper = new TerminalCommandWrapper();
            }


        }
        #endregion

        #region Main Methods

        IEnumerator ProcessCommand()
        {
            yield return new WaitForFixedUpdate();
            _commandArgs.Clear();
            _rawCommand = uiInput.ReturnText;
            ParseCommand(_rawCommand);



        }

        void ParseCommand(string commandToParse)
        {

            string word = "";
            for (int i = 0; i < commandToParse.Length; i++)
            {
                if (commandToParse[i] == ' ')
                {
                    word.TrimEnd();

                    _commandArgs.Add(word);
                    word = "";
                    
                }
                else
                {
                    word += commandToParse[i];
                }
            }
            SearchCommand();

        }

        void SearchCommand()
        {
            switch (_commandArgs[0])
            {
                
                case "CONNECT":
                    Debug.Log("args from Connect" + _commandArgs.Count);
                    if (_commandArgs.Count > 1)
                    {
                        //search based on _commandArgs

                        wrapper.Connect(_commandArgs[1]);
                    }
                    break;
                case "SCAN":
                    if(_commandArgs.Count > 1)
                    {
                        
                        wrapper.Scan(_commandArgs[1]);
                    }
                    break;
                case "HELP":
                    Debug.Log(_commandArgs.Count);
                    switch (_commandArgs.Count)
                    {
                        case 1:
                            wrapper.Help("DEFAULT");
                            break;
                        case 2:
                            switch (_commandArgs[1])
                            {
                                
                                case "CONNECT":
                                    Debug.Log("command args " + _commandArgs.Count);
                                    wrapper.Help("CONNECT");
                                    break;
                                case "SCAN":
                                    wrapper.Help("SCAN");
                                    break;
                                case "RUN":
                                    wrapper.Help("RUN");
                                    break;
                            }
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                            
                    
                    break;
                    
                case "EXIT":
                    
                        Debug.Log("exit");
                        wrapper.Exit();
                    
                    break;

            }
        }
        #endregion

        #region Utility Methods
        void ProcessCommandWrapper()
        {
            StartCoroutine(ProcessCommand());
        }
        #endregion



    }
}
