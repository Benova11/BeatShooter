
using UnityEngine;

public class fpsToggle : MonoBehaviour
{

    [SerializeField] GameObject[] firstPersonObject;
    [SerializeField] GameObject[] thirdPersonObject;
    [SerializeField] KeyCode toggleKey = KeyCode.F1;
    private bool isFpsMode;
    private Weapons _weapons;
    public bool IsFpsMode => isFpsMode;

    private void Awake()
    {
        _weapons = FindObjectOfType<Weapons>();
        Toggle();
    }
    private void OnEnable()
    {
        ToogleToCurMod();
    }
    void Update()
    {
     if (Input.GetKeyDown(toggleKey))
        {
            Toggle();
        }   
    }

    private void Toggle()
    {
        isFpsMode = !isFpsMode;
        _weapons.isFpsMode = isFpsMode;
        ToogleToCurMod();
    }

    private void ToogleToCurMod()
    {
        foreach (var item in firstPersonObject)
        {
            item.SetActive(isFpsMode);
        }
        foreach (var item in thirdPersonObject)
        {
            item.SetActive(!isFpsMode);
        }
    }
}
