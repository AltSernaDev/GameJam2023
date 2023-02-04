using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinatedSeed : Seed
{
    [SerializeField] float m_growthTimer;
    float initialGrowthTime;
    [SerializeField] float m_mayorSpawnPercentage;
    [SerializeField] float m_deathTimer;
    float initialDeathTime;

    Action onDeath;
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
        status = GrowthStatus.seed;
        initialGrowthTime = m_growthTimer;
        initialDeathTime = m_deathTimer;

        onDeath += Die;
    }
    public void SpecialEffect()
    {

    }   

    public override void SpawnNewSeeds()
    {
        GameObject newSeed = new GameObject("Seed");
        newSeed.AddComponent<CombinatedSeed>();
        CombinatedSeed seed = newSeed.GetComponent<CombinatedSeed>();
        seed = this;

        float spawnIndex = 0;
        spawnIndex = UnityEngine.Random.Range(0f, 1f);

        if (spawnIndex <= m_mayorSpawnPercentage)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(newSeed, transform);
                print("a");
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(newSeed, transform);
                print("b");
            }
        }

        onDeath();
    }
}
