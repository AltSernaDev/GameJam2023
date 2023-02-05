using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinatedSeed : Seed
{
    [SerializeField] float minSpawnValue, maxSpawnValue;
    public enum SeedType : int
    {
        AB = 1,
        BC,
        AC,
        DA,
        DB,
        DC
    }
    public SeedType seedType;

    [SerializeField] Transform[] spawnPoints;

    private void OnEnable()
    {
        Status = GrowthStatus.seed;
        InitialGrowthTime = GrowthTimer;

        OnDeath += Die;
    }
    public void SpecialEffect(Seed affectedSeed = null /*, Enemy taggedEnemy*/)
    {
        switch (seedType)
        {
            case SeedType.AB:
                //taggedEnemy.Kill();
                break;
            case SeedType.BC:
                //Mejorar Spawn
                if (affectedSeed.Status == GrowthStatus.planted)
                {
                    affectedSeed.MayorSpawnPercentage = 0;
                }
                break;
            case SeedType.AC:
                //Tiempo de Crecimiento
                if (affectedSeed.Status == GrowthStatus.planted)
                {
                    affectedSeed.GrowthTimer *= 0.15f;
                }
                break;
            case SeedType.DA:
                break;
            case SeedType.DB:
                break;
            case SeedType.DC:
                break;
            default:
                //No FX feedback
                break;
        }
    }

    public override void SpawnNewSeeds()
    {
        if (seedType == SeedType.DA || seedType == SeedType.DB || seedType == SeedType.DC)
        {
            print("Seed can't be planted");
        }
        else
        {
            float spawnIndex;
            spawnIndex = UnityEngine.Random.Range(0f, 1f);
            print("SpawnIndex" + spawnIndex);
            if (spawnIndex < MayorSpawnPercentage)
            {
                for (int i = 0; i < 2; i++)
                {
                    switch (seedType)
                    {
                        case SeedType.AB:
                            SeedSpawnManager.instance.SpawnCombinedSeed(1, spawnPoints[i]);
                            break;
                        case SeedType.BC:
                            SeedSpawnManager.instance.SpawnCombinedSeed(2, spawnPoints[i]);
                            break;
                        case SeedType.AC:
                            SeedSpawnManager.instance.SpawnCombinedSeed(3, spawnPoints[i]);
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
                        case SeedType.AB:
                            SeedSpawnManager.instance.SpawnCombinedSeed(1, spawnPoints[i]);
                            break;
                        case SeedType.BC:
                            SeedSpawnManager.instance.SpawnCombinedSeed(2, spawnPoints[i]);
                            break;
                        case SeedType.AC:
                            SeedSpawnManager.instance.SpawnCombinedSeed(3, spawnPoints[i]);
                            break;
                    }
                    print("A");
                }
            }

            OnDeath();
        }
    }
}
