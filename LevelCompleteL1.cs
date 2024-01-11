using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteL1 : MonoBehaviour
{
   void OnTriggerEnter(Collider other) {
    Destroy(other.gameObject);
   SceneManager.LoadScene(2);
   }
}
