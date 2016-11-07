using UnityEngine;
using System.Collections;

public class StatePatternTerminal : MonoBehaviour {

    [HideInInspector]
    public ITerminalState currentState;
    [HideInInspector]
    public IdleState idleState;
    [HideInInspector]
    public ConnectedState connectState;
    [HideInInspector]
    public RunState runState;
    [HideInInspector]
    public ScanState scanState;
    [HideInInspector]
    public SleepState sleepState;
    [HideInInspector]
    public HelpState helpState;

    void Awake()
    {
        idleState = new IdleState(this);
        runState = new RunState(this);
        sleepState = new SleepState(this);
        connectState = new ConnectedState(this);
        scanState = new ScanState(this);
        helpState = new HelpState(this);
    }

    //will figure out later if this should be in start or in the initializer
    void Start()
    {
        currentState = idleState;
    }

    void Update()
    {
        //Debug.Log("current state is " + currentState);
        currentState.UpdateState();
    }

}
