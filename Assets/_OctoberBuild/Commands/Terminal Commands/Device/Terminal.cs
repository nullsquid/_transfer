using UnityEngine;
using System.Collections;
using Transfer.System;
using Transfer.Data;
public class Terminal : IReceiver {

    StatePatternTerminal terminalState;
    //Data
    CharacterDatabase database;
    Transfer.Data.HelpMenu helpMenu;
    public void Help(string request)
    {
        if(terminalState == null)
        {
            terminalState = GameObject.Find("Terminal(Clone)").GetComponent<StatePatternTerminal>();
        }
        if (terminalState != null)
        {
            if (terminalState.currentState == terminalState.idleState)
            {
                terminalState.currentState.ToHelpState();
            }
            if(helpMenu == null)
            {
                helpMenu = new Transfer.Data.HelpMenu();
                helpMenu.InitializeHelpMenu();
            }
            if (helpMenu != null)
            {
                Transfer.System.EventManager.TriggerEvent("TriggerClear");
                UIMain.SetTextContent(helpMenu.helpContents[request]);
                Transfer.System.EventManager.TriggerEvent("TriggerPrint");
            }
        }
    }

	public void Exit()
    {
        if (terminalState == null)
        {
            terminalState = GameObject.Find("Terminal(Clone)").GetComponent<StatePatternTerminal>();
        }
        if (terminalState.currentState != terminalState.idleState)
        {
                terminalState.currentState.ToIdleState();
        }
        else
        {
                Debug.Log("Already Idle");
        }
        
        Debug.Log("Returning to idle state");
    }

    public void Connect(string ID)
    {
        
        if(terminalState == null)
        {
            terminalState = GameObject.Find("Terminal(Clone)").GetComponent<StatePatternTerminal>();
        }
        if (terminalState.currentState == terminalState.idleState)
        {
            terminalState.idleState.ToConnectState();
        }
        Debug.Log("Connected to " + ID);
        //Connect to ID via tree search
    }

    public void Run(string programID)
    {
		if (terminalState == null) {
			terminalState = GameObject.Find("Terminal(Clone)").GetComponent<StatePatternTerminal>();
		}
        Debug.Log("Running program " + programID);
    }

    public void Scan(string place)
    {
        Debug.Log("Scanning " + place);
        if (terminalState == null)
        {
            terminalState = GameObject.Find("Terminal(Clone)").GetComponent<StatePatternTerminal>();
        }
        if(terminalState.currentState != terminalState.scanState)
        {
            terminalState.currentState.ToScanState();
        }
        if(database == null)
        {
            database = new CharacterDatabase();
        }

        if (place == "HOME")
        {
            
            Transfer.System.EventManager.TriggerEvent("TriggerClear");
            UIMain.SetTextContent(
                  CharacterDatabase.GetCharacterName("A") + "\n"
                + CharacterDatabase.GetCharacterName("B") + "\n"
                + CharacterDatabase.GetCharacterName("C") + "\n"
                + CharacterDatabase.GetCharacterName("D") + "\n"
                + CharacterDatabase.GetCharacterName("E") + "\n"
                + CharacterDatabase.GetCharacterName("F") + "\n"
                + CharacterDatabase.GetCharacterName("G") + "\n"
                + CharacterDatabase.GetCharacterName("H") + "\n"
                + CharacterDatabase.GetCharacterName("I") + "\n"
                + CharacterDatabase.GetCharacterName("0") + "\n");
            


            Transfer.System.EventManager.TriggerEvent("TriggerPrint");
        }

        else if (place == "ROOM")
        {
            Transfer.System.EventManager.TriggerEvent("TriggerClear");
            UIMain.SetTextContent("the room is empty");
            Transfer.System.EventManager.TriggerEvent("TriggerPrint");
        }
        else
        {
            Transfer.System.EventManager.TriggerEvent("TriggerClear");
            UIMain.SetTextContent("EXCEPTION: did you mean to pass a different argument?\n\nInput help for more options");
            Transfer.System.EventManager.TriggerEvent("TriggerPrint");
        }
    }

    public void Sleep()
    {
        Debug.Log("Is sleeping");
    }
}
