using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Collectable
{
    public Rigidbody rigidbody;
    [SerializeField] float growthTimer;
    float initialGrowthTime;
    [SerializeField] float mayorSpawnPercentage;

    public ParticleSystem dieFX;

    Action onDeath;
    public enum GrowthStatus
    {
        seed,
        planted,
        tree
    }

    private GrowthStatus status;

    public GrowthStatus Status { get => status; set => status = value; }
    public float GrowthTimer { get => growthTimer; set => growthTimer = value; }
    public float InitialGrowthTime { get => initialGrowthTime; set => initialGrowthTime = value; }
    public float MayorSpawnPercentage { get => mayorSpawnPercentage; set => mayorSpawnPercentage = value; }
    public Action OnDeath { get => onDeath; set => onDeath = value; }

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

    IEnumerator Die(float fxTime)
    {
        //do Something        
        yield return new WaitForSeconds(fxTime);
        //Destroy(gameObject);
    }

    public virtual void Die()
    {
        float animationTime = dieFX.main.duration;

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(Die(animationTime));
        dieFX.Play();
    }
    public virtual void SpawnNewSeeds()
    {
    }
}
