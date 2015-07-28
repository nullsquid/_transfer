using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConvNode : MonoBehaviour {

	public string prompt;
	public bool hasVisited;
	public List<string> responses = new List<string>();
	public List<ConvNode> children = new List<ConvNode>();

	List<ConvNode> nodeChildren = new List<ConvNode>();

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
