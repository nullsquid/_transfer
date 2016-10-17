using UnityEngine;
using System.Collections;

public class TerminalCommandInvoker {

    Command commandToInvoke;

    public TerminalCommandInvoker(Command newCommand)
    {
        commandToInvoke = newCommand;
    }

    public void InvokeCommand()
    {
        commandToInvoke.Execute();
    }
}
