using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class TreeTraversal : MonoBehaviour {

	//HACK
	//temporary until we can get the tree automatically
	public ConvTree curTree;



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

	public int ChooseNode(ConvTree tree, int choice){

		return choice;
	}

	public ConvNode FindNewNode(ConvTree tree, int decision){
		for(int i = 0; i < tree.branches.Count; i++){
			if(tree.branches[i] != null){
				Debug.Log(tree.branches[i].GetComponent<ConvNode>().level);
			}
			if(tree.branches[i].GetComponent<ConvNode>().level == tree.curLevel){
				if(tree.branches[i].GetComponent<ConvNode>().decision == decision){
				tree.curNode = tree.branches[i].GetComponent<ConvNode>();
				Debug.Log(tree.curNode);
				//Debug.Log(tree.branches[i]);
				//TODO this logic looks fucked
				/*if(tree.branches[i].GetComponent<ConvNode>().decision == ChooseNode(curTree, 0)){
					Debug.Log(tree.branches[i]);
					ConvNode newNode = tree.branches[i].GetComponent<ConvNode>();
					Debug.Log(newNode);
					return  newNode as ConvNode;

				}*/
				}
			}
		}
		return null;
	}

	public ConvNode NodeChange(ConvTree tree, int choice){
		tree.curLevel += 1;

		ConvNode newNode = FindNewNode(tree, choice);
		tree.curNode = newNode;
		Debug.Log(newNode);

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
