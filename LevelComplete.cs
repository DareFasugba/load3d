using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

     private int currentSceneIndex;
     
     void Start()
     {
         currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
     }
    void OnTriggerEnter(Collider other) {
   // Calculate the previous scene index
        int previousSceneIndex = currentSceneIndex + 2;
        UnlockNewLevel();

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

   void UnlockNewLevel() {
    if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
   }
}
