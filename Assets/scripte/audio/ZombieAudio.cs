using UnityEngine;

public class ZombieAudio: MonoBehaviour
{
    [SerializeField] simpleAduioEvent randomSound;
    [SerializeField] simpleAduioEvent _dieSound;
    AudioSource _audioSource;

    float timer;
    float randomNam;
    Health _health;
    bool isAlive = true;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _health = GetComponent<Health>();
      
        randomNam = Random.Range(1, 3);
    }
    private void Start()
    {
        _health.OnDie += _health_OnDie;
    }

    private void _health_OnDie()
    {
        Debug.Log("1");
        isAlive = false;
        _audioSource.Stop();   
        _dieSound.Play(_audioSource);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if ( timer > randomNam && isAlive == true)
        {
           
            randomSound.Play(_audioSource);
            randomNam = Random.Range(1, 3);
            timer = 0;
        }
    }
}
