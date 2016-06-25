using UnityEngine;
using System.Collections;

public interface ITerminalState {

    void UpdateState();

    void InputCommand(string command);

    void ToIdleState();

    void ToPackageLibraryState();

    void ToHelpState();

    void ToMapState();

    void ToChatState();

    void ToMailState();

    void ToMemoryState();

    void ToCommandState();

    void ToSleepState();
}
