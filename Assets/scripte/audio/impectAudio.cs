using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class impectAudio : MonoBehaviour
{
    [SerializeField] simpleAduioEvent aduioEvent;
    AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        GetComponent<Health>().OnTookHit += ImpectAudio_OnTookHit;
    }

    private void ImpectAudio_OnTookHit()
    {
        aduioEvent.Play(_audioSource);
    }

}
