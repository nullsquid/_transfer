using UnityEngine;
using System.Collections;
using TransferInput;
public class InputMain : MonoBehaviour {


    InputController input;
	// Update is called once per frame
	void OnGUI () {
	    if(input == null)
        {
            input = new InputController();
        }
        Debug.Log(input);
        Debug.Log(Event.current);
        input.UpdateInput(Event.current);
	}
}
