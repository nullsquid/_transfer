using UnityEngine;
using System.Collections;

public class ConvTreeManager : MonoBehaviour {

	public CharacterMananger characterM;
	public Init initializer;
	public TextReader reader;
	public ConvTree treePrefab;

	PathEditor pathEditor;
	public string player;
	// Use this for initialization
	void Start () {
		pathEditor = gameObject.GetComponent<PathEditor>();
		player = characterM.charPlayer.charID;
		MakeTree(player);

	}
	void MakeTree(string playerID){
		switch(playerID){
			case "A":
				Debug.Log(playerID);
				//Instantiate(treePrefab
				break;
			case "C":
				
				break;
			default:
				Debug.Log("no player");
				break;
		}
	}
}
