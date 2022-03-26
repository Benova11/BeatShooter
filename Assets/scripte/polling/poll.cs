
using System.Collections.Generic;
using UnityEngine;

public class poll : MonoBehaviour
{
    static Dictionary<polledMonoBehaviour, poll> _pools = new Dictionary<polledMonoBehaviour, poll>();
    Queue<polledMonoBehaviour> _objects = new Queue<polledMonoBehaviour>();
    polledMonoBehaviour _prefab;

    public static poll getPool(polledMonoBehaviour prefab)
    {
        if (_pools.ContainsKey(prefab))
        {
            return _pools[prefab];
        }

        var pool = new GameObject("pool- " + prefab.name).AddComponent<poll>();

        pool._prefab = prefab;

        _pools.Add(prefab, pool);
        return pool;
    }
    public T get<T>() where T: polledMonoBehaviour
    {
        if (_objects.Count == 0)
        {
            GrowPool();
        }
        var poolObjects = _objects.Dequeue();
        return poolObjects as T;
    }

    private void GrowPool()
    {
        for (int i = 0; i < _prefab.InitialPoolSize; i++)
        {
            var pooledObject = Instantiate(_prefab) as polledMonoBehaviour;
            pooledObject.gameObject.name += " " + i;

            pooledObject.OnReturnToPoll += addToAvailableQueue;

            pooledObject.transform.SetParent(this.transform);
            pooledObject.gameObject.SetActive(false);
        }
    }

     void addToAvailableQueue(polledMonoBehaviour polledObject)
    {
        polledObject.transform.SetParent(this.transform);
        _objects.Enqueue(polledObject);
    }
}
