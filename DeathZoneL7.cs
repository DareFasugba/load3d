using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZoneL7 : MonoBehaviour
{
   void OnTriggerEnter(Collider other) {
    Destroy(other.gameObject);
   SceneManager.LoadScene(28);
   }
}
