using UnityEngine;
using System.Collections;
using Transfer.System;
public class ConnectCommandExecute : Command {
    //TODO add connect 
    SilkTreeTraversalController silkTree;
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
        if(silkTree == null)
        {
            silkTree = GameObject.Find("DialogueTaverser").GetComponent<SilkTreeTraversalController>();
        }
        if(silkTree)
        terminalDevice.Connect(_nameToConnect);
    }
}
