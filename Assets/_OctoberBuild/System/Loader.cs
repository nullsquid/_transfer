using UnityEngine;
using System.Collections;

namespace Transfer.System
{
    public class Loader : MonoBehaviour
    {

        public GameManager gameManager;
        public CharacterManager characterManager;
        public TerminalController terminalController;
        // Use this for initialization
        void Awake()
        {
            if (GameManager.instance == null)
            {
                Instantiate(gameManager);
            }
            if(TerminalController.instance == null)
            {
                Instantiate(terminalController);
            }
            if(CharacterManager.instance == null)
            {
                Instantiate(characterManager);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
