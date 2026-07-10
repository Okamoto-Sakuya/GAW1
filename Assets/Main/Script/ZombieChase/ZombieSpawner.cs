using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    public Transform[] spawnPoints;

    public float spawnInterval = 1f;

    public IEnumerator SpawnWave(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, spawnPoints.Length);

            Instantiate(
                zombiePrefab,
                spawnPoints[index].position,
                spawnPoints[index].rotation
            );

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}