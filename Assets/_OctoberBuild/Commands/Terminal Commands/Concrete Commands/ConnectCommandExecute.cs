using UnityEngine;
using System.Collections;

public class ConnectCommandExecute : Command {

    IReceiver terminalDevice;

    string _nameToConnect = "MEMM";

    public string NameToConnect{
        set
        {
            _nameToConnect = value;

        }
    }

    public ConnectCommandExecute(IReceiver newTerminal)
    {
        terminalDevice = newTerminal;
    }

    public void Execute()
    {
        terminalDevice.Connect(_nameToConnect);
    }
}
