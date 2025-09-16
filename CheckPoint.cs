using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float checkPointTimeExtension = 5f;
    [SerializeField] float obstacleDecreaseTimeAmount = 0.2f;

    [SerializeField] GameManager gameManager;
    [SerializeField] ObstacleSpawner obstacleSpawner;

    const string playerString = "Player";

    void Awake()
    {
        // Only find if not assigned in Inspector
        if (gameManager == null)
            gameManager = FindFirstObjectByType<GameManager>();

        if (obstacleSpawner == null)
            obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerString)) return;

        if (gameManager == null || obstacleSpawner == null)
        {
            Debug.LogError("CheckPoint: Missing GameManager or ObstacleSpawner reference!");
            return;
        }

        gameManager.IncreaseTime(checkPointTimeExtension);
        obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
    }
}
