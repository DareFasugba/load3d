using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI CoinsText;

    private string coinsKey = "PlayerCoins";

    void Start()
    {
        LoadCoins();
    }

    void Update()
    {
        CoinsText.text = "Coins: " + numberOfCoins;
    }

    // Call this function whenever you want to increase the coin count
    public void AddCoins(int amount)
    {
        numberOfCoins += amount;
        SaveCoins();
    }

    public void SubtractCoins(int amount)
    {
        numberOfCoins = Mathf.Max(0, numberOfCoins - amount);
        SaveCoins();
    }

    // Save the current coin count to PlayerPrefs
    private void SaveCoins()
    {
        PlayerPrefs.SetInt(coinsKey, numberOfCoins);
        PlayerPrefs.Save();
    }

    // Load the saved coin count from PlayerPrefs
    private void LoadCoins()
    {
        if (PlayerPrefs.HasKey(coinsKey))
        {
            numberOfCoins = PlayerPrefs.GetInt(coinsKey);
            Debug.Log("Loaded coins: " + numberOfCoins);
        }
        else
        {
            // Set a default value if no saved value is found
            numberOfCoins = 0;
            Debug.Log("No saved coins found. Setting to default: " + numberOfCoins);
        }
    }
}
