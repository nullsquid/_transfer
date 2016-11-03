using UnityEngine;
using System.Collections;

public class ScanCommandExecute : Command {

    IReceiver terminalDevice;

    string _placeToScan;

    public ScanCommandExecute(IReceiver newTerminal)
    {
        terminalDevice = newTerminal;
    }

    public void Execute()
    {
        terminalDevice.Scan(_placeToScan);
    }
}
