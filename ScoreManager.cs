using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;

    int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
        else
        {
            Debug.LogWarning("ScoreManager: scoreText is not assigned!");
        }

        if (gameManager != null)
        {
            // Example usage, if needed
            // gameManager.SomeMethod();
        }
        else
        {
            Debug.LogWarning("ScoreManager: gameManager is not assigned!");
        }
    }
}
