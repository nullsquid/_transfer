﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace TransferInput
{
    public class InputController
    {
        #region Private Variables
        //private List<string> args = new List<string>();

        private bool canRecordInput = true;
        public string _inputText = "";
        private string returnText;
        public string ReturnText
        {
            get
            {
                return returnText;
            }
            set
            {
                returnText = value;
            }
        }
        #endregion
        //private string wordsInCommand;
        //private List<string> commands = new List<string>();
        //shouldn't be responsible for any parsing
        #region Public Events
        public delegate void ReturnAction();
        public static event ReturnAction OnReturnPressed;
        #endregion
        //need to figure out the architecture for how to link all this together

        public string UpdateInput(Event e)
        {

            if (canRecordInput)
            {
                if (e.keyCode != KeyCode.None)
                {

                    if (e.keyCode >= KeyCode.A && e.keyCode <= KeyCode.Z)
                    {
                        //get only alphabetical characters
                        AddText(e);
                    }
                    else if(e.keyCode == KeyCode.Backspace)
                    {
                        RemoveText();
                    }
                    else if(e.keyCode == KeyCode.Space)
                    {
                        AddSpace();
                    }
                    else if(e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter)
                    {
                        EnterCommand();
                        ReturnText = ReturnInputText(_inputText);
                        
                    }
                }
            }
            return null;
        }
        private string AddText(Event e)
        {
            return _inputText += e.keyCode;
        }

        private void AddSpace()
        {
            _inputText += " ";
            
        }

        private void RemoveText()
        {
            if (_inputText.Length > 0)
            {
                _inputText = _inputText.Remove(_inputText.Length - 1);
            }
        }

        private void EnterCommand()
        {

            OnReturnPressed.Invoke();

            
            /*
            foreach(char character in _inputText)
            {
                wordsInCommand += character;
                if(character == ' ')
                {
                    commands.Add(wordsInCommand);
                    wordsInCommand = "";
                }
                
            }
            for(int i = 0; i < commands.Count; i++)
            {
                commands[i].TrimEnd();
            }
            */
            ///////////
            ///////////
            //_inputText = "";



        }
        private string ReturnInputText(string inputText)
        {
            inputText += " ";
            return inputText;
        }

        public string GetInputText()
        {
            return _inputText;
        }

        //move these to parser
        /*
        public string GetCommand(int index)
        {
            for(int i = 0; i < commands.Count; i++)
            {
                if (index <= commands.Count)
                {
                    if (commands.Count > 0)
                    {
                        Debug.Log(commands[i]);
                        if (i == index)
                        {
                            return commands[i];
                        }
                    }
                }
            }
            return null;

        }
        */

        //this doesn't work yet
        /*
        public string GetCommand()
        {
            for(int i = 1; i < args.Count; i++)
            {
                
                if (commands.Count > 0)
                {
                    args.Add(commands[i]);
                }
            }
            return commands[0];
            
        }
        */


    }
}
