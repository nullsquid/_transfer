﻿using UnityEngine;
using System.Collections;

namespace Transfer.System
{
    public class IdleState : IGameState
    {
        private readonly StatePatternOverlord overlord;

        public IdleState(StatePatternOverlord statePatternOverlord)
        {
            overlord = statePatternOverlord;
        }

        public void UpdateState()
        {

        }

        public void OnCommandRecieved(string command)
        {

        }

        public void OnCommandRecieved(string command, string[] args)
        {

        }

        public void ToRunningState()
        {

        }

        public void ToPauseState()
        {

        }

        public void ToCutsceneState()
        {

        }

        public void ToIdleState()
        {

        }

        public void ToExitState()
        {

        }
    }
}
