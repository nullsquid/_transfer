using UnityEngine;
using System.Collections;
using TransferInput;
public class InputTest : MonoBehaviour {
    public InputController input;
	// Use this for initialization
	void Start () {
	    if(input == null)
        {
            input = new InputController();
        }
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(input);
        Debug.Log("test 4: " + input.ReturnText);
	}
}
