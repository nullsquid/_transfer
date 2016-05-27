using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour {
    public AudioClip ambientDrone;
    public AudioClip startDrone;
	// Use this for initialization
	void Start () {
        EventManager.TriggerEvent("audioInit");
        EventManager.TriggerEvent("setupCamera");
        EventManager.TriggerEvent("makeCharacters");
        EventManager.TriggerEvent("uiSetup");
        EventManager.TriggerEvent("setupTextCapture");
        EventManager.TriggerEvent("findStartTree");
        //
        //EventManager.TriggerEvent("getCharacterInfo");
        EventManager.TriggerEvent("uiImageInit");
        EventManager.TriggerEvent("audioSetup");
        EventManager.TriggerEvent("setUpResponses");
        EventManager.TriggerEvent("getNodes");
        
        //EventManager.TriggerEvent("TESTNodeTraversal");        
        
	}
    
	
}
