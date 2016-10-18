using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CommandTester  : MonoBehaviour{

	// Use this for initialization
	void Start () {
        IReceiver newDevice = DeviceGetter.GetDevice();

        ConnectCommandExecute connectCommand = new ConnectCommandExecute(newDevice);

        //Following Code to set the name for lookup
        //connectCommand.NameToConnect = Character.Name;
        //the name might also come from a getter somewhere else that will have a list of all of the names

        TerminalCommandInvoker connectInvoked = new TerminalCommandInvoker(connectCommand);

        

        connectInvoked.InvokeCommand();
	}
}
