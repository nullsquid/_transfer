using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Transfer.Data
{
    public class NameData
    {
        private static Dictionary<string, string> nameDictionary = new Dictionary<string, string>();

        public static void AddName(string ID, string newName)
        {
            nameDictionary.Add(ID, newName);
        }

        public static string GetName(string ID)
        {
            if (nameDictionary.ContainsKey(ID))
            {
                return nameDictionary[ID];
            }
            else
            {
                return null;
            }
        }


    }
}
