using UnityEngine;
using System.Collections;

namespace Transfer.System
{
    public class RunningState : IGameState
    {
        private readonly StatePatternOverlord overlord;
		private GameManager manager;
        public RunningState(StatePatternOverlord statePatternOverlord)
        {
            overlord = statePatternOverlord;
        }

        public void UpdateState()
        {
			if (manager == null) {
				manager = GameObject.Find ("GameManager(Clone)").GetComponent<GameManager> ();
			}
			if (manager.GameHasStarted == false) {
				manager.GameHasStarted = true;
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
			Debug.LogWarning ("Cannot transition to the same state");
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
