
using UnityEngine;

public class AmbienceZone : MonoBehaviour
{
    public AmbienceController ambienceController;
    public bool isInterior;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isInterior)
            {
                ambienceController.PlayInterior();
            }
            else
            {
                ambienceController.PlayCity();
            }
        }
    }
}
