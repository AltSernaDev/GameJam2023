using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSeed : Seed
{
    [SerializeField] float m_growthTimer;
    float m_initialGrowthTime;
    [SerializeField] float m_mayorSpawnPercentage;
    [SerializeField] float m_deathTimer;

    Action onDeath;

    public enum SeedType : int
    {
        A = 1,
        B = 2,
        C = 3,
        D = 5
    }
    public SeedType seedType;

    private void Start()
    {
        status = GrowthStatus.seed;
        m_initialGrowthTime = m_growthTimer;

        onDeath += Die;
    }

    public override void SpawnNewSeeds()
    {
        float spawnIndex = 0;
        spawnIndex = UnityEngine.Random.Range(0f, 1f);

        if (spawnIndex <= m_mayorSpawnPercentage)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject newSeed = new GameObject("Seed");
                newSeed.AddComponent<BasicSeed>();
                BasicSeed seed = newSeed.GetComponent<BasicSeed>();
                seed = this;

                Instantiate(newSeed, transform);
                print("a");
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
                print("b");
            }
        }

        onDeath();
    }
}
