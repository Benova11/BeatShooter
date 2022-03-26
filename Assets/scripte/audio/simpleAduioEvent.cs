using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "audio event")]
public class simpleAduioEvent : ScriptableObject
{
    [SerializeField] AudioClip[] Clips = new AudioClip[0];
    [SerializeField] rangedFlot volume = new rangedFlot(1, 1);
    [SerializeField] [minMaxRanged(0f, 2f)] rangedFlot ptich = new rangedFlot(1, 1);
    [SerializeField] [minMaxRanged(0f, 1000f)] rangedFlot distance = new rangedFlot(1, 1000);

    [SerializeField] AudioMixerGroup Mixer;
    public void Play(AudioSource source)
    {
        source.outputAudioMixerGroup = Mixer;
        int clipIndex = Random.Range(0, Clips.Length);
        source.clip = Clips[clipIndex];

        source.pitch = Random.Range(ptich._minValue, ptich._maxValue);
        source.volume = Random.Range(volume._minValue, volume._maxValue);


        source.minDistance = distance._minValue;
        source.maxDistance = distance._maxValue;

        source.Play();
    }

    public void startEvent()
    {
        Play(AudioManager.instcne.setAudioSours());
    } 

}
