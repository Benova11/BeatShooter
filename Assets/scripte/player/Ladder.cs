using UnityEngine;

public class Ladder: MonoBehaviour
{
    public Transform chController;
    bool _inside = false;
    public float speed;
    movement _movement;

    private void Awake()
    {
        _movement = GetComponent<movement>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ladder")
        {
           // _movement.enabled = false;
            _inside = !_inside;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ladder")
        {
            
           // _movement.enabled = true;
        }
    }
    private void Update()
    {
        if (_inside && Input.GetKey(KeyCode.W))
        {
            GetComponent<CharacterController>().Move( Vector3.up * speed * Time.deltaTime);
        }  
        if (_inside && Input.GetKey(KeyCode.S))
        {
            GetComponent<CharacterController>().Move(Vector3.down * speed * Time.deltaTime);
        }



    }
}