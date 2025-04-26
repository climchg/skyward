using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public float spawnRate = 2f;
    public Vector2 spawnArea = new Vector2(8f, 4f);

    void Start()
    {
        InvokeRepeating("SpawnBlock", 1f, spawnRate);
    }

    void SpawnBlock()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            spawnArea.y,
            0
        );
        Instantiate(blockPrefab, spawnPos, Quaternion.identity);
    }
}