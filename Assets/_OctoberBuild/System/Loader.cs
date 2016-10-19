using UnityEngine;
using System.Collections;

namespace TransferManager
{
    public class Loader : MonoBehaviour
    {

        public GameManager gameManager;
        public TerminalCommandParser commandParser;
        // Use this for initialization
        void Awake()
        {
            if (GameManager.instance == null)
            {
                Instantiate(gameManager);
            }
            if(TerminalCommandParser.instance == null)
            {
                Instantiate(commandParser);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
