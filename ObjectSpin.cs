using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0 * Time.deltaTime, 3, 0);
    }

 private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        // Get the CharacterManager script from the player object
        CharacterManager characterManager = other.GetComponent<CharacterManager>();

        // Check if the CharacterManager script is found
        if (characterManager != null)
        {
            // Call the AddCoins method on the CharacterManager instance
            characterManager.AddCoins(5);

            // Access the numberOfCoins property through the instance
            Debug.Log("Coins: " + CharacterManager.numberOfCoins);

            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("CharacterManager script not found on the player.");
        }
    }
}
}
