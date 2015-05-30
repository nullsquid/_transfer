using UnityEngine;
using System.Collections;
using SimpleJSON;
public class JSONTest : MonoBehaviour {
	public TextAsset testVar; 
	// Use this for initialization
	void Start () {
		var test = JSONNode.Parse(testVar.text);
		Debug.Log("test is " + testVar);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
