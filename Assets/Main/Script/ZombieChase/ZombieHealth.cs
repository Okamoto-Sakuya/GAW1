using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    private RoundManager roundManager;

    void Start()
    {
        currentHP = maxHP;

        roundManager = FindFirstObjectByType<RoundManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (roundManager != null)
        {
            roundManager.ZombieKilled();
        }

        Destroy(gameObject);
    }
}