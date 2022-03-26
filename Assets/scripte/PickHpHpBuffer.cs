using UnityEngine;

public class PickHpHpBuffer: MonoBehaviour
{
    [SerializeField] int ammontToGive = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<movement>())
        {
            GetComponent<Health>().modifyHealth(ammontToGive);
            Destroy(gameObject);
        }
    }
}
