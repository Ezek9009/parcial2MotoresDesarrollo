using UnityEngine;
using UnityEngine.UIElements;

public class GoldenOrbInteractable : Interactable
{
    public GameObject inventoryIcon;

    public GameObject platformPrefab;
    public Transform platformSpawnPoint;
    public GameObject escapePoint;
    public TMPro.TMP_Text objectiveText;
    public AudioClip pickupSound;
    public AudioClip escapeSound;
    public AudioSource escapeAudioSource;

    private void Start()
    {
        if (escapePoint != null)
        {
            escapePoint.SetActive(false);
        }
        if (objectiveText != null)
        {
            objectiveText.gameObject.SetActive(false);
        }
    }
    public override void Interact()
    {
        StartCoroutine(PickupSequence());
    }

    private System.Collections.IEnumerator PickupSequence()
    {
        Debug.Log("Se ejecutó Interact de la reliquia");

        GameManager.Instance.hasGoldenOrb = true;

        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Intentando reproducir audio de escape");
        if (escapeAudioSource != null)
        {
           
            escapeAudioSource.Play();
            yield return new WaitForSeconds(escapeAudioSource.clip.length);
        }
        else
        {
            Debug.LogWarning("Escape Sound está vacío");
        }
        GameManager.Instance.ActivateAlarm();
        

        if (inventoryIcon != null)
            inventoryIcon.SetActive(true);

        if (platformPrefab != null && platformSpawnPoint != null)
        {
            Instantiate(platformPrefab, platformSpawnPoint.position, platformSpawnPoint.rotation);
        }

        if (objectiveText != null)
        {
            objectiveText.text = "¡Ve a la camioneta!";
            objectiveText.gameObject.SetActive(true);
        }
        if (escapePoint!=null)
        {
            escapePoint.SetActive(true);
        }

        Destroy(gameObject);
    }
}
