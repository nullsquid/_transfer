using UnityEngine;
using System.Collections;
using Transfer.System;
public class Terminal : IReceiver {

    
	public void Exit()
    {
        Debug.Log("Returning to idle state");
    }

    public void Connect(string ID)
    {
        
        Debug.Log("Connected to " + ID);
        //Connect to ID via tree search
    }

    public void Run(string programID)
    {
        Debug.Log("Running program " + programID);
    }

    public void Scan(string place)
    {
        Debug.Log("Scanning " + place);
    }

    public void Sleep()
    {
        Debug.Log("Is sleeping");
    }
}
