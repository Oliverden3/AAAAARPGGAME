using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public int numEnemies = 5;

    void Start()
    {
        float angleStep = 360f / numEnemies;

        for (int i = 0; i < numEnemies; i++)
        {
            float angle = i * angleStep;
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius;
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius;

            Vector3 spawnPos = new Vector3(x, y, 0f) + transform.position;
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
