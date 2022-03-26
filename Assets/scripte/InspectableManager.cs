using System.Linq;
using UnityEngine;

public class InspectableManager : MonoBehaviour
{
    static PickUpItem _currentAudioLog;

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentAudioLog = PickUpItem.InspectablesInRange.FirstOrDefault();
        }
        if (Input.GetKey(KeyCode.E) && _currentAudioLog != null)
        {
            _currentAudioLog.Inspect();

        }
        else
        {
            _currentAudioLog = null;
        }
    }
}
