using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleDistance : MonoBehaviour
{
    public Transform player;
    public float hitDistance = 1.5f;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < hitDistance)
        {
            Debug.Log("Hit obstacle! Restarting...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}