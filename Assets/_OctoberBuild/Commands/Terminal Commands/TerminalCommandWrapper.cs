﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Transfer.Data;
public class TerminalCommandWrapper {

    ConnectCommandExecute connectCommand;
    ExitCommandExecute exitCommand;

    public TerminalCommandWrapper()
    {
        IReceiver newDevice = DeviceGetter.GetDevice();
        connectCommand = new ConnectCommandExecute(newDevice);
        exitCommand = new ExitCommandExecute(newDevice);
    }

    public void Connect(string identifier)
    {

        //Following Code to set the name for lookup
        //connectCommand.NameToConnect = Character.Name;
        //the name might also come from a getter somewhere else that will have a list of all of the names

        //responsible for setting the FSM to switch to connected state
        if (CharacterDatabase.ContainsName(identifier))
        {
            connectCommand.NameToConnect = identifier;
            TerminalCommandInvoker connectInvoked = new TerminalCommandInvoker(connectCommand);
            connectInvoked.InvokeCommand();
        }
        else
        {
            Debug.LogError("No Name Found");
        }
        
    }

    public void Scan(string place)
    {

    }

    public void Exit()
    {
        TerminalCommandInvoker exitInvoked = new TerminalCommandInvoker(exitCommand);
        exitInvoked.InvokeCommand();
    }

}
