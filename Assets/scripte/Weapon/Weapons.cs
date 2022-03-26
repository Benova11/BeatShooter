using UnityEngine;

public class Weapons: MonoBehaviour
{

    [SerializeField] GameObject firstPersonObject;
    [SerializeField] GameObject thirdPersonObject;
    public bool isFpsMode { get; set; }
    [SerializeField] KeyCode toggleKey = KeyCode.F1;


    private void Update()
    {
        if (isFpsMode)
        {
            transform.position = firstPersonObject.transform.position;
            transform.rotation = firstPersonObject.transform.rotation;
        }
        else
        {
            transform.position = thirdPersonObject.transform.position;
            transform.rotation = thirdPersonObject.transform.rotation;
        }
    }
}
