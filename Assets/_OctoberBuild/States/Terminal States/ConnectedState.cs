using UnityEngine;
using System.Collections;
using Transfer.System;
using Transfer.Display;
public class ConnectedState : ITerminalState {

    private readonly StatePatternTerminal terminal;
    SilkTreeTraversalController silkTreeController;
    //TODO extricate old dialogue controller
    DialogueTreeTraversalController dialogController;

    public ConnectedState(StatePatternTerminal statePatternTerminal)
    {
        terminal = statePatternTerminal;
    }

	public void UpdateState()
    {
        Debug.Log("CONNECTED");
        if(silkTreeController == null)
        { 
            silkTreeController = GameObject.Find("DialogueTaverser").GetComponent<SilkTreeTraversalController>();
        }
        //Debug.LogWarning(silkTreeController);

        if (silkTreeController.CurNode.HasVisited == false)
        {
            UIMain.SetTextContent(silkTreeController.CurNode.NodePassage);
            Transfer.System.EventManager.TriggerEvent("TriggerClear");
            Transfer.System.EventManager.TriggerEvent("TriggerPrint");
            //TODO write catch for when the player exits out of a conversation and then comes back
            silkTreeController.CurNode.HasVisited = true;
        }
        /*
		if (dialogController == null) {
			dialogController = GameObject.Find ("DialogueTreeManager").GetComponent<DialogueTreeTraversalController>();
			dialogController.InitializeTree ();
		}
        //traversal algorithm
        if (dialogController.GetVisitedState() == false)
        {
            UIMain.SetTextContent(dialogController.GetPrompt());
            Transfer.System.EventManager.TriggerEvent("TriggerClear");
            Transfer.System.EventManager.TriggerEvent("TriggerPrint");
            dialogController.SetHasVisited();
        }
        */
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
