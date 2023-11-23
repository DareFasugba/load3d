using UnityEngine;
using UnityEngine.UI; // Import the UI namespace

public class JumpButton : MonoBehaviour
{
    public MovementScript movementScript; // Reference to your MovementScript component
    private bool canJump = true;
    private float jumpCooldown = 1.0f; // Adjust the cooldown time as needed
    private float lastJumpTime = 0.0f;

    // Attach this method to the button's OnClick event in the Unity Inspector.
    public void OnJumpButtonClick()
{
    if (canJump && Time.time - lastJumpTime >= jumpCooldown)
    {
        if (movementScript != null)
        {
            movementScript.PerformJump(); // Call the jump method from MovementScript
            lastJumpTime = Time.time; // Record the time of the last jump
            canJump = false; // Set the flag to prevent rapid clicks
        }
    }
}

void Update()
{
    // Check if cooldown has passed and enable jumping again
    if (!canJump && Time.time - lastJumpTime >= jumpCooldown)
    {
        canJump = true;
    }

    // Rest of your Update() code...
}

}
