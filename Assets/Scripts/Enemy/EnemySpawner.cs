using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [SerializeField] int maxEnemies;
    [SerializeField] GameObject enemyPrefab;

    private void Start()
    {
        StartCoroutine(SpawnCycle());
    }

    IEnumerator SpawnCycle()
    {
        if (enemies.Count < maxEnemies)
        {
            for (int i = 0; i < maxEnemies - enemies.Count; i++)
            {
                enemies.Add(Instantiate(enemyPrefab, transform.position, Quaternion.identity));
                yield return new WaitForSeconds(5);
            }
        }

        yield return new WaitForSeconds(10);

        StartCoroutine(SpawnCycle());
    }
}
