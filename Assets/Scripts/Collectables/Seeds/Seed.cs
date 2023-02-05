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
            BecomeTree();
        }
    }

    public void ToPlant()
    {
        status = GrowthStatus.planted;
    }
    public void BecomeTree()
    {
        SpawnNewSeeds();
    }

    public IEnumerator DestroyFX(float fxTime)
    {
        //do Something        
        yield return new WaitForSeconds(fxTime);
        //Destroy(gameObject);
    }

    public virtual void Die()
    {
        if (Status == GrowthStatus.seed)
        {
            float animationTime = dieFX.main.duration;

            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyFX(animationTime));
            dieFX.Play();
        }
        else Destroy(gameObject);
    }
    public virtual void SpawnNewSeeds()
    {
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        rigidbody.Sleep();
    }
}
