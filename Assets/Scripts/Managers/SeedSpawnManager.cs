using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawnManager : MonoBehaviour
{
    [SerializeField] Seed prefab_A, prefab_B, prefab_C, prefab_D, prefab_AB, prefab_BC, prefab_AC , prefab_DA , prefab_DB , prefab_DC;

    public static SeedSpawnManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else instance = this;
    }
    public void SpawnBasicSeed(int typeIndex , Transform spawnPoint)
    {
        switch (typeIndex)
        {
            case 1:
                Instantiate(prefab_A, spawnPoint.position, spawnPoint.rotation);
                break;
            case 2:
                Instantiate(prefab_B, spawnPoint.position, spawnPoint.rotation);
                break;
            case 3:
                Instantiate(prefab_C, spawnPoint.position, spawnPoint.rotation);
                break;
            case 5:
                Instantiate(prefab_D, spawnPoint.position, spawnPoint.rotation);
                break;
        }
    }

    public void SpawnCombinedSeed(int typeIndex, Transform spawnPoint)
    {
        switch (typeIndex)
        {
            case 3:
                Instantiate(prefab_AB, spawnPoint.position , spawnPoint.rotation);
                break;

            case 5:
                Instantiate(prefab_BC, spawnPoint.position, spawnPoint.rotation);
                break;

            case 4:
                Instantiate(prefab_AC, spawnPoint.position, spawnPoint.rotation);
                break;

            case 6:
                Instantiate(prefab_DA, spawnPoint.position, spawnPoint.rotation);
                break;

            case 7:
                Instantiate(prefab_DB, spawnPoint.position, spawnPoint.rotation);
                break;

            case 8:
                Instantiate(prefab_DC, spawnPoint.position, spawnPoint.rotation);
                break;
        }
    }
}
