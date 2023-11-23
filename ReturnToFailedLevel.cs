using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToFailedLevel : MonoBehaviour
{
  private int currentSceneIndex;

    private void Start()
    {
        // Get the current scene index
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadPreviousScene()
    {
        // Calculate the previous scene index
        int previousSceneIndex = currentSceneIndex - 1;

        // Check if the previous scene index is valid (greater than or equal to 0)
        if (previousSceneIndex >= 0)
        {
            // Load the previous scene by index
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("No previous scene available.");
        }
    }
}
