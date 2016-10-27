using UnityEngine;
using System.Collections;

namespace Transfer.Data
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(string ID, string newName, Gender newGender){
            Identifier = ID;
            Name = newName;
            Gender = newGender;
            
        }
      
    }
}
