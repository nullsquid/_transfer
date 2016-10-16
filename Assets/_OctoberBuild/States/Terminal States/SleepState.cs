using UnityEngine;
using System.Collections;

public class SleepState : MonoBehaviour {

    private readonly StatePatternTerminal terminal;

    public SleepState(StatePatternTerminal statePatternTerminal)
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
}
