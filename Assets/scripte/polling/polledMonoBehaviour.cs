using System;
using System.Collections;
using UnityEngine;

public class polledMonoBehaviour : MonoBehaviour
{
    [SerializeField] int poolSize = 50;

    public event Action<polledMonoBehaviour> OnReturnToPoll;
    public int InitialPoolSize => poolSize;

    public T Get<T>(bool enable = true) where T: polledMonoBehaviour
    {
        var pool = poll.getPool(this);
        var pooledObject = pool.get<T>();

        if (enable)
        {
            pooledObject.gameObject.SetActive(true);
        }

        return pooledObject;

    }
    public T Get<T>(Vector3 pos ,Quaternion rotation) where T : polledMonoBehaviour
    {
        var pooledObject = Get<T>();
        pooledObject.transform.position = pos;
        pooledObject.transform.rotation = rotation;
        return pooledObject;
    }

    private void OnDisable()
    {
        if (OnReturnToPoll != null)
        {
            OnReturnToPoll(this);
        }
    }
    public void ReturnToPool(float Delay)
    {
        StartCoroutine(EReturnToPool(Delay));
    }

    private IEnumerator EReturnToPool(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        gameObject.SetActive(false);
    }
}
