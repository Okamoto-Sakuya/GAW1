using UnityEngine;
using UnityEngine.AI;

public class ZombieChase : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Playerタグのオブジェクトが見つかりません。");
        }
    }

    void Update()
    {
        if (player == null) return;

        agent.SetDestination(player.position);
    }
}