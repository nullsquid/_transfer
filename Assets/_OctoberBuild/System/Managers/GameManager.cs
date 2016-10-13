using UnityEngine;
using System.Collections;
namespace TransferManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

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
            //initialize all the things
        }
    }
}
