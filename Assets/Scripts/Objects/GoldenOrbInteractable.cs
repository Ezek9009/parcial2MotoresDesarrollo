using UnityEngine;

public class GoldenOrbInteractable : Interactable
{
    public AudioClip pickupSound;
    public GoldenOrbSequenceManager sequenceManager;

    private bool collected = false;

    public override void Interact()
    {
        if (collected)
            return;

        collected = true;

        Debug.Log("Se recogió la reliquia");

        GameManager.Instance.hasGoldenOrb = true;

        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }

        if (sequenceManager != null)
        {
            sequenceManager.StartSequence();
        }
        else
        {
            Debug.LogWarning("No está asignado GoldenOrbSequenceManager");
        }

        Destroy(gameObject);
    }
}