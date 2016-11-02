using UnityEngine;
using System.Collections;

public class ConnectedState : ITerminalState {

    private readonly StatePatternTerminal terminal;

    public ConnectedState(StatePatternTerminal statePatternTerminal)
    {
        terminal = statePatternTerminal;
    }

	public void UpdateState()
    {
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

    public void ToSleepState()
    {

    }

}
