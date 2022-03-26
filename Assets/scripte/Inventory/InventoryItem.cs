using UnityEngine;

[CreateAssetMenu(fileName ="InventoryItem",menuName = "InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
   
    public ItemType PostiveType;
    public ItemType NagtiveType;

    public Sprite icon;

    public int AmmountToGive=1;
    public int AmmountToTake=-1;

    public GameObject Prepab;
    public void OnUse()
    {
        if (PostiveType == ItemType.Food)
        {
            playerStats.instanc.AmmountOfFoodToReduce(AmmountToGive);
            playerStats.instanc.AmmountOfWaterToReduce(AmmountToTake);
           
           
        }      
        if (PostiveType == ItemType.Water)
        {
            playerStats.instanc.AmmountOfWaterToReduce(AmmountToGive);
            playerStats.instanc.AmmountOfFoodToReduce(AmmountToTake);
        }

        if (PostiveType == ItemType.Hp)
        {
            playerStats.instanc.GetComponent<Health>().modifyHealth(AmmountToGive);
        }
       
    }



   
}
