using UnityEngine;
using System.Collections;

public class quadPlay : MonoBehaviour {

	public MovieTexture movTexture;

	// Use this for initialization
	void Start () {
		MovieTexture t = (MovieTexture)this.GetComponent<Renderer>().material.mainTexture;
		t.loop = true;
		t.Play();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
