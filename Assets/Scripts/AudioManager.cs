using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour {
    public Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();
    public List<AudioClip> audioFiles = new List<AudioClip>();
    //public List<string> audioNames = new List<string>();
	// Use this for initialization
	void OnEnable() {
        EventManager.StartListening("audioSetup", AudioSetup);
    }

    void OnDisable() {
        EventManager.StopListening("audioSetup", AudioSetup);
    }

    void AudioSetup() {
        for(int i = 0; i < audioFiles.Count; i++) {
            sounds.Add(audioFiles[i].name, audioFiles[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void PlaySound(string soundName) {
        
    }
}
