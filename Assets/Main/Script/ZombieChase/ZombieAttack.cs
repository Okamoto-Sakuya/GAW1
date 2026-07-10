using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieAttack : MonoBehaviour
{
    public string sceneName; // Inspector‚Å“ü—Í

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}