using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CharacterGenerator : MonoBehaviour {

    public Character playerCharacter;
    //public string[] characterIDs;
    //public string[] playableCharacterIDs;
    public List<string> characterIDs = new List<string>();
    public List<string> playableCharacterIDs = new List<string>();
    public string[] nameBits;
    private List<string> vowels = new List<string>();
    private List<string> consonants = new List<string>();
    public List<string> names = new List<string>();
    public string[] genders;
    public string playerCharacterID;
    public List<Color> npcColors = new List<Color>();
    public Character playerCharacterPrefab;
    public Character nonPlayerCharacterPrefab;
    void OnEnable() {
        EventManager.StartListening("makePlayer", MakePlayer);
        EventManager.StartListening("makeNonPlayers", MakeNonPlayers);
    }

    void OnDisable() {
        EventManager.StopListening("makePlayer", MakePlayer);
        EventManager.StopListening("makeNonPlayers", MakeNonPlayers);
    }
    
    public void CharacterInit() {
        MakeNonPlayers();
        
    }
   
    void MakePlayer() {
        
        playerCharacterID = ChoosePlayer();
        playerCharacter = Instantiate(playerCharacterPrefab, transform.position, transform.rotation) as Character;
        playerCharacter.name = playerCharacterID;
        GenerateGenders(playerCharacter);
        GenerateName(playerCharacter);
        playerCharacter.transform.parent = gameObject.transform;
        for(int i = 0; i < characterIDs.Count; i++) {
            if(characterIDs[i] == playerCharacterID) {
                characterIDs.Remove(characterIDs[i]);

            }

        }

        
        
    }
    
    void MakeNonPlayers() {
        
        Character newCharacter;
        for(int i = 0; i < characterIDs.Count; i++) {
            newCharacter = Instantiate(nonPlayerCharacterPrefab, transform.position, transform.rotation) as Character;
            newCharacter.name = characterIDs[i];
            newCharacter.ID = characterIDs[i];
            GenerateGenders(newCharacter);
            GenerateName(newCharacter);
            newCharacter.transform.parent = gameObject.transform;
        }
    }



    string ChoosePlayer() {
        string playerID = playableCharacterIDs[Random.Range(0, playableCharacterIDs.Count)];
        for(int i = 0; i < playableCharacterIDs.Count; i++) {
            if(playableCharacterIDs[i] == playerID) {
                playableCharacterIDs.Remove(playableCharacterIDs[i]);
            }
        }
        //playableCharacterIDs
        return playerID;
    }


    
    
    void GenerateName(Character character) {
        for(int i = 0; i < nameBits.Length; i++) {
            if(nameBits[i] == "A" || nameBits[i] == "E" || nameBits[i] == "I" || nameBits[i] == "O" || nameBits[i] == "U") {
                vowels.Add(nameBits[i]);
            }
            else {
                consonants.Add(nameBits[i]);
            }
        }
        string newName;
        newName = consonants[Random.Range(0, consonants.Count)] + vowels[Random.Range(0, vowels.Count)] + consonants[Random.Range(0, consonants.Count)] + consonants[Random.Range(0, consonants.Count)];
        if (names.Contains(newName)) {
            Debug.LogError("retry");
            GenerateName(character);
            
        }
        else {
            character.Name = newName;
            names.Add(newName);
        }
        if (names.Contains("MEMM")) {
            Debug.Log("It's MEMM!");
        }
    }

    void GenerateGenders(Character character) {
        character.Gender = genders[Random.Range(0, genders.Length)];
    }

    void GenerateColors(Character characters)
    {

    }

    void PopulateAttributes() {

    }

}
