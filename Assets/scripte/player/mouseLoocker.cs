using System;
using UnityEngine;

public class mouseLoocker : MonoBehaviour
{

    public event Action<bool> OnCursorVisible = delegate{};

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        OnCursorVisible(Cursor.visible);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Cursor.visible == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (Cursor.visible == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            OnCursorVisible(Cursor.visible);
        }
    }

}
