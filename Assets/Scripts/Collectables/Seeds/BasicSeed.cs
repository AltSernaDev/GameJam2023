using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSeed : Seed
{
    public enum SeedType : int
    {
        A = 1,
        B = 2,
        C = 3,
        D = 5
    }

    public SeedType seedType;
    [SerializeField] Transform[] spawnPoints;

    private void OnEnable()
    {
        Status = GrowthStatus.seed;
        InitialGrowthTime = GrowthTimer;

        OnDeath += Die;
    }

    public override void SpawnNewSeeds()
    {
        float spawnIndex ;
        spawnIndex = UnityEngine.Random.Range(0f, 1f);
        print("SpawnIndex" + spawnIndex);


        if (spawnIndex < MayorSpawnPercentage)
        {
            for (int i = 0; i < 2; i++)
            {
                switch (seedType)
                {
                    case SeedType.A:
                        SeedSpawnManager.instance.SpawnBasicSeed(1 , spawnPoints[i]);
                        break;
                    case SeedType.B:
                        SeedSpawnManager.instance.SpawnBasicSeed(2, spawnPoints[i]);
                        break;
                    case SeedType.C:
                        SeedSpawnManager.instance.SpawnBasicSeed(3, spawnPoints[i]);
                        break;
                    case SeedType.D:
                        SeedSpawnManager.instance.SpawnBasicSeed(5, spawnPoints[i]);
                        break;
                    default:
                        break;
                }
                print("B");
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                switch (seedType)
                {
                    case SeedType.A:
                        SeedSpawnManager.instance.SpawnBasicSeed(1, spawnPoints[i]);
                        break;
                    case SeedType.B:
                        SeedSpawnManager.instance.SpawnBasicSeed(2, spawnPoints[i]);
                        break;
                    case SeedType.C:
                        SeedSpawnManager.instance.SpawnBasicSeed(3, spawnPoints[i]);
                        break;
                    case SeedType.D:
                        SeedSpawnManager.instance.SpawnBasicSeed(5, spawnPoints[i]);
                        break;
                    default:
                        break;
                }
                print("A");
            }
        }

        OnDeath();
    }
}
