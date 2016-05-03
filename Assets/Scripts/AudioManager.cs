using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : Singleton<AudioManager> {
    
    void Awake() {
        Debug.Log("Audiomanager initializing");
        try {
            transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
            transform.localPosition = new Vector3(0, 0, 0);
        }
        catch {
            Debug.Log("Unable to find main camera");
        }
    }

}
