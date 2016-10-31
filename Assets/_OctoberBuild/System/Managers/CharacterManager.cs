using UnityEngine;
using System.Collections;
using Transfer.Data;
namespace Transfer.System
{
    public class CharacterManager : MonoBehaviour
    {
		public PlayerCharacter pcPrefab;
		public NonPlayerCharacter npcPrefab;
        public static CharacterManager instance;
        private CharacterInitializer charInit;
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
			if (charInit == null) {
				charInit = new CharacterInitializer ();
			}

            DontDestroyOnLoad(gameObject);
            InitializeCharacters();
        }

        void InitializeCharacters()
        {
			charInit.PopulateCharacterDatabase(true);
            /*
			Debug.Log(CharacterDatabase.GetCharacterID("A") + " " + CharacterDatabase.GetCharacterName("A"));
			Debug.Log(CharacterDatabase.GetCharacterID("B") + " " + CharacterDatabase.GetCharacterName("B"));
			Debug.Log(CharacterDatabase.GetCharacterID("C") + " " + CharacterDatabase.GetCharacterName("C"));
			Debug.Log(CharacterDatabase.GetCharacterID("D") + " " + CharacterDatabase.GetCharacterName("D"));
			Debug.Log(CharacterDatabase.GetCharacterID("E") + " " + CharacterDatabase.GetCharacterName("E"));
			Debug.Log(CharacterDatabase.GetCharacterID("F") + " " + CharacterDatabase.GetCharacterName("F"));
			Debug.Log(CharacterDatabase.GetCharacterID("G") + " " + CharacterDatabase.GetCharacterName("G"));
			Debug.Log(CharacterDatabase.GetCharacterID("H") + " " + CharacterDatabase.GetCharacterName("H"));
			Debug.Log(CharacterDatabase.GetCharacterID("I") + " " + CharacterDatabase.GetCharacterName("I"));
            Debug.Log(CharacterDatabase.GetCharacterID("0") + " " + CharacterDatabase.GetCharacterName("0"));
            */

        }
    }

}