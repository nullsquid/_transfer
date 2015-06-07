using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CharacterToEdit{
	A,
	B,
	C,
	D,
	E,
	F,
	G,
	H,
	I,
	Z
};


public class PathEditor : MonoBehaviour {
	public CharacterToEdit dropdown = CharacterToEdit.A;
	public List<string> FilesForA = new List<string>();
	public List<string> FilesForB = new List<string>();
	public List<string> FilesForC = new List<string>();
	public List<string> FilesForD = new List<string>();
	public List<string> FilesForE = new List<string>();
	public List<string> FilesForF = new List<string>();
	public List<string> FilesForG = new List<string>();
	public List<string> FilesForH = new List<string>();
	public List<string> FilesForI = new List<string>();
	public List<string> FilesFor0 = new List<string>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame

}
