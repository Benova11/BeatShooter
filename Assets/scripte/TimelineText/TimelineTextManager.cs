using UnityEngine;
using UnityEngine.UI;

public class TimelineTextManager: MonoBehaviour
{
    public Text TextObject;

    public static TimelineTextManager instance;
    private void Awake()
    {
        instance = this;
    }
}