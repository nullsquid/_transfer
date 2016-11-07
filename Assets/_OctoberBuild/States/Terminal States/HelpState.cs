using UnityEngine;
using System.Collections;
using System;

public class HelpState : ITerminalState {

    private readonly StatePatternTerminal terminal;

    public HelpState(StatePatternTerminal statePatternTerminal)
    {
        terminal = statePatternTerminal;
    }

	public void UpdateState()
    {

    }

    public void ToHelpState()
    {
        terminal.currentState = terminal.helpState;
    }

    public void ToIdleState()
    {

    }

    public void OnCommandReceived(string command)
    {
        
    }

    public void OnCommandReceived(string command, string[] args)
    {
        throw new NotImplementedException();
    }

    public void ToConnectState()
    {

    }

    public void ToRunState()
    {
        throw new NotImplementedException();
    }

    public void ToScanState()
    {
        throw new NotImplementedException();
    }

    public void ToSleepState()
    {
        throw new NotImplementedException();
    }

}
