using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CharacterGenerator : MonoBehaviour {

    public Character playerCharacter;
    public string[] characterIDs;
    public string[] playableCharacterIDs;
    public string playerCharacterID;

    public Character playerCharacterPrefab;
    public Character nonPlayerCharacterPrefab;
    // Use this for initialization
    public Character CharacterInitialization() {
        //Character newCharacter;
        return nonPlayerCharacterPrefab;
    }



    string ChoosePlayer() {
        string playerID = playableCharacterIDs[Random.Range(0, playableCharacterIDs.Length)];
        return playerID;
    }


    void PopulateAttributes() {

    }

    void GenerateNames() {

    }

    void GenerateGenders() {

    }

}
