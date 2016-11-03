using UnityEngine;
using System.Collections;

public class IdleState : ITerminalState {

    private readonly StatePatternTerminal terminal;

    public IdleState(StatePatternTerminal statePatternTerminal)
    {
        terminal = statePatternTerminal;
    }

    public void UpdateState()
    {
        //What the state does
    }

    public void OnCommandReceived(string command)
    {
        if(command == "CONNECT")
        {
            ToConnectState();
        }
    }

    public void OnCommandReceived(string command, string[] args)
    {

    }

    public void ToConnectState()
    {
        terminal.currentState = terminal.connectState;
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
}
