using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
public class ConvTree : MonoBehaviour {

	public PathEditor pathEditor;
	public ConvNode curNode;
	public int curLevel;
	ConvNode startNode;
	public List<Transform> branches = new List<Transform>();
	private Transform[] children;
	// Use this for initialization
	void Start () {
		curLevel = 1;
		//BuildTree();
		//foreach(Transform child in transform){
		//	branches.Add(child);
		//}
		children = gameObject.GetComponentsInChildren<Transform>();
		branches = children.OfType<Transform>().ToList();

		//branches = children
		//foreach(Transform child in gameObject.transform){
			//branches.Add(child);
		//}
		branches.RemoveAt(0);
		startNode = branches[0].GetComponent<ConvNode>() as ConvNode;
		curNode = startNode;
	}

	void BuildTree(){

	}
	

}
