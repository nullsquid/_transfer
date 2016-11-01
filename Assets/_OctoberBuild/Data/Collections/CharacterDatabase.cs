using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Transfer.Data
{
    public enum Case
    {
        subjective,
        objective,
        possessive

    }

    public class CharacterDatabase
    {
        private static Dictionary<string, Character> characterDictionary = new Dictionary<string, Character>();
        
		public static string GetCharacterID(string ID){
			if (characterDictionary.ContainsKey (ID)) {
				return characterDictionary [ID].Identifier;
			}
			return null;
		}

        public static bool ContainsName(string _name)
        {
            foreach(KeyValuePair<string, Character> entry in characterDictionary)
            {
                if(entry.Value.Name == _name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }

        public static string GetCharacterName(string ID)
        {
            if (characterDictionary.ContainsKey(ID))
            {
                return characterDictionary[ID].Name;
            }
            return null;
        }

        public static Gender GetCharacterGender(string ID)
        {
            
            if (characterDictionary.ContainsKey(ID))
            {
                
                return characterDictionary[ID].Gender;
            }
            return Gender.Masculine;

        }

        public static string GetPronoun(string ID, Case pronounCase)
        {
            if (characterDictionary.ContainsKey(ID))
            {
                if (characterDictionary[ID].Gender == Gender.Masculine)
                {
                    switch (pronounCase)
                    {
                        case Case.objective:
                            return "him";

                        case Case.subjective:
                            return "he";

                        case Case.possessive:
                            return "his";
                    }
                }
                else if (characterDictionary[ID].Gender == Gender.Feminine)
                {
                    switch (pronounCase)
                    {
                        case Case.objective:
                            return "her";
                        case Case.subjective:
                            return "she";
                        case Case.possessive:
                            return "hers";
                    }
                }
                else if (characterDictionary[ID].Gender == Gender.Androgynous)
                {
                    switch (pronounCase)
                    {
                        case Case.objective:
                            return "them";
                        case Case.subjective:
                            return "they";
                        case Case.possessive:
                            return "their";
                    }
                }
                else if (characterDictionary[ID].Gender == Gender.Neutral)
                {
                    switch (pronounCase)
                    {
                        case Case.objective:
                            return "it";
                        case Case.subjective:
                            return "it";
                        case Case.possessive:
                            return "its";
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            return null;
        }

        public static void AddCharacter(Character newCharacter)
        {
            characterDictionary.Add(newCharacter.Identifier, newCharacter);
        }


    }
}
