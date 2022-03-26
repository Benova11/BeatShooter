using System;
using System.Collections.Generic;
using UnityEngine;
public  class WindowsManager: MonoBehaviour
{
    public static HashSet<WindowsManager> OpneWindows = new HashSet<WindowsManager>();
    public static bool isVisble => OpneWindows.Count > 0;

    
    private CanvasGroup _canvasGroup;


    public void OpneWindow()
    { 
        OpneWindows.Add(this);
        if (_canvasGroup != null)
        {
           
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0;
        }
    }

    public void CloseWindow()
    { 
        OpneWindows.Remove(this);
        if (_canvasGroup != null)
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            if (OpneWindows.Count == 0)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            Time.timeScale = 1;

        }
    }

   
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }


}