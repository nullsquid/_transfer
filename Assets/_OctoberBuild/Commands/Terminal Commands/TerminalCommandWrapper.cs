using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Transfer.Data;
public class TerminalCommandWrapper {

    ConnectCommandExecute connectCommand;

    public TerminalCommandWrapper()
    {
        IReceiver newDevice = DeviceGetter.GetDevice();
        connectCommand = new ConnectCommandExecute(newDevice);
    }

    public void Connect(string identifier)
    {

        //Following Code to set the name for lookup
        //connectCommand.NameToConnect = Character.Name;
        //the name might also come from a getter somewhere else that will have a list of all of the names
        connectCommand.NameToConnect = identifier;
        TerminalCommandInvoker connectInvoked = new TerminalCommandInvoker(connectCommand);
        connectInvoked.InvokeCommand();
    }

}
