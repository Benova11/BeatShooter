using Cinemachine;

using UnityEngine;

public class CameraController : WindowsManager
{
    [SerializeField] CinemachineVirtualCamera followCamera;
    [SerializeField] CinemachineVirtualCamera FpsCamera;
 
    [SerializeField] CinemachineFreeLook freeLoockCamera;
    [SerializeField]float mouseLookSenstivity =1f;

    CinemachineComposer aim;
    bool _inSettings;

    void Awake()
    {
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();

        FindObjectOfType<mouseLoocker>().OnCursorVisible += CameraController_OnCursorVisible;
    }

    private void CameraController_OnCursorVisible(bool obj)
    {
        _inSettings = obj;
    }

    void Update()
    {
        if (_inSettings) return;
            if (Input.GetMouseButtonDown(1))
            {
                freeLoockCamera.Priority = 100;
                freeLoockCamera.m_RecenterToTargetHeading.m_enabled = false;
            }
            else if (Input.GetMouseButtonUp(1))
            {
                freeLoockCamera.Priority = 1;
                freeLoockCamera.m_RecenterToTargetHeading.m_enabled = true;
            }
        
            if (Input.GetMouseButtonDown(1) == false && isVisble== false)
            {
                var mouseVertical = Input.GetAxis("Mouse Y") * mouseLookSenstivity;

                aim.m_TrackedObjectOffset.y += mouseVertical;
                aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, -10f, 10f);
            }
        
    }
}
