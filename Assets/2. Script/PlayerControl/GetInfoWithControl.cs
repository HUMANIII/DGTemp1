using UnityEngine;

public class GetInfoWithControl : MonoBehaviour
{
    [SerializeField] private float _distance = 5f;
    [SerializeField] private KeyCode Key;
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
        var temp = Physics2D.CircleCastAll(transform.position, _distance, Vector2.zero);
        Targets = new GameObject[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            Targets[i] = temp[i].collider.gameObject;
        }
    }
}
