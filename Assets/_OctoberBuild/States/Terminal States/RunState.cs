using UnityEngine;
using System.Collections;

public class RunState : ITerminalState {

    private readonly StatePatternTerminal terminal;

    public RunState (StatePatternTerminal statePatternTerminal)
    {
        terminal = statePatternTerminal;
    }

    public void UpdateState()
    {

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

    public void ToIdleState()
    {

    }
}
