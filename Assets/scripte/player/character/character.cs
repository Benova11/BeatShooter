using UnityEngine;

public class character: MonoBehaviour
{
    public string CharacterName;
    public Sprite Icon;

    private void Awake()
    {
        CharacterName = gameObject.name;
    }
}
