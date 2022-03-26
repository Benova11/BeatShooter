using UnityEngine;
using System;
using UnityEngine.Events;

public class GameEventLisner:MonoBehaviour
{

    [SerializeField] UnityEvent _unityEvent;
    [SerializeField] WorldEvent GameEvent;

    private void Awake() => GameEvent.Registar(this);
    private void OnDisable() => GameEvent.deRegistar(this);

    public void RaiseEvent() => _unityEvent.Invoke();
}
