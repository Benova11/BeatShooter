using UnityEngine;

public class spawnable : polledMonoBehaviour
{
    [SerializeField] float returnToPoolDelay = 10;

    private void Start()
    {
        if (GetComponent<Health>() != null)
        GetComponent<Health>().OnDie += () => ReturnToPool(returnToPoolDelay);
    }
}
