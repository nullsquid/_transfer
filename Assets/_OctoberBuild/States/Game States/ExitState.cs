﻿using UnityEngine;
using System.Collections;

namespace TransferManager
{
    public class ExitState : IGameState
    {
        private readonly StatePatternOverlord overlord;

        public ExitState(StatePatternOverlord statePatternOverlord)
        {
            overlord = statePatternOverlord;
        }

        public void UpdateState()
        {

        }   
        
        public void OnCommandRecieved(string command, string[] args)
        {

        }
        
        public void OnCommandRecieved(string command)
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
