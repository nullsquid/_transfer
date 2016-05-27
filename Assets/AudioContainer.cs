using UnityEngine;
using System.Collections;

public class AudioContainer : MonoBehaviour {
    public AudioClip startDrone;
    public AudioClip harshDrone;
    void OnEnable()
    {

        EventManager.StartListening("audioInit", AudioInit);
        EventManager.StartListening("changeAudio", ChangeAudio);
    }

    void OnDisable()
    {
        EventManager.StopListening("audioInit", AudioInit);
        EventManager.StopListening("changeAudio", ChangeAudio);
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
        AM.PlayMusic(harshDrone, 0.5f);
    }
    
}
