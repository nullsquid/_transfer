using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour {
    public string userName;
    public string command;
    public string commandPrompt;
    public string prompt;
    public string startupText_1;
    public string startupText_2;
    public string versionNumber;
    public string commandError = "ERROR: INPUT NOT RECGOGNIZED";
    public bool canType = true;
    public GameObject[] historyLines;
    public TextMesh commandText;
    public GameObject treeManager;
    public bool gameHasStarted = false;
    public bool isChatting = false;
    public int lineLength;
    public Vector3 speakerLinePosition;

    private int promptLength;

    void OnEnable() {
        EventManager.StartListening("uiSetup", UISetup);
        EventManager.StartListening("startEndSequence", StartEndSequence);
    }
    void OnDisable() {
        EventManager.StopListening("uiSetup", UISetup);
        EventManager.StopListening("startEndSequence", StartEndSequence);
    }
    void GetUserName() {
        userName = GameObject.FindObjectOfType<PlayerCharacter>().Name;
    }
    void Update()
    {
        if (isChatting)
        {
            //historyLines[0].GetComponent<TextMesh>().text = treeManager.GetComponent<ConvTreeSearch>().DisplayPrompt();
            historyLines[0].GetComponent<TextMesh>().text = FormatText(treeManager.GetComponent<ConvTreeSearch>().GetSpeakerName() + ": " + treeManager.GetComponent<ConvTreeSearch>().DisplayPrompt());
            EventManager.TriggerEvent("setCurResponses");
        }
        else if(isChatting == false)
        {
            historyLines[0].GetComponent<TextMesh>().text = "";
        }
    }
    void UISetup() {
        GetUserName();
        EventManager.TriggerEvent("setupResponses");
        commandPrompt = userName + prompt;
        promptLength = commandPrompt.Length;
        commandText.text = commandPrompt;
        //speakerLineTransform = historyLines[0].transform.position;
        treeManager = GameObject.Find("ConvTreeManager");
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
    public string FormatText(string inText)
    {

        int countToLinebreak = 0;
        historyLines[0].GetComponent<Transform>().position = new Vector3(-28.6f, -8f, 0f);
        string formattedString = "";
        for(int i = 0; i < inText.Length; i++)
        {
            
            if(countToLinebreak <= lineLength) {
                countToLinebreak += 1;
                formattedString += inText[i];
            }
            else if(countToLinebreak > lineLength)
            {
                if (inText[i] == ' ')
                {
                    formattedString += inText[i];
                    formattedString += "\n";
                    historyLines[0].GetComponent<Transform>().position += new Vector3(0, 1.7f, 0);
                    countToLinebreak = 0;
                }
                else
                {
                    //countToLinebreak += 1;
                    formattedString += inText[i];
                }
            }
            //Debug.Log(formattedString);    
        }
        return formattedString;
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
                    //TEST
                    
                    if(e.keyCode == KeyCode.Alpha0)
                    {
                        commandText.text += "0";
                        command += "0";
                        Debug.Log(prompt);

                    }
                    else if ( e.keyCode == KeyCode.Alpha1)
                    {
                        commandText.text += "1";
                        command += "1";

                    }
                    else if (e.keyCode == KeyCode.Alpha2)
                    {
                        commandText.text += "2";
                        command += "2";
                    }
                    else if (e.keyCode == KeyCode.Alpha3)
                    {
                        commandText.text += "3";
                        command += "3";
                    }
                    else if (e.keyCode == KeyCode.Alpha4)
                    {
                        commandText.text += "4";
                        command += "4";
                    }
                    else if(e.keyCode == KeyCode.Alpha5)
                    {
                        commandText.text += "5";
                        command += "5";
                    }
                    else if (e.keyCode == KeyCode.Alpha6)
                    {
                        commandText.text += "6";
                        command += "6";
                    }
                    else if (e.keyCode == KeyCode.Alpha7)
                    {
                        commandText.text += "7";
                        command += "7";
                    }
                    else if(e.keyCode == KeyCode.Alpha8)
                    {
                        commandText.text += "8";
                        command += "8";
                    }
                    else if(e.keyCode == KeyCode.Alpha9)
                    {
                        commandText.text += "9";
                        command += "9";
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
    void StartEndSequence()
    {
        StartCoroutine(EndSequence());
    }
    IEnumerator EndSequence()
    {
        isChatting = false;
        canType = false;
        yield return new WaitForSeconds(2.0f);
        for (int j = 0; j < historyLines.Length; j++)
        {
            historyLines[j].GetComponent<TextMesh>().text = "";
            Debug.Log(historyLines[j].name);
        }
        //yield return new WaitForEndOfFrame();
        for (int i = 0; i < historyLines.Length; i++)
        {
            historyLines[i].GetComponent<TextMesh>().color = Color.gray;

            if (historyLines[i] == historyLines[0])
            {
                historyLines[i].GetComponent<TextMesh>().text = "oneirOS PATH TRANSFER UNLOCKED";
                yield return new WaitForSeconds(.02f);
            }
            else if (historyLines[i] == historyLines[1])
            {
                historyLines[i].GetComponent<TextMesh>().text = "PATH://oneirOS%ROOT/INIT";
                yield return new WaitForSeconds(.02f);
            }
            else if (historyLines[i] == historyLines[2])
            {
                historyLines[i].GetComponent<TextMesh>().text = "ESTABLISHING REMOTE CONNECTION";
                yield return new WaitForSeconds(.02f);
            }
            else if (historyLines[i] == historyLines[3])
            {
                historyLines[i].GetComponent<TextMesh>().text = "PATH://oneirOS%DATA/MASK";
                yield return new WaitForSeconds(.02f);
            }
            else if (historyLines[i] == historyLines[4])
            {
                historyLines[i].GetComponent<TextMesh>().text = "MASK RECONSTRUCTION COMPLETE";
                yield return new WaitForSeconds(.02f);
            }
            else if (historyLines[i] == historyLines[5])
            {
                historyLines[i].GetComponent<TextMesh>().text = "SYNCING CHANGELOG";
                yield return new WaitForSeconds(.02f);
            }
            else if (historyLines[i] == historyLines[6])
            {
                historyLines[i].GetComponent<TextMesh>().text = "PATH://oneirOS%ROOT/LOG";
                yield return new WaitForSeconds(.02f);
            }
            else if (historyLines[i] == historyLines[7])
            {
                historyLines[i].GetComponent<TextMesh>().text = "WELCOME HOME";
                yield return new WaitForSeconds(.02f);
            }
            yield return new WaitForSeconds(1.0f);
            Application.Quit();
        }
    }

    
}
