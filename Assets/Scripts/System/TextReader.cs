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

	//List<string> 


	int blockNumber = 0;
	string W;
	string[] responses = new string[2];
	string val;
	//public string[] test = new string[2];

	//string N = JSON.Parse(text.text);
	//string N = JSON.Parse(
	// Use this for initialization
	void Start(){
		#region 9 variables
		var _9A = JSONNode.Parse(_9[0].text);
		#endregion

		#region 8 variables
		//var _8A = JSONNode.Parse(_8[
		var _8C = JSONNode.Parse(_8[2].text);
		#endregion

		#region 7 variables
		var _7C = JSONNode.Parse(_7[2].text);
		#endregion

		#region 6 variables
		var _6A = JSONNode.Parse(_6[0].text);
		#endregion

		#region 5 variables
		var _5C = JSONNode.Parse(_5[2].text);
		#endregion

		#region 4 variables
		var _4C = JSONNode.Parse(_4[2].text);
		#endregion

		#region 3 variables
		var _3A = JSONNode.Parse(_3[0].text);
		#endregion

		#region 2 variables
		var _2A = JSONNode.Parse(_2[0].text);
		#endregion

		#region 1 variables
		var _1A = JSONNode.Parse(_1[0].text);
		#endregion

		Debug.Log(_9A["C"]["1"]["prompt"]);
		for(int i = 0; i < _8C["C"].Count; i++){
			Debug.Log(_8C["C"][i]["prompt"]);
		}
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
	//require 9 files every time
	//gets passed the character ID and loads all of the text associated with that character
	void SetPathTemplate(string characterID){

	}
	//returns all of the text for prompts
	string LoadText(){
		return null;
	}
}
