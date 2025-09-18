using UnityEngine;
using System.Collections;

public class Coin : PickUp
{
    [SerializeField] int scoreAmount = 100;
    ScoreManager scoreManager;

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    void Start()
    {
        // Fallback for coins placed manually in the scene
        if (scoreManager == null)
        {
            scoreManager = FindFirstObjectByType<ScoreManager>();
        }
    }


    protected override void OnPickup()
    {
        if (scoreManager != null)
        {
            scoreManager.IncreaseScore(scoreAmount);
        }
        else
        {
            Debug.LogWarning("ScoreManager not set on Coin!");
        }
    }
}
