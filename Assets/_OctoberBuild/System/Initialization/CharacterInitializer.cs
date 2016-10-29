using UnityEngine;
using System.Collections;
using Transfer.Data;

namespace Transfer.System
{
    public class CharacterInitializer
    {
        

        public string playerID;
        public string[] characterIDs = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "0" };
        public string[] shortCharacterIDs = { "A", "E", "I", "0" };
        string GeneratePlayerID(bool useShortCharacters)
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



        Data.PlayerCharacter GeneratePlayerCharacter(string playerID, string playerName, Gender playerGender){
            Transfer.Data.PlayerCharacter newPlayer = new Transfer.Data.PlayerCharacter(playerID, playerName, playerGender);
            return newPlayer;
        }

        Data.NonPlayerCharacter GenerateCharacter(string charID, string charName, Gender charGender)
        {
            Data.NonPlayerCharacter newCharacter = new Data.NonPlayerCharacter(charID, charName, charGender);
            return newCharacter;
        }

        

        Data.Gender SetRandomCharacterGender()
        {
            Gender gender = (Gender)Random.Range(0, 3);
            return gender;
        }

		public Data.Character GenerateCharacters(bool useShortCharacters)
        {
			GeneratePlayerID (useShortCharacters);
			Debug.Log ("player ID is " + playerID);
			for(int i = 0; i < characterIDs.Length; i++)
            {
				string newID = characterIDs[Random.Range(0, characterIDs.Length)];
				Debug.Log ("new id is " + newID);
                Data.Character newCharacter;
                if (newID == playerID)
                {
					newCharacter = GeneratePlayerCharacter(playerID, "MEMM", SetRandomCharacterGender());
                    CharacterDatabase.AddCharacter(newCharacter);

                    return newCharacter;
                }
                else
                {
                    newCharacter = GenerateCharacter(characterIDs[i], "MEMM", SetRandomCharacterGender());
                    CharacterDatabase.AddCharacter(newCharacter);
                    return GenerateCharacter(characterIDs[i], "name " + characterIDs[i], Gender.Masculine);
                }

            }
            return null;
        }





    }
}
