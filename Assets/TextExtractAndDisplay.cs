using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class TextExtractAndDisplay : MonoBehaviour {
	public ConvTree tree;
	public string curPrompt;
	public string outText;
	public List<string> curResponses = new List<string>();
	// Use this for initialization
	void Awake(){
		tree = GetComponent<TreeTraversal>().curTree;

	}
	void OnEnable(){

	}

	void OnDisable(){

	}
	void Start () {
		//TODO might need to change to describe as the starting node in the tree
		//new variable or somesuch for the initial text

		StartCoroutine("GetNewText");
		curPrompt = tree.curNode.prompt;
		for(int i = 0; i < tree.curNode.responses.Count; i++){
			curResponses.Add(tree.curNode.responses[i]);
		}
	}
	void Update(){
		Debug.Log (curPrompt);
		Debug.Log(curResponses);
	}
	//TODO trigger with an event
	IEnumerator GetNewText(){

		curPrompt = tree.curNode.prompt;
		string newPrompt = NameReplace(curPrompt);

		Debug.Log(newPrompt);
		//curPrompt = PronounReplace(curPrompt);
		yield return null;
	}

	//TODO put "characters" list in nodes and make sure that the node knows who is speaking at a given time for replacement
	public string NameReplace(string inText){
		if(inText.Contains("Well")){
			return inText.Replace("Well", "bloop"); 
		}
		return null;
	}
	//TODO see above, but for pronouns
	public string PronounReplace(string inText){

		return null;
	}

}
