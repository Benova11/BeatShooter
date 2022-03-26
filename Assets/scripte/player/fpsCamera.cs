
using UnityEngine;
using Cinemachine;
using System;

public class fpsCamera : MonoBehaviour
{
    [SerializeField] float mouseLookSenstivity =100;
    [SerializeField]  Weapon _weapon;

    [SerializeField] CinemachineVirtualCamera FpsCam;
    float normalPov;
    [SerializeField] float scoopPov;

    float timer;
    private float startingIntensstiy;
    private float timerTotal;

    public float RicoilSenstivity { get; private set; }


    private void Awake()
    {
        FpsCam = GetComponent<CinemachineVirtualCamera>();
        _weapon.onFire += _weapon_onFire;
        _weapon.setRicoil += _weapon_setRicoil;
        normalPov = FpsCam.m_Lens.FieldOfView;
    }

    private void _weapon_setRicoil(float ricoail)
    {
        RicoilSenstivity = ricoail;

    }

    private void OnEnable()
    {

    }

    private void _weapon_onFire()
    {

        transform.Rotate(Vector3.Lerp(Vector3.zero, -Vector3.right *RicoilSenstivity,1- (Time.deltaTime /0.1F)));
    }


    void Update()
    {
       

       if (Input.GetMouseButtonDown(1))
        {
            FpsCam.m_Lens.FieldOfView = scoopPov;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            FpsCam.m_Lens.FieldOfView = normalPov;
        }
    }
    //colld on shoting
    private void ShakeCamera(float intenstiy, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = FpsCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intenstiy;

        startingIntensstiy = intenstiy;
        timerTotal = time;

        timer = time;

    }
    // call on update
    private void ShakeCameraRetrnToNormal()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = FpsCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensstiy, 0f, 1 - (timer / timerTotal)); ;


        }
    }

    private void LateUpdate()
    {

         float mouseVertical;
        mouseVertical = Input.GetAxis("Mouse Y") * mouseLookSenstivity * Time.deltaTime; ;
        transform.Rotate( -mouseVertical * Vector3.right);
    }
}
