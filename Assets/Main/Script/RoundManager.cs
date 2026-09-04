using UnityEngine;
using System.Collections;
using TMPro;

public class RoundManager : MonoBehaviour
{
    [Header("スポナー")]
    public ZombieSpawner[] spawners;

    [Header("ラウンド設定")]
    public int round = 1;
    public int zombiesPerRound = 10;

    [Header("スポーン設定")]
    public float spawnInterval = 1f;

    [Header("ラウンド表示")]
    public TMP_Text roundText;
    public float roundTextDuration = 2f;

    private int aliveZombies;

    void Start()
    {
        StartCoroutine(StartRound());
    }

    IEnumerator StartRound()
    {
        aliveZombies = zombiesPerRound;

        // ラウンド表示
        roundText.text = "ROUND " + round;
        roundText.gameObject.SetActive(true);

        // ラウンド表示を2秒
        yield return new WaitForSeconds(roundTextDuration);

        // テキストを消す
        roundText.gameObject.SetActive(false);

        Debug.Log("Round " + round + " 開始！");

        // 徐々にゾンビを出す
        for (int i = 0; i < zombiesPerRound; i++)
        {
            // 登録されているスポナーからランダム選択
            ZombieSpawner spawner =
                spawners[Random.Range(0, spawners.Length)];

            // ゾンビ1体出現
            spawner.SpawnOne();

            // 次のゾンビまで待つ
            yield return new WaitForSeconds(spawnInterval);
        }

        // 全ゾンビが倒されるまで待つ
        while (aliveZombies > 0)
        {
            yield return null;
        }

        Debug.Log("Round " + round + " クリア！");

        // 次のラウンド
        round++;

        // 次のラウンドまで3秒
        yield return new WaitForSeconds(3f);

        StartCoroutine(StartRound());
    }

    public void ZombieKilled()
    {
        aliveZombies--;

        if (aliveZombies < 0)
        {
            aliveZombies = 0;
        }

        Debug.Log("ゾンビ撃破！ 残り：" + aliveZombies);
    }
}