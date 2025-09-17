using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    float timeLeft;
    public bool gameOver = false;
    public bool GameOver => gameOver;

    void Start()
    {
        timeLeft = startTime;
        UpdateTimeText();
    }

    void Update()
    {
        DecreaseTime();
    }

    public void IncreaseTime(float amount)
    {
        if (gameOver) return;
        timeLeft += amount; // ? Fixed: Increase time
        UpdateTimeText();
    }

    private void DecreaseTime()
    {
        if (gameOver) return;
        timeLeft -= Time.deltaTime;
        UpdateTimeText();

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }

    private void UpdateTimeText()
    {
        if (timeText != null)
            timeText.text = timeLeft.ToString("F1");
    }

    void PlayerGameOver()
    {
        gameOver = true;
        if (playerController != null) playerController.enabled = false;
        if (gameOverText != null) gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}
