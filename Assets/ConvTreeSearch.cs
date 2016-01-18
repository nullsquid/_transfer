using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class ConvTreeSearch : MonoBehaviour {
    GameObject characterManager;
    ConvTree startTree;
    ConvTree nextTree;
    Dictionary<string, string> characterNames = new Dictionary<string, string>();

    public ConvNode firstNode;
    ConvNode curNode;
    public List<ConvNode> nextNodes = new List<ConvNode>();

    void OnEnable() {
        EventManager.StartListening("findStartTree", FindStartTree);
    }

    void OnDisable() {
        EventManager.StopListening("findStartTree", FindStartTree);
    }

    void GetCharacterInfoFromManager()
    {
        characterManager = GameObject.Find("CharacterManager");
        
        for(int i = 0; i < characterManager.GetComponent<CharacterManager>().characters.Count; i++)
        {
            characterNames.Add(characterManager.GetComponent<CharacterManager>().characters[i].ID, characterManager.GetComponent<CharacterManager>().characters[i].Name);
        }

    }
    void FindStartTree() {
        bool first = true;
        Character playerCharacter = GameObject.FindObjectOfType<PlayerCharacter>();
        startTree = GameObject.Find("9" + playerCharacter.name + "_Tree").GetComponent<ConvTree>();
        Transform tree = startTree.GetComponent<Transform>();
        foreach(Transform child in tree)
        {
            
            if(first == true)
            {
                firstNode = child.GetComponent<ConvNode>();
                first = false;
            }
            
        }
        GetCurrentNode(firstNode);
    }

    void IncomingConversation() {

    }

    void DisplayResponses() {

    }

    public string DisplayPrompt() {
        Debug.Log(curNode.prompt);
        return curNode.prompt;
    }
    void GetCurrentNode(ConvNode node)
    {
        curNode = node;
        GetNextNodes(curNode);
    }

    void GetNextNodes(ConvNode curNode)
    {
        foreach(Transform child in curNode.GetComponent<Transform>())
        {
            nextNodes.Add(child.GetComponent<ConvNode>());
        }
    }
    
    public string GetSpeakerName()
    {
        string character = curNode.characterTalking;
        string speakerName;
        
        foreach(KeyValuePair<string, string> entry in characterNames)
        {
            if(entry.Key == character)
            {
                Debug.Log("key is " + entry.Key);
                return entry.Key;
            }
        }
        return null;
    }
    IEnumerator FirstConversation(){
        yield return new WaitForSeconds(1.0f);

    }
    
}
