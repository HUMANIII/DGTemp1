using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private int InitCount;
    [SerializeField] private PoolableObj prefab;
    private Queue<PoolableObj> pool = new();

    private static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            instance ??= FindFirstObjectByType<PoolManager>();
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        for (int i = 0; i < InitCount; i++)
        {
            AddObject();
        }
    }

    public GameObject Get()
    {
        if (pool.Count <= 0)
        {
            AddObject();
        }

        var script = pool.Dequeue();
        script.OnGet();
        GameObject obj = script.gameObject;
        obj.SetActive(true);
        return obj;
    }

    public void Release(PoolableObj obj)
    {
        obj.OnRelease();
        pool.Enqueue(obj);
    }

    private void AddObject()
    {
        GameObject obj = Instantiate(prefab.gameObject);
        var script = obj.GetComponent<PoolableObj>();
        script.OnRelease();
        pool.Enqueue(script);
    }
}
