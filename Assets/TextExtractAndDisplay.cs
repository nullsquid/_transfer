using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
public class TextExtractAndDisplay : MonoBehaviour {
	public ConvTree tree;
	public string curPrompt;
	public string outText;
	public List<string> curResponses = new List<string>();
	public InterfaceElementController displayInterface;
	public Text mainText;
	public Text responses;

	private UnityAction triggerNewNodeText;
	private UnityAction triggerNewResponseText;
    
    // Use this for initialization
	void Awake(){
		tree = GetComponent<TreeTraversal>().curTree;

		triggerNewNodeText = new UnityAction(GetNewText);
		triggerNewResponseText = new UnityAction(GetNewResponses);
	}
	void OnEnable(){
		EventManager.StartListening("getNewNodeText", triggerNewNodeText);
		EventManager.StartListening("getNewResponseText", triggerNewResponseText);
	}

	void OnDisable(){
		EventManager.StopListening("getNewNodeText", triggerNewNodeText);
		EventManager.StopListening("getNewResponseText", triggerNewResponseText);
        
    }
	void Start () {

		//TODO might need to change to describe as the starting node in the tree
		//new variable or somesuch for the initial text


		curPrompt = tree.curNode.prompt;
		for(int i = 0; i < tree.curNode.responses.Count; i++){
			curResponses.Add(tree.curNode.responses[i]);
		}
		GetNewText();
		GetNewResponses();
	}
	void Update(){
		//Debug.Log (curPrompt);
		//Debug.Log(curResponses);
	}

	//TODO trigger with an event
	public void GetNewText(){
		StartCoroutine("CoGetNewText");
	}
	public void GetNewResponses(){
		StartCoroutine("CoGetNewResponses");
	}

	private IEnumerator CoGetNewResponses(){
		curResponses.RemoveAt(0);
		responses.text = "";
		//for(int i = 0; i < tree.curNode.responses.Count; i++){
		foreach(string response in tree.curNode.responses){
			//Debug.Log(response);
			//Debug.Log ("Responses " + response);

			curResponses.Add (response);

			responses.text +=  tree.curNode.responses.IndexOf(response) + ": " + response;

		}

		/*foreach(string newResponse in curResponses){
			responses.text += ": " + newResponse;
		}*/
        /*for(int j = 0; j <= curResponses.Count; j++){
			responses.text += j + ": " + curResponses[j];

		}*/
		yield return null;
	}
	IEnumerator WaitToPrint(string newText){
		EventManager.TriggerEvent("disableCommand");
		responses.enabled = false;
		yield return new WaitForSeconds(2.0f);
		responses.enabled = true;
		EventManager.TriggerEvent("enableCommand");
		EventManager.TriggerEvent("getNewResponseText");
		mainText.text = mainText.text + "\n \n" + newText;
	}

	private IEnumerator CoGetNewText(){

		curPrompt = tree.curNode.prompt;

		DisplayText(NameReplace(curPrompt).ToUpper());
		Debug.Log("cur prompt is " + curPrompt);

		yield return null;
	}


	//TODO put "characters" list in nodes and make sure that the node knows who is speaking at a given time for replacement
	public string NameReplace(string inText){
		if(inText.Contains("Well")){
			//return inText.Replace("Well", "bloop");
			return inText;
		}
		return inText;
	}
	//TODO see above, but for pronouns
	public string PronounReplace(string inText){

		return null;
	}

	//TODO placeholder; this should probably go in a different class

	public void DisplayText(string newText){
		mainText.text = mainText.text + "\n \n" + GetComponent<TreeTraversal>().lastChoice.ToUpper();
		StartCoroutine(WaitToPrint(newText));
        
        //StartCoroutine(WaitToPrint(newText));
        
        
        //Debug.Log("new text is " + newText);
	}

}
