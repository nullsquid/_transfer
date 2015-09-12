using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
public class TreeTraversal : MonoBehaviour {

	//HACK
	//temporary until we can get the tree automatically
	public ConvTree curTree;
	public string lastChoice;
	public CharacterMananger cManager;


	//some way of getting the current conversation tree
	/*
	 * 
	*/
	public List<ConvTree> childTrees = new List<ConvTree>();

	void OnEnable(){

	}
	
	void OnDisable(){
	}
	
	void Awake(){

		foreach(Transform child in transform){
			childTrees.Add (child.gameObject.GetComponent<ConvTree>());
		}

	}
	void Start(){
		cManager = GetComponent<ConvTreeManager>().characterM;
		//curTree = LoadStartTree(cManager.charPlayer.charID);

	}

	public ConvTree LoadStartTree(string playerID){
		ConvTree startingTree;
		//send event here
		string startingTreeName = "9" + playerID + "_Tree";
		startingTree = GameObject.Find(startingTreeName).GetComponent<ConvTree>() as ConvTree;
		Debug.Log(startingTree + " is tree");
		return startingTree;
	}
	public ConvTree LoadNewTree(ConvNode node){

		//handle switching tree
		if(node.outLinkedTrees != null){
			return node.outLinkedTrees[0];
		}
		return null;
    }




	public void LoadNewNode(ConvTree tree, int choice){
		//if tree == null, call LoadTree
		//if reached end of current tree, call LoadTree
		ConvNode curNode;
		curNode = tree.curNode;
		lastChoice = curNode.responses[choice];
		//TODO put in its own function
		/*
		if(curNode.children.Count <= 0){
			if(curNode.outLinkedTrees.Count > 0){
			curTree = curNode.outLinkedTrees[0];
			tree = curTree;
			//TODO way to check if last node has finished all that it needs to
			//probably by way of coroutine
			curNode = tree.branches[1].gameObject.GetComponent<ConvNode>();
			Debug.Log("new tree");
			//curNode = tree.curNode;
			}
			else if (curNode.outLinkedTrees.Count <= 0){

				Debug.Log("Game Over");
			}
		}*/

		for(int i = 0; i < curNode.children.Count; i++){
			//TODO see if finding by child index works better
			//if(curNode.children[i] != null && curNode.children[i].decision == choice){
			if(curNode.children.Count > 0){
			if(i == choice){
				if(curNode.children.Count > 0){
				tree.curNode = curNode.children[i];
				EventManager.TriggerEvent("getNewNodeText");
				EventManager.TriggerEvent("getNewResponseText");
				//Debug.Log(tree.curNode.prompt);
				}
			}
			
			}

			//TODO need to fire this when the event triggers the next node to happen
			/*if(curNode.children.Count == 0){
				if(curNode.outLinkedTrees.Count == 1){


				}
			}*/
		}
		if(curNode.children.Count <= 0){
			curTree = LoadNewTree(curNode);
			curNode = curTree.branches[0].GetComponent<ConvNode>();
		}

	

	}
	//TODO 
	private IEnumerator CoConversationStep (ConvNode node){
		yield return null;
		//if(
	}
	/*public ConvNode FindNewNode(ConvTree tree, int decision){
		tree.curLevel += 1;
		//TODO likely problematic--if i hit 0 a bunch it just increments the level
		//should probably look at the node's children and pick from them
		for(int i = 0; i < tree.branches.Count; i++){

			if(tree.branches[i].gameObject.GetComponent<ConvNode>().level == (tree.curLevel)){
				Debug.Log(tree.branches[i]);
				if(tree.branches[i].gameObject.GetComponent<ConvNode>().decision == decision){
					Debug.Log(tree.branches[i]);
					return tree.branches[i].gameObject.GetComponent<ConvNode>() as ConvNode;
				//Debug.Log(tree.curNode);
				//Debug.Log(tree.branches[i]);
				//TODO this logic looks fucked
				/*if(tree.branches[i].GetComponent<ConvNode>().decision == ChooseNode(curTree, 0)){
					Debug.Log(tree.branches[i]);
					ConvNode newNode = tree.branches[i].GetComponent<ConvNode>();
					Debug.Log(newNode);
					return  newNode as ConvNode;

				}
				}
				else{
					return null;
				}
			}
		}
		return null;
	}*/
	/*
	public void NodeChange(ConvTree tree, int choice){

		//if(tree.curNode.responses.Count <= choice){
			
		ConvNode newNode = FindNewNode(tree, choice);
		//Debug.Log(newNode);
			if(tree.curNode = null){
				tree.curNode = newNode;
				Debug.Log(newNode);
			}
			//return newNode;
		//}

		//return null;
	}
*/



	

}
