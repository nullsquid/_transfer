using UnityEngine;
using System.Collections;

public class HelpCommandExecute : Command {

    IReceiver terminalDevice;

    string _helpRequest = "DEFAULT";

    public string HelpRequest
    {
        set
        {
            _helpRequest = value;
        }
    }

    public HelpCommandExecute(IReceiver newTerminal)
    {
        terminalDevice = newTerminal;
    }

	public void Execute()
    {
        terminalDevice.Help(_helpRequest);
    }
}
