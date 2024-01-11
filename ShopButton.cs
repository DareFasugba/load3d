using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour
{
    public Button buyButton;
    public TextMeshProUGUI coinText;
    public int cost = 800; // Set the cost of the item
    public CharacterManager characterManager; // Reference to the CharacterManager instance

    private void Start()
{
    // Load the purchased state
    int itemPurchased = PlayerPrefs.GetInt("ItemPurchased", 0);

    if (itemPurchased == 1)
    {
        // Item has been purchased, update UI and change to play button
        UpdateUI();
        ChangeToPlayButton();
        buyButton.interactable = true;
    }
    else
    {
        // Item has not been purchased, initialize UI accordingly
        UpdateUI();
    }

    buyButton.onClick.AddListener(BuyItem);
}

 void UpdateUI()
{
    if (characterManager != null)
    {
        coinText.text = "Coins: " + CharacterManager.numberOfCoins;

        int itemPurchased = PlayerPrefs.GetInt("ItemPurchased", 0);
        buyButton.interactable = CharacterManager.numberOfCoins >= cost && itemPurchased != 1;
    }
    else
    {
        Debug.LogError("CharacterManager reference is null. Assign it in the Unity Editor.");
    }
}

void BuyItem()
{
    if (characterManager != null)
    {
        if (CharacterManager.numberOfCoins >= cost)
        {
            // Deduct the cost from coins
            characterManager.SubtractCoins(cost);

            // Save the purchased state
            PlayerPrefs.SetInt("ItemPurchased", 1);
            PlayerPrefs.Save();

            // Update UI after purchasing
            UpdateUI();

            // Change the button to a play button or trigger scene transition
            ChangeToPlayButton();
            buyButton.interactable = true;
        }
        else
        {
            Debug.Log("Not enough coins to buy the item. Current coins: " + CharacterManager.numberOfCoins);
        }
    }
    else
    {
        Debug.LogError("CharacterManager reference is null. Assign it in the Unity Editor.");
    }
}

    void ChangeToPlayButton()
    {
        // Assuming you have a reference to the button's text
        TextMeshProUGUI buttonText = buyButton.GetComponentInChildren<TextMeshProUGUI>();

        // Change the button text to "Play" or whatever you want
        buttonText.text = "Play";

        // Attach a new listener or trigger the scene transition directly
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(PlayGame);
    }

    void PlayGame()
    {
        // Replace "YourSceneName" with the name of the scene you want to load
        SceneManager.LoadScene("2LevelSelection");
    }
}
