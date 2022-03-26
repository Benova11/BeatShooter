using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : WindowsManager
{

    public static AudioManager instcne;
    AudioSource _audioSource;
    private void Start()
    {
        CloseWindow();
    }
    private void Update()
    {
        if (isVisble)
        {
            _audioSource.Pause();
        }
        else
        {
            _audioSource.UnPause();
        }

    }
    public void Awake()
    {
        instcne = this;
       _audioSource = GetComponent<AudioSource>();
    }
    public AudioSource setAudioSours()
    {
        return _audioSource;
    }
}
