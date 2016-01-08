using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CharacterManager : MonoBehaviour {
    CharacterGenerator generator;
    List<Character> characters = new List<Character>();
    //database of characters and their during-play states
    //generated in character generator
    void Start() {
        generator = gameObject.GetComponent<CharacterGenerator>();
    }


}
