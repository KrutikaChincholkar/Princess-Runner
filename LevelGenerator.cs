using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab; // Prefab for the level chunk
    [SerializeField] int startingChunksAmount = 12; // Number of chunks to instantiate at the start
    [SerializeField] Transform chunkParent; // Parent transform for instantiated chunks
    [SerializeField] float chunkLength = 10f; // Length of each chunk

    void Start()
    {
        for (int i = 0; i < startingChunksAmount; i++) 
        {
            float spawnPositionZ;
            if(i==0)
            {
                spawnPositionZ = transform.position.z;
            }
            else
            {
                spawnPositionZ = transform.position.z + (i * chunkLength);
            }
            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

            Instantiate(chunkPrefab, transform.position, Quaternion.identity, chunkParent); // Instantiate the chunk prefab at the position of the LevelGenerator
        }
    }
}
