using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Transfer.System;
namespace Transfer.Input
{
    public class InputController
    {
        #region Private Variables
        //private List<string> args = new List<string>();

        private bool _canRecordInput = true;
        private string _inputText = "";
        private string _returnText;
        

        #endregion

        #region Public Accessors
        public string ReturnText
        {
            get
            {
                return _returnText;
            }



        }

        public string InputText
        {
            get
            {
                return _inputText;
            }
        }
        #endregion

        #region Public Events

        public delegate void ReturnAction();
        public static event ReturnAction OnReturnPressed;
        #endregion

        public string UpdateInput(Event e)
        {

            if (_canRecordInput)
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
						_inputText = "";

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
            
            _returnText = ReturnInputText(_inputText);
            Transfer.System.EventManager.TriggerEvent("ProcessCommand");
            
        }
        private string ReturnInputText(string inputText)
        {
            inputText += " ";
            return inputText;
        }

    }
}
