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

    private void OnEnable()
    {
        Status = GrowthStatus.seed;
        InitialGrowthTime = GrowthTimer;

        OnDeath += Die;
    }

    public override void SpawnNewSeeds()
    {
        float spawnIndex = 0;
        spawnIndex = UnityEngine.Random.Range(0f, 1f);

        if (spawnIndex <= MayorSpawnPercentage)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject newSeed = new GameObject("Seed");
                newSeed.AddComponent<BasicSeed>();
                BasicSeed seed = newSeed.GetComponent<BasicSeed>();
                seed = this;

                Instantiate(newSeed, transform);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject newSeed = new GameObject("Seed");
                newSeed.AddComponent<BasicSeed>();
                BasicSeed seed = newSeed.GetComponent<BasicSeed>();
                seed = this;

                Instantiate(newSeed, transform);
            }
        }

        OnDeath();
    }
}
