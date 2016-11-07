﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Transfer.Data
{
    public class HelpMenu
    {
        public Dictionary<string, string> helpContents = new Dictionary<string, string>();

        void InitializeHelpMenu()
        {
            helpContents.Add("DEFAULT","scan\nconnect\nrun\nsleep\ninput help followed by any command to see more options");
            helpContents.Add("SCAN", "to check on who's home, input scan followed by home\nto scan room, input scan followed by room");
            helpContents.Add("CONNECT", "to connect to an entity, input connect followed by the entity's identifier");
            helpContents.Add("RUN", "to run an installed program, input run followed by the program identifier");

        }
        
    }
}
