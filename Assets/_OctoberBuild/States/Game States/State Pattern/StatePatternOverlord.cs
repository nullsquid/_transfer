using UnityEngine;
using System.Collections;

namespace Transfer.System
{
    public class StatePatternOverlord : MonoBehaviour
    {

        [HideInInspector]
        public IGameState currentState;
        [HideInInspector]
        public IdleState idleState;
        [HideInInspector]
        public RunningState runningState;
        [HideInInspector]
        public PauseState pauseState;
        [HideInInspector]
        public CutsceneState cutsceneState;
        [HideInInspector]
        public ExitState exitState;

        void Awake()
        {
            idleState = new IdleState(this);
            runningState = new RunningState(this);
            pauseState = new PauseState(this);
            cutsceneState = new CutsceneState(this);
            exitState = new ExitState(this);
        }

        void Start()
        {
            currentState = idleState;
        }

        void Update()
        {
            currentState.UpdateState();
        }
    }
}
