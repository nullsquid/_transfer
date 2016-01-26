using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour {

	// Use this for initialization
	void Start () {

        EventManager.TriggerEvent("setupCamera");
        EventManager.TriggerEvent("makeCharacters");
        EventManager.TriggerEvent("uiSetup");

        EventManager.TriggerEvent("findStartTree");
        //EventManager.TriggerEvent("getCharacterInfo");
        EventManager.TriggerEvent("uiImageInit");
        EventManager.TriggerEvent("audioSetup");
        EventManager.TriggerEvent("setUpResponses");
        EventManager.TriggerEvent("getNodes");
        //EventManager.TriggerEvent("TESTNodeTraversal");        
	}
    
	
}
