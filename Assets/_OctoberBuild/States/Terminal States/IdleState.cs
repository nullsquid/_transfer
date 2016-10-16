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
