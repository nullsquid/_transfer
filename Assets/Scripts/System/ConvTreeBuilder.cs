using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConvTreeBuilder : MonoBehaviour {
	public CharacterMananger cManager;
	public TextManager tManager;

	public TextReader reader;
	public PlayerCharacter player;
	public ConvTree tree;
	//public ConvNode node;
	// Use this for initialization
	
	// Update is called once per frame
	void Start () {
		if(player == null){
			player = cManager.GetComponent<CharacterMananger>().charPlayer;

		}

	}

	ConvTree BuildTree(){

		return null;

	}
}
