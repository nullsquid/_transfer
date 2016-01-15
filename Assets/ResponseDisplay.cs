using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ResponseDisplay : MonoBehaviour {
    public GameObject[] responses;
    public List<int> responseNumbers = new List<int>();
    // Use this for initialization
    void OnEnable() {
        EventManager.StartListening("setupResponses", SetUpResponses);
    }
    void OnDisable() {
        EventManager.StopListening("setupResponses", SetUpResponses);
    }
    void SetUpResponses() {
        for(int i = 0; i < responses.Length; i++) {
            responses[i].GetComponent<TextMesh>().color = Color.green;
            responses[i].GetComponent<TextMesh>().text = "";
        }
        
    }

    int NumberResponses() {
        
        for(int i = 0; i < responses.Length; i++) {
            if(responses[i].GetComponent<TextMesh>().text != "") {
                responseNumbers.Add(i);
            }
            
        }
        return 0;

    }

    void Update() {
        
    }

}
