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
			if (charInit == null) {
				charInit = new CharacterInitializer ();
			}

            DontDestroyOnLoad(gameObject);
            InitializeCharacters();
        }

        void InitializeCharacters()
        {
			charInit.GenerateCharacters (true);
			Debug.Log(CharacterDatabase.GetCharacterID("A") + " " + CharacterDatabase.GetCharacterName("A"));
			Debug.Log(CharacterDatabase.GetCharacterID("B") + " " + CharacterDatabase.GetCharacterName("B"));
			Debug.Log(CharacterDatabase.GetCharacterID("0") + " " + CharacterDatabase.GetCharacterName("0"));
			/*Debug.Log(CharacterDatabase.GetCharacterID("A") + " " + CharacterDatabase.GetCharacterName("A"));
			Debug.Log(CharacterDatabase.GetCharacterID("A") + " " + CharacterDatabase.GetCharacterName("A"));
			Debug.Log(CharacterDatabase.GetCharacterID("A") + " " + CharacterDatabase.GetCharacterName("A"));
			Debug.Log(CharacterDatabase.GetCharacterID("A") + " " + CharacterDatabase.GetCharacterName("A"));
			Debug.Log(CharacterDatabase.GetCharacterID("A") + " " + CharacterDatabase.GetCharacterName("A"));
			Debug.Log(CharacterDatabase.GetCharacterID("A") + " " + CharacterDatabase.GetCharacterName("A"));
			*/

			//charDB

        }
    }

}