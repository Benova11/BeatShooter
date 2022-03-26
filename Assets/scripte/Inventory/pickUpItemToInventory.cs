using UnityEngine;

public class pickUpItemToInventory: MonoBehaviour
{
    public InventoryItem item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<movement>())
        {
            if (InventoryOfItem.instance.thereIsSapce)
            {
                InventoryOfItem.instance.AddItem(item);
                Destroy(gameObject);
            }
        }
    }

}
