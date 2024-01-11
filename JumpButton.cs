using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    public MovementScript movementScript;

    private void Update()
    {
        // For testing purposes, check if the space bar is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar pressed");
            TryJump();
        }
    }

    public void OnJumpButtonClick()
    {
        Debug.Log("Jump button clicked");
        TryJump();
    }

    private void TryJump()
    {
        if (movementScript != null)
        {
            movementScript.PerformJump();
        }
        else
        {
            Debug.LogError("MovementScript is not assigned!");
        }
    }
}
