using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CharacterManager : MonoBehaviour {
    CharacterGenerator generator;
    List<Character> characters = new List<Character>();
    void Start() {
        generator = gameObject.GetComponent<CharacterGenerator>();
    }


}
