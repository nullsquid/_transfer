using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TextParser : MonoBehaviour {


	//will take a text file and turn it into a dictionary
	//the key will be the player line and the value will be the NPC line
	//
	//might be useful to have a different dictionary for each character
	//public TextAsset textA = null;
	public TextAsset textA = null;
	public string readerA = @"E:\Games in Progress\_transfer\_transfer\Assets\test.txt";

	// Use this for initialization
	void Start () {
		//Dictionary<string, string> fullText = new Dictionary<string, string>();
		//string a = textA.ToString();
		//a.Split

		//Dictionary<string,string> fullTextA = new Dictionary<string,string>();

		ReadFromFile();
	
	}
	
	// Update is called once per frame
	void Update () {

		//print (a);
	}

	private void ReadFromFile(){
	
		StreamReader reader = new StreamReader(readerA);

		string a = reader.ReadLine();

		while(a != null){
			char[] delimiter = {'A'};
			string[] fields = a.Split(delimiter);
			//string.trim


			a = reader.ReadLine();
			Debug.Log(fields[0]);
			Debug.Log(fields[1]);
		}




	}
}
