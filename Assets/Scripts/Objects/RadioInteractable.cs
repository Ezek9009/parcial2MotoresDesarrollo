
using UnityEngine;

public class RadioInteractable : Interactable
{
    [Header("Audio")]
    public AudioSource radioAudio;
    public AudioClip[] stations;

    private bool isPlaying = false;
    private int currentStation = -1;

    public override void Interact()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            ChangeStation();
        }
        else
        {
            ChangeStation();
        }
    }

    void ChangeStation()
    {
        if (stations.Length == 0)
            return;

        int newStation;

        do
        {
            newStation = Random.Range(0, stations.Length);
        }
        while (stations.Length > 1 && newStation == currentStation);

        currentStation = newStation;

        radioAudio.clip = stations[currentStation];
        radioAudio.Play();
    }
}
