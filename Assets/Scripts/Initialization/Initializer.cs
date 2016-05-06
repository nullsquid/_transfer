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
        //it breaks after FindStartTree
        //NOTE: FindStartTree and GetCharacterInfo both are returning null somehow--both are on the same script
        EventManager.TriggerEvent("findStartTree");
        EventManager.TriggerEvent("getCharacterInfo");
        /////////////////////////////////////////
        EventManager.TriggerEvent("uiImageInit");
        //EventManager.TriggerEvent("audioSetup");
        EventManager.TriggerEvent("setUpResponses");
        EventManager.TriggerEvent("getNodes");
        //Debug.Log("hello");
        //EventManager.TriggerEvent("TESTNodeTraversal");        
        
	}
    
	
}
