using UnityEngine;
using System.Collections;

public class ScanState : ITerminalState {

    private readonly StatePatternTerminal terminal;

    public ScanState(StatePatternTerminal statePatternTerminal)
    {
        terminal = statePatternTerminal;
    }

    public void UpdateState()
    {

    }

    public void ToIdleState()
    {

    }

    public void ToConnectState()
    {

    }

    public void ToSleepState()
    {

    }

    public void ToScanState(string place)
    {

    }

    public void ToRunState()
    {

    } 

    public void OnCommandReceived(string ID)
    {

    }

    public void OnCommandReceived(string ID, string[] args)
    {

    }

    
}
