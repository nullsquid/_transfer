using UnityEngine;
using System.Collections;

public class AudioContainer : MonoBehaviour {
    public AudioClip startDrone;
    public AudioClip harshDrone;
    public float startTimer = 0f;
    void OnEnable()
    {

        EventManager.StartListening("audioInit", AudioInit);
        EventManager.StartListening("changeAudio", ChangeAudio);
        EventManager.StartListening("stopAllAudio", StopAllAudio);
    }

    void OnDisable()
    {
        EventManager.StopListening("audioInit", AudioInit);
        EventManager.StopListening("changeAudio", ChangeAudio);
        EventManager.StopListening("stopAllAudio", StopAllAudio);

    }

    // Use this for initialization


    void AudioInit()
    {
        var AM = AudioManager.Instance;
        AM.PlayMusic(startDrone, 0.5f);

    }
    void ChangeAudio()
    {
        var AM = AudioManager.Instance;
        AM.Play(harshDrone, Vector3.zero, 0.5F);
        //if(start)
        
    }

    void StopAllAudio() {
        var AM = AudioManager.Instance;
        AM.PauseFX();
    }
    
}
