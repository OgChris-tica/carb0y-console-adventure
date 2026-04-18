using UnityEngine;
using TMPro;

public class MessageUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public GameObject messagePanel;

    public void ShowMessage(string message, float duration)
    {
        messageText.text = message;
        messagePanel.SetActive(true);

        CancelInvoke();
        Invoke("HideMessage", duration);
    }

    void HideMessage()
    {
        messagePanel.SetActive(false);
    }
}