using UnityEngine;

public class GetInfoWithControl : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private KeyCode Key;
    [SerializeField] private LayerMask TargetLayer;
    public GameObject[] Targets { get; private set; }

    private void OnEnable()
    {
        EventManager.AddEvent(EventManager.EventType.OnClickTab, GetObjects);
    }

    private void OnDisable()
    {
        EventManager.RemoveEvent(EventManager.EventType.OnClickTab, GetObjects);
    }

    private void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            EventManager.DoEvent(EventManager.EventType.OnClickTab);
        }
    }


    public void GetObjects()
    {
        var temp = Physics2D.CircleCastAll(transform.position, distance, Vector2.zero, distance, TargetLayer);
        Targets = new GameObject[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            Targets[i] = temp[i].collider.gameObject;
        }

        foreach (var target in Targets)
        {
            target.TryGetComponent(out PoolableObj poolableObj);
            PoolManager.Instance.Release(poolableObj);
        }
#if UNITY_EDITOR
        Debug.Log("GetObjResult");
        DebugPanel.LogMessage("GetObjResult");
        foreach (var target in Targets)
        {
            Debug.Log(target.name);
            DebugPanel.LogMessage(target.name);
        }
        Debug.Log("");
        DebugPanel.LogMessage("");
#endif
    }
}
