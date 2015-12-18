using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour {

    public string command;
    public string commandPrompt;
    public TextMesh commandText;

    private int promptLength;

    void Start()
    {
        promptLength = commandPrompt.Length;
        commandText.text = commandPrompt;
    }
    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.keyDown)
        {

            ChangeText(e);
            //RemoveText(e);
            
            
            Debug.Log(commandText.text);

        }
        

    }
    void ChangeText(Event e)
    {
        if (e.keyCode != KeyCode.None)
        {
            if (e.keyCode != KeyCode.Space && e.keyCode != KeyCode.Backspace)
            {
                if (e.keyCode >= KeyCode.A && e.keyCode <= KeyCode.Z)
                {
                    //get only alphabetical characters
                    commandText.text += e.keyCode;
                    command += e.keyCode;
                }

            }
            else if (e.keyCode == KeyCode.Space)
            {
                commandText.text += " ";
                command += " ";
            }
            else if (e.keyCode == KeyCode.Backspace)
            {
                RemoveText(e);
            }
        }
    }

    void RemoveText(Event e)
    {
        if(e.keyCode == KeyCode.Backspace)
        {
            if (commandText.text.Length > promptLength)
            {
                commandText.text = commandText.text.Remove(commandText.text.Length - 1);
                command = command.Remove(command.Length - 1);
            }
        }
    }
}
