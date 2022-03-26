using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GameSettings: MonoBehaviour
{
    Resolution[] _resolution; 
    [SerializeField] TMP_Dropdown _resolutionDropdown;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] GameObject pnealFolder;

    private CanvasGroup canvasGroup;
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 100000;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        FindObjectOfType<mouseLoocker>().OnCursorVisible += GameSettings_OnCursorVisible;

            _resolution = Screen.resolutions;
        _resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int curResIndex = 0;
        for (int i = 0; i < _resolution.Length; i++)
        {
            var option = _resolution[i].width + " x " + _resolution[i].height;
            options.Add(option);
            if (_resolution[i].width == Screen.currentResolution.width 
                && _resolution[i].height == Screen.currentResolution.height)
            {
                curResIndex = i;
            }
        }
        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = curResIndex;
        _resolutionDropdown.RefreshShownValue();
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < pnealFolder.transform.childCount; i++)
        {
            pnealFolder.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    void GameSettings_OnCursorVisible(bool CursorVisibleity)
    {
        if (CursorVisibleity)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void SetQuality(int qulityIndex)
    {
        QualitySettings.SetQualityLevel(qulityIndex);
    }

    public void Set_resolution(int res)
    {
        Resolution resolution = _resolution[res];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }

    public void setFullScreen(bool t)
    {
        Screen.fullScreen = t;
    }
}
