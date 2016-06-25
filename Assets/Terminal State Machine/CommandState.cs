using UnityEngine;
using System.Collections;

public class CommandState : ITerminalState {
    private readonly StatePatternTerminal terminal;

    public CommandState(StatePatternTerminal statePatternTerminal) {
        terminal = statePatternTerminal;
    }

    public void UpdateState() {

    }

    public void InputCommand(string command) {

    }

    public void ToIdleState() {

    }

    public void ToPackageLibraryState() {

    }

    public void ToHelpState() {

    }

    public void ToMapState() {

    }

    public void ToChatState() {

    }

    public void ToMailState() {

    }

    public void ToMemoryState() {

    }

    public void ToCommandState() {

    }

    public void ToSleepState() {

    }
}
