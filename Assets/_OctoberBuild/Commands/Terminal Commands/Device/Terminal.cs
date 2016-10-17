using UnityEngine;
using System.Collections;

public class Terminal : IReceiver {

	public void Exit()
    {
        Debug.Log("Returning to idle state");
    }

    public void Connect(string ID)
    {
        Debug.Log("Connected to " + ID);
    }

    public void Run(string programID)
    {
        Debug.Log("Running program " + programID);
    }

    public void Sleep()
    {
        Debug.Log("Is sleeping");
    }
}
