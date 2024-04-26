using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class CapsuleCollector : MonoBehaviour
{
    // Reference to the Canvas text component to display the count
    public TextMeshProUGUI countText;

    // Number of capsules collected
    private int capsulesCollected = 0;

    // Called when the capsule GameObject collides with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected"); // Add this line for debugging

        // Check if the colliding GameObject is tagged as "Player" (the ball)
        if (other.CompareTag("Player"))
        {
            // Increment the count of capsules collected
            capsulesCollected++;

            // Log the updated value of capsulesCollected
            Debug.Log("Capsules collected: " + capsulesCollected);

            // Update the count displayed on the Canvas
            if (countText != null)
            {
                countText.text = "Capsules Collected: " + capsulesCollected;
            }

            // Hide the capsule GameObject
            gameObject.SetActive(false);
        }
    }
}
