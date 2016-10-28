using UnityEngine;
using System.Collections;
using Transfer.Data;
using Transfer.System;
public class CharTest : MonoBehaviour {
    CharacterInitializer init;
	// Use this for initialization
	void Start () {

                
	}
	
	// Update is called once per frame
	void Update () {
        if (init == null)
        {
            init = new CharacterInitializer();
            init.GenerateCharacters(true);
            Debug.Log(init.playerID);
            Debug.Log(CharacterDatabase.GetCharacterGender(init.playerID));
        }
    }
}
