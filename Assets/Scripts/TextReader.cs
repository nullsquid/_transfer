﻿using UnityEngine;
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
	string W;
	string[] responses = new string[2];
	string val;
	//public string[] test = new string[2];

	//string N = JSON.Parse(text.text);
	//string N = JSON.Parse(
	// Use this for initialization
	void Start(){
		var N = JSONNode.Parse(_9A.text);

		val = N["C"]["2"]["responses"][1];
		//string N = JSON.Parse(text.text);
		//Debug.Log(N);
		//int version = N["version"].Value;
		//Debug.Log(N["version"].Value);
		Debug.Log(N["C"]["2"]["prompt"]);
		Debug.Log(val);
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
