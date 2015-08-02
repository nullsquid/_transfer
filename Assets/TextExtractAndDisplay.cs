using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class TextExtractAndDisplay : MonoBehaviour {
	public ConvTree tree;
	public string curPrompt;
	public List<string> curResponses = new List<string>();
	// Use this for initialization
	void Awake(){
		tree = GetComponent<TreeTraversal>().curTree;

	}
	void Start () {
		//curPrompt = tree.curNode.prompt;
		//for(int i = 0; i <= tree.curNode.responses.Count; i++){
		//	curResponses.Add(tree.curNode.responses[i]);
		//}
	}
	void Update(){
		//if(
	}
	//TODO trigger with an event
	IEnumerator GetNewText(){

		curPrompt = tree.curNode.prompt;
		yield return null;
	}

}
