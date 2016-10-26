using UnityEngine;
using System.Collections;
using Transfer.Data;
namespace Transfer.System
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager instance;
        private CharacterInitializer charInit;
        private CharacterDatabase charDB;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
            InitializeCharacters();
        }

        void InitializeCharacters()
        {

        }
    }

}