using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CharacterManager : MonoBehaviour {
    
    public List<Character> characters = new List<Character>();
    //database of characters and their during-play states
    //generated in character generator
    
    void OnEnable() {
        EventManager.StartListening("makeCharacters", AddCharactersToList);
    }
    void OnDisable() {
        EventManager.StopListening("makeCharacters", AddCharactersToList);
    }
    void AddCharactersToList() {
        EventManager.TriggerEvent("makePlayer");
        EventManager.TriggerEvent("makeNonPlayers");
        foreach (Transform children in transform) {
            characters.Add(children.GetComponent<Character>());
        }
    }


}
