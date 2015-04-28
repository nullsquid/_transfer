using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;


public class TextReader : MonoBehaviour {

	public List<TextAsset> _9 = new List<TextAsset>();
	public List<TextAsset> _8 = new List<TextAsset>();
	public List<TextAsset> _7 = new List<TextAsset>();
	public List<TextAsset> _6 = new List<TextAsset>();
	public List<TextAsset> _5 = new List<TextAsset>();
	public List<TextAsset> _4 = new List<TextAsset>();
	public List<TextAsset> _3 = new List<TextAsset>();
	public List<TextAsset> _2 = new List<TextAsset>();
	public List<TextAsset> _1 = new List<TextAsset>();


	int blockNumber = 0;
	string W;
	string[] responses = new string[2];
	string val;
	//public string[] test = new string[2];

	//string N = JSON.Parse(text.text);
	//string N = JSON.Parse(
	// Use this for initialization
	void Start(){
		var _9A = JSONNode.Parse(_9[0].text);
		Debug.Log(_9A["C"]["1"]["prompt"]);
		//var N = JSONNode.Parse(_9A.text);
		var W = JSONNode.Parse(_9[0].text);

		//val = N["C"]["2"]["responses"][1];
		//string N = JSON.Parse(text.text);
		//Debug.Log(N);
		//int version = N["version"].Value;
		//Debug.Log(N["version"].Value);
		//Debug.Log(N["C"]["1"]["prompt"]);
		//Debug.Log(N["C"]["2"]["prompt"]);
		//Debug.Log(val);
		//Parse()
		//var W = JSONNode.Parse(_9A.text);
		//W = JSONNode.Parse(_9A.text);
		//responses[0] = W["C"]["2"]["responses"];

	}
	void Update(){


	}
	void Parse(string text){

	}
}
