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
	void Update(){

	}
	public int ChooseNode(ConvTree tree, int choice){
		FindNewNode(curTree);
		Debug.Log(choice);
		return choice;
	}

	public ConvNode FindNewNode(ConvTree tree){
		for(int i = 0; i <= tree.branches.Count; i++){
			if(tree.branches[i].GetComponent<ConvNode>().level == tree.curLevel){
				if(tree.branches[i].GetComponent<ConvNode>().decision == ChooseNode(curTree, 0)){
					Debug.Log(tree.branches[i]);
					return tree.branches[i].GetComponent<ConvNode>() as ConvNode;
				}
			}
		}
		return null;
	}

	public ConvNode NodeChange(ConvTree tree){

		return null;
	}

	//public

}
