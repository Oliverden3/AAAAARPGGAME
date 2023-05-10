using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public int numEnemiesPerWave = 5;
    public int numWaves = 3;
    public float waveInterval = 5f;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        for (int wave = 0; wave < numWaves; wave++)
        {
            for (int i = 0; i < numEnemiesPerWave; i++)
            {
                float angle = i * (360f / numEnemiesPerWave);
                float x = Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius;
                float y = Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius;

                Vector3 spawnPos = new Vector3(x, y, 0f) + transform.position;
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }

            yield return new WaitForSeconds(waveInterval);
        }
    }
}
