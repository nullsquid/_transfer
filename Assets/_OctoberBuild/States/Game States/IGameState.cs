using UnityEngine;
using System.Collections;

namespace Transfer.System
{
    public interface IGameState
    {

        void UpdateState();

        void OnCommandRecieved(string command);

        void OnCommandRecieved(string command, string[] args);

        void ToRunningState();

        void ToPauseState();
        //Might want to pass a thing here to tell it what text to run
        void ToCutsceneState();

        void ToIdleState();

        void ToExitState();


    }
}
