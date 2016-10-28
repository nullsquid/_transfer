using UnityEngine;
using System.Collections;
namespace Transfer.Data
{
    public class NonPlayerCharacter : Character
    {
        public NonPlayerCharacter(string ID, string newName, Gender newGender)
        {
            this.Identifier = ID;
            this.Name = newName;
            this.Gender = newGender;
        }
    }
}
