using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 playerVelocity;
    public AudioSource walkingAudio;

    public float speed = 5f;

    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    private PlayerAnimationManager playerAnimationManager;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        playerAnimationManager = GetComponent<PlayerAnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y;

        var playerMovementVelocity = transform.TransformDirection(moveDirection) * speed * Time.deltaTime;

        if (playerMovementVelocity.x == 0 && playerMovementVelocity.z == 0)
        {
            walkingAudio.Pause();
        }
        else
        {
            if (!walkingAudio.isPlaying) walkingAudio.Play();
        }

        playerAnimationManager.PlayMovementAnimations(playerMovementVelocity);

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
