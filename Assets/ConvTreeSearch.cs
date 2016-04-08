using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TOZ;
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
        //EventManager.StartListening("TESTNodeTraversal", TestNodeTraversal);
        EventManager.StartListening("findStartTree", FindStartTree);
        EventManager.StartListening("getCharacterInfo", GetCharacterInfoFromManager);
    }

    void OnDisable() {
        //EventManager.StopListening("TESTNodeTraversal", TestNodeTraversal);
        EventManager.StopListening("findStartTree", FindStartTree);
        EventManager.StopListening("getCharacterInfo", GetCharacterInfoFromManager);
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
        if (Input.GetKeyDown(KeyCode.LeftAlt)) {
            SetNextNode(0);
        }
        Debug.Log(curNode);
    }

    void GetCurrentTree(ConvTree newTree)
    {
        curTree = newTree;
        bool first = true; 

        Transform tree = curTree.GetComponent<Transform>();
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
        //GetSpeakerName();
        //ConversationState();
    }
    public void SetNextNode(int choice)
    {
        if (nextNodes.Count > 0)
        {
            if (GameObject.Find("TextManager").GetComponent<ResponseDisplay>().curResponses.Count > nextNodes.Count)
            {
                curNode = nextNodes[0];
                GetNextNodes(curNode);
            }
            else {
                curNode = nextNodes[choice];

                GetNextNodes(curNode);
            }

        }

        else if (nextNodes.Count == 0)
        {
            if (curNode.outLinkedTrees.Count > 0)
            {
                EventManager.TriggerEvent("pixelate");
                //StartCoroutine(TreeShift());
                GetCurrentTree(curNode.outLinkedTrees[choice]);

                GetNextNodes(firstNode);
                curNode = firstNode;
            }
            else
            {
                Debug.Log("end");
                GameObject.Find("TextManager").GetComponent<TextDisplay>().canType = false;
                EventManager.TriggerEvent("startEndSequence");
            }
            
        }

    }

    void GetNextNodes(ConvNode curNode)
    {
        nextNodes.Clear();
        foreach(Transform child in curNode.GetComponent<Transform>())
        {
            nextNodes.Add(child.GetComponent<ConvNode>());
        }
    }
    
    public string GetSpeakerName()
    {
        //Debug.Log("name is working");
        string character = curNode.characterTalking;
        string speakerName;
        string speakerID;
        CharacterManager charManager = GameObject.Find("CharacterManager").GetComponent<CharacterManager>();
        foreach(Transform child in characterManager.GetComponent<Transform>())
        {
            //Debug.Log(child.name);
            if(child.name == character)
            {
                speakerName = child.GetComponent<Character>().Name;
                Debug.Log("name is " + speakerName);
                return speakerName;
            }
            //return null;
        }
        return null;
        //Debug.Log("this is working");
        /*
        Debug.Log(characterNames.Keys);
        foreach(KeyValuePair<string, string> entry in characterNames)
        {
            Debug.Log(entry);
            speakerID = entry.Key;

            if(speakerID == character)
            {
                Debug.Log("key is " + entry.Key);
                return entry.Key;
            }
            return null;
        }
        return null;
        */
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
    
    public void TraverseToNextNode(int choice)
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
