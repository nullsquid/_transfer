using UnityEngine;
using System.Collections;
using Transfer.Data;

namespace Transfer.System
{
    public class CharacterInitializer
    {
        string playerID;
        public string[] characterIDs = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "0" };
        public string[] shortCharacterIDs = { "A", "E", "I", "0" };
        string ChoosePlayerID(bool useShortCharacters)
        {
            
            if (useShortCharacters)
            {
                playerID = shortCharacterIDs[Random.Range(0, shortCharacterIDs.Length)];
            }
            else
            {
                playerID = characterIDs[Random.Range(0, characterIDs.Length)];
            }
            return playerID;
                
        }



        PlayerCharacter GeneratePlayerCharacter(){
            PlayerCharacter newPlayer = new PlayerCharacter();
            
            return newPlayer;
            
        }

        Character GenerateCharacters(bool useShortCharacters)
        {
            playerID = ChoosePlayerID(useShortCharacters);
            for(int i = 0; i < characterIDs.Length; i++)
            {

            }
            return null;
        }



        

    }
}
