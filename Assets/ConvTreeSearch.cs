using UnityEngine;
using System.Collections;

public class ConvTreeSearch : MonoBehaviour {
    
    ConvTree startTree;

    void OnEnable() {
        EventManager.StartListening("findStartTree", FindStartTree);
    }

    void OnDisable() {
        EventManager.StopListening("findStartTree", FindStartTree);
    }

    
    void FindStartTree() {
        Character playerCharacter = GameObject.FindObjectOfType<PlayerCharacter>();
        startTree = GameObject.Find("9" + playerCharacter.name + "_Tree").GetComponent<ConvTree>();
    }

    void IncomingConversation() {

    }

    void DisplayResponses() {

    }

    void DisplayPrompt() {

    }

    IEnumerator FirstConversation(){
        yield return new WaitForSeconds(1.0f);

    }
    
}
