using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Transfer.Data;

namespace Transfer.System
{
    public class CharacterInitializer
    {
        

        private string playerID;
		private List<string> characterIDs = new List<string>();
		private List<string> shortCharacterIDs = new List<string>();

        //name generation collections
        private string[] nameBits = { "A", "B", "C", "D", "E", "F",
            "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q",
            "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private List<string> vowels = new List<string>();
        private List<string> consonants = new List<string>();
        private List<string> names = new List<string>();

		void AddCharacterIdentifiers(){
			characterIDs.Add ("A");
			characterIDs.Add ("B");
			characterIDs.Add ("C");
			characterIDs.Add ("D");
			characterIDs.Add ("E");
			characterIDs.Add ("F");
			characterIDs.Add ("G");
			characterIDs.Add ("H");
			characterIDs.Add ("I");
			characterIDs.Add ("0");
			/////
			/// 
			///
			shortCharacterIDs.Add("A");
			shortCharacterIDs.Add("E");
			shortCharacterIDs.Add("I");
			shortCharacterIDs.Add("0");
		}

		string GeneratePlayerID(bool useShortCharacters)
		{
			if (useShortCharacters)
			{
				playerID = shortCharacterIDs[Random.Range(0, shortCharacterIDs.Count)];
			}
			else
			{
				playerID = characterIDs[Random.Range(0, characterIDs.Count)];
			}
			return playerID;
		}
		//make independent loops for both PC and NPC object lists
        //might not need to return anything?
        void GeneratePlayerCharacter(string playerID, string playerName, Gender playerGender){
            
            Transfer.Data.PlayerCharacter newPlayer = new Transfer.Data.PlayerCharacter(playerID, playerName, playerGender);
            CharacterDatabase.AddCharacter(newPlayer);
            for(int i = 0; i < characterIDs.Count; i++)
            {
                if(characterIDs[i] == playerID)
                {
                    characterIDs.Remove(characterIDs[i]);
                }
            }
            

        }

        void GenerateCharacters(Gender charGender)
        {
            Data.NonPlayerCharacter newCharacter;
            for (int i = 0; i < characterIDs.Count; i++)
            {
                newCharacter = new Data.NonPlayerCharacter(characterIDs[i], GenerateName(), charGender);
                CharacterDatabase.AddCharacter(newCharacter);
            }
        }

        

        Data.Gender SetRandomCharacterGender()
        {
            Gender gender = (Gender)Random.Range(0, 3);
            return gender;
        }



		public void PopulateCharacterDatabase(bool useShortCharacters)
        {
			AddCharacterIdentifiers ();
			playerID = GeneratePlayerID (useShortCharacters);
            GeneratePlayerCharacter(playerID, GenerateName(), SetRandomCharacterGender());
            GenerateCharacters(SetRandomCharacterGender());
            /*
			for(int i = 0; i < characterIDs.Count; i++)
            {
				string newID = characterIDs[Random.Range(0, characterIDs.Count)];
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
                    //newCharacter = GenerateCharacter(characterIDs[i], "MEMM", SetRandomCharacterGender());
                    //CharacterDatabase.AddCharacter(newCharacter);
                    //return GenerateCharacter(characterIDs[i], "name " + characterIDs[i], Gender.Masculine);
                }

            }
            return null;
            */
        }

        ////////////////////////////////

        string GenerateName()
        {
            for (int i = 0; i < nameBits.Length; i++)
            {
                if (nameBits[i] == "A" || nameBits[i] == "E" || nameBits[i] == "I" || nameBits[i] == "O" || nameBits[i] == "U")
                {
                    vowels.Add(nameBits[i]);
                }
                else
                {
                    consonants.Add(nameBits[i]);
                }
            }
            string newName;
            newName = consonants[Random.Range(0, consonants.Count)] + vowels[Random.Range(0, vowels.Count)] + consonants[Random.Range(0, consonants.Count)] + consonants[Random.Range(0, consonants.Count)];
            if (names.Contains(newName))
            {
                Debug.LogError("retry");
                GenerateName();

            }
            else
            {
                
                names.Add(newName);
                return newName;
            }
            if (names.Contains("MEMM"))
            {
                Debug.Log("It's MEMM!");
            }
            return null;
        }



    }
}
