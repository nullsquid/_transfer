using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TextCapture : MonoBehaviour {
    public string rootCommand;
    //public string parameter_1;
    public List<string> commandList = new List<string>();
    public string[] commands;
    TextDisplay display;
    void Start()
    {
        display = GetComponent<TextDisplay>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            InputGet();
        }
    }

	void InputGet()
    {
        for(int i = 0; i < display.historyLines.Length; i++)
        {

        }
        //display.historyLines[0].GetComponent<TextMesh>().text = display.commandText.text;
        
        commands = display.command.Split(' ');
        rootCommand = commands[0];
        /*for(int i = 1; i < commands.Length; i++)
        {
            
        }*/
        //Connect
        //Install
        //Run
        //Make
        //Help
        CheckRootComand(rootCommand);
        display.command = "";
        display.commandText.text = display.commandPrompt;



    }

    IEnumerator UpdateHistory()
    {

        yield return null;
    }
    void CheckRootComand(string rootToCheck)
    {
        switch (rootToCheck)
        {
            case "CONNECT":
                Debug.Log("Connect");
                break;
            case "HELP":
                for(int i = 0; i < display.historyLines.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            display.historyLines[i].GetComponent<TextMesh>().text = "TO VIEW LOCATION: INPUT 'MAP'";
                            break;
                        case 1:
                            display.historyLines[i].GetComponent<TextMesh>().text = "TO CALL ACTION: INPUT 'ACTION' FOLLOWED BY ACTION";
                            break;
                        case 2:
                            display.historyLines[i].GetComponent<TextMesh>().text = "TO CALL OBJECT: INPUT 'OBJECT' FOLLOWED BY OBJECT ID";
                            break;
                        case 3:
                            display.historyLines[i].GetComponent<TextMesh>().text = "TO RETRIEVE MEMORY: INPUT 'MEMORY'";
                            break;
                        case 4:
                            display.historyLines[i].GetComponent<TextMesh>().text = "TO CHAT: INPUT 'CHAT' FOLLOWED BY USER ID";
                            break;
                        case 5:
                            display.historyLines[i].GetComponent<TextMesh>().text = "TO SLEEP: INPUT 'SLEEP'";
                            break;
                        case 6:
                            display.historyLines[i].GetComponent<TextMesh>().text = "TO SHUT DOWN: INPUT CONTROL + F4";
                            break;





                    }
                }
                break;
            default:
                //cannot find appropriate command
                break;

        }
    }
}
