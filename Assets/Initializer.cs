using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour {

	// Use this for initialization
	void Start () {

        EventManager.TriggerEvent("setupCamera");
        EventManager.TriggerEvent("makeCharacters");
        EventManager.TriggerEvent("findStartTree");
        EventManager.TriggerEvent("uiSetup");
        EventManager.TriggerEvent("uiImageInit");
        EventManager.TriggerEvent("getNodes");

	}
	
}
