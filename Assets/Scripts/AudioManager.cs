using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : Singleton<AudioManager> {
    
    class ClipInfo {
        public AudioSource source { get; set; }
        public float defaultVolume { get; set; }

    }

    private List<ClipInfo> m_activeAudio;

    void Awake() {
        m_activeAudio = new List<ClipInfo>();

        Debug.Log("Audiomanager initializing");
        try {
            transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
            transform.localPosition = new Vector3(0, 0, 0);
        }
        catch {
            Debug.Log("Unable to find main camera");
        }
    }
    public AudioSource Play(AudioClip clip, Vector3 soundOrigin, float volume) {
        //Create an empty game object
        GameObject soundLoc = new GameObject("Audio: " + clip.name);
        soundLoc.transform.position = soundOrigin;

        //Create the source
        AudioSource source = soundLoc.AddComponent<AudioSource>();
        SetSource(ref source, clip, volume);
        source.Play();
        Destroy(soundLoc, clip.length);

        //Set the source as active
        m_activeAudio.Add(new ClipInfo { source = source, defaultVolume = volume });
        return source;
    }
    private void SetSource(ref AudioSource source, AudioClip clip, float volume) {

    }
}
