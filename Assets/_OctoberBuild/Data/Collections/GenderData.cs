using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Transfer.Data
{
    public class GenderData
    {
        private static Dictionary<string, Gender> genderDictionary = new Dictionary<string, Gender>();

        public enum Case
        {
            subjective,
            objective,
            possessive

        }

        public enum Gender
        {
            Masculine,
            Feminine,
            Neutral,
            Androgynous
        }

        public static void AddGender(string ID, Gender gender)
        {
            genderDictionary.Add(ID, gender);
        }

        public static Gender GetGender(string ID)
        {
            if (genderDictionary.ContainsKey(ID))
            {
                return genderDictionary[ID];
            }
            return Gender.Masculine;

        }

        public static string GetPronoun(string ID, Case pronounCase)
        {
            if (genderDictionary.ContainsKey(ID))
            {
                if(genderDictionary[ID] == Gender.Masculine)
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
                else if(genderDictionary[ID] == Gender.Feminine)
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
                else if(genderDictionary[ID] == Gender.Androgynous)
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
                else if (genderDictionary[ID] == Gender.Neutral)
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
       
    }
}
