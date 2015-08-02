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
		//ChooseNode(curTree, 0);
	}
	void Update(){

	}
	public int ChooseNode(ConvTree tree, int choice){
		ConvNode newNode = FindNewNode(curTree);
		//FindNewNode(curTree);
		Debug.Log(newNode);
//		Debug.Log(choice);
		return choice;
	}

	public ConvNode FindNewNode(ConvTree tree){
		for(int i = 1; i < tree.branches.Count; i++){
			if(tree.branches[i] != null){
				Debug.Log(tree.branches[i]);
			}
			if(tree.branches[i].GetComponent<ConvNode>().level == tree.curLevel){
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
		return null;
	}

	public ConvNode NodeChange(ConvTree tree){

		return null;
	}

	//public

}
