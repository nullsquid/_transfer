using UnityEngine;
using System.Collections;

namespace Transfer.Data
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(string ID, string newName, Gender newGender){
            this.Identifier = ID;
            this.Name = newName;
            this.Gender = newGender;
            this.IsPlayer = true;
        }
      
    }
}
