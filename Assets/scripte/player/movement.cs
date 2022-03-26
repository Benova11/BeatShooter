using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    CharacterController _characterController;
    [SerializeField] private float _moveSpeed =5;
    [SerializeField] private float _moveSideSpeed =2;
     Animator _animator;
    [SerializeField] float _rotationSpeed = 100;

    float horizontal;
    float vertical;
   
    public event Action<float,float> move = delegate { };
    Vector3 vel;
    float grabity = -9.81f;
    [SerializeField] Transform gruandCheck;
    [SerializeField] float gruandDistance;
    [SerializeField] LayerMask _layerMask;

    bool InSettings = false;
   public bool isGrounded()
    {
        if (Physics.CheckSphere(gruandCheck.position, gruandDistance, _layerMask))
        {
            return true;
        }
        return false;
    }



    [SerializeField] fpsToggle _fpsToggle;

    bool isAim => _fpsToggle.IsFpsMode;
   

    private void Awake()
    {
        _fpsToggle = GetComponent<fpsToggle>();
        _animator = GetComponentInChildren<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        FindObjectOfType<mouseLoocker>().OnCursorVisible += Movement_OnCursorVisible;
    }

    private void Movement_OnCursorVisible(bool CursorVisible)
    {
        InSettings = CursorVisible;
    }

    void Update()
    {

        if (InSettings)
        {
            horizontal = 0;
            vertical = 0;
            return;
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        var mouseHorizontal = Input.GetAxis("Mouse X");


       

        if (Input.GetMouseButton(1) == false && isAim == false)
        { 
            transform.Rotate(Vector3.up, mouseHorizontal * Time.deltaTime * _rotationSpeed);
        }
        else if (isAim == true)
        {
            transform.Rotate(Vector3.up, mouseHorizontal * Time.deltaTime * _rotationSpeed);
        }

       if (isGrounded() && vel.y <0)
        {
            vel.y = -2f;
        }
       vel.y += (grabity * Time.deltaTime);
     
    }
    private void FixedUpdate()
    {
        move(vertical, horizontal);
        _animator.SetFloat("speed_X", vertical);
        _animator.SetFloat("speed_y", horizontal);
        _characterController.Move((transform.forward * Time.deltaTime * _moveSpeed * vertical)+ (transform.right * Time.deltaTime * _moveSideSpeed * horizontal));
       // _characterController.Move(transform.right * Time.deltaTime * _moveSideSpeed * horizontal);

        _characterController.Move(vel * Time.deltaTime);
    }
}
