﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class TreeTraversal : MonoBehaviour {

	//HACK
	//temporary until we can get the tree automatically
	public ConvTree curTree;
	public string lastChoice;


	//some way of getting the current conversation tree
	/*
	 * 
	*/

	void OnEnable(){

	}
	
	void OnDisable(){
	}
	
	void Awake(){

	}
	void Start(){
		//FindNewNode(curTree);
		//StartNode(curTree);


	}
	
	public ConvNode FindNewNode(ConvTree tree, int decision){
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

				}*/
				}
				else{
					return null;
				}
			}
		}
		return null;
	}
	void Update(){
//		Debug.Log(curTree.curNode);
	}
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

	public void LoadNewNode(ConvTree tree, int choice){
		ConvNode curNode;
		curNode = tree.curNode;
		lastChoice = curNode.responses[choice];
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
		}
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
	

	}

	public ConvTree LoadNewTree(){

		return null;
	}


	/*public void StartNode(ConvTree tree){
		if(tree.curNode == null){
			Debug.Log("startnode is working");
			FindNewNode(tree);
		
		}

	}*/

	//public

}
