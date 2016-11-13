﻿using UnityEngine;
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
        terminal.currentState = terminal.idleState;
    }

    public void ToConnectState()
    {
        terminal.currentState = terminal.connectState;
    }

    public void ToSleepState()
    {

    }

    public void ToScanState()
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

    public void ToHelpState()
    {
        terminal.currentState = terminal.helpState;
    }

    
}
