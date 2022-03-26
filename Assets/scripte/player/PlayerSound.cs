using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] simpleAduioEvent simpleAduioEvent;
    void Start()
    {
        GetComponent<movement>().move += PlayerSound_move;
    }

    private void PlayerSound_move(float arg1, float arg2)
    {
        if (arg1 != 0)
        {
            if (!_audioSource.isPlaying)
            {
                simpleAduioEvent.Play(_audioSource);
            }
        }
    }


}
