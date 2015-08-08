using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConvNode : MonoBehaviour {

	//TODO make prompt a list
	//TODO make each sentence an item in that list
	//TODO loop over and split on period to dynamically parse
	public string prompt;
	public bool hasVisited;
	public List<string> responses = new List<string>();
	public ConvTree outLinkedTree;
	//public Memory memory

	public int level;
	public int decision;


	public List<ConvNode> children = new List<ConvNode>();

	List<ConvNode> nodeChildren = new List<ConvNode>();
	void Awake(){
		foreach(Transform child in transform){
			children.Add(child.gameObject.GetComponent<ConvNode>());
		}
	}
	void OnEnable(){
		//register an event to trigger a function that 
		//creates the tree
		//making a child for each response and nests it
		//might need to play with the JSON structure a bit

	}

	public string LinkToNode(){
		return null;
	}

}
