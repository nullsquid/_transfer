using UnityEngine;
using System.Collections;

public class ExitCommandExecute : Command {

    IReceiver terminalDevice;

    public ExitCommandExecute(IReceiver newTerminal)
    {
        terminalDevice = newTerminal;
    }

    public void Execute()
    {
        terminalDevice.Exit();
    }
}
