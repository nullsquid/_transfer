using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;


public class TextReader : MonoBehaviour {
	/*
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
	public List<string> _9AChars = new List<string>();
	public List<string> _8CChars = new List<string>();

	int blockNumber = 0;
	string W;
	string[] responses = new string[2];
	string val;
	public ConvNode convNodePrefab;
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
		//JSONNode _8C = JSONNode.Parse(_8[2].text);
		var _8C = JSON.Parse(_8[2].text);
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
		ConvNode newConvNode;
		#region get _9 characters
		foreach(var key in _9A.Keys){
			_9AChars.Add(key);
		}
		#endregion
		#region get _8 characters
		foreach( var key in _8C.Keys )
		{

			Debug.Log(key);
			_8CChars.Add(key);

		}
		#endregion
		/*The following is how to get the top level key:
		 * 
		foreach( var key in _8C.Keys )
		{
			Debug.Log(key);
		}
		
		//TODO write this loop for all textassets==>maybe parse out the characters into either an array or dictionary

		//TODO figure out how to best use the keys gotten this way>>
		*/
		
		/*
		//Debug.Log(_8C["Character"][0]);

		for(int i = 0; i < _8C["C"].Count; i++){
			newConvNode = Instantiate(convNodePrefab, transform.position, transform.rotation) as ConvNode;
			//this doesn't extend out to all things because filename
			newConvNode.prompt = _8C["C"][i]["prompt"];
		
			for(int j = 0; j <= _8C["C"][i]["responses"].Count - 1; j++){
				newConvNode.responses.Add(_8C["C"][i]["responses"][j]);
			}
		}
		*/


	}

	/*
	//require 9 files every time
	//gets passed the character ID and loads all of the text associated with that character
	void SetPathTemplate(string characterID){

	}
	//returns all of the text for prompts
	string LoadText(){
		return null;
	}
	*/
	
//}
