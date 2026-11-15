using UnityEngine;
using UnityEngine.Audio;

public class AmbienceController : MonoBehaviour
{
    [Header("Sonidos")]
    public AudioSource cityAmbience;
    public AudioSource interiorAmbience;

    [Header("Snapshots")]
    public AudioMixerSnapshot exteriorSnapshot;
    public AudioMixerSnapshot interiorSnapshot;

    [Header("Transicion")]
    public float transitionTime = 2f;

    void Start()
    {
        cityAmbience.Play();
        interiorAmbience.Play();

        exteriorSnapshot.TransitionTo(0f);
    }

    public void PlayCity()
    {
        exteriorSnapshot.TransitionTo(transitionTime);
    }

    public void PlayInterior()
    {
        interiorSnapshot.TransitionTo(transitionTime);
    }
}
