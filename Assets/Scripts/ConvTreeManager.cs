using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConvTreeManager : MonoBehaviour {

	public CharacterManager characterM;
	public Init initializer;
	public TextReader reader;
	public ConvTree treePrefab;
	//be able to look up the appropriate file by indexing it with a number
	//maybe should go in the path editor?
	//path editor will add to the dictionary based on the character that's selected
	//taking the data from textreader
	public Dictionary<int, string> indexedTextInSequence = new Dictionary<int, string>();
	public int currentFileIndex;

	//PathEditor pathEditor;

	/*TODO write recursive algorithm that 
	 * 
	 * sees currently processing JSON hub
	 * creates node with appropriate data as child of tree
	 * creates child nodes based on responses that are siblings of each other
	 * keeps going deeper until there is no more data for the tree
	 * 
	 * For traversal:
	 * has value for current node
	 * sees children
	 * only allows selection of one of the children
	 * moves to that node and displays data
	 * 
	 */
	/*
	public string player;
	// Use this for initialization
	void Start () {
		//pathEditor = gameObject.GetComponent<PathEditor>();
		player = characterM.charPlayer.charID;
		MakeTree(player);

	}
	void MakeTree(string playerID){
		switch(playerID){
			case "A":
				//Debug.Log(playerID);
				//Instantiate(treePrefab
				break;
			case "C":
				
				break;
			default:
				Debug.Log("no player");
				break;
		}
	}
	*/
}
