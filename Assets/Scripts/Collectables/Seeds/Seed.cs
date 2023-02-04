using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Collectable
{
    [SerializeField] float growthTimer;
    float initialGrowthTime;
    [SerializeField] float mayorSpawnPercentage;

    Action onDeath;
    public enum GrowthStatus
    {
        seed,
        planted,
        tree
    }

    public GrowthStatus status;

    public float GrowthTime { get => growthTimer; }

    private void Start()
    {
        status = GrowthStatus.seed;
        initialGrowthTime = growthTimer;

        onDeath += Die;
    }

    private void Update()
    {
        if(status == GrowthStatus.planted)
        {
            growthTimer -= 1 * Time.deltaTime;
        }

        if(growthTimer <= 0 && status == GrowthStatus.planted)
        {
            status = GrowthStatus.tree;
            growthTimer = initialGrowthTime;
            BecomeTree();
        }
    }

    public void ToPlant()
    {
        status = GrowthStatus.planted;
    }
    public void BecomeTree()
    {
        //Do Something
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
    public virtual void SpawnNewSeeds()
    {
    }
}
