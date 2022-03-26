
using UnityEngine;

public class EnableChildrenOnEnter:MonoBehaviour
{
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<movement>()!= null)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        foreach (var item in GetComponents<Collider>())
        {
            item.enabled = false;
        }

        Destroy(this);
      
    }
}
