using UnityEngine;
using System.Collections;

public class StatePatternTerminal : MonoBehaviour {

    [HideInInspector]
    public ITerminalState currentState;

    [HideInInspector]
    public IdleState idleState;

    [HideInInspector]
    public ChatState chatState;

    [HideInInspector]
    public CommandState commandState;

    private void Awake() {

        idleState = new IdleState(this);

        chatState = new ChatState(this);

        commandState = new CommandState(this);
    }

    void Start() {
        currentState = idleState;
    }

    void Update() {
        currentState.UpdateState();
    }
}
