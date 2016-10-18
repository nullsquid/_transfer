using UnityEngine;
using System.Collections;

public class ConnectCommandExecute : Command {

    IReceiver terminalDevice;

    //default. need a way to update this at runtime
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
