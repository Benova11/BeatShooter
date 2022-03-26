using UnityEngine;

public class PickUpItemReuqerd : MonoBehaviour, IMet
{
    [SerializeField] Objective Robjective;
    public bool Met()
    {
        return Robjective.MissionAccomplished;
    }
}