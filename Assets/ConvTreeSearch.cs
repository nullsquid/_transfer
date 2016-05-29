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
        
        Character playerCharacter = GameObject.FindObjectOfType<PlayerCharacter>();
        startTree = GameObject.Find("9" + playerCharacter.name + "_Tree").GetComponent<ConvTree>();
        
        GetCurrentTree(startTree);
        GetCurrentNode(firstNode);
        GetCharacterInfoFromManager();
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt)) {
            SetNextNode(0);
        }
       
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
        
        
        return curNode.prompt;
    }
    void GetCurrentNode(ConvNode node)
    {
        curNode = node;
        GetNextNodes(curNode);
        
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
                GetCurrentTree(curNode.outLinkedTrees[choice]);

                GetNextNodes(firstNode);
                curNode = firstNode;
            }
            else
            {
                
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
        
        string character = curNode.characterTalking;
        string speakerName;
        string speakerID;
        CharacterManager charManager = GameObject.Find("CharacterManager").GetComponent<CharacterManager>();
        foreach(Transform child in characterManager.GetComponent<Transform>())
        {
            
            if(child.name == character)
            {
                speakerName = child.GetComponent<Character>().Name;
                
                return speakerName;
            }
            //return null;
        }
        return null;
        
    }

    public string GetSpeakerColor() {
        string character = curNode.characterTalking;
        Color32 speakerColor;
        string speakerID;
        CharacterManager charManager = GameObject.Find("CharacterManager").GetComponent<CharacterManager>();
        foreach (Transform child in characterManager.GetComponent<Transform>()) {
            if(child.name == character) {
                speakerColor = child.GetComponent<Character>().Color;
                //Debug.Log(speakerColor);
                //string hex;
                //hex = string.Format("#{0:X4}{1:X4}{2:X4}{3:X4}", speakerColor.b, speakerColor.g, speakerColor.r, speakerColor.a);
                string hex = "#" + (speakerColor.r).ToString("x2") + (speakerColor.g).ToString("x2") + (speakerColor.b).ToString("x2");
                //Debug.Log(hex);
                return hex;

            }
              
        }
        return null;
        
        
        
        
    }
    public void ConversationState()
    {
        
        DisplayPrompt();
        EventManager.TriggerEvent("setCurResponses");
        
    }
    
    public void TraverseToNextNode(int choice)
    {
        
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
