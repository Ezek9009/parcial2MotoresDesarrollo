
using UnityEngine;

public class DoubleDoorInteractable : Interactable
{
    public Transform leftDoorPivot;
    public Transform rightDoorPivot;

    public float openAngle = 90f;
    public float rotateSpeed = 90f;

    public AudioSource doorAudio;

    private Quaternion leftClosedRotation;
    private Quaternion rightClosedRotation;

    private Quaternion leftOpenRotation;
    private Quaternion rightOpenRotation;

    private bool isOpen = false;

    private void Start()
    {
        leftClosedRotation = leftDoorPivot.localRotation;
        rightClosedRotation = rightDoorPivot.localRotation;

        leftOpenRotation = leftClosedRotation * Quaternion.Euler(0, -openAngle, 0);

        rightOpenRotation = rightClosedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    public override void Interact()
    {
        isOpen = !isOpen;

        if (doorAudio != null)
        {
            doorAudio.Play();
        }
    }

    private void Update()
    {
        Quaternion leftTarget = isOpen ? leftOpenRotation : leftClosedRotation;
        Quaternion rightTarget = isOpen ? rightOpenRotation : rightClosedRotation;

        leftDoorPivot.localRotation = Quaternion.RotateTowards(leftDoorPivot.localRotation, leftTarget, rotateSpeed * Time.deltaTime);

        rightDoorPivot.localRotation = Quaternion.RotateTowards(rightDoorPivot.localRotation, rightTarget, rotateSpeed * Time.deltaTime);
    }
}
