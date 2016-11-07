using UnityEngine;
using System.Collections;

public interface ITerminalState {

    void UpdateState();

    void ToIdleState();

    void ToHelpState();

    void ToConnectState();

    void ToRunState();

    void ToScanState();

    void ToSleepState();
}
