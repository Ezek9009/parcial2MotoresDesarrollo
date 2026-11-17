using UnityEngine;
using System.Collections;

public class GoldenOrbSequenceManager : MonoBehaviour
{
    public GameObject inventoryIcon;
    public GameObject platformPrefab;
    public Transform platformSpawnPoint;
    public GameObject escapePoint;
    public TMPro.TMP_Text objectiveText;

    public AudioSource escapeAudioSource;

    public void Start()
    {
        if (objectiveText != null)
        {
            objectiveText.gameObject.SetActive(false);
        }
    }
    public void StartSequence()
    {
        StartCoroutine(PickupSequence());
    }

    private IEnumerator PickupSequence()
    {
        if (inventoryIcon != null)
            inventoryIcon.SetActive(true);

        if (platformPrefab != null && platformSpawnPoint != null)
            Instantiate(platformPrefab, platformSpawnPoint.position, platformSpawnPoint.rotation);

        if (objectiveText != null)
        {
            objectiveText.text = "¡Ve a la camioneta!";
            objectiveText.gameObject.SetActive(true);
        }

        if (escapePoint != null)
            escapePoint.SetActive(true);

        if (escapeAudioSource != null && escapeAudioSource.clip != null)
        {
            escapeAudioSource.Play();
            yield return new WaitForSeconds(escapeAudioSource.clip.length);
        }

        GameManager.Instance.ActivateAlarm();
    }
}