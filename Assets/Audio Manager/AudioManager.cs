using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : Singleton<AudioManager> {
    
    class ClipInfo {
        public AudioSource source { get; set; }
        public float defaultVolume { get; set; }

    }

    private List<ClipInfo> m_activeAudio;
    private AudioSource m_activeMusic;
    private AudioSource m_activeVoiceOver;
    private float m_volumeMod, m_volumeMin;
    private bool m_VOFade; //used to fade other effects for VO
    private bool m_BKGFade;
    void Awake() {
        m_activeAudio = new List<ClipInfo>();
        m_volumeMod = 1;
        m_volumeMin = 0.2f;
        m_VOFade = false;
        m_BKGFade = false;
        m_activeVoiceOver = null;
        m_activeMusic = null;

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

    public AudioSource Play(AudioClip clip, Transform emitter, float volume) {
        var source = Play(clip, emitter.position, volume);
        source.transform.parent = emitter;
        return source;
    }

    public AudioSource PlayLoop(AudioClip loop, Transform emitter, float volume) {
        GameObject movingSoundLoc = new GameObject("Audio: " + loop.name);
        movingSoundLoc.transform.position = emitter.position;
        movingSoundLoc.transform.parent = emitter;

        //Create the source
        AudioSource source = movingSoundLoc.AddComponent<AudioSource>();
        SetSource(ref source, loop, volume);
        source.loop = true;
        source.Play();
        //set the source as active
        m_activeAudio.Add(new ClipInfo { source = source, defaultVolume = volume });
        return source;
    }

    public AudioSource PlayMusic(AudioClip music, float volume) {
        m_activeMusic = PlayLoop(music, transform, volume);
        return m_activeMusic;
    }

    public AudioSource PlayVoiceOver(AudioClip voiceOver, float volume) {
        AudioSource source = Play(voiceOver, transform, volume);
        m_activeVoiceOver = source;
        m_VOFade = true;
        
        return source;
    }
    public void FadeMusic() {
        m_VOFade = true;
    }

    private void SetSource(ref AudioSource source, AudioClip clip, float volume) {
        source.rolloffMode = AudioRolloffMode.Logarithmic;
        source.dopplerLevel = 0.2f;
        source.minDistance = 150;
        source.maxDistance = 1500;
        source.clip = clip;
        source.volume = volume;
    }

    public void StopSource(AudioSource toStop) {
        try {
            Destroy(m_activeAudio.Find(s => s.source == toStop).source.gameObject);
        }
        catch {
            Debug.Log("Error trying to stop audio source " + toStop);
        }
    }

    public void PauseFX() {
        foreach (var audioClip in m_activeAudio) {
            try {
                if (audioClip.source != m_activeMusic) {
                    audioClip.source.Pause();
                }
            }
            catch {
                continue;
            }
        }
    }

    public void UnpauseFX() {
        foreach(var audioClip in m_activeAudio) {
            try {
                if (!audioClip.source.isPlaying) {
                    audioClip.source.Play();
                }
            }
            catch {
                continue;
            }
        }
    }

    private void UpdateActiveAudio() {
        var toRemove = new List<ClipInfo>();
        try {
            if (!m_activeVoiceOver) {
                m_VOFade = false;
            }
            foreach(var audioClip in m_activeAudio) {
                if (!audioClip.source) {
                    toRemove.Add(audioClip);
                }
                else if(audioClip.source != m_activeVoiceOver) {
                    audioClip.source.volume = audioClip.defaultVolume * m_volumeMod;
                }
            }

        }
        catch {
            Debug.Log("Error updating active audio clips");
            return;
        }
        foreach(var audioClip in toRemove) {
            m_activeAudio.Remove(audioClip);
        }
    }

    void Update() {
        //fade volume for VO
        if (m_VOFade && m_volumeMod >= m_volumeMin) {
            m_volumeMod -= 0.1f;

        }
        else if (!m_VOFade && m_volumeMod < 1.0f) {
            m_volumeMod += 0.1f;
        }
        if (m_BKGFade && m_volumeMod >= m_volumeMin) {
            m_volumeMod -= 0.1f;

        }
        else if (!m_BKGFade && m_volumeMod < 1.0f) {
            m_volumeMod += 0.1f;
        }

        UpdateActiveAudio();
    }
}
