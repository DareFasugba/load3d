using UnityEngine;
using UnityEngine.UI;

public class JumpController : MonoBehaviour
{
    public float jumpHeight = 2.0f;
    public float gravity = 9.8f;

    private CharacterController characterController;
    private float ySpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Assuming you have a UI button in your scene with the name "JumpButton"
        Button jumpButton = GameObject.Find("Button").GetComponent<Button>();

        // Attach the Jump method to the button's click event
        jumpButton.onClick.AddListener(Jump);
    }

    void Update()
    {
        // Apply gravity
        ySpeed -= gravity * Time.deltaTime;

        // Apply vertical movement
        Vector3 verticalMove = new Vector3(0, ySpeed, 0);
        characterController.Move(verticalMove * Time.deltaTime);
    }

    void Jump()
    {
        // Check if the character is grounded before allowing a jump
        if (characterController.isGrounded)
        {
            // Calculate jump speed based on jump height and apply it
            ySpeed = Mathf.Sqrt(2 * jumpHeight * gravity);
        }
    }
}
