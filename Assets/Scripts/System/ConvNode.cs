using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConvNode : MonoBehaviour {

	
	public string prompt;
	public bool hasVisited;
	public List<string> responses = new List<string>();
	public List<ConvTree>outLinkedTrees = new List<ConvTree> ();
	//public Memory memory
	//public List<string> charactersInConversation = new List<string>();
	public string characterTalking;
	public int level;
	public int decision;

    //i have to be able to determine that a given node has a specific sort of event associated with it
    //such as a sound effect, or starting a battle, or special camera movement, etc.......
    //will design a system to do this



	public List<ConvNode> children = new List<ConvNode>();

	
	void OnEnable(){
        //register an event to trigger a function that 
        //creates the tree
        //making a child for each response and nests it
        //might need to play with the JSON structure a bit
        EventManager.StartListening("getNodes", GetChildNodes);

	}

    void OnDisable() {
        EventManager.StopListening("getNodes", GetChildNodes);
    }

    void GetChildNodes() {
        foreach(Transform child in transform){
            children.Add(child.gameObject.GetComponent<ConvNode>());
        }
    }
	public string LinkToNode(){
		return null;
	}

}
