using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TextCapture : MonoBehaviour {
    public string rootCommand;
    //public string parameter_1;
    public List<string> commandList = new List<string>();
    public string[] commands;
    bool isSleeping;
    TextDisplay display;
    HelpMenu helpMenu;
    EffectManager effects;
    void Start()
    {

        effects = GetComponent<EffectManager>();
        display = GetComponent<TextDisplay>();
        helpMenu = GetComponent<HelpMenu>();
    }
    void Update()
    {
        if(isSleeping == true)
        {
            if (Input.anyKeyDown)
            {
                Sleep(false);

            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            InputGet();
        }
        
    }


	void InputGet()
    {

        //display.historyLines[0].GetComponent<TextMesh>().text = display.commandText.text;

        commands = display.command.Split(' ');
        
        //StartCoroutine(UpdateHistory());
            
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
        if (display.gameHasStarted == true)
        {
            for (int i = 0; i < display.historyLines.Length; i++)
            {
                display.historyLines[i].GetComponent<TextMesh>().color = Color.gray;
                if (display.historyLines[i] == display.historyLines[0])
                {

                    display.historyLines[i].GetComponent<TextMesh>().text = display.commandText.text;
                    //yield return null;
                }
                else
                {

                    //display.historyLines[i - 1].GetComponent<TextMesh>().text = display.historyLines[i].GetComponent<TextMesh>().text;
                    display.historyLines[i].GetComponent<TextMesh>().text = display.historyLines[i - 1].GetComponent<TextMesh>().text;
                    yield return null;


                }
                yield return null;
            }
        }
        //yield return null;
    }
    void Sleep(bool state)
    {
        Transform text;
        if(state == true)
        {
            isSleeping = true;
            display.canType = false;
            text = GameObject.Find("InterfaceText").GetComponent<Transform>();
            foreach(Transform child in text)
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }

            
        }
        if(state == false)
        {
            isSleeping = false;
            display.canType = true;
            text = GameObject.Find("InterfaceText").GetComponent<Transform>();
            foreach (Transform child in text)
            {
                child.GetComponent<MeshRenderer>().enabled = true;
            }

        }
    }
    void CheckRootComand(string rootToCheck)
    {
        for (int n = 0; n < display.historyLines.Length; n++)
        {
            display.historyLines[n].GetComponent<TextMesh>().color = Color.gray;
        }
        if (display.gameHasStarted == true)
        {
            switch (rootToCheck)
            {
                case "EXIT":
                    Application.Quit();
                    break;
                case "SLEEP":
                    if (isSleeping == false)
                    {
                        if (commands.Length == 1)
                        {
                            Sleep(true);
                        }
                        else
                        {
                            display.historyLines[0].GetComponent<TextMesh>().color = Color.red;
                            display.historyLines[0].GetComponent<TextMesh>().text = "NO APPROPRIATE OVERLOAD FOR COMMAND 'SLEEP' FOUND";
                        }
                    }
                    
                    break;
                case "CHAT":
                    if(commands.Length <= 1)
                    {
                        display.historyLines[1].GetComponent<TextMesh>().color = Color.red;
                        display.historyLines[1].GetComponent<TextMesh>().text = "NO OVERLOAD OF COMMAND 'CHAT' FOUND.";
                        display.historyLines[0].GetComponent<TextMesh>().color = Color.red;
                        display.historyLines[0].GetComponent<TextMesh>().text = "DID YOU MEAN TO ENTER A NETWORK ID?";
                    }
                    else if(commands.Length == 2)
                    {
                        Debug.Log("works");
                        display.historyLines[0].GetComponent<TextMesh>().text = "CONNECTED";

                    }
                    else if(commands.Length > 2)
                    {
                        //if(commands[1] == something)
                        display.historyLines[0].GetComponent<TextMesh>().color = Color.red;
                        display.historyLines[0].GetComponent<TextMesh>().text = "NO OVERLOAD OF COMMAND 'CHAT' FOUND.";

                    }
                    Debug.Log("Connect");
                    break;
                case "HELP":
                    if (commands.Length == 1)
                    {
                        StartCoroutine(DisplayHelpMenu());
                    }
                    else
                    {
                        Debug.Log("error");
                        display.historyLines[0].GetComponent<TextMesh>().text = display.commandError;
                        display.historyLines[0].GetComponent<TextMesh>().color = Color.red;
                        // display.historyLines[0].GetComponent<TextMesh>().color = Color.Lerp(Color.red, Color.gray, Time.time);

                    }
                    break;
                case "CLEAR":
                    Clear();
                    break;
                case "":
                    break;
                
                default:
                    effects.StartScreenShake(7);
                    display.historyLines[0].GetComponent<TextMesh>().color = Color.red;
                    display.historyLines[0].GetComponent<TextMesh>().text = "NO DEFINITION FOR COMMAND '" + display.command +"' FOUND"; 
                    break;

            }

        }
        else if(display.gameHasStarted == false)
        {
            switch (rootToCheck)
            {
                case "START":
                    StartGame();
                    break;
                case "EXIT":
                    ExitGame();
                    break;
                default:

                    display.historyLines[0].GetComponent<TextMesh>().color = Color.green;
                    display.historyLines[1].GetComponent<TextMesh>().color = Color.green;

                    break;
            }
        }
    }
    
    IEnumerator DisplayHelpMenu()
    {
        Clear();
        for(int j = 0; j < display.historyLines.Length; j++)
        {
            display.historyLines[j].GetComponent<TextMesh>().color = Color.gray;
        }
        for (int i = 0; i < display.historyLines.Length; i++)
        {
            switch (i)
            {
                case 0:
                    display.historyLines[i].GetComponent<TextMesh>().text = helpMenu.formattedHelpItems[i];
                    yield return new WaitForSeconds(.05f);
                    break;
                case 1:
                    display.historyLines[i].GetComponent<TextMesh>().text = helpMenu.formattedHelpItems[i];
                    yield return new WaitForSeconds(.05f);
                    break;
                case 2:
                    display.historyLines[i].GetComponent<TextMesh>().text = helpMenu.formattedHelpItems[i];
                    yield return new WaitForSeconds(.05f);
                    break;
                case 3:
                    display.historyLines[i].GetComponent<TextMesh>().text = helpMenu.formattedHelpItems[i];
                    yield return new WaitForSeconds(.05f);
                    break;
                case 4:
                    display.historyLines[i].GetComponent<TextMesh>().text = helpMenu.formattedHelpItems[i];
                    yield return new WaitForSeconds(.05f);
                    break;
                case 5:
                    display.historyLines[i].GetComponent<TextMesh>().text = helpMenu.formattedHelpItems[i];
                    yield return new WaitForSeconds(.05f);
                    break;
                case 6:
                    display.historyLines[i].GetComponent<TextMesh>().text = helpMenu.formattedHelpItems[i];
                    yield return new WaitForSeconds(.05f);
                    break;

            }
        }
    }

    void Clear()
    {
        for (int i = 0; i < display.historyLines.Length; i++)
        {
            display.historyLines[i].GetComponent<TextMesh>().text = "";
        }
    }
    IEnumerator StartupRoutine()
    {
        display.canType = false;
        if (display.gameHasStarted == false)
        {
            //Debug.Log("Start");
            for (int i = 0; i < display.historyLines.Length; i++)
            {
                display.historyLines[i].GetComponent<TextMesh>().color = Color.gray; 

                if (display.historyLines[i] == display.historyLines[0])
                {
                    display.historyLines[i].GetComponent<TextMesh>().text = "INITIALIZING oneirOS PATH";
                    yield return new WaitForSeconds(.02f);
                }
                else if (display.historyLines[i] == display.historyLines[1])
                {
                    display.historyLines[i].GetComponent<TextMesh>().text = "PATH://oneirOS%ROOT/INIT";
                    yield return new WaitForSeconds(.02f);
                }
                else if (display.historyLines[i] == display.historyLines[2])
                {
                    display.historyLines[i].GetComponent<TextMesh>().text = "ESTABLISHING REMOTE CONNECTION";
                    yield return new WaitForSeconds(.02f);
                }
                else if (display.historyLines[i] == display.historyLines[3])
                {
                    display.historyLines[i].GetComponent<TextMesh>().text = "PATH://oneirOS%DATA/MASK";
                    yield return new WaitForSeconds(.02f);
                }
                else if (display.historyLines[i] == display.historyLines[4])
                {
                    display.historyLines[i].GetComponent<TextMesh>().text = "COPYING MASK NEGATIVE";
                    yield return new WaitForSeconds(.02f);
                }
                else if (display.historyLines[i] == display.historyLines[5])
                {
                    display.historyLines[i].GetComponent<TextMesh>().text = "ORIGIN DELTA CHECK";
                    yield return new WaitForSeconds(.02f);
                }
                else if (display.historyLines[i] == display.historyLines[6])
                {
                    display.historyLines[i].GetComponent<TextMesh>().text = "PATH://oneirOS%ROOT/DELTA";
                    yield return new WaitForSeconds(.02f);
                }
                else if (display.historyLines[i] == display.historyLines[7])
                {
                    display.historyLines[i].GetComponent<TextMesh>().text = "CLEANING UP...";
                    yield return new WaitForSeconds(.02f);
                }

            }
            
            yield return new WaitForSeconds(1.5f);
            for (int q = 0; q < display.historyLines.Length; q++)
            {
                display.historyLines[q].GetComponent<TextMesh>().color = Color.gray;
                display.historyLines[q].GetComponent<TextMesh>().text = "";
            }
            for (int l = 0; l < display.historyLines.Length; l++)
            {
                if (display.historyLines[l] == display.historyLines[1])
                {
                    display.historyLines[l].GetComponent<TextMesh>().text = "COPYING CORE COMPONENTS...";
                    yield return new WaitForSeconds(0.5f);
                }
                else if (display.historyLines[l] == display.historyLines[3])
                {
                    display.historyLines[l].GetComponent<TextMesh>().text = "COPYING NEURAL MASK...";
                    yield return new WaitForSeconds(1.0f);
                }
                else if (display.historyLines[l] == display.historyLines[5])
                {
                    display.historyLines[l].GetComponent<TextMesh>().text = "SEVERING ORIGIN LINK...";
                    yield return new WaitForSeconds(0.5f);
                }
            }
            for(int z = 0; z < display.historyLines.Length; z++)
            {
                display.historyLines[z].GetComponent<TextMesh>().text = "";
            }
            for (int j = 0; j < display.historyLines.Length; j++)
           
            {
                if(display.historyLines[j] == display.historyLines[2] || display.historyLines[j] == display.historyLines[3])
                {
                    display.historyLines[j].GetComponent<TextMesh>().color = Color.red;
                }
                if (display.historyLines[j] == display.historyLines[0])
                {
                    display.historyLines[j].GetComponent<TextMesh>().text = "PATH://oneirOS%SYSTEM: COMPLETE";
                    yield return new WaitForSeconds(.05f);
                }
                else if (display.historyLines[j] == display.historyLines[1])
                {
                    display.historyLines[j].GetComponent<TextMesh>().text = "PATH://oneirOS%INTERFACE: COMPLETE";
                    yield return new WaitForSeconds(.05f);
                }
                else if (display.historyLines[j] == display.historyLines[2])
                {
                    display.historyLines[j].GetComponent<TextMesh>().text = "PATH://oneirOS%MEMORY: ERROR";
                    yield return new WaitForSeconds(Random.Range(.5f, 1.0f));
                }
                else if (display.historyLines[j] == display.historyLines[3])
                {
                    display.historyLines[j].GetComponent<TextMesh>().text = "PATH://oneirOS%APPLICATION: ERROR";
                    yield return new WaitForSeconds(Random.Range(1f, 1.5f));
                }
                else if (display.historyLines[j] == display.historyLines[4])
                {
                    display.historyLines[j].GetComponent<TextMesh>().text = "PATH://oneirOS%SYSTEM: COMPLETE";
                    yield return new WaitForSeconds(.01f);
                }
                else if (display.historyLines[j] == display.historyLines[5])
                {
                    display.historyLines[j].GetComponent<TextMesh>().text = "PATH://oneirOS%AHR$%#N: COMPLETE";
                    yield return new WaitForSeconds(.01f);
                }
                else if (display.historyLines[j] == display.historyLines[6])
                {
                    display.historyLines[j].GetComponent<TextMesh>().text = "PATH://oneirOS%NETWORK: COMPLETE";
                    yield return new WaitForSeconds(.01f);
                }
                else if (display.historyLines[j] == display.historyLines[7])
                {
                    display.historyLines[j].GetComponent<TextMesh>().text = "PATH://oneirOS%PERSONA: COMPLETE";
                    yield return new WaitForSeconds(.01f);
                }

            }
            yield return new WaitForSeconds(1.0f);
            
            for(int k = 0; k < display.historyLines.Length; k++)
            {
                
                display.historyLines[k].GetComponent<TextMesh>().text = "";
                yield return new WaitForSeconds(.3f);
                
                
            }
            yield return new WaitForSeconds(0.5f);
            display.historyLines[0].GetComponent<TextMesh>().text = "TRANSFER COMPLETED WITH ERRORS";
            yield return new WaitForSeconds(1.0f);
            display.historyLines[0].GetComponent<TextMesh>().text = "WELCOME TO oneirOS v 0.9.9.3";
            yield return new WaitForSeconds(.5f);
            display.historyLines[1].GetComponent<TextMesh>().text = "WELCOME TO oneirOS v " + GetComponent<TextDisplay>().versionNumber;
            display.historyLines[0].GetComponent<TextMesh>().text = "INPUT HELP FOR MORE OPTIONS";
        }
        
        display.canType = true;
        yield return null;

    }
    void Log()
    {

    }

    void StartGame()
    {
        StartCoroutine("StartupRoutine");
        display.gameHasStarted = true;
    }

    void ExitGame()
    {
        Application.Quit();
    }


}
