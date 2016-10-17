using UnityEngine;
using System.Collections;

public class ConnectCommandExecute : MonoBehaviour {

    IReceiver terminalDevice;
    string nameToConnect;

    public ConnectCommandExecute(IReceiver newTerminal)
    {
        terminalDevice = newTerminal;
    }

    public void Execute()
    {
        terminalDevice.Connect(nameToConnect);
    }
}
