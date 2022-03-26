using UnityEngine;
using UnityEngine.Events;

public enum type
{
    audio,text
}
public enum ItemType
{
    Food,Water,Gun,Hp
}

[CreateAssetMenu(fileName ="item",menuName ="crateNewItem")]
public class Item: ScriptableObject
{
    public string itemName;
    public UnityEvent EventOnPick;
    public type Type;

    public simpleAduioEvent aduioEvent;
}
