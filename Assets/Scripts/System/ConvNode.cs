using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConvNode : MonoBehaviour {

	public string prompt;
	public List<string> responses = new List<string>();

	List<ConvNode> nodeChildren = new List<ConvNode>();


	public string LinkToNode(){
		return null;
	}

}
