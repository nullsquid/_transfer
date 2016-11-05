using UnityEngine;
using System.Collections;

namespace Transfer.System
{
    public class IdleState : IGameState
    {
        private readonly StatePatternOverlord overlord;
		private GameManager manager;

        public IdleState(StatePatternOverlord statePatternOverlord)
        {
            overlord = statePatternOverlord;
        }

        public void UpdateState()
        {
			if (manager == null) {
				GameObject.Find ("GameManager(Clone)").GetComponent<GameManager> ();
			}
			if (manager.GameHasStarted != false) {
				manager.GameHasStarted = false;
			}
        }

        public void OnCommandRecieved(string command)
        {

        }

        public void OnCommandRecieved(string command, string[] args)
        {

        }

        public void ToRunningState()
        {
			overlord.currentState = overlord.runningState;
        }

        public void ToPauseState()
        {
			overlord.currentState = overlord.runningState;
        }

        public void ToCutsceneState()
        {
			overlord.currentState = overlord.cutsceneState;
        }

        public void ToIdleState()
        {
			Debug.LogWarning ("Cannot transition to the current state");
        }

        public void ToExitState()
        {
			overlord.currentState = overlord.exitState;
        }
    }
}
