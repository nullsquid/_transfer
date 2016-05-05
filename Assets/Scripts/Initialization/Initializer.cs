using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour {
    public AudioClip ambientDrone; 
	// Use this for initialization
	void Start () {
        var AM = AudioManager.Instance;
        AM.PlayMusic(ambientDrone, 0.5f);
        EventManager.TriggerEvent("setupCamera");
        EventManager.TriggerEvent("makeCharacters");
        EventManager.TriggerEvent("uiSetup");
        EventManager.TriggerEvent("setupTextCapture");
        EventManager.TriggerEvent("findStartTree");
        //EventManager.TriggerEvent("getCharacterInfo");
        EventManager.TriggerEvent("uiImageInit");
        EventManager.TriggerEvent("audioSetup");
        EventManager.TriggerEvent("setUpResponses");
        EventManager.TriggerEvent("getNodes");
        
        //EventManager.TriggerEvent("TESTNodeTraversal");        
        
	}
    
	
}
