using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
public class TextExtractAndDisplay : MonoBehaviour {
	public ConvTree tree;
	public ConvTree startTree;
	public string curPrompt;
	public string outText;
	public List<string> curResponses = new List<string>();
	public InterfaceElementController displayInterface;
	public Text mainText;
	public Text responses;
	public string speaker;
	public CharacterMananger cManager;

	private UnityAction triggerNewNodeText;
	private UnityAction triggerNewResponseText;
    

	ConvTree oldTree;
	ConvTree newTree;
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
		tree = GetComponent<TreeTraversal>().curTree;


		for(int i = 0; i < tree.curNode.responses.Count; i++){
			curResponses.Add(tree.curNode.responses[i]);
		}
		GetNewText();
		GetNewResponses();
	}
	void Update(){
		//HACK probably want to put in a coroutine
		curPrompt = tree.curNode.prompt;
		//Debug.Log (curPrompt);
		//Debug.Log(curResponses);
		//HACK 
		//the following line might be necessary but i'm not sure
		//tree = GetComponent<TreeTraversal>().curTree;

	}

	//TODO trigger with an event
	public void GetNewText(){
		StartCoroutine("CoGetNewText");
	}

	public void GetNewResponses(){
		StartCoroutine("CoGetNewResponses");
	}

	private IEnumerator CoGetNewResponses(){
		curResponses.Clear();
		//curResponses.RemoveAt(0);
		responses.text = "";
		//for(int i = 0; i < tree.curNode.responses.Count; i++){
		foreach(string response in tree.curNode.responses){


			curResponses.Add (response);

			responses.text +=  tree.curNode.responses.IndexOf(response) + ": " + response;

		}

	
		yield return null;
	}
	IEnumerator WaitToPrint(string newText){
		float waitTime = 0;
		EventManager.TriggerEvent("disableCommand");
		responses.enabled = false;
		//mainText.text = mainText.text + "\n \n" + "...";
		if(newText.Length <= 10){
			waitTime = Random.Range(.5f, 1.5f);
		}
		else if(newText.Length > 10 && newText.Length <=30){
			waitTime = Random.Range(1.5f, 3.0f);
		}
		else if (newText.Length >30 && newText.Length<=50){
			waitTime = Random.Range(3.0f, 4.5f);
		}
		else if(newText.Length > 50){
			waitTime = Random.Range(4.5f, 6.5f);
		}

		yield return new WaitForSeconds(waitTime);
		responses.enabled = true;
		EventManager.TriggerEvent("enableCommand");
		EventManager.TriggerEvent("getNewResponseText");

		//mainText.text.Replace("...", newText);
		for(int i = 0; i < cManager.characters.Length; i++){
			if(cManager.characters[i].charID == tree.curNode.characterTalking){
				speaker = cManager.characters[i].charName;
			}
		}
		mainText.text = mainText.text + "\n \n" + speaker + ": " + newText;
	}

	private IEnumerator CoGetNewText(){

		curPrompt = tree.curNode.prompt;

		DisplayText(NameReplace(curPrompt).ToUpper());
		//Debug.Log("cur prompt is " + curPrompt);

		yield return null;
	}


	//TODO put "characters" list in nodes and make sure that the node knows who is speaking at a given time for replacement
	public string NameReplace(string inText){
		if(inText.Contains("%H")){
			return inText.Replace("%H", cManager.nameH);

		}
		else if (inText.Contains("%F")){
			return inText.Replace("%F", cManager.nameF);
		}
		return inText;
	}
	//TODO see above, but for pronouns
	public string PronounReplace(string inText){

		return null;
	}

	//TODO placeholder; this should probably go in a different class

	public void DisplayText(string newText){
		if(GetComponent<TreeTraversal>().lastChoice != ""){
			mainText.text = mainText.text + "\n \n" + cManager.charPlayer.charName +": " + GetComponent<TreeTraversal>().lastChoice.ToUpper();
		}
		StartCoroutine(WaitToPrint(newText));
        
        //StartCoroutine(WaitToPrint(newText));
        
        
        //Debug.Log("new text is " + newText);
	}


}
