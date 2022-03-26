using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "game event")]
public class WorldEvent : ScriptableObject
{
    static HashSet<WorldEvent> _ListEvents = new HashSet<WorldEvent>();
    HashSet<GameEventLisner> gameEventLisners = new HashSet<GameEventLisner>();

    public void Registar(GameEventLisner gameEventLisner)
    {
        gameEventLisners.Add(gameEventLisner);
        _ListEvents.Add(this);
    }

    public void deRegistar(GameEventLisner gameEventLisner)
    {
        gameEventLisners.Remove(gameEventLisner);
        if (gameEventLisners.Count == 0)
            _ListEvents.Remove(this);
    }

    [ContextMenu("invoke")]
    public void Inovke()
    {
        foreach (var item in gameEventLisners)
        {
            item.RaiseEvent();
        }
    }

    public static void RaiseEvent(string eventName)
    {
        foreach (var item in _ListEvents)
        {
            if (item.name == eventName)
                item.Inovke();
        }
    }
}
