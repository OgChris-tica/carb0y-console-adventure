using UnityEngine;

public class EncouragementPillar : MonoBehaviour
{
    [Header("Message Settings")]
    public string message = "Lock in. You will win.";

    [Header("Boost Settings (Optional)")]
    public bool giveBoost = true;
    public Vector3 boostForce = new Vector3(0, 5, 8);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(message);

            if (giveBoost)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.AddForce(boostForce, ForceMode.Impulse);
                }
            }
        }
    }
}