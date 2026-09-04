using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [Header("ゾンビ")]
    public GameObject zombiePrefab;

    [Header("スポーン地点")]
    public Transform[] spawnPoints;

    public void SpawnOne()
    {
        if (zombiePrefab == null)
        {
            Debug.LogWarning("ZombiePrefabが設定されていません！");
            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("SpawnPointが設定されていません！");
            return;
        }

        // このスポナー内のスポーン地点をランダム選択
        int index = Random.Range(0, spawnPoints.Length);

        Instantiate(
            zombiePrefab,
            spawnPoints[index].position,
            spawnPoints[index].rotation
        );
    }
}