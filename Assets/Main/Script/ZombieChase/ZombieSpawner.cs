using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;

    public float spawnInterval = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnZombie), 1f, spawnInterval);
    }

    void SpawnZombie()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Transform point = spawnPoints[index];

        Instantiate(zombiePrefab, point.position, point.rotation);
    }
}