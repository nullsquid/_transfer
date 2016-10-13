using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace TransferInput
{
    public class InputController
    {
        private List<string> args = new List<string>();

        private bool canRecordInput = true;
        private string inputText = "";
        private string wordsInCommand;
        private List<string> commands = new List<string>();
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
                    }
                }
            }
            return null;
        }
        private string AddText(Event e)
        {
            return inputText += e.keyCode;
        }

        private void AddSpace()
        {
            inputText += " ";
            
        }

        private void RemoveText()
        {
            if (inputText.Length > 0)
            {
                inputText = inputText.Remove(inputText.Length - 1);
            }
        }

        private void EnterCommand()
        {
            inputText += " ";
            foreach(char character in inputText)
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
            inputText = "";
        }

        public string GetInputText()
        {
            return inputText;
        }
        public string GetCommand(int index)
        {
            for(int i = 0; i < commands.Count; i++)
            {
                if (index <= commands.Count)
                {
                    if (i == index)
                    {
                        return commands[i];
                    }
                }
            }
            return null;

        }

        //this doesn't work yet
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


    }
}
