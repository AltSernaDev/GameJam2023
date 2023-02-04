using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Collectable
{
    [SerializeField] float growthTime;
    [SerializeField] float spawnPercentage;
    public enum GrowthStatus
    {
        seed,
        planted,
        tree
    }

    public GrowthStatus status;

    public float GrowthTime { get => growthTime; }


}
