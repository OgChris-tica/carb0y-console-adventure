using UnityEngine;

public class CapsulePowerUp : MonoBehaviour
{
    public GameObject spherePlayer;
    public GameObject capsulePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == spherePlayer)
        {
            capsulePlayer.transform.position = spherePlayer.transform.position;

            spherePlayer.SetActive(false);
            capsulePlayer.SetActive(true);

            Destroy(gameObject);
        }
    }
}