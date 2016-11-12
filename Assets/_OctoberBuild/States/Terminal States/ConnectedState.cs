using UnityEngine;
using System.Collections;
using Transfer.System;
using Transfer.Display;
public class ConnectedState : ITerminalState {

    private readonly StatePatternTerminal terminal;
	DialogueTreeTraversalController dialogController;

    public ConnectedState(StatePatternTerminal statePatternTerminal)
    {
        terminal = statePatternTerminal;
    }

	public void UpdateState()
    {
		if (dialogController == null) {
			dialogController = GameObject.Find ("DialogueTreeManager").GetComponent<DialogueTreeTraversalController>();
			dialogController.InitializeTree ();
		}
        //traversal algorithm


    }

    public void OnCommandReceived(string command)
    {
        
    }

    public void OnCommandReceived(string command, string[] args)
    {

    }

    public void ToConnectState()
    {

    }

    public void ToRunState()
    {

    }

    public void ToScanState()
    {
        terminal.currentState = terminal.scanState;
    }

    public void ToSleepState()
    {

    }

    public void ToIdleState()
    {
        terminal.currentState = terminal.idleState;

    }

    public void ToHelpState()
    {
        terminal.currentState = terminal.helpState;
    }

}
