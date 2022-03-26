using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inspectblePnel : MonoBehaviour
{
    [SerializeField] GameObject text;
    private void OnEnable()
    {
        PickUpItem.onItemPickitUp += AudioLog_onAudioPick;
    }

    private void AudioLog_onAudioPick(bool obj)
    {
        text.SetActive(obj);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
