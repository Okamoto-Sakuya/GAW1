using UnityEngine;
using System.Collections;

public class RoundManager : MonoBehaviour
{
    public ZombieSpawner[] spawners;

    public int round = 1;
    public int zombiesPerRound = 5;

    private int aliveZombies;

    void Start()
    {
        StartCoroutine(StartRound());
    }

    IEnumerator StartRound()
    {
        aliveZombies = zombiesPerRound;

        // 複数スポナーからランダム出現
        yield return StartCoroutine(
            spawners[Random.Range(0, spawners.Length)]
            .SpawnWave(zombiesPerRound)
        );

        while (aliveZombies > 0)
            yield return null;

        round++;

        zombiesPerRound += 3;

        yield return new WaitForSeconds(3);

        StartCoroutine(StartRound());
    }

    public void ZombieKilled()
    {
        aliveZombies--;
    }
}