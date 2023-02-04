using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinatedSeed : Seed
{
    public enum SeedType: int
    {
        AB = 1,
        BC,
        AC,
        DA,
        DB,
        DC
    }
    public SeedType seedType;

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
                if(affectedSeed.Status == GrowthStatus.planted)
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
        GameObject newSeed = new GameObject("Seed");
        newSeed.AddComponent<CombinatedSeed>();
        CombinatedSeed seed = newSeed.GetComponent<CombinatedSeed>();
        seed = this;

        float spawnIndex = 0;
        spawnIndex = UnityEngine.Random.Range(0f, 1f);

        if (spawnIndex < MayorSpawnPercentage)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(newSeed, transform);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(newSeed, transform);
            }
        }

        OnDeath();
    }
}
