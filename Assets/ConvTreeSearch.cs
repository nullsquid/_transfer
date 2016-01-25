using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class ConvTreeSearch : MonoBehaviour {
    GameObject characterManager;
    ConvTree startTree;
    public ConvTree curTree;
    ConvTree nextTree;
    Dictionary<string, string> characterNames = new Dictionary<string, string>();

    public ConvNode firstNode;
    public ConvNode curNode;
    public List<ConvNode> nextNodes = new List<ConvNode>();
   
    void OnEnable() {
        EventManager.StartListening("TESTNodeTraversal", TestNodeTraversal);
        EventManager.StartListening("findStartTree", FindStartTree);
        EventManager.StartListening("getCharacterInfo", GetCharacterInfoFromManager);
    }

    void OnDisable() {
        EventManager.StopListening("TESTNodeTraversal", TestNodeTraversal);
        EventManager.StopListening("findStartTree", FindStartTree);
        EventManager.StopListening("getCharacterInfo", GetCharacterInfoFromManager);
    }
    void TestNodeTraversal()
    {
        TraverseToNextNode(0);
    }
    void Start()
    {
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
        //bool first = true;
        Character playerCharacter = GameObject.FindObjectOfType<PlayerCharacter>();
        startTree = GameObject.Find("9" + playerCharacter.name + "_Tree").GetComponent<ConvTree>();
        
        GetCurrentTree(startTree);
        GetCurrentNode(firstNode);
        GetCharacterInfoFromManager();
        //TEST
        //StartCoroutine(ConversationState());
        //TraverseToNextNode(0);
    }
    void Update()
    {
        Debug.Log(curNode);
    }

    void GetCurrentTree(ConvTree newTree)
    {
        curTree = newTree;
        bool first = true; 

        Transform tree = startTree.GetComponent<Transform>();
        foreach (Transform child in tree)
        {

            if (first == true)
            {
                firstNode = child.GetComponent<ConvNode>();
                first = false;
            }

        }

    }

    void IncomingConversation() {

    }

    void DisplayResponses() {

    }

    public string DisplayPrompt() {
        //Debug.Log(curNode.prompt);
        return curNode.prompt;
    }
    void GetCurrentNode(ConvNode node)
    {
        curNode = node;
        GetNextNodes(curNode);
        GetSpeakerName();
        //ConversationState();
    }
    void SetNextNode(int choice)
    {
        curNode = nextNodes[choice];
    }
    void GetNextNodes(ConvNode curNode)
    {
        foreach(Transform child in curNode.GetComponent<Transform>())
        {
            nextNodes.Add(child.GetComponent<ConvNode>());
        }
    }
    
    public void GetSpeakerName()
    {
        string character = curNode.characterTalking;
        string speakerName;
        string speakerID;
        //Debug.Log("this is working");
        Debug.Log(characterNames.Keys);
        foreach(KeyValuePair<string, string> entry in characterNames)
        {
            Debug.Log(entry);
            speakerID = entry.Key;

            if(speakerID == character)
            {
                Debug.Log("key is " + entry.Key);
                //return entry.Key;
            }
        }
        //return null;
    }
    public void ConversationState()
    {
        //TEST
        //THIS SHOULD'T FIRE AT START
        DisplayPrompt();
        EventManager.TriggerEvent("setCurResponses");
        /*for(int i = 0; i < responseLines.Length; i++)
        {
            Debug.Log("working");
            //responseLines[i].GetComponent<TextMesh>().text = curNode.responses[i];
            /*

            if (i < curNode.responses.Count) {
                responseLines[i].GetComponent<TextMesh>().text = i + ". " + curNode.responses[i];
            }
            else
            {
                responseLines[i].GetComponent<TextMesh>().text = "";
            }
            
        }*/
        //yield return new WaitForEndOfFrame();
    }
    
    void TraverseToNextNode(int choice)
    {
        Debug.Log("traversing");
        for(int i = 0; i < nextNodes.Count; i++)
        {
            if(nextNodes.Count > 0)
            {
                GetCurrentNode(nextNodes[choice]);
            }
            else if (curNode.outLinkedTrees.Count > 0)
            {
                GetCurrentTree(curNode.outLinkedTrees[choice]);
            }
        }
    }
    IEnumerator FirstConversation(){
        yield return new WaitForSeconds(1.0f);

    }
    
}
