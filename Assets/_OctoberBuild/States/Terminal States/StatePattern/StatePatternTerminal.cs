using UnityEngine;
using System.Collections;

public class StatePatternTerminal : MonoBehaviour {

    [HideInInspector]
    ITerminalState currentState;
    [HideInInspector]
    IdleState idleState;
    [HideInInspector]
    ConnectedState connectState;
    [HideInInspector]
    RunState runState;
    [HideInInspector]
    SleepState sleepState; 

    void Awake()
    {
        idleState = new IdleState(this);
        runState = new RunState(this);
        sleepState = new SleepState(this);
        connectState = new ConnectedState(this);
    }

    //will figure out later if this should be in start or in the initializer
    void Start()
    {
        currentState = idleState;
    }

    void Update()
    {
        Debug.Log("current state is " + currentState);
        currentState.UpdateState();
    }

}
