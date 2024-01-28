using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        foreach (Sound _sound in sounds)
        {
            _sound.source = gameObject.AddComponent<AudioSource>();
            _sound.source.clip = _sound.clip;
            _sound.source.volume = _sound.volume;
            _sound.source.pitch = _sound.pitch;
            _sound.source.loop = _sound.loop;   
        }
    }

    private void Start()
    {
        //Play theme
    }

    public void PlaySound(string _soundName)
    {
        Sound _sound = Array.Find(sounds, sound => sound.name == name);
        if(_sound == null) 
        {
            Debug.Log("sound" + _sound.name + "is missing");
            return;
        }
        _sound.source.Play();
    }
}
