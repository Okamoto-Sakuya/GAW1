using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Hit: " + collision.gameObject.name);
        ZombieHealth zombie = collision.gameObject.GetComponent<ZombieHealth>();

        if (zombie != null)
        {
            zombie.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}