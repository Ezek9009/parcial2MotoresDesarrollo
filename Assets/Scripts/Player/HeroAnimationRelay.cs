
using UnityEngine;

public class HeroAnimationRelay : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;
    public Animator heroAnimator;

    private CharacterController characterController;
    private StarterAssets.StarterAssetsInputs inputs;
    private StarterAssets.ThirdPersonController playerController;

    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        inputs = player.GetComponent<StarterAssets.StarterAssetsInputs>();
        playerController = player.GetComponent<StarterAssets.ThirdPersonController>();

        if (heroAnimator == null)
            heroAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (characterController == null || inputs == null ||
            playerController == null || heroAnimator == null)
            return;

        Vector3 velocity = characterController.velocity;
        float horizontalSpeed = new Vector3(velocity.x, 0f, velocity.z).magnitude;

        heroAnimator.SetFloat("Speed", horizontalSpeed);
        heroAnimator.SetFloat("MotionSpeed", inputs.move.magnitude);

        bool grounded = playerController.Grounded;

        heroAnimator.SetBool("Grounded", grounded);
        heroAnimator.SetBool("Jump", !grounded && velocity.y > 0.1f);
        heroAnimator.SetBool("FreeFall", !grounded && velocity.y <= 0.1f);
    }
     public void OnLand()
    {
    }

    public void OnFootstep()
    {
    }
}
