using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Transfer.Input;
using Transfer.Data;
namespace Transfer.System
{
    public class TerminalCommandParser : MonoBehaviour
    {

        #region Instance
        public static TerminalCommandParser instance;
        #endregion

        #region Private Data Variables
        string _terminalCommand;
        string _rawCommand;
        string _newText;
        List<string> _commandArgs = new List<string>();
        string _text;
        #endregion

        #region Public Accessors
        public string RootCommand
        {
            get
            {
                return _commandArgs[0];
            }
        }
        #endregion

        #region Private References
        UIMainInput uiInput;
        #endregion

        #region Unity Callbacks
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            if (instance != this)
            {
                Destroy(gameObject);
            }


            DontDestroyOnLoad(gameObject);
        }

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
