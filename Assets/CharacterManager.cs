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
        for(int i = 0; i < generator.characterIDs.Length; i++)
        {
            characters.Add(generator.CharacterInitialization());
            Instantiate(characters[i]);
            characters[i].transform.parent = gameObject.transform;
        }
    }


}
