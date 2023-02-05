using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Collectable
{
    public Rigidbody rigidbody;
    [SerializeField] float growthTimer, deathTimer;
    float initialGrowthTime, initialDeathTimer;
    [SerializeField] float mayorSpawnPercentage;

    public float healthPoints;

    Action onDeath;
    public enum GrowthStatus
    {
        seed,
        planted,
        tree
    }

    [SerializeField]
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
        if (status == GrowthStatus.planted)
        {
            growthTimer -= 1 * Time.deltaTime;
        }

        if (growthTimer <= 0 && status == GrowthStatus.planted)
        {
            rigidbody.useGravity = false;
            rigidbody.Sleep();

            GetComponent<Collider>().enabled = false;

            status = GrowthStatus.tree;
            growthTimer = initialGrowthTime;
            SpawnNewSeeds();
        }
        if (status == GrowthStatus.tree)
        {
            deathTimer -= 1 * Time.deltaTime;
        }
        if (deathTimer == 0)
        {
            Die();
        }

        if (healthPoints <= 0)
        {
            Die();
        }
    }

    public void ToPlant()
    {
        status = GrowthStatus.planted;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    public void ReceiveDamage(float damage)
    {
        healthPoints -= damage;
    }
    public virtual void SpawnNewSeeds()
    {
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        rigidbody.Sleep();
    }
}
