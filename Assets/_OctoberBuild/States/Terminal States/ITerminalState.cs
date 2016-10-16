using UnityEngine;
using System.Collections;

public interface ITerminalState {

    void UpdateState();

    void OnCommandReceived(string command);

    void OnCommandReceived(string command, string[] args);

    void ToConnectState();

    void ToRunState();

    void ToSleepState();
}
