using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {

	#region setup variables
	public string charName;
	public string charID;
	public string gender;
	public string pronoun;
	public bool isPlayer;
	#endregion

	#region alterable variables
	public float dispositionTowardsPlayer;
	public bool hasMetPlayer;
	public int level;
	//public Dictionary<string, Character> KnownCharacters = new Dictionary<string, Character>();
	#endregion

	void Start(){

	}



	void Connect(){
		Debug.Log(charName + " is connected with player");
	}
}
