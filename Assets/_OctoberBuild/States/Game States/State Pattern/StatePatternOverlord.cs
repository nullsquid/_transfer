﻿using UnityEngine;
using System.Collections;

namespace TransferManager
{
    public class StatePatternOverlord : MonoBehaviour
    {

        [HideInInspector]
        IGameState currentState;
        [HideInInspector]
        TransferManager.IdleState idleState;
        [HideInInspector]
        RunningState runningState;
        [HideInInspector]
        PauseState pauseState;
        [HideInInspector]
        CutsceneState cutsceneState;
        [HideInInspector]
        ExitState exitState;

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
