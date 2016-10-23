using UnityEngine;
using System.Collections;

namespace Transfer.System
{
    public class RunningState : IGameState
    {
        private readonly StatePatternOverlord overlord;

        public RunningState(StatePatternOverlord statePatternOverlord)
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

        public void ToIdleState()
        {

        }

        public void ToPauseState()
        {

        }

        public void ToCutsceneState()
        {

        }

        public void ToExitState()
        {

        }

    }
}
