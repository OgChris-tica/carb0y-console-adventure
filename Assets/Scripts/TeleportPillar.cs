using UnityEngine;

public class TeleportPillar : MonoBehaviour
{
    public Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null && teleportTarget != null)
            {
                // Stop movement before teleport
                rb.linearVelocity = Vector3.zero;

                // Move player safely
                rb.position = teleportTarget.position;

                Debug.Log("Teleported!");
            }
        }
    }
}