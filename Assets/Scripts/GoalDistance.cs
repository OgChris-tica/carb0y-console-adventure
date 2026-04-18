using UnityEngine;
using TMPro;

public class GoalDistance : MonoBehaviour
{
    [Header("Player Reference")]
    public Transform player;        // Drag gamer player sphere here
    public float winDistance = 2f;  // Distance to trigger win condition

    [Header("UI Reference")]
    public GameObject winTextObject;   // Drag WinText GameObject here
    public TextMeshProUGUI winText;    // Drag TMP Text component here

    private bool hasWon = false;

    void Update()
    {
        if (!hasWon && Vector3.Distance(transform.position, player.position) < winDistance)
        {
            hasWon = true;

            string message = "You overcame the obstacles with positivity!";
            Debug.Log(message);

            // Showing UI message
            if (winTextObject != null && winText != null)
            {
                winTextObject.SetActive(true);
                winText.text = message;
            }

            // Changing goal color safely
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.green;
            }
        }
    }
}