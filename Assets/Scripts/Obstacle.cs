using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit obstacle! Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}