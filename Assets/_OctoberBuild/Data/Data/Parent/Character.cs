using UnityEngine;
using System.Collections;

namespace Transfer.Data
{
    public abstract class Character
    {
        private string _identifier;
        private string _name;
        private Gender _gender;

        public string Identifier
        {
            get
            {
                return _identifier;
            }

            set
            {
                _identifier = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }
        

    }
}