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
    public List<Color> nameColors = new List<Color>();
    public string playerCharacterID;
    public List<Color> npcColors = new List<Color>();
    public Character playerCharacterPrefab;
    public Character nonPlayerCharacterPrefab;

    public float reGlitchTime;
    string newGlitchName;
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
        GenerateColors(playerCharacter);
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
            GenerateColors(newCharacter);
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


    
    public string GenerateGlitchName() {
        
        for (int j = 0; j < 4; j++) {
            for (int i = 0; i < nameBits.Length; i++) {
                if (reGlitchTime > .3f) {
                    newGlitchName += nameBits[i];

                }
            }
        }
        return newGlitchName;
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
    void GenerateColors(Character character) {
        int colorIndex = Random.Range(0, nameColors.Count);
        character.Color = nameColors[colorIndex];
        nameColors.RemoveAt(colorIndex);

    }

    void GenerateGenders(Character character) {
        character.Gender = genders[Random.Range(0, genders.Length)];
        if(character.Gender == "Male")
        {
            character.Pronoun = "him";
        }
        else if(character.Gender == "Female")
        {
            character.Pronoun = "her";
        }
        else if (character.Gender == "Queer")
        {
            character.Pronoun = "them";
        }
        else if (character.Gender == "Agender")
        {
            character.Pronoun = "it";
        }




    }


    void PopulateAttributes() {

    }

}
