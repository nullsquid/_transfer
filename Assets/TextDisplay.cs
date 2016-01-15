using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour {
    public string userName;
    public string command;
    public string commandPrompt;
    public string prompt;
    public string startupText_1;
    public string startupText_2;
    public string commandError = "ERROR: INPUT NOT RECGOGNIZED";
    public bool canType = true;
    public GameObject[] historyLines;
    public TextMesh commandText;

    public bool gameHasStarted = false;

    private int promptLength;

    void OnEnable() {
        EventManager.StartListening("uiSetup", UISetup);
    }
    void OnDisable() {
        EventManager.StopListening("uiSetup", UISetup);
    }
    void GetUserName() {
        userName = GameObject.FindObjectOfType<PlayerCharacter>().Name;
    }
    void UISetup() {
        GetUserName();
        EventManager.TriggerEvent("setupResponses");
        commandPrompt = userName + prompt;
        promptLength = commandPrompt.Length;
        commandText.text = commandPrompt;
        for (int i = 0; i < historyLines.Length; i++) {
            historyLines[i].GetComponent<TextMesh>().color = Color.gray;
        }
        DisplayStartText();
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
        if (canType == true)
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

    void UserColor()
    {
        //Randomly color username to C, Y, M, on start

    }

    void ColorText()
    {
        //Color text on event
    }

    void DisplayStartText()
    {

        if(gameHasStarted == false)
        {
            Debug.Log("hello");
            historyLines[1].GetComponent<TextMesh>().color = Color.green;
            historyLines[1].GetComponent<TextMesh>().text = startupText_1;
            historyLines[0].GetComponent<TextMesh>().color = Color.green;
            historyLines[0].GetComponent<TextMesh>().text = startupText_2;
        }
    }

    
}
