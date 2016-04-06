using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour {
    private static AudioManager audioManager;
    public List<AudioClip> soundEffects = new List<AudioClip>();
    public List<AudioSource> audioSources = new List<AudioSource>();
    Dictionary<string, AudioClip> soundDictionary;

    public static AudioManager instance {
        get {
            if (!audioManager) {
                audioManager = FindObjectOfType(typeof(AudioManager)) as AudioManager;
                if (!audioManager) {
                    Debug.LogError("There needs to be an active audiomanager script in the scene");
                }
                else {
                    audioManager.Init();
                }
            }
            return audioManager;
        }
    }

    void Init() {
        if (soundDictionary == null) {
            soundDictionary = new Dictionary<string, AudioClip>();
        }
        SetupAudio();
    }
    //should run at start
    private void SetupAudio() {
        foreach (AudioClip sound in soundEffects) {
            soundDictionary.Add(sound.name, sound);
        }


    }

    public static void AssignSounds(string clipID, int source) {
        instance.audioSources[source].clip = instance.soundDictionary[clipID];
    }

    public static void PlaySound(string clipID, int source) {

        instance.audioSources[source].Play();
    }
}
