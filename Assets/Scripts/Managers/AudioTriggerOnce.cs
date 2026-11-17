using UnityEngine;

public class AudioTriggerUnaVez : MonoBehaviour
{
    public AudioSource audioSource;

    private bool yaSeReprodujo = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !yaSeReprodujo)
        {
            audioSource.Play();
            yaSeReprodujo = true;
        }
    }
}