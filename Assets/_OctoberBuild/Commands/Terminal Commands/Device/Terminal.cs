using UnityEngine;
using System.Collections;
using Transfer.System;
public class Terminal : IReceiver {

    StatePatternTerminal terminalState;
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
        Debug.Log("Running program " + programID);
    }

    public void Scan(string place)
    {
        Debug.Log("Scanning " + place);
    }

    public void Sleep()
    {
        Debug.Log("Is sleeping");
    }
}
