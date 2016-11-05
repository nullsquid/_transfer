using UnityEngine;
using System.Collections;
namespace Transfer.System
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
		public StatePatternOverlord overlord;

        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else if(instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            InitializeGame();
        }

        
        void InitializeGame()
        {
			if (overlord == null) {
				overlord = GetComponent<StatePatternOverlord> ();
			}
			overlord.currentState.ToIdleState ();
        }

		public void StartGame(){
			overlord.currentState.ToRunningState ();
		}

		public void PauseGame(){
			overlord.currentState.ToPauseState ();
		}

		public void StartCutscene(){
			overlord.currentState.ToCutsceneState ();
		}


    }
}
