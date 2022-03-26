using UnityEngine;

public enum TypeOfReword
{
    coins,item,quest
}
[CreateAssetMenu (menuName = "objectivesReword" )]
public class ObjectivesReword : ScriptableObject
{
    public TypeOfReword type;
    public int GiveAmount = 1;
    public Item item;
    public Objective NextObjective;
}