using UnityEngine;
using System.Collections;
using SimpleJSON;


public class TextReader : MonoBehaviour {
	//public TextAsset text;
	//JSON N = JSON.Parse(
	public TextAsset text; //= Resources.Load("JSONTEST") as TextAsset; //= //Resources.Load("JSONTest") as TextAsset;
	public TextAsset _1A;
	public TextAsset _1B;
	public TextAsset _1C;
	public TextAsset _1D;
	public TextAsset _1E;
	public TextAsset _1F;

	public TextAsset _9A;

	//string N = JSON.Parse(text.text);
	//string N = JSON.Parse(
	// Use this for initialization
	void Start(){
		var N = JSONNode.Parse(text.text);
		//string N = JSON.Parse(text.text);
		//Debug.Log(N);
		//int version = N["version"].Value;
		Debug.Log(N["version"].Value);
		//Parse()

	}
	void Update(){

	}
	void Parse(string text){

	}
}
