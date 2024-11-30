using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnDealy;


    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnDealy);
    }

    public void SpawnEnemy()
    {
        var obj = PoolManager.Instance.Get();
        obj.transform.position = spawnPoint.position;
    }
}
