using UnityEngine;

public class GetInfoWithControl : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private KeyCode Key;
    [SerializeField] private LayerMask TargetLayer;
    public GameObject[] Targets { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            GetObjects();
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
