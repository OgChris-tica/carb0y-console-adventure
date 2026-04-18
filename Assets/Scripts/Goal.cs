using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private Renderer rend;

    [Header("Final Message")]
    public GameObject victoryText; // Assign in Inspector

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (victoryText != null)
        {
            victoryText.SetActive(false); // Hide at start
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Level Complete!");

            // Turn goal green
            rend.material.color = Color.green;

            // Freeze player (polish)
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            // Show final message ONLY on Level 3
            int currentIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentIndex == 3)
            {
                if (victoryText != null)
                {
                    victoryText.SetActive(true);
                }

                Invoke("LoadMainMenu", 3f); // Slightly longer for message
            }
            else
            {
                Invoke("LoadNextLevel", 1.5f);
            }
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}